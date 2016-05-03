using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB;

namespace EmailValidatorService.Controllers.API
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        // GET: api/Users
        public List<User> Get(bool testable)
        {
            var users = MLManager.InitializeHelper.MongoUsers;
            if (users != null && users.Any())
            {
                if (testable)
                {
                    return MLManager.InitializeHelper.MongoTestableUsers;
                }
                return users;
            }
            return null;

        }

        // GET: api/Users/5
        public User Get(string id)
        {
            var users = MLManager.InitializeHelper.MongoUsers;
            if (users != null && users.Any())
            {
                return users.Where(x=> x.Email==id).FirstOrDefault();
            }
            return null;
        }
    
    }
}
