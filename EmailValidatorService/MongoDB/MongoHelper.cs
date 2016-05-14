using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB
{
    public class MongoHelper
    {

        private MongoServer mongoServer = null;
        private bool disposed = false;

        private const string dbName = "enron_mail";
        private const string collectionName = "messages";
        private string connectionString = "localhost";
        private IMongoCollection<Message> GetTasksCollection()
        {
            MongoClient client = new MongoClient( );  //connection string 
            var database = client.GetDatabase(dbName);
            var todoTaskCollection = database.GetCollection<Message>(collectionName);
            return todoTaskCollection;
        }
        public List<Message> QueryAll()
        {
            List<Message> ans=null;
            try
            {
                var collection = GetTasksCollection();
                int dCount = (int)collection.Find(new BsonDocument()).Count();
# if DEBUG
                dCount = (int) dCount/20;
#endif
                int paging = 100;
                ans=new List<Message>();
                int skipped = 0,actuallRet=0;
                while(skipped<dCount)
                {

                        List<Message> documents =
                            collection.Find(new BsonDocument()).Skip(skipped).Limit(paging).ToList();
                        if (documents != null)
                        {
                            ans.AddRange(documents);
                            actuallRet += documents.Count;
                        }
                        skipped += paging;
                    
                }
                //ans= collection.Find(new BsonDocument()).Limit(100).ToList();


            }
            catch (Exception e)
            {
             
            }
            return ans;
        } 
    }
}
