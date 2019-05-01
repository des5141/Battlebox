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
                if (message.Author.Id == 518286982288506880)
                {
                    Processing(message).Wait();
                }
            };
        }

        public async Task Processing(SocketMessage message)
        {
            var msgList = await message.Channel.GetMessagesAsync(100).FlattenAsync();

            var msgEnumerator = msgList.GetEnumerator();

            while (msgEnumerator.MoveNext())
            {
                msgEnumerator.Current.DeleteAsync();
            }
        }
    }
}
