namespace Server.Source
{
    public class SendTo
    {
        public const short
            Server = 1,
            MySpace = 2;
    }
    public class Signal
    {
        public const short
            HeartbeatFirst = -3,
            HeartbeatSecond = -4,

            Login = 1;
    }
}
