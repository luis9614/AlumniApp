using System;
using Alumni.App.Db;
using Alumni.App.Db.DTO;
using AlumniAppCore.Models;
namespace AlumniAppCore.Controllers
{
    public class DBConnection
    {
        private static DBConnection _userDB;
        private UserService _service;

        /// <summary>
        /// Initializes a new instance of the DBConnection class.
        /// </summary>
        private DBConnection()
        {
            this._service = new UserService();
        }

        /// <summary>
        /// Gets the single instance for the DB interface.
        /// </summary>
        /// <value>The get instance.</value>
        public static DBConnection GetInstance
        {
            get
            {
                if (_userDB == null)
                {
                    _userDB = new DBConnection();
                }
                return _userDB;
            }
        }

        public LogInReponseDto LogIn(String UserName, string UserPassword){
            return this._service.LogIn(UserName, UserPassword);
        }
    }

    public class UserInstance
    {
        private static UserInstance _user;

        private UserInstance(User NewUser){

        }
    }
}
