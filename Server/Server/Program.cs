using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;
using Server.Source.Database;
using Server.Source.Event;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace Server
{
    class Program
    {
        static void Main()
        {
            var database = new SQLManager();

            var mConfig = new ServerConfig()
            {
                Port = 65535,
                Ip = "Any",
                MaxConnectionNumber = 5000,
                Mode = SocketMode.Tcp,
                Name = "battlebox server"
            };

            // Signal Event 불러오기
            SignalScan.Start();

            // 서버 시작
            var server = new Main(mConfig, ServerStarted.Func, ServerNewSessionConnected.Func, ServerSessionClosed.Func, ServerNewRequestReceived.Func);

            // 서버 꺼짐 방지
            KeyWaiting.Func();
        }
    }
}
