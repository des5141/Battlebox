using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;
using Server.Source.Database;

namespace Server.Source.Event
{
    class ServerStarted
    {
        public static void Func()
        {
            Main.Database = new SqlManager("Server=61.84.196.75;Port=20001;Database=battlebox;Uid=rhea31;Pwd=Rheapass5141*;");
        }
    }
}
