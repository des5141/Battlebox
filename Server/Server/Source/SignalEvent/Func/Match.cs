using Server.Source.Room.Lock;

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
                    MatchOperator.Add(user);
                    user.PlayCharacter = buffer.extract_byte();
                }
                else if (playerInput == 1)
                {
                    MatchOperator.Remove(user);
                }
            };
        }
    }
}
