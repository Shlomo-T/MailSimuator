using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Runtime.Serialization;

namespace MongoDB
{
    [BsonIgnoreExtraElements]
    public class Message
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("body")]
        public string body { get; set; }

        [BsonElement("headers")]
        public Headers headers { get; set; }


    }

    [BsonIgnoreExtraElements]
    public class Headers
    {

        [BsonElement("From")]
        public string From { get; set; }

        [BsonElement("To")]
        public string To { get; set; }

        [BsonElement("X-From")]
        public string SenderName { get; set; }
        [BsonElement("X-To")]
        public string RecieverName { get; set; }

        [BsonElement("Date")]
        public string Date { get; set; }

        [BsonElement("Subject")]
        public string Subject { get; set; }
    }

    public class User
    {
        [DataMemberAttribute]
        public string Email { get; set; }
        [DataMemberAttribute]
        public string PersonalName { get; set; }

        public User(string Email, string privateName)
        {
            this.Email = Email;
            this.PersonalName = privateName;
        }
    }
}
