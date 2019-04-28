using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    public class DatabaseUserConnection
    {
        public static void Func(String UserId, int Connection)
        {
            new Task(async () =>
            {
                using (await Program.TaskLockInDatabase.LockAsync())
                {
                    DataTable Dt = Program.SqlManager.Read($"update user set connect={Connection} where id='{UserId}'");
                }
            }).Start();
        }
    }
}
