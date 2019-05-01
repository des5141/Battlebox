using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Additional.Discord.Message
{
    public class ping : Routing.Function
    {
        public ping()
        {
            Msg["--ping"] = (message, list) =>
            {
                if (message.Author.Id == Config.Admin)
                    message.Channel.SendMessageAsync("pong");
            };
        }

    }
}
