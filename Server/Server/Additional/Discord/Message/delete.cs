using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Server.Additional.Discord.Message
{
    public class delete : Routing.Function
    {
        public delete()
        {
            Msg["--delete"] = (message, list) =>
            {
                if (message.Author.Id == Config.Admin)
                {
                    Processing(message).Wait();
                }
            };
        }

        public async Task Processing(SocketMessage message)
        {
            IEnumerable<IMessage> messages = await message.Channel.GetMessagesAsync(100).FlattenAsync();
            await ((ITextChannel)message.Channel).DeleteMessagesAsync(messages);
        }
    }
}
