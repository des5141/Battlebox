using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class RoomJoin
    {
        public static void Func(NcsUser User)
        {
            new Task(async () =>
            {
                using (await Program.TaskLockInMatchingList.LockAsync())
                {
                    Program.MatchingList.Enqueue(User);
                }
            }).Start();
        }
    }
}
