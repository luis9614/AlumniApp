using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlumniAppCore.Models;
using Alumni.App.Db;
using Alumni.App.Db.DTO;
using AlumniAppCore.Controllers;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlumniAppCore.Controllers
{
    public class SessionController : Controller
    {
        private readonly IOptions<AlumniConfig> _configuration;
        public SessionController(IOptions<AlumniConfig> configuration){
            this._configuration = configuration;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogIn(){
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(UserLogIn user){
            UserCreator UserFactory = new UserCreator();
            string message = "";

            if (ModelState.IsValid)
            {
                DBConnection UserDB = DBConnection.GetInstance;
                User CurrentUser = UserFactory.LogInUser(user);
                if(CurrentUser != null)
                {
                    TempData["User"] = CurrentUser.UserName;
                    TempData["Password"] = CurrentUser.Password;
                    return RedirectToAction("Overview", "Home");
                    //return Content(CurrentUser.ToString());
                }else{
                    message = "Failed to log in. Your information does not match any record in our database.\nIf your information was correct contact your admin.\n\nPlease try again";
                }
            }
            else
            {
                message = "Failed to log in. Unformatted information .\n\nPlease try again";
            }
            return RedirectToAction("Messages", "Home", new { Message = message });

        }

        /*[HttpGet]
        public IActionResult GetUser(string Name, string LastName, string SecondLastName, string FullName, string Address, string EMail, string Password, string UserName, int IdUser, int AccountType){
            UserCreator UserFactory = new UserCreator();
            User newUser = UserFactory.CreateUser(AccountType, Name, LastName, SecondLastName, FullName,Address, EMail, Password, UserName, IdUser);
            //CreateUser(int AccountType, string Name, string LastName, string SecondLastName, string FullName, string Address, string EMail, string Password, string UserName, int IdUser)
            TempData["CurrentUser"] = JsonConvert.SerializeObject(newUser) ;
            TempData["LOL"] = newUser.ToString();
            //return Content(newUser.ToString());
            return RedirectToAction("Overview", "Home");
        }*/
    }
}
