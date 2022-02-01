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
            if (!HttpContext.Request.Cookies.ContainsKey("HighScore"))
            {
                HttpContext.Response.Cookies.Append("HighScore", "");
            }
            int Guesses = 0;
            int randomNum = GameModel.GetRandomNumber();
            HttpContext.Session.SetInt32("RandomNum", randomNum);
            HttpContext.Session.SetInt32("Guesses", Guesses);
            ViewBag.HighScore = HttpContext.Request.Cookies["HighScore"];
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
                int? highScore = HttpContext.Session.GetInt32("Guesses").GetValueOrDefault();
                string prevHighScore = Regex.Match(HttpContext.Request.Cookies["HighScore"], @"\d+").Value;
                int prevScore = Int32.Parse(prevHighScore);

                if (prevScore == 0 || prevScore > highScore)
                {
                    HttpContext.Response.Cookies.Append("HighScore", $"{highScore} \nDate: {DateTime.Now}");
                    ViewBag.HighScore = HttpContext.Request.Cookies["HighScore"];
                }
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
                ViewBag.HighScore = HttpContext.Request.Cookies["HighScore"];
            }

            

            return View();
        }
    }
}
