using System;

namespace BattleboxServer
{
    public class UserData
    {
        public uint PlayIndex = 0;
        public ushort X = 0;
        public ushort Y = 0;
        public byte Column = 0;
        public byte Row = 0;
        public string Animation = "";
        private readonly string Uuid = Guid.NewGuid().ToString();

        public UserData()
        {
            Console.WriteLine($" - Create user play data ({Uuid})");
        }

        ~UserData()
        {
            Console.WriteLine($" - Destroy user play data ({Uuid})");
        }
    }
}
