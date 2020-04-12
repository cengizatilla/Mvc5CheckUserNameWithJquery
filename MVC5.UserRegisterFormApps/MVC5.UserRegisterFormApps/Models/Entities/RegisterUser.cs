using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.UserRegisterFormApps.Models.Entities
{
    public class RegisterUser
    {
        public Guid ID { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string password { get; set; }
        public DateTime createdDate { get; set; }
        public bool isActive { get; set; }
        public string activationCode { get; set; }
    }
}