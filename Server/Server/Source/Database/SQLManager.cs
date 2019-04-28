using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Server.Source.Database
{
    class SQLManager
    {
        static string connectionString = "mongodb://61.84.196.75:20002";
        MongoClient cli = new MongoClient(connectionString);
        public SQLManager()
        {
            Test();
        }

        public void Test()
        {
            var db = cli.GetDatabase("test");
            var Collec = db.GetCollection<BsonDocument>("computers");
            var documnt = new BsonDocument
            {
                {"Brand","Dell"},
                {"Price","400"},
                {"Ram","8GB"},
                {"HardDisk","1TB"},
                {"Screen","16inch"}
            };
            Collec.InsertOneAsync(documnt);
        }
    }
}
