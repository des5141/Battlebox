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
        public ushort X = 0;
        public ushort Y = 0;
        public byte Z;
        public byte ImageIndex;
        public sbyte ImageXScale;
        public byte WeaponIndex;
        public short WeaponDir = 0;
        private readonly string _uuid = Guid.NewGuid().ToString();

        public NcsUserData()
        {
            ImageIndex = 0;
            Z = 0;
            ImageXScale = 0;
        }
    }
}
