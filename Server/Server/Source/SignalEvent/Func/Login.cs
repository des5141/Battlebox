using System;
using Discord;
using Server.Source.Core;
using Server.Source.Database.Event;
using Server.Source.Task;

namespace Server.Source.SignalEvent.Func
{
    class Login : Core.SignalEvent
    {
        public Login()
        {
            Msg[Signal.Login] = (user, requestinfo, buffer) =>
            {
                Program.Discord.GetGuild(573111073616560128).GetTextChannel(573111191468245002).SendMessageAsync( "test");

                var playerId = buffer.extract_gmlstring();
                var playerNickname = buffer.extract_gmlstring();

                if (DatabaseCheckCanLogin.Func(playerId).Result)
                {
                    // 로그인 가능
                    var getPlayerDataTable = DatabaseLogin.Func(playerId).Result;
                    user.Nickname = (string) getPlayerDataTable.Rows[0]["nickname"];
                    user.Id = (string) getPlayerDataTable.Rows[0]["id"];

                    // 로그인 성공했다고 돌려주기
                    var buf = NewBuffer.Func(128);
                    buf.append<byte>(1);
                    buf.append_gmlstring(user.Nickname);
                    user.Send(buf, Signal.Login);

                    // 허가된 위치로 이동
                    MoveSpace.Func(user, 1);
                }
                else
                {
                    // 로그인 실패
                    if (DatabaseRegister.Func(playerId, playerNickname).Result)
                    {
                        // 성공적으로 만듬
                        user.Nickname = playerNickname;
                        user.Id = playerId;
                        var buf = NewBuffer.Func(16);
                        buf.append<byte>(2);
                        user.Send(buf, Signal.Login);
                    }
                    else
                    {
                        // 못 만듬. 정지당했거나 로그인 중 인지 확인 필요
                        var buf = NewBuffer.Func(16);
                        buf.append<byte>(3);
                        user.Send(buf, Signal.Login);
                    }
                }
            };
        }
    }
}
