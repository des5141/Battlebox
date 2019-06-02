using System;
using System.Collections.Generic;
using Server.Source.Core;
using Server.Source.Room.Lock;

namespace Server.Source.SignalEvent.Func
{
    class BoxDamage : Core.SignalEvent
    {
        public BoxDamage()
        {
            Msg[Signal.BoxDamage] = (user, requestinfo, buffer) =>
            {
                var index = buffer.extract_byte();
                var damage = buffer.extract_byte();

                if (user.PlayRoom != null)
                {
                    new System.Threading.Tasks.Task(async () =>
                    {
                        using (await user.PlayRoom.TaskLockInRoom.LockAsync())
                        {
                            // 박스에 데미지 적용
                            user.PlayRoom.Box[index, 0] -= damage;

                            // 박스 체력 변경 점을 전송
                            var buf = NewBuffer.Func(16);
                            buf.append<byte>(index);
                            buf.append<byte>(user.PlayRoom.Box[index, 0]);

                            foreach (var t in user.PlayRoom.UserList)
                            {
                                t.Send(buf, Signal.BoxDamage);
                            }

                            // 아이템 추가
                            user.PlayRoom.Item.Add(new List<int>());
                            var arrayIndex = user.PlayRoom.Item.Count - 1;
                            user.PlayRoom.Item[arrayIndex].Add(user.PlayRoom.Box[index, 1]); // i
                            user.PlayRoom.Item[arrayIndex].Add(user.PlayRoom.Box[index, 2]); // j
                            user.PlayRoom.Item[arrayIndex].Add(1); // index
                            user.PlayRoom.Item[arrayIndex].Add(Ran.Next(1, 99)); // count
                        }
                    }).Start();
                }
            };
        }
    }
}
