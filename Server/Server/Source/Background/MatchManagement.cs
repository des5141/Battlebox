using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Room;
using Server.Source.Task;
using Server.Source.User;

namespace Server.Source.Background
{
    class MatchManagement
    {
        public static void Func()
        {
            AliveCheck();
            Matching();
        }

        private static void AliveCheck()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await Lock.RoomList.LockAsync())
                {
                    var i = 0;
                    while (true)
                    {
                        if (i >= Data.RoomList.Count)
                            break;
                        if (Data.RoomList.ElementAt(i).UserList.Count <= 0)
                            Data.RoomList.Remove(Data.RoomList.Skip(i).First());
                        else
                            i++;
                    }
                }
                await System.Threading.Tasks.Task.Delay(1000);
                AliveCheck();
            }).Start();
        }
        private static void Matching()
        {
            var room = new NcsRoom();
            new System.Threading.Tasks.Task(async () =>
            {
                using (await Lock.MatchingList.LockAsync())
                {
                    using (await Lock.RoomList.LockAsync())
                    {
                        // 이중 Lock
                        // 잘못해서 여기가 꼬이면 그대로 망한다
                        if (Data.MatchingList.Count >= Data.MatchingMin)
                        {
                            var roomIndex = Data.RoomList.Count + 1;
                            Data.RoomList.AddLast(room);

                            var tempUser = Data.MatchingList.Dequeue();
                            for (var i = 0; i < Data.MatchingMin; i++)
                            {
                                tempUser.Data = new NcsUserData { PlayIndex = Convert.ToUInt16(i + 1) };
                                // 인 게임 순번 적기 (0은 안나오도록! +1 함)
                                tempUser.PlayRoom = room;
                                room.UserList.Add(tempUser);
                                MoveSpace.Func(tempUser, roomIndex);
                            }
                            room.Start(); // ※중요※ 이 코드들은 동기로 처리되는 것이어서, 맵 만들다 멈추면 매칭 기능 자체가 멈춰버린다.
                        }
                    }
                }
                await System.Threading.Tasks.Task.Delay(200);
                Func();
            }).Start();
        }
    }
}
