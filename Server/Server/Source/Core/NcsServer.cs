﻿using Server.Source.User;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace Server.Source.Core
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
