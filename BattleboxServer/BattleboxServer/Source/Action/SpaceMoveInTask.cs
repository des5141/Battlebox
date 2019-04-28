using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class SpaceMoveInTask
    {
        public static void Func(NcsUser User, int Space)
        {
            for (int i = 0; i < Program.SpaceMax; i++)
            {
                Program.UserList[i].Remove(User);
            }
            Program.UserList[Space].Add(User);
            User.Space = Space;
        }
    }
}
