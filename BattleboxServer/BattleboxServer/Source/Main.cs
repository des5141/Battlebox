using System;
using System.Collections.Generic;
using BattleboxServer;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace Networking_with_Supersocket
{
    public class Main
    {
        NcsServer ncsServer = new NcsServer();

        public Main(ServerConfig config, Action ServerStarted, SessionHandler<NcsUser> NewSessionConnected, SessionHandler<NcsUser, CloseReason> SessionClosed, RequestHandler<NcsUser, NcsRequestInfo> NewRequestReceived)
        {
            ncsServer.Setup(new RootConfig(), config);
            NcsTemplateBuffer.SetTempBuffer();
            if (ncsServer.Start() == true)
                ServerStarted();
            ncsServer.NewSessionConnected += new SessionHandler<NcsUser>(NewSessionConnected);
            ncsServer.SessionClosed += new SessionHandler<NcsUser, CloseReason>(SessionClosed);
            ncsServer.NewRequestReceived += new RequestHandler<NcsUser, NcsRequestInfo>(NewRequestReceived);
        }
    }
}