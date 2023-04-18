using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyHours.Helper
{
    public static class CheckPayFormat
    {
        public static bool checkPayFormat(String input)
        {
            input = input.Trim();
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Contains("."))
                {
                    string[] splitInput = input.Split('.');
                    String pound = splitInput[0];
                    String pence = splitInput[1];
                    if (pound.Length <= 17 && pence.Length == 2)
                    {
                        Regex regOne = new Regex(@"^\d+\.\d+$");
                        Match matchFormat = regOne.Match(input);

                        Regex regTwo = new Regex(@"^\d+$");
                        Match matchFormatTwo = regTwo.Match(input);

                        if (matchFormat.Success || matchFormatTwo.Success)
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
//                }
//                else if(input.Length <= 20)
//                {
//                    Regex regOne = new Regex(@"^\d+\.\d+$");
//                    Match matchFormat = regOne.Match(input);
//
//                    Regex regTwo = new Regex(@"^\d+$");
//                    Match matchFormatTwo = regTwo.Match(input);

//                    if (matchFormat.Success || matchFormatTwo.Success)
//                    {
//                        return true;
//                    }
//                    else
//                    {
//                        return false;
//                    }
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
