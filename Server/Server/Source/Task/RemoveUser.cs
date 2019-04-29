using Server.Source.Core;
using Server.Source.User;

namespace Server.Source.Task
{
    class RemoveUser
    {
        public static void Func(NcsUser user)
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await Main.TaskLockInUserList.LockAsync())
                {
                    for (int i = 0; i < Main.SpaceMax; i++)
                        Main.UserList[i].Remove(user);
                }
            }).Start();
        }
    }
}
