using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class SpaceMove
    {
        public static async Task Func(NcsUser User, int Space)
        {
            using (await Program.TaskLockInUserList.LockAsync())
            {
                for (int i = 0; i < Program.SpaceMax; i++)
                {
                    Program.UserList[i].Remove(User);
                }
                Program.UserList[Space].Add(User);
                User.Space = Space;
            }
        }
    }
}
