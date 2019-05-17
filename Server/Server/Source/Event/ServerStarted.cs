using Server.Source.Background;
using Server.Source.Core;
using Server.Source.Database;

namespace Server.Source.Event
{
    class ServerStarted
    {
        public static void Func()
        {
                //Main.Database = new SqlManager("Server=61.84.196.75;Port=20001;Database=battlebox;Uid=rhea31;Pwd=vkcjs8688;");
                Main.Database = new SqlManager("Server=127.0.0.1;Port=20001;Database=battlebox;Uid=rhea31;Pwd=vkcjs8688;");
                MatchManagement.Func();
        }
    }
}
