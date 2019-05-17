using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;
using Server.Source.User;

namespace Server.Source.Room
{
    public class NcsRoom
    {
        // Variable's Init
        public readonly AsyncLock TaskLockInRoom = new AsyncLock();    // Common Processing
        public List<NcsUser> UserList = new List<NcsUser>();
        public int ReadyTime = 60;
        public int Time = 0;
        public bool GameStart = false;
        public bool End = false;

        public void Start()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await TaskLockInRoom.LockAsync())
                {
                    // 유저들에게 맵 이동하라고 전송

                }
            }).Start();
        }
    }
}
