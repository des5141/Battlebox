using CGD;

namespace Server.Source.Core
{
    public static class NcsTemplateBuffer
    {
        public static buffer HeartbeatBuffer1 = new buffer(16);
        public static buffer HeartbeatBuffer2 = new buffer(16);

        public static void SetTempBuffer()
        {
            NcsTemplateBuffer.HeartbeatBuffer1.append<uint>(0);
            NcsTemplateBuffer.HeartbeatBuffer1.append<short>(1);
            NcsTemplateBuffer.HeartbeatBuffer1.set_front<uint>(HeartbeatBuffer1.Count);

            NcsTemplateBuffer.HeartbeatBuffer2.append<uint>(0);
            NcsTemplateBuffer.HeartbeatBuffer2.append<short>(2);
            NcsTemplateBuffer.HeartbeatBuffer2.set_front<uint>(HeartbeatBuffer2.Count);
        }
    }
}
