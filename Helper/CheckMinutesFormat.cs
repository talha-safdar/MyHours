using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyHours.Helper
{
    public static class CheckMinutesFormat
    {
        public static bool checkMinutesFormat(String minutes)
        {
            minutes = minutes.Trim();
            Regex regOne = new Regex(@"^\d+$");
            Match matchFormat = regOne.Match(minutes);
            if (minutes.Length == 2 && matchFormat.Success)
            {
                int minutesCheck = Int32.Parse(minutes);
                if (minutesCheck <= 59 && minutesCheck >= 0)
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
