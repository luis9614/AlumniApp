using System;
using Alumni.App.Db.DTO;
using AlumniAppCore.Controllers;

namespace AlumniAppCore.Models
{
    public abstract class User
    {
        public readonly Boolean[] Permissions = new Boolean[4];
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
            return Name + " " + LastName + " " + SecondLastName + "\ne-mail: " + EMail + " (" + UserName + ")\nId: " + IdUser + "\nAccountType: " + IdAccountType + "\n";
        }
    }
    public class Student : User
    {
        public Student(string Name, string LastName, string SecondLastName, string FullName, string Address, string EMail, string Password, string UserName, int IdUser)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.SecondLastName = SecondLastName;
            this.FullName = FullName;
            this.Address = Address;
            this.EMail = EMail;
            this.Password = Password;
            this.UserName = UserName;
            this.IdUser = IdUser;
            this.IdAccountType = 1;
            SetPermissions();
        }

        public override void SetPermissions()
        {
            this.Permissions[(int)FeatureEnumeration.OWN_CALS] = true;
            this.Permissions[(int)FeatureEnumeration.OWN_PROFILE] = true;
            //this.Permissions[(int)FeatureEnumeration.BASIC_INFO] = true;
            this.Permissions[(int)FeatureEnumeration.ALL_CALS] = false;
            this.Permissions[(int)FeatureEnumeration.DOWNLOAD_CALS] = true;
        }

        public override string ToString()
        {
            return "Student\n" + base.ToString();
        }
    }

    public class Supervisor : User
    {
        public Supervisor(string Name, string LastName, string SecondLastName, string FullName, string Address, string EMail, string Password, string UserName, int IdUser)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.SecondLastName = SecondLastName;
            this.FullName = FullName;
            this.Address = Address;
            this.EMail = EMail;
            this.Password = Password;
            this.UserName = UserName;
            this.IdUser = IdUser;
            this.IdAccountType = 3;
            SetPermissions();
        }

        public override void SetPermissions()
        {
            this.Permissions[(int)FeatureEnumeration.OWN_CALS] = false;
            this.Permissions[(int)FeatureEnumeration.OWN_PROFILE] = true;
            //this.Permissions[(int)FeatureEnumeration.BASIC_INFO] = true;
            this.Permissions[(int)FeatureEnumeration.ALL_CALS] = false;
            this.Permissions[(int)FeatureEnumeration.DOWNLOAD_CALS] = false;
        }

        public override string ToString()
        {
            return "Supervisor\n" + base.ToString();
        }
    }

    public class Teacher : User
    {
        public Teacher(string Name, string LastName, string SecondLastName, string FullName, string Address, string EMail, string Password, string UserName, int IdUser)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.SecondLastName = SecondLastName;
            this.FullName = FullName;
            this.Address = Address;
            this.EMail = EMail;
            this.Password = Password;
            this.UserName = UserName;
            this.IdUser = IdUser;
            this.IdAccountType = 2;
            this.SetPermissions();
        }

        public override void SetPermissions()
        {
            this.Permissions[(int)FeatureEnumeration.OWN_CALS] = false;
            this.Permissions[(int)FeatureEnumeration.OWN_PROFILE] = true;
            //this.Permissions[(int)FeatureEnumeration.BASIC_INFO] = true;
            this.Permissions[(int)FeatureEnumeration.ALL_CALS] = true;
            this.Permissions[(int)FeatureEnumeration.DOWNLOAD_CALS] = false;
        }
        public override string ToString()
        {
            return "Teacher\n" + base.ToString();
        }
    }

    public class UserLogIn
    {
        public string UserName
        {
            get;
            set;
        }
        public string UserPassword
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

    public class UserCreator
    {
        private readonly UserDBService _db;
        public UserCreator()
        {
            this._db = UserDBService.GetInstance;

        }

        public User LogInUser(UserLogIn UserLogInInfo)
        {
            LogInReponseDto response = _db.LogIn(UserLogInInfo.UserName, UserLogInInfo.UserPassword);
            if (!response.HasError)
            {
                return this.CreateUser(
                    response.LoggedUser.IdUserType,
                    response.LoggedUser.Name,
                    response.LoggedUser.LastName,
                    response.LoggedUser.SecondLastName,
                    response.LoggedUser.FullName,
                    response.LoggedUser.Address,
                    response.LoggedUser.Email,
                    response.LoggedUser.Password,
                    response.LoggedUser.UserName,
                    response.LoggedUser.IdUser
                );
            }
            return null;
        }
        public User LogInUser(string UserName, string Password)
        {
            LogInReponseDto response = _db.LogIn(UserName, Password);
            if (!response.HasError)
            {
                return this.CreateUser(
                    response.LoggedUser.IdUserType,
                    response.LoggedUser.Name,
                    response.LoggedUser.LastName,
                    response.LoggedUser.SecondLastName,
                    response.LoggedUser.FullName,
                    response.LoggedUser.Address,
                    response.LoggedUser.Email,
                    response.LoggedUser.Password,
                    response.LoggedUser.UserName,
                    response.LoggedUser.IdUser
                );
            }
            return null;
        }

        /*public User GetUser(int UserID){
            return new Student();
        }*/


        private User CreateUser(int AccountType, string Name, string LastName, string SecondLastName, string FullName, string Address, string EMail, string Password, string UserName, int IdUser)
        {
            switch (AccountType)
            {
                case 1:
                    return new Student(Name, LastName, SecondLastName, FullName, Address, EMail, Password, UserName, IdUser);
                case 2:
                    return new Teacher(Name, LastName, SecondLastName, FullName, Address, EMail, Password, UserName, IdUser);
                case 3:
                    return new Supervisor(Name, LastName, SecondLastName, FullName, Address, EMail, Password, UserName, IdUser);
            }
            return null;
        }


    }
}
