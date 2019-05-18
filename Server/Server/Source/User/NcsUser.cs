using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGD;
using Server.Source.Core;
using Server.Source.Room;
using SuperSocket.SocketBase;

namespace Server.Source.User
{
    public class NcsUser : AppSession<NcsUser, NcsRequestInfo>
    {
        public int Space = -1;
        public int HeartbeatCount = 0;
        public byte PlayCharacter = 0;
        public bool Heartbeat = false;
        public bool Die = false;
        public bool Authentication = false;
        public bool PlayReady = false;
        public string Nickname = "";
        public string Id = "";
        public NcsUserData Data = null;
        public NcsRoom PlayRoom = null;

        public void HeartBeatStart()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                if (HeartbeatCount >= 3)
                    Heartbeat = false;
                else
                    HeartbeatCount++;

                Send(NcsUserHeartbeat.HeartbeatBuffer1);

                await System.Threading.Tasks.Task.Delay(1000);

                if ((Heartbeat == false) && (HeartbeatCount >= 3) || (Die == true))
                    this.Close();
                else
                    HeartBeatStart();

                if (HeartbeatCount >= 3)
                    HeartbeatCount = 0;
            }).Start();
        }

        protected override void HandleException(Exception e)
        {
            Console.WriteLine("Application error: {0}", e.Message);
        }

        public void Send(buffer buffer)
        {
            try
            {
                this.Send(buffer.buf, 0, buffer.len);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Send(buffer buffer, int signal)
        {
            try
            {
                buffer.set_front<uint>(buffer.Count);
                buffer.set_front<short>(signal, 4);
                this.Send(buffer.buf, 0, buffer.Count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
