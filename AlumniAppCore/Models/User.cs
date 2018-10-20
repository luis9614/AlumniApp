using System;
using AlumniAppCore.Models;
namespace AlumniAppCore.Models
{
    public abstract class User
    {
        public Boolean[] Permissions = new Boolean[5];
        public String Name
        {
            get;
            set;
        }

        public String LastName
        {
            get;
            set;
        }
        public String EMail
        {
            get;
            set;
        }
        public String Address
        {
            get;
            set;
        }
        public String Password
        {
            get;
            set;
        }
        public String SecondLastName
        {
            get;
            set;
        }
        public String UserName
        {
            get;
            set;
        }
        public int IdUser
        {
            get;
            set;
        }
        public int IdAccountType
        {
            get;
            set;
        }
        public abstract void SetPermissions();
    }
}
