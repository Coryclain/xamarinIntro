using System;
using System.Collections.Generic;

namespace MyLogin.Models
{
    public class LoginSuccess
    {
        public string username { get; set; }
        public List<string> roles { get; set; }
        public string token_type { get; set; }
        public string access_token { get; set; }
        public string expires_in { get; set;  }
        public string refresh_token { get; set; }
    }

}
