using System;
using Server.Source.Room.Lock;

namespace Server.Source.SignalEvent.Func
{
    class UserAttack : Core.SignalEvent
    {
        public UserAttack()
        {
            Msg[Signal.UserAttack] = (user, requestinfo, buffer) =>
            {
                // 공격 부분 처리

            };
        }
    }
}
