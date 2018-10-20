using System;
namespace AlumniAppCore.Models
{
    public class UserLogIn
    {
        public string UserName
        {
            get;
            set;
        }public string UserPassword
        {
            get;
            set;
        }
        public UserLogIn()
        {
        }
        public UserLogIn(string UserName, string UserPassword)
        {
            this.UserName = UserName;
            this.UserPassword = UserPassword;
        }

        public override string ToString()
        {
            return "UserName: " + this.UserName + "\nPass: " + this.UserPassword;
        }
    }
}
