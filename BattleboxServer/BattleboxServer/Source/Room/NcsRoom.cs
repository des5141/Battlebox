using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGD;
using Networking_with_Supersocket;

namespace BattleboxServer
{
    public class NcsRoom
    {
        // Variable's Init
        public readonly AsyncLock TaskLockInRoom = new AsyncLock();    // Common Processing
        public List<NcsUser> UserList = new List<NcsUser>();
        public int ReadyTime = 60;
        public int Time = 0;
        public bool GameStart = false;
        public bool end = false;

        #region Map
        public static int MapSize = 21;
        public int Length = 14;  // 자기장 범위
        public int SelectX = -1;
        public int SelectY = -1;
        public int[,] Map = new int[MapSize, MapSize];
        public int[,] MapBack = new int[MapSize, MapSize];
        public int[,] MapType = new int[MapSize, MapSize];
        public Stack<int> MapStack = new Stack<int>();
        public List<List<int>> Item = new List<List<int>>();
        #endregion

        public NcsRoom()
        {
            #region MapMake
            int MakingTime = 1;
            while (true)
            {
                bool Mapcheck = false;
                bool exist = false;
                int i = 0, j = 0;

                for (i = 0; i < MapSize; i++)
                {
                    for (j = 0; j < MapSize; j++)
                    {
                        Map[i, j] = 0;
                        MapBack[i, j] = 0;
                        if ((i % 2 == 0) && (j % 2 == 0))
                            MapBack[i, j] = 1;
                        else
                            MapBack[i, j] = 0;
                        Map[i, j] = MapBack[i, j];
                    }
                }
                for (i = 0; i < MapSize; i++)
                {
                    for (j = 0; j < MapSize; j++)
                    {
                        if ((i % 2 == 0) && (j % 2 != 0))
                            MapBack[i, j] = 2;
                        if ((i % 2 != 0) && (j % 2 == 0))
                            MapBack[i, j] = 3;
                    }
                }
                for (i = 0; i < MapSize; i += 2)
                {
                    for (j = 0; j < MapSize; j += 2)
                    {
                        int IRandomvalue = IRandom.Next(0, 3);
                        if (IRandomvalue == 0)
                        {
                            if (i + 1 != MapSize)
                                MapBack[i + 1, j] = 0;
                            if (i - 1 != -1)
                                MapBack[i - 1, j] = 0;
                            if (j + 1 != MapSize)
                                MapBack[i, j + 1] = 0;
                            if (j - 1 != -1)
                                MapBack[i, j - 1] = 0;
                            MapBack[i, j] = 0;
                        }
                    }
                }
                for (i = 0; i < MapSize; i++)
                {
                    for (j = 0; j < MapSize; j++)
                    {
                        if ((!(i <= 4)) && (!(j <= 2)))
                        {
                            if (MapBack[i, j] == 1)
                            {
                                exist = true;
                                break;
                            }
                        }
                    }
                    if (exist == true)
                        break;
                }

                MapStack.Push(i);
                MapStack.Push(j);

                while (MapStack.Count > 0)
                {
                    int tempj = MapStack.Pop();
                    int tempi = MapStack.Pop();
                    if (MapBack[tempi, tempj] == 1)
                    {
                        MapBack[tempi, tempj] = 4;
                        if (!(tempi + 2 >= MapSize))
                        {
                            MapStack.Push(tempi + 2);
                            MapStack.Push(tempj);
                        }
                        if (!(tempj + 2 >= MapSize))
                        {
                            MapStack.Push(tempi);
                            MapStack.Push(tempj + 2);
                        }
                        if (!(tempi - 2 < 0))
                        {
                            MapStack.Push(tempi - 2);
                            MapStack.Push(tempj);
                        }
                        if (!(tempj - 2 < 0))
                        {
                            MapStack.Push(tempi);
                            MapStack.Push(tempj - 2);
                        }
                    }
                }
                for (i = 0; i < MapSize; i++)
                {
                    for (j = 0; j < MapSize; j++)
                    {
                        if (MapBack[i, j] == 1)
                            Mapcheck = true;
                        else if (MapBack[i, j] == 4)
                            MapBack[i, j] = 1;
                    }
                }
                MapStack.Clear();
                if (Mapcheck == true)
                {
                    MakingTime++;
                    continue;
                }
                else
                {
                    for (i = 0; i < MapSize; i++)
                    {
                        for (j = 0; j < MapSize; j++)
                        {
                            Map[i, j] = MapBack[i, j];
                            switch (Map[i, j])
                            {
                                case 1:
                                    MapType[i, j] = IRandom.Next(-1, 7);
                                    break;

                                default:
                                    MapType[i, j] = 0;
                                    break;
                            }
                        }
                    }
                    //GC.Collect();
                    Console.WriteLine($" - Map was created (try \"{MakingTime}\" times)", ConsoleColor.Black, ConsoleColor.DarkGray);
                    break;
                }
            }
            #endregion
            #region ItemMake
            ItemInit();
            #endregion
        }

