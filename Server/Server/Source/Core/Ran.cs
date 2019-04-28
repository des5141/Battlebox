using System;

namespace Server.Source.Core
{
    public class Ran
    {
        public static Random Temp = new Random();
        public static int Next(int min, int max)
        {
            return Temp.Next(min, max);
        }
    }
}
