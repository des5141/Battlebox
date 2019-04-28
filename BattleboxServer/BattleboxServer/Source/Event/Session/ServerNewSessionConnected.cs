namespace BattleboxServer
{
    class ServerNewSessionConnected
    {
        public static void Func(NcsUser User)
        {
            User.HeartBeatStart();
            UserAdd.Func(User, 0).Wait();
        }
    }
}