        public void Start()
        {
            new Task(async () =>
            {
                using (await TaskLockInRoom.LockAsync())
                {
                    foreach (NcsUser index in UserList)
                    {
                        index.UserReady = false;

                        var SendBuffer = NewBuffer.Func(5120);
                        SendBuffer.append<Byte>(Convert.ToByte(index.Data.PlayIndex)); // 인 게임 순번
                        SendBuffer.append<Byte>(Convert.ToByte(MapSize));
                        for (int i = 0; i < MapSize; i++)
                        {
                            for (int j = 0; j < MapSize; j++)
                            {
                                SendBuffer.append<SByte>(Convert.ToSByte(Map[i, j]));
                                SendBuffer.append<SByte>(Convert.ToSByte(MapType[i, j]));
                            }
                        }

                        SendBuffer.append<UInt16>(Convert.ToUInt16(Item.Count));
                        for (int i = 0; i < Item.Count; i++)
                        {
                            SendBuffer.append<Byte>(Convert.ToByte(Item[i][0]));
                            SendBuffer.append<Byte>(Convert.ToByte(Item[i][1]));
                            SendBuffer.append<UInt16>(Convert.ToUInt16(Item[i][2]));
                            SendBuffer.append<UInt16>(Convert.ToUInt16(Item[i][3]));
                            SendBuffer.append<Byte>(Convert.ToByte(Item[i][4]));
                            SendBuffer.append<Byte>(Convert.ToByte(Item[i][5]));
                        }
                        index.Send(SendBuffer, Signal.RoomReady);
                    }
                }
            }).Start();

            Timer();
            ReadyTimer();
            UserCheck();
            Alive();
            UserCoordinate();
        }

