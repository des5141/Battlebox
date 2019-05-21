using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace Server.Additional.Discord.Message
{
    public class Stop : Routing.Function
    {
        public Stop()
        {
            Msg["--stop"] = (message, list) =>
            {
                if (message.Author.Id == Config.Admin)
                {
                    var embed = new EmbedBuilder()
                        .WithDescription("TURN OFF")
                        .WithTimestamp(DateTimeOffset.Now)
                        .Build();
                    Program.Discord.GetGuild(573111073616560128).GetTextChannel(573111191468245002).SendMessageAsync("", embed: embed).Wait();


                    // 넌.. 죽었다..
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            };
        }

    }
}
