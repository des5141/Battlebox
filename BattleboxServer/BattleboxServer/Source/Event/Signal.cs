namespace BattleboxServer
{
    public class Signal
    {
        public const int
        SendToClient = 1,
        SendToServer = 2,

        MySpace = -1,
        AllSpace = -2,

        Heartbeat = 1,

        Login = 3,
        Register = 4,
        UserInfo = 5,
        UserSave = 6,
        MenuUserCount = 7,
        RoomJoin = 8,
        RoomOut = 9,
        RoomReady = 10,
        ReadyTimer = 11,
        GameTimer = 12,
        Map = 13,
        UserCoordinate = 14,
        UserPosition = 15,
        GameDrop = 16,
        GameUse = 17;
    }
}
