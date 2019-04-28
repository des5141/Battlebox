using Networking_with_Supersocket;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class SignalUserInfo
    {
        public static void Func(NcsUser User, CGD.buffer Buffer)
        {
            // 이걸 Task 를 만들어서 하는 이유는
            // 반환 값을 받아야하는 처리가 아니기도 하고, 비동기로 속도를 높힐 수 있기도 해서다
            new Task(async () =>
            {
                using (await Program.TaskLockInUserList.LockAsync())
                {
                    // 해당 유저가 허가 되지 않았다면,
                    if (User.Authentication == true)
                    {
                        // 유저 정보를 들고 온다
                        DataTable Result = DatabaseUserInfo.Func(User.Id).Result;
                        
                        // 유저 정보가 없다면
                        if (Result == null)
                        {
                            var SendBuffer = NewBuffer.Func(8);
                            SendBuffer.append<SByte>(0);
                            User.Send(SendBuffer, Signal.UserInfo);
                        }

                        // 유저 정보가 있다면
                        else
                        {
                            Console.WriteLine(Result.Rows[0]["nickname"]);
                            var SendBuffer = NewBuffer.Func(1024);
                            SendBuffer.append<sbyte>(2);
                            SendBuffer.append_gmlstring(Convert.ToString(Result.Rows[0]["nickname"] ?? "EMPTY"));
                            SendBuffer.append<UInt16>(Convert.ToUInt16(Result.Rows[0]["level"]));
                            SendBuffer.append<uint>(Convert.ToUInt32(Result.Rows[0]["exp"]));
                            SendBuffer.append<uint>(Convert.ToUInt32(Result.Rows[0]["point"]));
                            SendBuffer.append<uint>(Convert.ToUInt32(Result.Rows[0]["play_game"]));
                            SendBuffer.append<uint>(Convert.ToUInt32(Result.Rows[0]["play_win"]));
                            SendBuffer.append<uint>(Convert.ToUInt32(Result.Rows[0]["play_kill"]));
                            SendBuffer.append<uint>(Convert.ToUInt32(Result.Rows[0]["diamond"]));
                            SendBuffer.append<uint>(Convert.ToUInt32(Result.Rows[0]["money"]));
                            User.Send(SendBuffer, Signal.UserInfo);
                        }
                    }
                    else
                    {
                        // 요청한 사용자 계정이 허가되어있지 않음
                        var SendBuffer = NewBuffer.Func(8);
                        SendBuffer.append<SByte>(1);
                        User.Send(SendBuffer, Signal.UserInfo);
                    }
                }
            }).Start();
        }
    }
}