        public void ItemInit()
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    if (Map[i, j] == 1)
                    {
                        int base_x = i * 64 * 20 + 64 / 2;
                        int base_y = j * 64 * 20 + 64 / 2;
                        // 영역 선택 완료
                        switch (MapType[i, j])
                        {
                            case 1:
                                {
                                    // 왼쪽 위 4개
                                    ItemAdd(i, j, base_x, base_y, 6, 6, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 6, 5, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 5, 6, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 5, 5, IRandom.Next(1, 38), 1);

                                    // 오른쪽 위 4개
                                    ItemAdd(i, j, base_x, base_y, 12, 5, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 12, 4, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 13, 5, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 13, 4, IRandom.Next(1, 38), 1);

                                    // 왼쪽 아래 3개
                                    ItemAdd(i, j, base_x, base_y, 4, 12, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 5, 12, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 4, 13, IRandom.Next(1, 38), 1);
                                }
                                break;

                            case 2:
                                {
                                    // 오른쪽 위 2개
                                    ItemAdd(i, j, base_x, base_y, 15, 6, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 16, 7, IRandom.Next(1, 38), 1);

                                    // 왼쪽 아래 4개
                                    ItemAdd(i, j, base_x, base_y, 3, 14, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 4, 14, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 5, 14, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 6, 14, IRandom.Next(1, 38), 1);

                                    // 오른쪽 아래 6개
                                    ItemAdd(i, j, base_x, base_y, 14, 13, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 14, 14, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 15, 13, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 15, 14, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 16, 14, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 16, 15, IRandom.Next(1, 38), 1);
                                }
                                break;

                            case 3:
                                {
                                    // 오른쪽 가운데 4개
                                    ItemAdd(i, j, base_x, base_y, 12, 7, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 12, 8, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 13, 7, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 13, 8, IRandom.Next(1, 38), 1);

                                    // 가운데 아래 2개
                                    ItemAdd(i, j, base_x, base_y, 6, 13, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 7, 13, IRandom.Next(1, 38), 1);
                                }
                                break;

                            case 4:
                                {
                                    // 왼쪽 위 3개
                                    ItemAdd(i, j, base_x, base_y, 2, 2, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 3, 2, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 4, 2, IRandom.Next(1, 38), 1);

                                    // 가운데 가운데 3개
                                    ItemAdd(i, j, base_x, base_y, 7, 8, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 8, 8, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 9, 7, IRandom.Next(1, 38), 1);

                                    // 왼쪽부터 오른쪽까지 아래 4개
                                    ItemAdd(i, j, base_x, base_y, 3, 17, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 4, 17, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 11, 14, IRandom.Next(1, 38), 1);
                                    ItemAdd(i, j, base_x, base_y, 11, 15, IRandom.Next(1, 38), 1);
                                }
                                break;
                        }
                    }
                }
            }
        }

        public void ItemAdd(int column, int row, int base_x, int base_y, int x, int y, int index, int count)
        {
            lock (Item)
            {
                Item.Add(new List<int>());
                int array_index = Item.Count - 1;
                Item[array_index].Add(column);
                Item[array_index].Add(row);
                Item[array_index].Add(x * 64 + base_x);
                Item[array_index].Add(y * 64 + base_y);
                Item[array_index].Add(index);
                //item[array_index].Add(count);
                Item[array_index].Add(IRandom.Next(1, 20));
            }
        }

        public void MapCrap()
        {
            if (end == false)
            {
                for (int i = 0; i < MapSize; i++)
                {
                    for (int j = 0; j < MapSize; j++)
                    {
                        if (MapBack[i, j] == 4)
                            MapBack[i, j] = 6;
                    }
                }
                while (true)
                {
                    var exit = false;
                    if (SelectX != -1)
                    {
                        MapBack[SelectY, SelectX] = 1;
                        SelectX = -1;
                        SelectY = -1;
                    }

                    for (int i = 0; i < MapSize; i++)
                    {
                        for (int j = 0; j < MapSize; j++)
                        {
                            if (MapBack[i, j] == 1)
                            {
                                if ((IRandom.Next(-1, 10) == 1) && (IRandom.Next(-1, 10) == 1))
                                {
                                    SelectX = j;
                                    SelectY = i;
                                    break;
                                }
                            }
                            if (SelectX != -1)
                                break;
                        }
                        if (SelectX != -1)
                            break;
                    }
                    if (SelectX == -1)
                        continue;

                    for (int i = 0; i < MapSize; i++)
                    {
                        for (int j = 0; j < MapSize; j++)
                        {
                            if ((i < SelectY - Length) || (j < SelectX - Length) || (i > SelectY + Length) || (j > SelectX + Length))
                            {
                                if (MapBack[i, j] != 6)
                                {
                                    MapBack[i, j] = 4;
                                    exit = true;
                                }
                            }
                        }
                    }

                    if ((SelectX == -1) || (IRandom.Next(-1, 10) == 1) || (exit == false))
                        continue;
                    else
                        break;
                }
                MapBack[SelectY, SelectX] = 5;
                Length -= 2;

                foreach (NcsUser index in UserList)
                {
                    var SendBuffer = NewBuffer.Func(1024);
                    SendBuffer.append<Byte>(Convert.ToByte(MapSize));
                    for (int i = 0; i < MapSize; i++)
                    {
                        for (int j = 0; j < MapSize; j++)
                        {
                            SendBuffer.append<SByte>(Convert.ToSByte(MapBack[i, j]));
                        }
                    }
                    index.Send(SendBuffer, Signal.Map);
                }
            }
        }

        public void Timer()
        {
            if (end == false)
            {
                new Task(async () =>
                {
                    using (await TaskLockInRoom.LockAsync())
                    {
                        if (GameStart == true)
                            Time++;
                    }
                    await Task.Delay(1000);
                    Timer();
                }).Start();
            }
        }

        public void Alive()
        {
            if (end == false)
            {
                new Task(async () =>
                {
                    using (await TaskLockInRoom.LockAsync())
                    {
                        if (UserList.Count <= 0)
                        {
                            UserList.Clear();
                            end = true;
                        }
                    }
                    Alive();
                    await Task.Delay(1000);
                }).Start();
            }
        }

        public void ReadyTimer()
        {
            if (end == false)
            {
                new Task(async () =>
                {
                    using (await TaskLockInRoom.LockAsync())
                    {
                        if (GameStart == false)
                        {

                            foreach (NcsUser index in UserList)
                            {
                                if (index.UserReady == true)
                                {
                                    var SendBuffer = NewBuffer.Func(16);
                                    SendBuffer.append<Byte>(Convert.ToSByte(ReadyTime));
                                    index.Send(SendBuffer, Signal.ReadyTimer);
                                }
                            }
                            ReadyTime--;
                        }
                    }
                    await Task.Delay(1000);
                    ReadyTimer();
                }).Start();
            }
        }

        public void UserCheck()
        {
            if (end == false)
            {
                new Task(async () =>
                {
                    if (GameStart == false)
                    {
                        using (await TaskLockInRoom.LockAsync())
                        {
                            if (ReadyTime < 0)
                            {
                                foreach (NcsUser index in UserList)
                                    if (index.UserReady == false)
                                        index.Close();
                                GameStart = true;
                            }
                        }

                        if (ReadyTime >= 0)
                        {
                            await Task.Delay(1000);
                            UserCheck();
                        }
                    }
                }).Start();
            }
        }

        public void UserCoordinate()
        {
            if (end == false)
            {
                // 좌표 정보 보내기
                new Task(async () =>
                {
                    using (await TaskLockInRoom.LockAsync())
                    {
                        foreach (NcsUser index in UserList)
                        {
                            if (index.UserReady == true)
                            {
                                // 접속하고 있는 유저일 경우
                                foreach (NcsUser target in UserList)
                                {
                                    // index 와 target 이 다를때만 전송하도록
                                    if (index != target)
                                    {
                                        // 보낼 target의 접속 상태
                                        if (target.UserReady == true)
                                        {
                                            if (((int)(Math.Abs((index.Data.Column - target.Data.Column))) < 2 /* 2칸 영역 안에 있나*/)
                                            && (int)(Math.Abs((index.Data.Row - target.Data.Row))) < 2 /* 2칸 영역 안에 있나*/)
                                            {
                                                var SendBuffer = NewBuffer.Func(32);
                                                SendBuffer.append<Byte>(Convert.ToByte(index.Data.PlayIndex));
                                                SendBuffer.append<UInt16>(Convert.ToUInt16(index.Data.X));
                                                SendBuffer.append<UInt16>(Convert.ToUInt16(index.Data.Y));
                                                target.Send(SendBuffer, Signal.UserCoordinate);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    await Task.Delay(30);
                    UserCoordinate();
                }).Start();
            }
        }

        public void ItemDelete(int item_index, int item_count, uint who)
        {
            if (end == false)
            {
                // 좌표 정보 보내기
                new Task(async () =>
                {
                    using (await TaskLockInRoom.LockAsync())
                    {
                        bool trigger = false;
                        int return_count = -1;

                        if (Item[item_index][4] /* Item Index */ != -1)
                        {
                            if (Item[item_index][5] /* Item Count */ > 0)
                            {
                                if (Item[item_index][5] >= item_count)
                                {
                                    return_count = item_count;
                                    Item[item_index][5] -= item_count;
                                }
                                else
                                {
                                    return_count = Item[item_index][5];
                                    Item[item_index][5] = 0;
                                    Item[item_index][4] = -1; // delete
                                }
                            }

                            trigger = true;
                        }

                        foreach (NcsUser index in UserList)
                        {
                            if (index.UserReady == true)
                            {
                                // 접속하고 있는 유저일 경우
                                // 아이템 제거 상태를 알려줌
                                // target에게 index의 데이터 전송
                                var SendBuffer = NewBuffer.Func(16);
                                SendBuffer.append<UInt16>(Convert.ToUInt16(item_index));
                                SendBuffer.append<Int16>(Convert.ToInt16(return_count));
                                if ((trigger == true) && (index.Data.PlayIndex == who))
                                    SendBuffer.append<Byte>(Convert.ToByte(1));
                                else
                                    SendBuffer.append<Byte>(Convert.ToByte(2));
                                index.Send(SendBuffer, Signal.GameUse);
                            }
                        }
                    }
                }).Start();
            }
        }


        public void ItemAdd_Player(uint x, uint y, byte item_index, byte item_count)
        {
            if (end == false)
            {
                // 좌표 정보 보내기
                new Task(async () =>
                {
                    using (await TaskLockInRoom.LockAsync())
                    {
                        Item.Add(new List<int>());
                        int array_index = Item.Count - 1;
                        Item[array_index].Add((int)Math.Floor((double)x / 64 / 20));
                        Item[array_index].Add((int)Math.Floor((double)y / 64 / 20));
                        Item[array_index].Add((int)x);
                        Item[array_index].Add((int)y);
                        Item[array_index].Add((int)item_index);
                        Item[array_index].Add(item_count);



                        foreach (NcsUser index in UserList)
                        {
                            if (index.UserReady == true)
                            {
                                // 접속하고 있는 유저일 경우
                                // 아이템 생성 상태를 알려줌
                                var SendBuffer = NewBuffer.Func(1024);
                                SendBuffer.append<UInt16>(Convert.ToUInt16(x));
                                SendBuffer.append<UInt16>(Convert.ToUInt16(y));
                                SendBuffer.append<Byte>(Convert.ToByte(Item[array_index][0]));
                                SendBuffer.append<Byte>(Convert.ToByte(Item[array_index][1]));
                                SendBuffer.append<Byte>(Convert.ToByte(item_index));
                                SendBuffer.append<Byte>(Convert.ToByte(item_count));
                                SendBuffer.append<UInt16>(Convert.ToUInt16(array_index));
                                index.Send(SendBuffer, Signal.GameDrop);
                            }
                        }

                    }
                }).Start();

            }
        }


        ~NcsRoom()
        {
            // 룸 사망
            Console.WriteLine(" - Room Destroyed");
        }
    }
}
