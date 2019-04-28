using Networking_with_Supersocket;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class SignalRegister
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
                    if (User.Authentication == false)
                    {
                        // 회원가입이 가능한가 체크
                        // 가능하다면 SByte 1 반환, 아닐경우 0 반환
                        String TempId = Encoding.UTF8.GetString(Buffer.extract<byte[]>());
                        String TempDeviceId = Encoding.UTF8.GetString(Buffer.extract<byte[]>());
                        SByte Result = DatabaseRegister.Func(TempId, TempDeviceId).Result;

                        // 값 전송
                        var SendBuffer = NewBuffer.Func(8);
                        SendBuffer.append<SByte>(Result);
                        User.Send(SendBuffer, Signal.Register);
                    }

                    // 이미 해당 유저는 로그인 하였다
                    else
                    {
                        // 이미 로그인 한 상태
                        var SendBuffer = NewBuffer.Func(8);
                        SendBuffer.append<SByte>(2);
                        User.Send(SendBuffer, Signal.Register);
                    }
                }
            }).Start();
        }
    }
}
