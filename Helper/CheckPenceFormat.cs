using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyHours.Helper
{
    public static class CheckPenceFormat
    {
        public static bool checkPenceFormat(String pence)
        {
            pence = pence.Trim();
            if (!String.IsNullOrEmpty(pence))
            {
                Regex regTwo = new Regex(@"^\d+$");
                Match matchFormat = regTwo.Match(pence);
                if (matchFormat.Success)
                {
                    if (pence.Length == 2)
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
