using SuperSocket.SocketBase;

namespace BattleboxServer
{
    partial class NcsUser
    {
        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
        }
    }
}
