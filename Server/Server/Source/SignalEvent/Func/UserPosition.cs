using System;
using Server.Source.Room.Lock;

namespace Server.Source.SignalEvent.Func
{
    class UserPosition : Core.SignalEvent
    {
        public UserPosition()
        {
            Msg[Signal.UserPosition] = (user, requestinfo, buffer) =>
            {
                user.Data.X = buffer.extract_ushort();
                user.Data.Y = buffer.extract_ushort();
                user.Data.Z = buffer.extract_byte();
                user.Data.ImageIndex = buffer.extract_byte();
                user.Data.ImageXScale = buffer.extract_sbyte();
                user.Data.WeaponIndex = buffer.extract_byte();
                user.Data.WeaponDir = buffer.extract_short();
            };
        }
    }
}
