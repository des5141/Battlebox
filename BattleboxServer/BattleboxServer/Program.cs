using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using Networking_with_Supersocket;
using CGD;
using System;
using System.Text;
using System.Collections.Generic;

namespace BattleboxServer
{
    partial class Program
    {
        public static SqlManager SqlManager;

        public static AsyncLock TaskLockInUserList = new AsyncLock();
        public static AsyncLock TaskLockInMatchingList = new AsyncLock();
        public static AsyncLock TaskLockInRoomList = new AsyncLock();
        public static AsyncLock TaskLockInDatabase = new AsyncLock();

        public static List<List<NcsUser>> UserList = new List<List<NcsUser>>();
        public static LinkedQueue<NcsUser> MatchingList = new LinkedQueue<NcsUser>();
        public static LinkedList<NcsRoom> RoomList = new LinkedList<NcsRoom>();

        public static int SpaceMax = 10;
        public static int TotalUserCount = 0;
        public static int MatchingMin = 1;

        static void Main()
        {
            ServerConfig MConfig = new ServerConfig()
            {
                Port = 65535,
                Ip = "Any",
                MaxConnectionNumber = 5000,
                Mode = SocketMode.Tcp,
                Name = "GameServer"
            };

            // 실행되면 ServerStarted.Func 실행
            Main ncsServer = new Main(MConfig, ServerStarted.Func, ServerNewSessionConnected.Func, ServerSessionClosed.Func, ServerNewRequestReceived.Func);

            // Task 실행
            UserCounting.Func();
            RoomAlive.Func();
            UserMatching.Func();

            // 계속 기다리기
            KeyWaiting.Func();
        }
    }
}