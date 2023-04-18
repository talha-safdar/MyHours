using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyHours.Helper
{
    public static class CheckHoursFormat
    {
        public static bool checkHoursFormat(String hours)
        {
            hours = hours.Trim();
            Regex regOne = new Regex(@"^\d+$");
            Match matchFormat = regOne.Match(hours);
            if(matchFormat.Success)
            {
                int hoursCheck = Int32.Parse(hours);
                if (hoursCheck <= 23 && hoursCheck >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
