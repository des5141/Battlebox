using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;

namespace Server.Source.User
{
    public class NcsUserData
    {
        public byte PlayIndex = 0;
        public ushort X = Convert.ToUInt16((Ran.Next(0, 480)));
        public ushort Y = Convert.ToUInt16((Ran.Next(0, 270)));
        private readonly string _uuid = Guid.NewGuid().ToString();
    }
}
