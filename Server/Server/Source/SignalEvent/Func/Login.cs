using System;
using CGD;
using Server.Source.Core;

namespace Server.Source.SignalEvent.Func
{
    class Login : Core.SignalEvent
    {
        public Login()
        {
            Msg[Signal.Login] = (user, requestinfo, buffer) =>
            {

            };
        }
    }
}
