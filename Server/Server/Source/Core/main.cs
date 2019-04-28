using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.User;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace Server.Source.Core
{
    public class Main
    {
        readonly NcsServer _ncsServer = new NcsServer();

        public Main(ServerConfig config, Action serverStarted, SessionHandler<NcsUser> newSessionConnected, SessionHandler<NcsUser, CloseReason> sessionClosed, RequestHandler<NcsUser, NcsRequestInfo> newRequestReceived)
        {
            _ncsServer.Setup(new RootConfig(), config);
            NcsTemplateBuffer.SetTempBuffer();
            if (_ncsServer.Start() == true)
                serverStarted();
            _ncsServer.NewSessionConnected += new SessionHandler<NcsUser>(newSessionConnected);
            _ncsServer.SessionClosed += new SessionHandler<NcsUser, CloseReason>(sessionClosed);
            _ncsServer.NewRequestReceived += new RequestHandler<NcsUser, NcsRequestInfo>(newRequestReceived);
        }
    }
}
