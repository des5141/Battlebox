using System;
using System.Collections.Generic;
using Discord;
using Server.Source.Core;
using Server.Source.Room;
using Server.Source.User;

namespace Server.Source
{
    public class Chat
    {
        public static void SendLog(string message)
        {
            var embed = new EmbedBuilder()
                .WithTitle("Server log")
                .WithDescription(message ?? "~~null string~~")
                .WithTimestamp(DateTimeOffset.Now)
                .Build();
            Program.Channel.SendMessageAsync("", embed : embed);
        }
    }
    public class SendTo
    {
        public const short
            Server = -1,
            MySpace = -2;
    }
    public class Signal
    {
        public const short
            HeartbeatFirst = -3,
            HeartbeatSecond = -4,

            Login = 1,
            Match = 2,
            UserCount = 3,
            UserReady = 4,
            GameStart = 5

            ;
    }
    public class Data
    {
        public static List<List<NcsUser>> UserList = new List<List<NcsUser>>();
        public static LinkedQueue<NcsUser> MatchingList = new LinkedQueue<NcsUser>();
        public static LinkedList<NcsRoom> RoomList = new LinkedList<NcsRoom>();
        public static int MatchingMin = 1;
        public static int MatchingWait = 1000;
    }
    public class Lock
    {
        public static AsyncLock UserList = new AsyncLock();
        public static AsyncLock MatchingList = new AsyncLock();
        public static AsyncLock RoomList = new AsyncLock();
        public static AsyncLock Database = new AsyncLock();
    }
}
