using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;
using Server.Source.User;

namespace Server.Source.Room.Lock
{
    class MatchOperator
    {
        public static void Add(NcsUser user)
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await Source.Lock.MatchingList.LockAsync())
                {
                    Data.MatchingList.Enqueue(user);
                }

                ShowList();
            }).Start();
        }

        public static void Remove(NcsUser user)
        {
            new System.Threading.Tasks.Task(async () =>
            {
                // 플레이하고 있었던 방이 있으면
                if (user.PlayRoom != null)
                {
                    new System.Threading.Tasks.Task(async () =>
                    {
                        using (await user.PlayRoom.TaskLockInRoom.LockAsync())
                        {
                            var buf = NewBuffer.Func(16);
                            buf.append<byte>(user.Data.PlayIndex);
                            // 유저가 나갔다는 메세지를 보냄
                            foreach (var t in user.PlayRoom.UserList)
                            {
                                t.Send(buf, Signal.UserDelete);
                            }

                            // 리스트에서 제거
                            user.PlayRoom.UserList.Remove(user);
                            user.PlayRoom = null;
                            user.Data = null;
                        }
                    }).Start();
                }

                using (await Source.Lock.MatchingList.LockAsync())
                {
                    Data.MatchingList.Remove(user);
                }
                ShowList();
            }).Start();
        }

        private static void ShowList()
        {
            var i = 0;
            var str = "# MATCH LIST\n";
            foreach (var item in Data.MatchingList.Items)
            {
                str += $"[{i}] {item.Nickname}\n";
            }
            str += "# END";
            Chat.SendLog(str);
        }
    }
}
