using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlumniAppCore.Models;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlumniAppCore.Controllers
{
    public class SettingsController : Controller
    {
        private Settings _conf;
        private IConfiguration _configuration;

        public SettingsController(IConfiguration configuration){
            _configuration = configuration;
            _conf = Settings.GetInstance;
        }

        [HttpGet]
        public IActionResult SettingsManager()
        {
            _conf._conf.ExportTXT = _configuration["ExportOptions:ExportTXT"] == "true";
            _conf._conf.ExportWord = _configuration["ExportOptions:ExportWord"] == "true";
            return View(_conf._conf);
        }

        [HttpGet]
        public IActionResult SettingsMan(Boolean ExportTXT)
        {
            if(ExportTXT){
                _configuration["ExportOptions:ExportTXT"] = "true";
                _configuration["ExportOptions:ExportWord"] = "false";
            }
            else{
                _configuration["ExportOptions:ExportTXT"] = "false";
                _configuration["ExportOptions:ExportWord"] = "true";
            }
            return RedirectToAction("Overview", "Home");
        }
    }
}
