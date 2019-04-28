using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class RoomOut
    {
        public static void Func(NcsUser User)
        {
            new Task(async () =>
            {
                using (await Program.TaskLockInMatchingList.LockAsync())
                {
                    Program.MatchingList.Remove(User);
                }
            }).Start();
        }
    }
}
