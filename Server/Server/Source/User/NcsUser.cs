using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGD;
using Server.Source.Core;
using SuperSocket.SocketBase;

namespace Server.Source.User
{
    public class NcsUser : AppSession<NcsUser, NcsRequestInfo>
    {
        protected override void HandleException(Exception e)
        {
            Console.WriteLine("Application error: {0}", e.Message);
        }

        public void Send(buffer buffer)
        {
            this.Send(buffer.buf, 0, buffer.len);
        }

        public void Send(buffer buffer, int signal)
        {
            buffer.set_front<uint>(buffer.Count);
            buffer.set_front<ushort>(signal, 4);
            this.Send(buffer.buf, 0, buffer.len);
        }
    }
}
