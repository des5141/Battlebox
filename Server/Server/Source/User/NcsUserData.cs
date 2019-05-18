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
        public ushort X = Convert.ToUInt16((Ran.Next(64, 320)));
        public ushort Y = Convert.ToUInt16((Ran.Next(64, 200)));
        public byte Z;
        public byte ImageIndex;
        public sbyte ImageXScale;
        private readonly string _uuid = Guid.NewGuid().ToString();

        public NcsUserData()
        {
            ImageIndex = 0;
            Z = 0;
            ImageXScale = 0;
        }
    }
}
