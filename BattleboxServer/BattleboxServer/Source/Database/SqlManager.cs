using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleboxServer
{
    class SqlManager
    {
        MySqlConnection Connection;
        String MySqlConnection;

        public SqlManager(String StrConnection)
        {
            MySqlConnection = StrConnection;
            try
            {
                Connection = new MySqlConnection(StrConnection);
                Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ConnectionCheck();
            }
            Console.WriteLine(" - Database start");
        }

        public bool Insert(String Sql)
        {
            ConnectionCheck();
            try
            {
                MySqlCommand Cmd = new MySqlCommand(Sql, Connection);
                int Result = Cmd.ExecuteNonQuery();
                if (Result < 0)
                    return false;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Insert(MySqlCommand Sql)
        {
            ConnectionCheck();
            try
            {
                Sql.Connection = Connection;
                int Result = Sql.ExecuteNonQuery();
                if (Result < 0)
                    return false;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public DataTable Read(String Sql)
        {
            ConnectionCheck();
            DataTable Dt = new DataTable();
            MySqlCommand Command = new MySqlCommand(Sql, Connection);
            try
            {
                using (var Data = Command.ExecuteReader())
                {
                    if (Data.HasRows)
                    {
                        Dt.Load(Data);
                        return Dt;
                    }
                    else
                        return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private void ConnectionCheck()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection = new MySqlConnection(MySqlConnection);
                Connection.Open();
                Console.WriteLine(" - Reconnect database");
            }
        }
    }
}
