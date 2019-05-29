using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;
using Server.Source.Room.Lock;
using Server.Source.User;

namespace Server.Source.Room
{
    public class NcsRoom
    {
        // Variable's Init
        public readonly AsyncLock TaskLockInRoom = new AsyncLock();    // Common Processing
        public List<NcsUser> UserList = new List<NcsUser>();
        public int ReadyTime = 60;
        public int Time = 0;
        public bool GameStart;
        public bool Destroy = false;
        public byte[,] Map = new byte[25, 40];
        public byte[,] Box = new byte[Data.BoxMax, 1];
        public byte[,] Electric = new byte[25, 40];

        public List<List<int>> Item = new List<List<int>>();

        public NcsRoom()
        {
            Chat.SendLog("Create Room");
            for (var i = 0; i < 25; i++)
            {
                for (var j = 0; j < 40; j++)
                {
                    Map[i, j] = 0;
                }
            }
        }
        ~NcsRoom()
        {
            Chat.SendLog("Delete Room");
        }

        public void Start()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await TaskLockInRoom.LockAsync())
                {
                    // 유저들의 위치를 맵에서 지정
                    foreach (var t in UserList)
                    {
                        while (true)
                        {
                            var x = Ran.Next(0, 39);
                            var y = Ran.Next(0, 24);
                            if (Map[y, x] != 0)
                                continue;
                            if (CheckRect(1, x, y, 5)) continue;
                            Map[y, x] = 1;
                            t.Data.X = Convert.ToUInt16(x * 32 + 16);
                            t.Data.Y = Convert.ToUInt16(y * 32 + 16);
                            break;
                        }
                    }

                    // 상자 설정
                    for (var i = 0; i < Data.BoxMax; i++)
                    {
                        while (true)
                        {
                            var x = Ran.Next(0, 39);
                            var y = Ran.Next(0, 24);
                            if (Map[y, x] != 0)
                                continue;
                            if (CheckRect(2, x, y, 7)) continue;
                            Map[y, x] = 2;
                            Box[i, 0] = 20; // 박스 체력
                            break;
                        }
                    }

                    // 벽 설정
                    for (var i = 0; i < 50; i++)
                    {
                        while (true)
                        {
                            var x = Ran.Next(0, 39);
                            var y = Ran.Next(0, 24);
                            if (Map[y, x] != 0)
                                continue;
                            Map[y, x] = 3;
                            break;
                        }
                    }

                    // 유저들에게 맵 이동하라고 전송
                    foreach (var t in UserList)
                    {
                        t.PlayReady = false;
                        var buf = NewBuffer.Func(16);
                        buf.append<byte>(1);
                        buf.append<byte>(t.Data.PlayIndex);
                        t.Send(buf, Signal.Match);
                    }

                    // 자기장 설정
                    for (var i = 0; i < 25; i++)
                    {
                        for (var j = 0; j < 40; j++)
                        {
                            Electric[i, j] = 0;
                        }
                    }
                }
                GameStartCheck();
                CheckAlive();
                SendUserCount();
            }).Start();
        }

        public void GameStartCheck()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                GameStart = true;
                using (await TaskLockInRoom.LockAsync())
                {
                    foreach (var t in UserList)
                    {
                        if (t.PlayReady == false)
                            GameStart = false;
                    }
                }

                if (GameStart == false)
                {
                    await System.Threading.Tasks.Task.Delay(1000);
                    GameStartCheck();
                }

                else
                {
                    // 게임 시작
                    using (await TaskLockInRoom.LockAsync())
                    {
                        // 플레이어 초기 데이터 생성
                        var buf = NewBuffer.Func(5120);
                        buf.append<byte>(25); // height
                        buf.append<byte>(40); // width
                        for (var i = 0; i < 25; i++)
                        {
                            for (var j = 0; j < 40; j++)
                            {
                                buf.append<byte>(Map[i, j]);
                            }
                        }

                        buf.append<byte>(UserList.Count); // 몇명인지 전달
                        foreach (var t in UserList)
                        {
                            buf.append<byte>(t.PlayCharacter);
                            buf.append<byte>(t.Data.PlayIndex);
                            buf.append<ushort>(t.Data.X);
                            buf.append<ushort>(t.Data.Y);
                            buf.append_gmlstring(t.Nickname);
                        }
                        buf.set_front<uint>(buf.Count);
                        buf.set_front<short>(Signal.GameStart, 4);

                        // 전달
                        foreach (var t in UserList)
                        {
                            t.Send(buf);
                        }
                    }
                    UserPosition();
                }
            }).Start();
        }

        public void UserPosition()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await TaskLockInRoom.LockAsync())
                {
                    // 플레이어 초기 데이터 생성
                    var buf = NewBuffer.Func(4096);
                    buf.append<byte>(UserList.Count); // 몇명인지 전달
                    foreach (var t in UserList)
                    {
                        buf.append<byte>(t.Data.PlayIndex);
                        buf.append<ushort>(t.Data.X);
                        buf.append<ushort>(t.Data.Y);
                        buf.append<byte>(t.Data.Z);
                        buf.append<byte>(t.Data.ImageIndex);
                        buf.append<sbyte>(t.Data.ImageXScale);
                        buf.append<byte>(t.Data.WeaponIndex);
                        buf.append<short>(t.Data.WeaponDir);
                    }
                    buf.set_front<uint>(buf.Count);
                    buf.set_front<short>(Signal.UserPosition, 4);

                    // 전달
                    foreach (var t in UserList)
                    {
                        t.Send(buf);
                    }
                }

                await System.Threading.Tasks.Task.Delay(10);
                if (Destroy != true)
                    UserPosition();
            }).Start();
        }

        private protected bool CheckRect(int value, int getX, int getY, int depth)
        {
            var x = getX - depth / 2;
            var y = getY - depth / 2;
            var tempX = x;
            var tempY = y;

            for (var i = 0; i < depth; i++)
            {
                for (var j = 0; j < depth; j++)
                {
                    if ((tempX < 0) || (tempX > 39) || (tempY < 0) || (tempY > 24)) continue;
                    if (Map[tempY, tempX] == value)
                        return true;
                    tempX++;
                }
                tempY++;
                tempX = x;
            }

            return false;
        }

        private protected void CheckAlive()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await TaskLockInRoom.LockAsync())
                {
                    if (UserList.Count <= 0)
                    {
                        Destroy = true;
                        using (await Source.Lock.RoomList.LockAsync())
                        {
                            Data.RoomList.Remove(this);
                        }
                        Chat.SendLog("Destroy Room Action !");
                    }
                }

                await System.Threading.Tasks.Task.Delay(5000);
                if (Destroy != true)
                    CheckAlive();
            }).Start();
        }

        private protected void SendUserCount()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await TaskLockInRoom.LockAsync())
                {
                    var buf = NewBuffer.Func(16);
                    var userCounting = 0;
                    foreach (var t in UserList)
                    {
                        if (t.Data.Die == false)
                            userCounting++;
                    }
                    buf.append<byte>(userCounting); // 몇명이나 있습니까? 닝겐?
                    buf.set_front<uint>(buf.Count);
                    buf.set_front<short>(Signal.UserCountInRoom, 4);

                    // 전달
                    foreach (var t in UserList)
                    {
                        t.Send(buf);
                    }
                }

                await System.Threading.Tasks.Task.Delay(2000);
                if (Destroy != true)
                    SendUserCount();
            }).Start();
            }
    }
}
