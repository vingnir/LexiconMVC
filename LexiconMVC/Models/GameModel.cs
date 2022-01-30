using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Models
{
    public class GameModel
    {
        public static bool CompareGuesses(int guess, int? random) 
        {        
            return guess == random;
        }

        public static int GetRandomNumber()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 100);
            return randomNumber;
        }

       
    }
}
