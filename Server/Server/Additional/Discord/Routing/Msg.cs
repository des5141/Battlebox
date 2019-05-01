using System;
using System.Collections.Generic;
using Discord.WebSocket;

namespace Server.Additional.Discord.Routing
{
    public class Msg
    {
        public Action<SocketMessage, string> this[dynamic i]
        {
            set
            {
                Console.WriteLine(i);
                this.Add(i, value);
            }
        }

        public static Dictionary<dynamic, Action<SocketMessage, string>> BufferDictionary = new Dictionary<dynamic, Action<SocketMessage, string>>();

        public void Add(dynamic type, Action<SocketMessage, string> action)
        {
            BufferDictionary.Add(type, action);
        }
    }
}
