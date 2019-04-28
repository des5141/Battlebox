using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class UserAdd
    {
        public static async Task Func(NcsUser User, int Space)
        {
            using (await Program.TaskLockInUserList.LockAsync())
            {
                Program.UserList[Space].Add(User);
                User.Space = Space;
            }
        }
    }
}
