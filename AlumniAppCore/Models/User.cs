using System;
using AlumniAppCore.Models;
namespace AlumniAppCore.Models
{
    public abstract class User
    {
        public Boolean[] Permissions = new Boolean[5];
        public string Name
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }
        public string EMail
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string SecondLastName
        {
            get;
            set;
        }
        public string FullName
        {
            get;
            set;
        }
        public string UserName
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
        public override string ToString()
        {
            return Name + " " + LastName + " " + SecondLastName + "\ne-mail: " + EMail + " (" + UserName + ")\nId: " + IdUser + "\nAccountType: "+ IdAccountType + "\n";
        }
    }
}
