using System;
using Server.Source.Core;
using Server.Source.Room.Lock;

namespace Server.Source.SignalEvent.Func
{
    class UserAttack : Core.SignalEvent
    {
        public UserAttack()
        {
            Msg[Signal.UserAttack] = (user, requestinfo, buffer) =>
            {
                var buf = NewBuffer.Func(64);
                buf.append<byte>(buffer.extract_byte());
                buf.append<ushort>(buffer.extract_ushort());
                buf.append<ushort>(buffer.extract_ushort());
                buf.append<byte>(buffer.extract_byte());
                buf.append<short>(buffer.extract_short());
                buf.append<sbyte>(buffer.extract_sbyte());
                buf.append<byte>(buffer.extract_byte());
                buf.set_front<uint>(buf.Count);
                buf.set_front<short>(Signal.UserAttack, 4);

                new System.Threading.Tasks.Task(async () =>
                {
                    using (await user.PlayRoom.TaskLockInRoom.LockAsync())
                    {
                        foreach (var t in user.PlayRoom.UserList)
                        {
                            t.Send(buf);
                        }
                    }
                }).Start();
            };
        }
    }
}
