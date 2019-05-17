using CGD;
using Server.Source.SignalEvent;

namespace Server.Source.Core
{
    public static class NcsUserHeartbeat
    {
        public static buffer HeartbeatBuffer1 = new buffer(16);
        public static buffer HeartbeatBuffer2 = new buffer(16);

        public static void SetTempBuffer()
        {
            NcsUserHeartbeat.HeartbeatBuffer1.append<uint>(0);
            NcsUserHeartbeat.HeartbeatBuffer1.append<short>(Signal.HeartbeatFirst); // signal
            NcsUserHeartbeat.HeartbeatBuffer1.set_front<uint>(HeartbeatBuffer1.Count);

            NcsUserHeartbeat.HeartbeatBuffer2.append<uint>(0);
            NcsUserHeartbeat.HeartbeatBuffer2.append<short>(Signal.HeartbeatSecond); // signal
            NcsUserHeartbeat.HeartbeatBuffer2.set_front<uint>(HeartbeatBuffer2.Count);
        }
    }
}
