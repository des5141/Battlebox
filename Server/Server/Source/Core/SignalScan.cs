using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Source.Core
{
    class SignalScan
    {
        public static void Start()
        {
            Console.WriteLine("# Signal Event Load");
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            foreach (var type in asm.GetTypes())
                if (type.BaseType != null)
                    if (type.BaseType.Name == "SignalEvent")
                        Activator.CreateInstance(type);
        }
    }
}
