using System;

namespace Server.Additional.Discord.Routing
{
    class FunctionScan
    {
        public static void StartScan()
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in asm.GetTypes())
                {
                    if (type.BaseType != null)
                    {
                        if (type.BaseType.Name == "Function")
                        {
                            dynamic instance = Activator.CreateInstance(type);
                        }
                    }
                }
            }
        }
    }
}
