using System;
using Server.Source.Core;

namespace Server.Source.Signal.Func
{
    class Login : SignalEvent
    {
        public Login()
        {
            Msg[Signal.Login] = (user, requestinfo) =>
            {
                Console.WriteLine("Hello");
            };
        }
    }
}
