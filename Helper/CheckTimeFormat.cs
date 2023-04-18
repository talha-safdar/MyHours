using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyHours.Helper
{
    public static class CheckTimeFormat
    {
        /*
         * Allow only 24 hours format (e.g. 14:12)
         */
        public static bool checkTimeFormat(String timeInput)
        {
            timeInput = timeInput.Trim();
            if(!String.IsNullOrEmpty(timeInput))
            {
                Regex regOne = new Regex(@"^\d{2}\:\d{2}$");
                Match matchFormat = regOne.Match(timeInput);
                if(matchFormat.Success)
                {
                    string hoursStr = timeInput[0].ToString() + timeInput[1].ToString();
                    decimal hours = decimal.Parse(hoursStr);
                    string minutesStr = timeInput[3].ToString() + timeInput[4].ToString();
                    decimal minutes = decimal.Parse(minutesStr); 

                    if(hours <= 23 && hours >= 0 && minutes <= 59 && minutes >= 0)
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
            else
            {
                return false;
            }
        }
    }
}
