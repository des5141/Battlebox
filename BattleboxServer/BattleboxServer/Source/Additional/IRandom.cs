using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    public class IRandom
    {
        public static Random random = new Random();
        public static int Next(int Min, int Max)
        {
            return random.Next(Min, Max);
        }
    }
}
