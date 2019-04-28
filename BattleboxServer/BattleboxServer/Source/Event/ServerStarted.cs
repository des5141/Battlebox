using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class ServerStarted
    {
        public static void Func()
        {
            Console.WriteLine("Hello Networking with Supersocket!");

            for (int i = 0; i < Program.SpaceMax; i++)
                Program.UserList.Add(new List<NcsUser>());
            Console.WriteLine(" - Make Space");

            // MySql 연결
            new Task(async () =>
            {
                using (var releaser = await Program.TaskLockInDatabase.LockAsync())
                {
                    Program.SqlManager = new SqlManager("Server=61.84.196.75;Port=20001;Database=battlebox;Uid=rhea31;Pwd=Rheapass5141*;");
                }
            }).Start();
        }
    }
}
