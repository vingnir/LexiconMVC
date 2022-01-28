﻿using LexiconMVC.Models;
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
        public IActionResult CheckFever(string temp)
        {
            
            ViewBag.Message = DoctorModel.CheckIfFever(temp);
            
            return View();
        }


        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Test", "test session");
            return View();
        }

        public IActionResult GetSession()
        {
            ViewBag.Message = HttpContext.Session.GetString("Test");
            return View();
        }
    }
}