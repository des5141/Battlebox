﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Room.Lock;
using Server.Source.Task;
using Server.Source.User;
using SuperSocket.SocketBase;

namespace Server.Source.Event
{
    class ServerSessionClosed
    {
        public static void Func(NcsUser session, CloseReason value)
        {
            session.Die = true;
            MatchOperator.Remove(session);
            RemoveUser.Func(session);
        }
    }
}
