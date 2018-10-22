using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlumniAppCore.Models;
using AlumniAppCore.Models.Utils;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace AlumniAppCore.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHttpContextAccessor _httpContextAccessor; // Cache Management
        private static User CurrentUser;

        public HomeController(IHttpContextAccessor httpContextAccessor){
            this._httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overview(string UserName, string Password)
        {

            UserCreator UserFactory = new UserCreator();
            //CurrentUser = UserFactory.LogInUser(new UserLogIn { UserName = TempData["User"].ToString(), UserPassword = TempData["Password"].ToString() });
            CurrentUser = UserFactory.LogInUser(new UserLogIn { UserName = HttpContext.Session.GetString(CookieKeys.USERNAME), UserPassword = HttpContext.Session.GetString(CookieKeys.PASSWORD) });
            //User newUser = UserFactory.CreateUser(AccountType, Name, LastName, SecondLastName, FullName, Address, EMail, Password, UserName, IdUser);
            //ViewData["UserInfo"] = CurrentUser;
            ViewData["Options"] = FeatureManager.GetFeatures(CurrentUser.Permissions);

            //ViewData["Options"] = newUser.Permissions;
            //ViewData["OptionNames"] = EnumUtils.GetOptions();
            return View(CurrentUser);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Messages(string Message){
            ViewBag.Message = Message;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
