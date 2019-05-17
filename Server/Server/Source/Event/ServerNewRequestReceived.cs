using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;
using Server.Source.User;

namespace Server.Source.Event
{
    class ServerNewRequestReceived
    {
        public static void Func(NcsUser user, NcsRequestInfo requestinfo)
        {
            try
            {
                // Header ----------------------------------------------------------------- //
                var buffer = requestinfo.Buffer; // 받은 버퍼
                var bufferLength = buffer.extract_uint(); // 받은 버퍼의 길이 4 byte

                // 여기서부터 패킷 처리 -------------------------------------------------- //
                var sendTo = buffer.extract_short(); // 누구에게 전송하여야 할 패킷인가 - s16 6 byte

                // 서버에게 보낸 것
                if (sendTo == SendTo.Server)
                {
                    var type = buffer.extract_short(); // 패킷 타입 ( 시그널 ) - s16 8 byte
                    
                    // 존재하는 SignalEvent 인지 확인
                    if (SignalBase.BufferDictionary.ContainsKey(type))
                     SignalBase.BufferDictionary[type](user, requestinfo, buffer);
                    // 없는 경우
                    else
                        Console.WriteLine($"None Signal Event {type}");
                }

                // 다른 유저에게 보낸 것
                else if (sendTo == SendTo.MySpace)
                {
                    var type = buffer.extract_short(); // 패킷 타입 ( 시그널 ) - s16 8 byte
                }
                else
                {
                    if (sendTo == Signal.HeartbeatFirst)
                    {
                        user.Send(NcsUserHeartbeat.HeartbeatBuffer2);
                        user.Heartbeat = true;
                    }
                }
                // ------------------------------------------------------------------------ //
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}
