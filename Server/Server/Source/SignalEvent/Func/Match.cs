namespace Server.Source.SignalEvent.Func
{
    class Match : Core.SignalEvent
    {
        public Match()
        {
            Msg[Signal.Match] = (user, requestinfo, buffer) =>
            {

            };
        }
    }
}
