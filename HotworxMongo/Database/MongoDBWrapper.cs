using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotworxMongo.Database
{
    internal class MongoDBWraper
    {
        protected MongoClient m_Client { get; set; }
        public IMongoDatabase Database { get; set; }

        public MongoDBWraper(string db) 
        {
            var user = System.Configuration.ConfigurationManager.AppSettings["MongoUser"]; ;
            var password = System.Configuration.ConfigurationManager.AppSettings["MongoPassword"]; ;
            var connectionString = $"mongodb+srv://{user}:{password}@cluster0.ie1zp2i.mongodb.net/?retryWrites=true&w=majority";
            m_Client = new MongoClient(connectionString);

            Database = m_Client.GetDatabase(db);
        }
    }
}
