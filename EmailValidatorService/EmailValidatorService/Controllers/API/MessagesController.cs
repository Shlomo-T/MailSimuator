using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB;

namespace EmailValidatorService.Controllers.API
{
    [RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        // GET: api/Messages
        public List<Message> Get()
        {
            var msgs = MLManager.InitializeHelper.MongoMessages;
            if (msgs != null && msgs.Any())
            {
                return msgs;
            }
            return null;
        }

        // GET: api/Messages/5
        public Message Get(string id)
        {
            var msgs = MLManager.InitializeHelper.MongoMessages;
            if (msgs != null && msgs.Any())
            {
                var res= msgs.Where(x=> x._id.ToString()==id);
                if(res!=null && res.Any()) { return res.First(); }
            }
            return null;
        }
        [Route("incoming")]
        [HttpGet]
        public List<Message> Incoming(string id)
        {
            var msgs = MLManager.InitializeHelper.MongoMessages;
            if (msgs != null && msgs.Any())
            {
                var toSend= msgs.Where(x => x.headers!=null&& !string.IsNullOrEmpty(x.headers.To) && x.headers.To.Contains(id));
                if (toSend != null && toSend.Any())
                {
                    return toSend.ToList();
                }
            }
            return null;
        }

        [Route("outgoing")]
        [HttpGet]
        public List<Message> Outgoing(string id)
        {
            var msgs = MLManager.InitializeHelper.MongoMessages;
            if (msgs != null && msgs.Any())
            {
                var toSend = msgs.Where(x => x.headers != null && !string.IsNullOrEmpty(x.headers.From) && x.headers.From.Contains(id));
                if (toSend != null && toSend.Any())
                {
                    return toSend.ToList();
                }
            }
            return null;
        }

    }
}
