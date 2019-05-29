using System;
using Server.Source.Core;
using Server.Source.Room.Lock;

namespace Server.Source.SignalEvent.Func
{
    class KillLog : Core.SignalEvent
    {
        public KillLog()
        {
            Msg[Signal.KillLog] = (user, requestinfo, buffer) =>
            {
                if (user.PlayRoom == null) return;

                var buf = NewBuffer.Func(512);
                var tar1 = buffer.extract_byte();
                var tar2 = buffer.extract_byte();
                string tar1String = "";
                string tar2String = "";

                buf.append<byte>(tar1);

                new System.Threading.Tasks.Task(async () =>
                {
                    using (await user.PlayRoom.TaskLockInRoom.LockAsync())
                    {
                        foreach (var t in user.PlayRoom.UserList)
                        {
                            if (t.Data.PlayIndex == tar1)
                            {
                                tar1String = t.Nickname;
                            }

                            if (t.Data.PlayIndex == tar2)
                            {
                                tar2String = t.Nickname;
                            }
                        }
                        buf.append_gmlstring(tar1String);
                        buf.append_gmlstring(tar2String);

                        // 유저의 킬 로그를 전송
                        foreach (var t in user.PlayRoom.UserList)
                        {
                            t.Send(buf, Signal.KillLog);
                        }
                    }
                }).Start();
            };
        }
    }
}
