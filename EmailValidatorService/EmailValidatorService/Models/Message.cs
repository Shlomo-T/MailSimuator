using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailValidatorService.Models
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
}