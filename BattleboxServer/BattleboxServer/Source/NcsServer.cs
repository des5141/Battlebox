using Networking_with_Supersocket;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;

namespace BattleboxServer
{
    public class NcsServer : AppServer<NcsUser, NcsRequestInfo>
    {
        public NcsServer() : base(new DefaultReceiveFilterFactory<NcsReceiveFilter, NcsRequestInfo>()) { }

        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }
    }
}
