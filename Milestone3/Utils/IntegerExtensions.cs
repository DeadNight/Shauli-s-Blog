using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Milestone3.Utils
{
    public static class IntegerExtensions
    {
        public static string ToOrdinalString(this int num)
        {
            string numString = string.Intern(num.ToString());
            string suffix = "th";
            if (numString.EndsWith("1") && !numString.EndsWith("11"))
                suffix = "st";
            else if (numString.EndsWith("2") && !numString.EndsWith("12"))
                suffix = "nd";
            else if (numString.EndsWith("3") && !numString.EndsWith("13"))
                suffix = "rd";
            return numString + suffix;
        }
    }
}