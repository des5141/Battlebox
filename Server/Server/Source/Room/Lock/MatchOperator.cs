using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                using (await Source.Lock.MatchingList.LockAsync())
                {
                    Data.MatchingList.Dequeue();
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
