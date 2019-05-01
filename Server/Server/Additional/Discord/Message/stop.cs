using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace Server.Additional.Discord.Message
{
    public class stop : Routing.Function
    {
        public stop()
        {
            Msg["--stop"] = (message, list) =>
            {
                if (message.Author.Id == Config.Admin)
                {
                    var embed = new EmbedBuilder()
                        .WithTitle("Server Info")
                        .WithDescription("서버의 **종료 명령**이 시작되었습니다")
                        .WithTimestamp(DateTimeOffset.Now)
                        .Build();
                    Program.Discord.GetGuild(573111073616560128).GetTextChannel(573111191468245002).SendMessageAsync("", embed: embed);

                    // 넌.. 죽었다..
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            };
        }

    }
}
