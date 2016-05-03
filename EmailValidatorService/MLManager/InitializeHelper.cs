
//using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using Message = MongoDB.Message;


namespace MLManager
{
    public static class InitializeHelper
    {
        /*public static List<Entities.User> usersPool = null;
        public static List<Entities.User> LoadUsers()
        {
            var db = new DBDriver.DBConnect();
            var dt = db.Select("employeelist");
            List<Entities.User> UserList = new List<Entities.User>();
            for (int i=0; i < dt.Rows.Count;i++)
            {
                string fName = dt.Rows[i].ItemArray[1].ToString();
                string lName = dt.Rows[i].ItemArray[2].ToString();
                string mail = dt.Rows[i].ItemArray[3].ToString();
                int eid = Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString());
                Entities.User user = new Entities.User(fName, lName, eid, mail);
                UserList.Add(user);
            }
            return UserList;

        }

        public static void LoadMessagePerUser(Entities.User user)
        {
            var db = new DBDriver.DBConnect();
            string sender = "'" + user.email + "'";
            var dt = db.Select("message where sender=" + sender);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string body = dt.Rows[i].ItemArray[5].ToString();
                string subject = dt.Rows[i].ItemArray[4].ToString();
                string date = dt.Rows[i].ItemArray[2].ToString();

                List<string> bodyAfterSplit = TextAnalysisHelper.SplitByDot(body);

                List<List<string>> wordsPerSent = TextAnalysisHelper.WordsPerSentence(bodyAfterSplit);

                double sentAVG = TextAnalysisHelper.GetSentenceAVG(wordsPerSent);

                Dictionary<string, int> wordsDict = TextAnalysisHelper.CountWords(wordsPerSent);

                double wordAVG = TextAnalysisHelper.GetWordAVG(wordsDict);
                double token = TextAnalysisHelper.GetTokenRatio(wordsDict);
                double subjectWordCount = subject.Split(' ').Length;
                int mistakeCount = 0;

                Entities.Message msg = new Entities.Message(sentAVG, wordAVG, token, DateTime.Parse(date), subjectWordCount, bodyAfterSplit.Count,mistakeCount,body);
                user.sentMail.Add(msg);

            }

        }

        public static void LoadAllServerData()
        {
            usersPool = InitializeHelper.LoadUsers();
            foreach (Entities.User user in usersPool)
            {
                try
                {
                    InitializeHelper.LoadMessagePerUser(user);
                }
                catch (Exception e)
                { }
            }
        }*/


        public static List<MongoDB.User> MongoUsers=null;
        public static List<MongoDB.User> MongoTestableUsers=null;
        public static List<MongoDB.Message> MongoMessages = null;


        public static void InitialDataFromMongoDB()
        {
            BuildMessages();
            if (MongoMessages != null && MongoMessages.Any())
            {
                BuildUsers();
            }
        }
        public static void BuildMessages()
        {
            var docs = new MongoHelper().QueryAll();
            MongoMessages = docs;
        }
        public static void BuildUsers()
        {
            var users = MongoMessages.Select(x => x.headers.To).Where(user => !string.IsNullOrEmpty(user) && user.ToLower().Contains("enron") && !user.Contains(',')).Distinct().ToList();
            if(users!=null && users.Any())
            {
                MongoUsers = new List<MongoDB.User>();
            }

             MongoTestableUsers = new List<MongoDB.User>();
            
            foreach (var u in users)
            {
                var msgs = MongoMessages.Where(x => x.headers.From == u);
                string privateName = null;
                if (msgs.Any())
                {
                    foreach (var m in msgs)
                    {
                        if (m.headers != null && !string.IsNullOrEmpty(m.headers.SenderName))
                        {
                            privateName = m.headers.SenderName;
                            break;
                        }
                    }
                }
                var user= new MongoDB.User(u,privateName);
                if (msgs.Count() >= 10)
                {
                    MongoTestableUsers.Add(user);
                }
                MongoUsers.Add(user);
            }
        }
    }
}
