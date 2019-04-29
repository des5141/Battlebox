using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGD;
using Server.Source.User;

namespace Server.Source.Core
{
    public class SignalBase
    {
        public void Add(dynamic type, Action<NcsUser, NcsRequestInfo, buffer> action)
        {
            BufferDictionary.Add(type, action);
        }
        public Action<NcsUser, NcsRequestInfo, buffer> this[dynamic i]
        {
            set
            {
                Console.WriteLine($" - {i} Loaded");
                this.Add(i, value);
            }
        }
        public static Dictionary<dynamic, Action<NcsUser, NcsRequestInfo, buffer>> BufferDictionary = new Dictionary<dynamic, Action<NcsUser, NcsRequestInfo, buffer>>();
    }
}
