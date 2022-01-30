using LexiconMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckFever()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult CheckFever(string temp, string tempScale)
        {
            
            ViewBag.Message = DoctorModel.CheckIfFever(temp, tempScale);
            
            return View();
        }

    }
}
