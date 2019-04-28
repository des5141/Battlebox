using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class UserCounting
    {
        public static void Func()
        {
            new Task(async () =>
            {
                using (await Program.TaskLockInUserList.LockAsync())
                {
                    Program.TotalUserCount = 0;
                    for (int i = 0; i < Program.SpaceMax; i++)
                        Program.TotalUserCount += Program.UserList[i].Count;
                }
                await Task.Delay(1000);
                Func();
            }).Start();
        }
    }
}
