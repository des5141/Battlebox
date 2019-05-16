using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Additional.Discord.Message
{
    public class Ping : Routing.Function
    {
        public Ping()
        {
            Msg["--ping"] = (message, list) =>
            {
                message.Channel.SendMessageAsync("pong");
            };
        }

    }
}
