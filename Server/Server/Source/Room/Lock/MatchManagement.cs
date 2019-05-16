using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.User;

namespace Server.Source.Room.Lock
{
    class MatchManagement
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
            var str = "# MATCH LIST";
            foreach (var item in Data.MatchingList.Items)
            {
                str += item.Nickname + "\n";
            }
            str += "# END";
            Chat.SendLog(str);
        }
    }
}
