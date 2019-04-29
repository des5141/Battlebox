using System;
using CGD;
using Server.Source.Core;
using Server.Source.Database.Event;

namespace Server.Source.SignalEvent.Func
{
    class Login : Core.SignalEvent
    {
        public Login()
        {
            Msg[Signal.Login] = (user, requestinfo, buffer) =>
            {
                var playerId = buffer.extract_gmlstring();
                var playerNickname = buffer.extract_gmlstring();

                if (DatabaseCheckCanLogin.Func(playerId).Result)
                {
                    // 로그인 가능
                }
                else
                {
                    // 로그인 실패
                    if (DatabaseRegister.Func(playerId, playerNickname).Result)
                    {
                        // 성공적으로 만듬
                    }
                    else
                    {
                        // 못 만듬. 정지당했거나 로그인 중 인지 확인 필요
                    }
                }
            };
        }
    }
}
