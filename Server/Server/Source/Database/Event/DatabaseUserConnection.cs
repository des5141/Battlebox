using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;
using Server.Source.User;

namespace Server.Source.Database.Event
{
    class DatabaseUserConnection
    {
        public static void Func(string playerId, int connection)
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await Main.TaskLockInDatabase.LockAsync())
                {
                    Main.Database.Read($"update user set connect={connection} where id='{playerId}'");
                }
            }).Start();
        }
    }
}
