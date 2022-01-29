using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Models
{
    public class DoctorModel
    {
        
    public static string CheckIfFever(string temp, string tempScale) 
        {   
            double temperature = double.Parse(temp.Replace(".", ","));
            string result = $"Your temperature is {temp}{tempScale}: ";

            if(tempScale == "°F")
            {
                result += temperature > 99.6 ?
                 "You got a fever!"
               : temperature < 95 ? "You got hypothermia!"
               : "You are not sick, enjoy the day!";
            }
            else
            { 
            result += temperature > 38 ?
                "You got a fever!" 
                : temperature < 35? "You got hypothermia!" 
                : "You are not sick, enjoy the day!";
            }
            return result;
        }
    }
}
