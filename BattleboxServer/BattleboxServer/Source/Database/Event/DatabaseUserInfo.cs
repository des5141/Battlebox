using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    public class DatabaseUserInfo
    {
        public static async Task<DataTable> Func(String UserId)
        {
            using (await Program.TaskLockInDatabase.LockAsync())
            {
                return Program.SqlManager.Read($"select * from user where id=\"{UserId}\"");
            }
        }
    }
}
