using System;
using Server.Source.Room.Lock;

namespace Server.Source.SignalEvent.Func
{
    class UserReady : Core.SignalEvent
    {
        public UserReady()
        {
            Msg[Signal.UserReady] = (user, requestinfo, buffer) => { user.PlayReady = true; };
        }
    }
}
