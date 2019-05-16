namespace Server.Source.SignalEvent.Func
{
    class Match : Core.SignalEvent
    {
        public Match()
        {
            Msg[Signal.Match] = (user, requestinfo, buffer) =>
            {
                var playerInput = buffer.extract_byte();
                if (playerInput == 0)
                {
                    Data.MatchingList.Enqueue(user);
                }
                else if (playerInput == 1)
                {
                    Data.MatchingList.Remove(user);
                }
                Discord.SendLog(string.Join(",", Data.MatchingList.ToString()));
            };
        }
    }
}
