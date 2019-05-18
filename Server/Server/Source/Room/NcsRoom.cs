using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;
using Server.Source.Room.Lock;
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
        public bool Destroy = false;

        public NcsRoom()
        {
            Chat.SendLog("룸 생성");
        }
        ~NcsRoom()
        {
            Chat.SendLog("룸 삭제");
        }

        public void Start()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await TaskLockInRoom.LockAsync())
                {
                    // 유저들에게 맵 이동하라고 전송
                    foreach (var t in UserList)
                    {
                        t.PlayReady = false;
                        var buf = NewBuffer.Func(16);
                        buf.append<byte>(1);
                        buf.append<byte>(t.Data.PlayIndex);
                        t.Send(buf, Signal.Match);
                    }

                    GameStartCheck();
                }
            }).Start();
        }

        public void GameStartCheck()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                GameStart = true;
                using (await TaskLockInRoom.LockAsync())
                {
                    foreach (var t in UserList)
                    {
                        if (t.PlayReady == false)
                            GameStart = false;
                    }
                }

                if (GameStart == false)
                {
                    await System.Threading.Tasks.Task.Delay(1000);
                    GameStartCheck();
                }

                else
                {
                    // 게임 시작
                    using (await TaskLockInRoom.LockAsync())
                    {
                        // 플레이어 초기 데이터 생성
                        var buf = NewBuffer.Func(5120);
                        buf.append<byte>(UserList.Count); // 몇명인지 전달
                        foreach (var t in UserList)
                        {
                            buf.append<byte>(t.PlayCharacter);
                            buf.append<byte>(t.Data.PlayIndex);
                            buf.append<ushort>(t.Data.X);
                            buf.append<ushort>(t.Data.Y);
                            buf.append_gmlstring(t.Nickname);
                        }
                        buf.set_front<uint>(buf.Count);
                        buf.set_front<short>(Signal.GameStart, 4);

                        // 전달
                        foreach (var t in UserList)
                        {
                            t.Send(buf);
                        }
                    }
                    UserPosition();
                }
            }).Start();
        }

        public void UserPosition()
        {
            new System.Threading.Tasks.Task(async () =>
            {
                using (await TaskLockInRoom.LockAsync())
                {
                    // 플레이어 초기 데이터 생성
                    var buf = NewBuffer.Func(1024);
                    buf.append<byte>(UserList.Count); // 몇명인지 전달
                    foreach (var t in UserList)
                    {
                        buf.append<byte>(t.Data.PlayIndex);
                        buf.append<ushort>(t.Data.X);
                        buf.append<ushort>(t.Data.Y);
                        buf.append<byte>(t.Data.Z);
                        buf.append<byte>(t.Data.ImageIndex);
                        buf.append<sbyte>(t.Data.ImageXScale);
                    }
                    buf.set_front<uint>(buf.Count);
                    buf.set_front<short>(Signal.UserPosition, 4);

                    // 전달
                    foreach (var t in UserList)
                    {
                        t.Send(buf);
                    }
                }

                await System.Threading.Tasks.Task.Delay(10);
                if (Destroy != true)
                    UserPosition();
            }).Start();
        }
    }
}
