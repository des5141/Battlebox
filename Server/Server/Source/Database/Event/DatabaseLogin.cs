using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;

namespace Server.Source.Database.Event
{
    class DatabaseLogin
    {
        public static async Task<DataTable> Func(string playerId)
        {
            using (await Lock.Database.LockAsync())
            {
                return Main.Database.Read($"select * from user where id=\"{playerId}\"");
            }
        }
    }
}
