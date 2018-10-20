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
            string message = "";

            if (ModelState.IsValid)
            {
                DBConnection UserDB = DBConnection.GetInstance;
                LogInReponseDto response = UserDB.LogIn(user.UserName, user.UserPassword);
                if(response.HasError){
                    String serializedUser = JsonConvert.SerializeObject(response.LoggedUser);
                    return View();
                }else{
                    message = "Failed to log in. If your inPlease try again";
                }
                message = user.ToString() + "\n" + response.HasError.ToString() + "\n" + response.LoggedUser.Address + "\n" + response.LoggedUser.IdUserType + "\nTXT Export = " + _configuration.Value.ExportTXT;
            }
            else
            {
                message = "Failed to log in. If your inPlease try again";
            }
            return Content(message);
        }
    }
}
