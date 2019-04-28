using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class SendSpace
    {
        public static async Task Func(CGD.buffer Buffer, int Space)
        {
            using (await Program.TaskLockInUserList.LockAsync())
            {
                foreach(NcsUser Index in Program.UserList[Space])
                {
                    Index.Send(Buffer);
                }
            }
        }
    }
}
