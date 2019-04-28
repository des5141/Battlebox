using CGD;

namespace Server.Source.Core
{
    public class NewBuffer
    {
        public static buffer Func(int size)
        {
            var buffer = new buffer(size);
            buffer.append<uint>(0); // size
            buffer.append<ushort>(0);  // type
            return buffer;
        }
    }
}
