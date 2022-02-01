using LexiconMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;

namespace LexiconMVC.Controllers
{
    public class GameController : Controller
    {
        public IActionResult GuessingGame()
        {          
            int Guesses = 0;
            int randomNum = GameModel.GetRandomNumber();
            HttpContext.Session.SetInt32("RandomNum", randomNum);
            HttpContext.Session.SetInt32("Guesses", Guesses);
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int guess)
        {
            int? random = HttpContext.Session.GetInt32("RandomNum");
            if (random == null) { HttpContext.Session.SetInt32("RandomNum", GameModel.GetRandomNumber()); }
            var result = GameModel.CompareGuesses(guess, random);

            if (result)
            {
                ViewBag.Message = $"You guessed correct!\n The number was {random}";
                HttpContext.Session.Clear();

            }
            else
            {
                int? counter = HttpContext.Session.GetInt32("Guesses");
                counter++;
                int updatedValue = counter.GetValueOrDefault();
                HttpContext.Session.SetInt32("Guesses", updatedValue);
                ViewBag.Guesses = updatedValue;
                ViewBag.Message = $"Incorrect";
            }

            

            return View();
        }
    }
}
