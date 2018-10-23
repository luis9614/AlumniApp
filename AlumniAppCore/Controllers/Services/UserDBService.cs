using System;
using Alumni.App.Db;
using Alumni.App.Db.DTO;
using AlumniAppCore.Models;
namespace AlumniAppCore.Controllers
{
    public class UserDBService
    {
        private static UserDBService _userDB;
        public UserService _service;

        /// <summary>
        /// Initializes a new instance of the DBConnection class.
        /// </summary>
        private UserDBService()
        {
            this._service = new UserService();
        }

        /// <summary>
        /// Gets the single instance for the DB interface.
        /// </summary>
        /// <value>The get instance.</value>
        public static UserDBService GetInstance
        {
            get
            {
                if (_userDB == null)
                {
                    _userDB = new UserDBService();
                }
                return _userDB;
            }
        }

        public LogInReponseDto LogIn(String UserName, string UserPassword){

            return this._service.LogIn(UserName, UserPassword);
        }

    }

    /*public class UserInstance
    {
        private static UserInstance _user;

        private UserInstance(User NewUser){

        }
    }*/
}
