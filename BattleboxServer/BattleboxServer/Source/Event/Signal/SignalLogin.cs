using Networking_with_Supersocket;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class SignalLogin
    {
        public static void Func(NcsUser User, CGD.buffer Buffer)
        {
            // 이걸 Task 를 만들어서 하는 이유는
            // 반환 값을 받아야하는 처리가 아니기도 하고, 비동기로 속도를 높힐 수 있기도 해서다
            new Task(async () =>
            {
                using (var releaser = await Program.TaskLockInUserList.LockAsync())
                {
                    // 해당 유저가 허가 되지 않았다면,
                    if (User.Authentication == false)
                    {
                        String TempId = Buffer.extract_gmlstring();
                        String TempDeviceId = Buffer.extract_gmlstring();

                        int CheckConnection = DatabaseCheckConnection.Func(TempId).Result;
                        int CheckBlocked = DatabaseCheckBlocked.Func(TempDeviceId).Result;

                        // 해당 deviceid 가 접속 중이 아니면서, 정지를 먹지않았을 시
                        if ((CheckConnection == -1) && (CheckBlocked == -1))
                        {
                            // 계정이 존재하는지 가져옴
                            DataTable Result = DatabaseLogin.Func(TempId).Result;
                            Console.WriteLine(Result);
                            // 없으면
                            if (Result == null)
                            {
                                // 계정이 없는 상태, 회원가입 가능
                                var SendBuffer = NewBuffer.Func(8);
                                SendBuffer.append<SByte>(2);
                                User.Send(SendBuffer, Signal.Login);
                            }

                            // 있으면
                            else
                            {
                                // 계정의 deviceid 와 일치할 시,
                                if ((string)Result.Rows[0]["deviceid"] == TempDeviceId)
                                {
                                    // 계정이 있고, 접근 할 수 있는 상태 - 바로 로그인 처리
                                    DatabaseUserConnection.Func(TempId, 1);
                                    User.Authentication = true;
                                    User.Id = TempId;
                                    User.DeviceId = TempDeviceId;
                                    User.Nickname = (string)Result.Rows[0]["nickname"];

                                    // 로딩 Space으로 이동
                                    SpaceMoveInTask.Func(User, 1);

                                    // 로그인 성공 전송
                                    var SendBuffer = NewBuffer.Func(8);
                                    SendBuffer.append<SByte>(1);
                                    User.Send(SendBuffer, Signal.Login);
                                }
                                else
                                {
                                    // 계정이 있고, 접근 할 수 없는 상태
                                    var SendBuffer = NewBuffer.Func(8);
                                    SendBuffer.append<SByte>(0);
                                    User.Send(SendBuffer, Signal.Login);
                                }
                            }
                        }
                        else
                        {
                            // 정지를 먹거나 접속 중인 계정
                            var SendBuffer = NewBuffer.Func(8);
                            SendBuffer.append<SByte>(0);
                            User.Send(SendBuffer, Signal.Login);
                        }
                    }
                    
                    // 이미 해당 유저는 로그인 하였다
                    else
                    {
                        var SendBuffer = NewBuffer.Func(8);
                        SendBuffer.append<SByte>(0);
                        User.Send(SendBuffer, Signal.Login);
                    }
                }
            }).Start();
        }
    }
}
