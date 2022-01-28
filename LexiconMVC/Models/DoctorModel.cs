using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Models
{
    public class DoctorModel
    {

        public static string CheckIfFever(string temp) 
        {
            string result = $"Your temperature is {temp}\n ";
            double temperature = double.Parse(temp);
            result += temperature > 37 ? "You got a fever <br> Call a doctor" : "You do not have a fever\n Enjoy the day!";


            return result;
        }
    }
}
