using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGD;
using Networking_with_Supersocket;

namespace BattleboxServer
{
    class SignalGameUse
    {
        public static void Func(NcsUser User, CGD.buffer Buffer)
        {
            int item_index = Buffer.extract<UInt16>(); // index
            int item_count = Buffer.extract<Int16>();  // count
            uint who = User.Data.PlayIndex;   // user play index

            bool trigger = false;
            int return_count = -1;

            new Task(async () =>
            {
                using (await User.PlayRoom.TaskLockInRoom.LockAsync())
                {
                    if (User.PlayRoom.Item[item_index][4] /* Item Index */ != -1)
                    {
                        if (User.PlayRoom.Item[item_index][5] /* Item Count */ > 0)
                        {
                            if (User.PlayRoom.Item[item_index][5] >= item_count)
                            {
                                return_count = item_count;
                                User.PlayRoom.Item[item_index][5] -= item_count;
                            }
                            else
                            {
                                return_count = User.PlayRoom.Item[item_index][5];
                                User.PlayRoom.Item[item_index][5] = 0;
                                User.PlayRoom.Item[item_index][4] = -1; // delete
                            }
                        }
                        trigger = true;
                    }
                    foreach (NcsUser index in User.PlayRoom.UserList)
                    {
                        if (index.UserReady == true)
                        {
                            // 접속하고 있는 유저일 경우
                            // 아이템 제거 상태를 알려줌
                            // target에게 index의 데이터 전송
                            var SendBuffer = NewBuffer.Func(64);
                            SendBuffer.append<UInt16>(Convert.ToUInt16(item_index));
                            SendBuffer.append<Int16>(Convert.ToInt16(return_count));
                            if ((trigger == true) && (index.Data.PlayIndex == who))
                                SendBuffer.append<Byte>(Convert.ToByte(1));
                            else
                                SendBuffer.append<Byte>(Convert.ToByte(2));
                            User.Send(SendBuffer, Signal.GameUse);
                        }
                    }
                }
            }).Start();
        }
    }
}
