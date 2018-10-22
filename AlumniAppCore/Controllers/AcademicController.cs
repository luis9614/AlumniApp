﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Alumni.App.Db;
using Alumni.App.Db.DTO;
using AlumniAppCore.Models;
using AlumniAppCore.Models.Utils;
using Microsoft.AspNetCore.Http;
using AlumniAppCore.Models.Adapters;
using System.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlumniAppCore.Controllers
{
    public class AcademicController : Controller
    {
        private readonly AcademicService _db;
        private readonly UserDBService _dbUser;
        private readonly UserCreator UserFactory;

        public AcademicController(){
            _db = AcademicService.GetInstance;
            _dbUser = UserDBService.GetInstance;
            UserFactory = new UserCreator();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyCals(){
            User CurrentUser = UserFactory.LogInUser(HttpContext.Session.GetString(CookieKeys.USERNAME), HttpContext.Session.GetString(CookieKeys.PASSWORD));

            if(CurrentUser!=null && CurrentUser.Permissions[(int)FeatureEnumeration.OWN_CALS]){
                IGrades ServiceAdapter = new GradesAdapter();
                DataTable Grades = ServiceAdapter.GetGrades(CurrentUser.IdUser);
                return View(Grades);
            }
            return RedirectToAction("Messages", "Home", new { Message = UtilMessages.NO_CREDENTIALS });

        }

        public IActionResult MyProfile()
        {
            User CurrentUser = UserFactory.LogInUser(HttpContext.Session.GetString(CookieKeys.USERNAME), HttpContext.Session.GetString(CookieKeys.PASSWORD));

            if (CurrentUser != null && CurrentUser.Permissions[(int)FeatureEnumeration.OWN_PROFILE])
            {
                //UserDto Profile = _dbUser._service.GetProfile(CurrentUser.IdUser);
                IProfile ProfileAdapter = new ProfileAdapter();
                DataTable Profile = ProfileAdapter.GetProfile(CurrentUser.IdUser);


                return View(Profile);
            }
            return RedirectToAction("Messages", "Home", new { Message = UtilMessages.NO_CREDENTIALS });
        }
    }
}
