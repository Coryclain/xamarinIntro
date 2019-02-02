using System;
namespace MyLogin.Models
{
    public class LoginResult
    {
        public LoginSuccess loginSuccess { get; set; }
        public bool success { get; set; }
        public string status { get; set; }
    }
}
