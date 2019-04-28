using SuperSocket.SocketBase.Protocol;

namespace Server.Source.Core
{
    public class NcsRequestInfo : RequestInfo<NcsRequestInfo>
    {
        public new byte[] Body { get; }
        public CGD.buffer Buffer { get; }
        public NcsRequestInfo(byte[] body, byte[] buffer)
        {
            this.Body = body;
            Buffer = new CGD.buffer(buffer, 0, buffer.Length);
        }
    }
}
