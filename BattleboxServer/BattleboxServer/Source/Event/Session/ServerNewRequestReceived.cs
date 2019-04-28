using Networking_with_Supersocket;
using System;
using System.Text;
// CGD.buffer TempBuffer = NewBuffer.Func(100);
namespace BattleboxServer
{
    class ServerNewRequestReceived
    {
        public static void Func(NcsUser User, NcsRequestInfo RequestInfo)
        {
            try
            {
                // Header ----------------------------------------------------------------- //
                var Buffer = RequestInfo.Buffer; // 받은 버퍼
                UInt32 BufferLength = Buffer.extract_uint(); // 받은 버퍼의 길이

                // ------------------------------------------------------------------------ //
                // 여기서부터 패킷 처리
                byte SendTo = Buffer.extract_byte(); // 누구에게 전송하여야 할 패킷인가 - u8
                short SpaceType = Buffer.extract_short(); // 누구에게 전송하여야 할 패킷인가 -s16
                short Type = Buffer.extract_short(); // 패킷 타입 ( 시그널 ) - s16

                if (SendTo == Signal.SendToClient)
                {
                    // Send to client
                    // 같은 스페이스에 있는 모든 인원에게 전송
                    if (User.Authentication == false)
                    {
                        // 허가되지 않은 유저
                    }else
                    {
                        // 허가된 유저
                        if(User.Space > 0) // 0 is Unauthentication user section
                            SendSpace.Func(Buffer, User.Space).Wait();
                    }
                }
                else if (SendTo == Signal.SendToServer)
                {
                    // Send to Server
                    // 들어온 메세지를 처리
                    switch (Type)
                    {
                        case Signal.Heartbeat:
                            User.Send(NcsTemplateBuffer.HeartbeatBuffer2);
                            User.heartbeat = true;
                            break;

                        case Signal.Login:
                            SignalLogin.Func(User, Buffer);
                            break;

                        case Signal.Register:
                            SignalRegister.Func(User, Buffer);
                            break;

                        case Signal.UserInfo:
                            SignalUserInfo.Func(User, Buffer);
                            break;

                        case Signal.MenuUserCount:
                            var SendBuffer = NewBuffer.Func(16);
                            SendBuffer.append<UInt32>(Convert.ToUInt32(Program.TotalUserCount));
                            User.Send(SendBuffer, Signal.MenuUserCount);
                            break;

                        case Signal.RoomJoin:
                            RoomJoin.Func(User);
                            break;

                        case Signal.RoomOut:
                            RoomOut.Func(User);
                            break;

                        case Signal.RoomReady:
                            User.UserReady = true;
                            break;

                        case Signal.UserCoordinate:
                            if (User.Data != null)
                            {
                                User.Data.X = Buffer.extract_ushort();
                                User.Data.Y = Buffer.extract_ushort();
                            }
                            break;

                        case Signal.UserPosition:
                            if (User.Data != null)
                            {
                                User.Data.Row = Buffer.extract_byte();
                                User.Data.Row = Buffer.extract_byte();
                            }
                            break;

                        case Signal.UserSave:

                            break;


                        case Signal.GameDrop:
                            SignalGameDrop.Func(User, Buffer);
                            break;

                        case Signal.GameUse:
                            SignalGameUse.Func(User, Buffer);
                            break;

                        default:
                            Console.WriteLine("unvaild : " + Type);
                            break;
                    }
                }
                // 여기까지
                // ------------------------------------------------------------------------ //
            }catch(Exception e)
            {
                // 심각한 오류 발생
                Console.WriteLine(e);
            }
        }
    }
}
