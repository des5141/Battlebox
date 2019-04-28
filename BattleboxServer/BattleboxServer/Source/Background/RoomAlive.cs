using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class RoomAlive
    {
        public static void Func()
        {
            new Task(async () =>
            {
                using (await Program.TaskLockInRoomList.LockAsync())
                {
                    int i = 0;
                    while (true)
                    {
                        if (i >= Program.RoomList.Count)
                            break;
                        else
                        {
                            if (Program.RoomList.ElementAt(i).UserList.Count <= 0)
                                Program.RoomList.Remove(Program.RoomList.Skip(i).First());
                            else
                                i++;
                        }
                    }
                }
                await Task.Delay(1000);
                Func();
            }).Start();
        }
    }
}
