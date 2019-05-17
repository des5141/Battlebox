using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Source.User
{
    public class NcsUserData
    {
        public uint PlayIndex = 0;
        public ushort X = 0;
        public ushort Y = 0;
        public byte Column = 0;
        public byte Row = 0;
        public string Animation = "";
        private readonly string _uuid = Guid.NewGuid().ToString();

        public NcsUserData()
        {
            Console.WriteLine($" - Create user play data ({_uuid})");
        }

        ~NcsUserData()
        {
            Console.WriteLine($" - Destroy user play data ({_uuid})");
        }
    }
}
