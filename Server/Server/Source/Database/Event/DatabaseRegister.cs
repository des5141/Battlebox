﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Server.Source.Core;

namespace Server.Source.Database.Event
{
    class DatabaseRegister
    {
        public static async Task<bool> Func(string playerId, string playerNickname)
        {
            using (await Lock.Database.LockAsync())
            {
                var dt = Main.Database.Read($"select * from user where id=\"{playerId}\"");
                if (dt != null) return false;
                var query = $"insert into user(" +
                            $"id, nickname, block, point, connect)" +
                            $"VALUES (@id, @nickname, false, 0, false)";

                MySqlCommand command = new MySqlCommand(query);
                command.Parameters.AddWithValue("@id", playerId);
                command.Parameters.AddWithValue("@nickname", playerNickname);
                return Main.Database.Insert(command);
            }
        }
    }
}
