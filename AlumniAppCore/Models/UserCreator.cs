using System;
using Newtonsoft.Json;
using Alumni.App.Db;
using Alumni.App.Db.DTO;
using AlumniAppCore.Controllers;

namespace AlumniAppCore.Models
{
    public class UserCreator
    {
        private readonly DBConnection _db;
        public UserCreator()
        {
            this._db = DBConnection.GetInstance;
        }

        public User LogInUser(UserLogIn UserLogInInfo){
            LogInReponseDto response = _db.LogIn(UserLogInInfo.UserName, UserLogInInfo.UserPassword);
            if (response.HasError)
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


        private User CreateUser(int AccountType, string Name, string LastName, string SecondLastName, string FullName, string Address, string EMail, string Password, string UserName, int IdUser)
        {
            switch (AccountType)
            {
                case 1:
                    return new Student(Name,  LastName,  SecondLastName,  FullName,  Address,  EMail,  Password,  UserName, IdUser);
                case 2:
                    return new Teacher(Name,  LastName,  SecondLastName,  FullName,  Address,  EMail,  Password,  UserName, IdUser);
                case 3:
                    return new Supervisor(Name,  LastName,  SecondLastName,  FullName,  Address,  EMail,  Password,  UserName, IdUser);
            }
            return null;
        }


    }
}
