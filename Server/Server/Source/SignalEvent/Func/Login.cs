using System;
using CGD;
using Server.Source.Core;

namespace Server.Source.SignalEvent.Func
{
    class Login : Core.SignalEvent
    {
        public Login()
        {
            Msg[Signal.Login] = (user, requestinfo) =>
            {
                //var buffer = NewBuffer.Func(16);
                //buffer.append<byte>(1);
                user.Send(NcsTemplateBuffer.HeartbeatBuffer1, 1);
            };
        }
    }
}
