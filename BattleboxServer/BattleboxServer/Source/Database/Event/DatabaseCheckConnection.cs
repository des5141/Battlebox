using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    public class DatabaseCheckConnection
    {
        public static async Task<int> Func(String Device)
        {
            using (await Program.TaskLockInDatabase.LockAsync())
            {
                DataTable Dt = Program.SqlManager.Read($"select * from user where deviceid=\"{Device}\" and connect=1");
                if (Dt != null)
                    return 1;
                else
                    return -1;
            }
        }
    }
}
