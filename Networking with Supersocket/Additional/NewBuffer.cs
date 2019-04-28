using CGD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking_with_Supersocket
{
    public class NewBuffer
    {
        public static buffer Func(int Size)
        {
            buffer Buffer = new buffer(Size);
            Buffer.append<UInt32>(0); // size
            Buffer.append<UInt16>(0);  // type
            return Buffer;
        }
    }
}
