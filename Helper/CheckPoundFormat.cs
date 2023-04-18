using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyHours.Helper
{
    public static class CheckPoundFormat
    {
        public static bool checkPoundFormat(String pound)
        {
            pound = pound.Trim();
            if (!String.IsNullOrEmpty(pound))
            {
                Regex regTwo = new Regex(@"^\d+$");
                Match matchFormat = regTwo.Match(pound);                
                
                Regex regThree = new Regex(@"^0+$");
                Match matchZeros = regThree.Match(pound);
                if (matchFormat.Success)
                {
                    if (!matchZeros.Success)
                    {
                        if (pound.Length <= 17)
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
            else
            {
                return false;
            }
        }
    }
}
