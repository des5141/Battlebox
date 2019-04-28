using System;
using CGD;
using Networking_with_Supersocket;
using SuperSocket.SocketBase;

namespace BattleboxServer
{
    public partial class NcsUser : AppSession<NcsUser, NcsRequestInfo>
    {
        public bool UserReady = false;
        public bool Die = false;
        public bool Authentication = false;
        public int Space = 0;
        public string Id = "";
        public string DeviceId = "";
        public string Nickname = "";
        public UserData Data = null;
        public NcsRoom PlayRoom = null;

        protected override void HandleException(Exception e)
        {
            Console.WriteLine("Application error: {0}", e.Message);
        }

        public void Send(buffer Buffer)
        {
            this.Send(Buffer.buf, 0, Buffer.len);
        }

        public void Send(buffer Buffer, int Signal)
        {
            Buffer.set_front<UInt32>(Buffer.Count);
            Buffer.set_front<UInt16>(Signal, 4);
            this.Send(Buffer.buf, 0, Buffer.len);
        }
    }
}