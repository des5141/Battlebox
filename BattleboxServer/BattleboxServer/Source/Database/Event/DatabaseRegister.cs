using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    public class DatabaseRegister
    {
        public static async Task<SByte> Func(String UserId, String UserDeviceId)
        {
            string TempNickname = "Guest" + IRandom.Next(100000, 999999);
            using (await Program.TaskLockInDatabase.LockAsync())
            {
                DataTable dt = Program.SqlManager.Read($"select * from user where deviceid=\"{UserDeviceId}\" and (block=1 or connect=1)");
                if (dt == null)
                {
                    DataTable dt2 = Program.SqlManager.Read($"select * from user where id=\"{UserId}\"");
                    if (dt2 == null)
                    {
                        string Query = $"insert into user(" +
                            $"id, nickname, block, point, exp, deviceid, money, connect, diamond)" +
                            $"VALUES (@id, @nickname, 0, 0, 0, @deviceid, 0, 0, 0)";

                        MySqlCommand Command = new MySqlCommand(Query);
                        Command.Parameters.AddWithValue("@id", UserId);
                        Command.Parameters.AddWithValue("@nickname", TempNickname);
                        Command.Parameters.AddWithValue("@deviceid", UserDeviceId);
                        if (Program.SqlManager.Insert(Command) == true)
                            return Convert.ToSByte(1);
                    }
                }
                return Convert.ToSByte(0);
            }
        }
    }
}
