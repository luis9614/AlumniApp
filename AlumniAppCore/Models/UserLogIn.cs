using System;
namespace AlumniAppCore.Models
{
    public class UserLogIn
    {
        public String UserName
        {
            get;
            set;
        }public String UserPassword
        {
            get;
            set;
        }
        public UserLogIn()
        {
        }
        public UserLogIn(String UserName, String UserPassword)
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
