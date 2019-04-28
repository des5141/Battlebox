using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGD;
using MySqlX.XDevAPI.Common;
using Networking_with_Supersocket;

namespace BattleboxServer
{
    class SignalGameDrop
    {
        public static void Func(NcsUser User, CGD.buffer Buffer)
        {
            uint x = Buffer.extract<UInt16>();
            uint y = Buffer.extract<UInt16>();
            byte item_index = Buffer.extract<Byte>();
            byte item_count = Buffer.extract<Byte>();
            new Task(async () =>
            {
                using (await User.PlayRoom.TaskLockInRoom.LockAsync())
                {
                    User.PlayRoom.Item.Add(new List<int>());
                    int array_index = User.PlayRoom.Item.Count - 1;
                    User.PlayRoom.Item[array_index].Add((int) Math.Floor((double) x / 64 / 20));
                    User.PlayRoom.Item[array_index].Add((int) Math.Floor((double) y / 64 / 20));
                    User.PlayRoom.Item[array_index].Add((int) x);
                    User.PlayRoom.Item[array_index].Add((int) y);
                    User.PlayRoom.Item[array_index].Add((int) item_index);
                    User.PlayRoom.Item[array_index].Add(item_count);

                    foreach (NcsUser index in User.PlayRoom.UserList)
                    {
                        if (index.UserReady == true)
                        {
                            // 접속하고 있는 유저일 경우
                            // 아이템 생성 상태를 알려줌
                            var SendBuffer = NewBuffer.Func(512);
                            SendBuffer.append<UInt16>(Convert.ToUInt16(x));
                            SendBuffer.append<UInt16>(Convert.ToUInt16(y));
                            SendBuffer.append<Byte>(Convert.ToByte(User.PlayRoom.Item[array_index][0]));
                            SendBuffer.append<Byte>(Convert.ToByte(User.PlayRoom.Item[array_index][1]));
                            SendBuffer.append<Byte>(Convert.ToByte(item_index));
                            SendBuffer.append<Byte>(Convert.ToByte(item_count));
                            SendBuffer.append<UInt16>(Convert.ToUInt16(array_index));
                            User.Send(SendBuffer, Signal.GameDrop);
                        }
                    }
                }
            }).Start();
    }
}
}
