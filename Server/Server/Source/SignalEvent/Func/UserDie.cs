using System;
using Server.Source.Core;
using Server.Source.Room.Lock;

namespace Server.Source.SignalEvent.Func
{
    class UserDie : Core.SignalEvent
    {
        public UserDie()
        {
            Msg[Signal.UserDie] = (user, requestinfo, buffer) =>
            {
                if (user.PlayRoom == null) return;

                var userIndex = buffer.extract_byte();
                var buf = NewBuffer.Func(32);
                buf.append<byte>(userIndex);

                new System.Threading.Tasks.Task(async () =>
                {
                    using (await user.PlayRoom.TaskLockInRoom.LockAsync())
                    {
                        // 유저가 죽었다는 사실을 전송
                        foreach (var t in user.PlayRoom.UserList)
                        {
                            if (t.Data.PlayIndex == userIndex)
                                t.Data.Die = true;
                            t.Send(buf, Signal.UserDie);
                        }
                    }
                }).Start();
            };
        }
    }
}
