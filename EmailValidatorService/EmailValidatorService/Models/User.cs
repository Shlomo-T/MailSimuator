using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailValidatorService.Models
{
    public class User
    {

        public string Email { get; set; }
        public string PersonalName { get; set; }

        public User(string Email, string privateName)
        {
            this.Email = Email;
            this.PersonalName = privateName;
        }
    }
}