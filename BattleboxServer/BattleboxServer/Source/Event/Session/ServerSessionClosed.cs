using SuperSocket.SocketBase;
using Networking_with_Supersocket;

namespace BattleboxServer
{
    class ServerSessionClosed
    {
        public static void Func(NcsUser User, CloseReason Reason)
        {
            User.Die = true;
            UserDelete.Func(User).Wait();
        }
    }
}
