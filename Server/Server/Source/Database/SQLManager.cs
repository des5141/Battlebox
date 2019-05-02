using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Server.Source.Database
{
    public class SqlManager
    {
        MySqlConnection _connection;
        readonly string _mySqlConnection;

        public SqlManager(string strConnection)
        {
            _mySqlConnection = strConnection;
            try
            {
                _connection = new MySqlConnection(strConnection);
                _connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ConnectionCheck();
            }
            Console.WriteLine(" - Database start");
        }

        public bool Insert(string sql)
        {
            ConnectionCheck();
            try
            {
                var cmd = new MySqlCommand(sql, _connection);
                var result = cmd.ExecuteNonQuery();
                return result >= 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Insert(MySqlCommand sql)
        {
            ConnectionCheck();
            try
            {
                sql.Connection = _connection;
                var result = sql.ExecuteNonQuery();
                return result >= 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public DataTable Read(string sql)
        {
            ConnectionCheck();
            var Dt = new DataTable();
            var command = new MySqlCommand(sql, _connection);
            try
            {
                using (var data = command.ExecuteReader())
                {
                    if (data.HasRows)
                    {
                        Dt.Load(data);
                        return Dt;
                    }
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
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    _connection = new MySqlConnection(_mySqlConnection);
                    _connection.Open();
                    Console.WriteLine(" - Reconnect database");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}

