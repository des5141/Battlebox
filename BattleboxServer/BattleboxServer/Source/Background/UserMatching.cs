using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class UserMatching
    {
        public static void Func()
        {
            new Task(async () =>
            {
                using (await Program.TaskLockInMatchingList.LockAsync())
                {
                    using (await Program.TaskLockInRoomList.LockAsync())
                    {
                        // 이중 Lock
                        // 잘못해서 여기가 꼬이면 그대로 망한다
                        if (Program.MatchingList.Count >= Program.MatchingMin)
                        {
                            NcsRoom Room = new NcsRoom();
                            int RoomIndex = Program.RoomList.Count + 1;
                            Program.RoomList.AddLast(Room);

                            for (int i = 0; i < Program.MatchingMin; i++)
                            {
                                NcsUser TempUser = Program.MatchingList.Dequeue();
                                TempUser.Data = new UserData {PlayIndex = Convert.ToUInt16(i + 1)};
                                // 인 게임 순번 적기 (0은 안나오도록! +1 함)
                                TempUser.PlayRoom = Room;
                                Room.UserList.Add(TempUser);
                                SpaceMove.Func(TempUser, RoomIndex).Wait();
                            }
                            Room.Start(); // ※중요※ 이 코드들은 동기로 처리되는 것이어서, 맵 만들다 멈추면 매칭 기능 자체가 멈춰버린다.
                        }
                    }
                }
                await Task.Delay(200);
                Func();
            }).Start();
        }
    }
}
