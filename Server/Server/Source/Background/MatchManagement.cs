using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;
using Server.Source.Room;
using Server.Source.Task;
using Server.Source.User;

namespace Server.Source.Background
{
    class MatchManagement
    {
        public static void Func()
        {
            Matching();
        }

        private static void Matching()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await Lock.MatchingList.LockAsync())
                {
                    using (await Lock.UserList.LockAsync())
                    {
                        // 유저들에게 현재 몇명이 매칭중인지 전송
                        var tempCount = Data.MatchingList.Count;
                        for (var i = 0; i < tempCount; i++)
                        {
                            var buf = NewBuffer.Func(16);
                            buf.append<byte>(1);
                            buf.append<ushort>(tempCount);
                            Data.MatchingList.PeekAt(i).Send(buf, Signal.UserCount);
                        }

                        using (await Lock.RoomList.LockAsync())
                        {
                            if (Data.MatchingList.Count >= Data.MatchingMin)
                            {
                                var room = new NcsRoom();
                                var roomIndex = Data.RoomList.Count + 1;
                                Data.RoomList.Enqueue(room);

                                for (var i = 0; i < Data.MatchingMin; i++)
                                {
                                    var tempUser = Data.MatchingList.Dequeue();
                                    // 인 게임 순번 적기 (0은 안나오도록! +1 함)
                                    tempUser.Data = new NcsUserData { PlayIndex = Convert.ToByte(i + 1) };
                                    tempUser.PlayRoom = room;
                                    room.UserList.Add(tempUser);
                                    MoveSpace.Func(tempUser, roomIndex);
                                }
                                room.Start(); // ※중요※ 이 코드는 동기로 처리되는 것이어서, 맵 만들다 멈추면 매칭 기능 자체가 멈춰버린다.
                            }
                        }
                    }
                }

                await System.Threading.Tasks.Task.Delay(Data.MatchingWait);
                Func();
            }).Start();
        }
    }
}
