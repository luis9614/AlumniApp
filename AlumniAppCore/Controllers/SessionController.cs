using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlumniAppCore.Models;
using AlumniAppCore.Models.Utils;
using Alumni.App.Db;
using Alumni.App.Db.DTO;
using AlumniAppCore.Controllers;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlumniAppCore.Controllers
{
    public class SessionController : Controller
    {
        private readonly IOptions<AlumniConfig> _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public SessionController(IOptions<AlumniConfig> configuration, IHttpContextAccessor httpContextAccessor){
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
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
                UserDBService UserDB = UserDBService.GetInstance;
                User CurrentUser = UserFactory.LogInUser(user);
                if(CurrentUser != null)
                {
                    // Debugging Purposes
                    //TempData["User"] = CurrentUser.UserName;
                    //TempData["Password"] = CurrentUser.Password;

                    //SetCookie("User", CurrentUser.UserName, 2);
                    //SetCookie("Password", CurrentUser.UserName, 2);

                    HttpContext.Session.SetString(CookieKeys.USERNAME, CurrentUser.UserName);
                    HttpContext.Session.SetString(CookieKeys.PASSWORD, CurrentUser.Password);

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

        // Cookie Related Stuff

        public string Get(string key)
        {
            return Request.Cookies[key];
        }

        private void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            Response.Cookies.Append(key, value, option);
        }

        private void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
