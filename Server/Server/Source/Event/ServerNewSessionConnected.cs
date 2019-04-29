using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Task;
using Server.Source.User;

namespace Server.Source.Event
{
    class ServerNewSessionConnected
    {
        public static void Func(NcsUser session)
        {
            session.HeartBeatStart();
            MoveSpace.Func(session, 0);
        }
    }
}
