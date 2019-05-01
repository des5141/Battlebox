using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Server.Additional.Discord;
using Server.Additional.Discord.Routing;
using Server.Source.Core;
using Server.Source.Database;
using Server.Source.Event;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace Server
{
    class Program
    {
        public static MessageSwitch Msg;
        public static DiscordSocketClient Client;
        public const string Token = "NTczMTEwODA0MTg3MTg1MTUy.XMmFGg.QkctThj48AY_CZrY1PWXKbvqv8A";
        static void Main()
        {
            //var database = new SQLManager();

            var mConfig = new ServerConfig()
            {
                Port = 20000,
                Ip = "Any",
                MaxConnectionNumber = 5000,
                Mode = SocketMode.Tcp,
                Name = "battlebox server"
            };

            // Signal Event 불러오기
            SignalScan.Start();

            // 서버 시작
            var server = new Main(mConfig, ServerStarted.Func, ServerNewSessionConnected.Func, ServerSessionClosed.Func, ServerNewRequestReceived.Func);


            // 디스코드 서버
            FunctionScan.StartScan();
            new Program().MainAsync().GetAwaiter().GetResult();


            // 서버 꺼짐 방지
            KeyWaiting.Func();
        }

        public async Task MainAsync()
        {
            Client = new DiscordSocketClient();
            Msg = new MessageSwitch();

            Client.Log += Log;
            Client.MessageReceived += Msg.MessageReceived;
            Client.Ready += Client_Ready;
            Client.GuildAvailable += Client_GuildAvailable;

            await Client.GetGuild(573111073616560128).GetTextChannel(573111191468245002).SendMessageAsync("Server run!");

            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();
            await Task.Delay(-1);
        }

        protected Task Client_GuildAvailable(SocketGuild arg)
        {
            return Task.CompletedTask;
        }

        protected Task Client_Ready() { return Task.CompletedTask; }

        protected static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
