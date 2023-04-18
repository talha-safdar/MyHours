using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyHours.Models
{
    public static class NormaliseTime
    {
        public static string normaliseTime(String time)
        {
            Regex regOne = new Regex(@"^\d{1}\:\d{2}$");
            Match matchFormat = regOne.Match(time);
            if (matchFormat.Success)
            {
                return "0" + time;
            }
            else
            {
                return time;
            }
        }
    }
}
