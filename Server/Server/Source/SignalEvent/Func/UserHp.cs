using System;
using Server.Source.Core;
using Server.Source.Room.Lock;

namespace Server.Source.SignalEvent.Func
{
    class UserHp : Core.SignalEvent
    {
        public UserHp()
        {
            Msg[Signal.UserHp] = (user, requestinfo, buffer) =>
            {
                if (user.PlayRoom == null) return;

                var userIndex = buffer.extract_byte();
                var hp = buffer.extract_byte();
                new System.Threading.Tasks.Task(async () =>
                {
                    using (await user.PlayRoom.TaskLockInRoom.LockAsync())
                    {
                        // 유저 체력 전송
                        var buf = NewBuffer.Func(16);
                        buf.append<byte>(userIndex);
                        buf.append<byte>(hp);

                        foreach (var t in user.PlayRoom.UserList)
                        {
                            t.Send(buf, Signal.UserHp);
                        }
                    }
                }).Start();
            };
        }
    }
}
