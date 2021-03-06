﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Source.Core;
using Server.Source.User;

namespace Server.Source.Database.Event
{
    class DatabaseCheckCanLogin
    {
        public static async Task<bool> Func(string playerId)
        {
            using (await Lock.Database.LockAsync())
            {
                var dt = Main.Database.Read($"select * from user where id=\"{playerId}\" and block=0 and connect=0");
                return dt != null;
            }
        }
    }
}
