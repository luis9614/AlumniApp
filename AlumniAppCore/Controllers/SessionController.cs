using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlumniAppCore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlumniAppCore.Controllers
{
    public class SessionController : Controller
    {
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
                message = user.ToString();
            }
            else
            {
                message = "Failed to log in the product. Please try again";
            }
            return Content(message);
        }
    }
}
