using Server.Source.Core;
using Server.Source.User;

namespace Server.Source.Task
{
    class MoveSpace
    {
        public static void Func(NcsUser user, int space)
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await Main.TaskLockInUserList.LockAsync())
                {
                    for (int i = 0; i < Main.SpaceMax; i++)
                        Main.UserList[i].Remove(user);
                    Main.UserList[space].Add(user);
                    user.Space = space;
                }
            }).Start();
        }
    }
}
