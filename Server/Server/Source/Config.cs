using System;
using System.Collections.Generic;
using Discord;
using Server.Source.Core;
using Server.Source.Room;
using Server.Source.User;

namespace Server.Source
{
    public class Discord
    {
        public static bool Trigger = false;

        public static void SendLog(string message)
        {
            if (!Trigger) return;
            var embed = new EmbedBuilder()
                .WithTitle("Server log")
                .WithDescription(message ?? "~~Null message~~")
                .WithTimestamp(DateTimeOffset.Now)
                .Build();
            Program.Discord.GetGuild(573111073616560128).GetTextChannel(573111191468245002)
                .SendMessageAsync("", embed: embed);
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
            Match = 2

            ;
    }
    public class Data
    {
        public static List<List<NcsUser>> UserList = new List<List<NcsUser>>();
        public static LinkedQueue<NcsUser> MatchingList = new LinkedQueue<NcsUser>();
        public static LinkedList<NcsRoom> RoomList = new LinkedList<NcsRoom>();
    }
    public class Lock
    {
        public static AsyncLock UserList = new AsyncLock();
        public static AsyncLock MatchingList = new AsyncLock();
        public static AsyncLock RoomList = new AsyncLock();
        public static AsyncLock Database = new AsyncLock();
    }
}
