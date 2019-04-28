using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class UserDelete
    {
        public static async Task Func(NcsUser User)
        {
            using (await Program.TaskLockInUserList.LockAsync())
            {
                for (int i = 0; i < Program.SpaceMax; i++)
                {
                    Program.UserList[i].Remove(User);
                }
            }
        }
    }
}
