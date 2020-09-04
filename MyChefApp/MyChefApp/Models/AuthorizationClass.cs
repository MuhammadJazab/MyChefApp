using System;
using System.Collections.Generic;
using System.Text;

namespace MyChefApp.Models
{
    public class RegistrationModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }

    public class SignIn
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
