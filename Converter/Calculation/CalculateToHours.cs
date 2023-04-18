using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyHours.Converter.Calculation
{
    class CalculateToHours : ICalculation
    {
        public string calculate(string decimalHours, string from, string to)
        {
            string smallMinute = "";
            string fine = "";
            string firstComplete = "";
            string passOrFail = "";
            if (decimalHours.Length == 5)
            {
                string fromm = from; // from :00
                string ffirst0 = from[0].ToString();
                string ffirst1 = from[1].ToString(); 
                string ffirst01 = ffirst0 + ffirst1; // quick get 00:
                

                string fsecond1 = from[3].ToString();
                string fsecond2 = from[4].ToString();
                string fsecond = fsecond1 + fsecond2;

                int ffirstInt = Int32.Parse(ffirst01); // from 00:
                int fsecondInt = Int32.Parse(fsecond); // from :00


                string too = to; // to :00
                string tfirst0 = to[0].ToString();
                string tfirst1 = to[1].ToString();
                string tfirst01 = tfirst0 + tfirst1; // quick get 00:

                string tsecond1 = to[3].ToString();
                string tsecond2 = to[4].ToString();
                string tsecond = tsecond1 + tsecond2;

                int tfirstInt = Int32.Parse(tfirst01); // from 00:
                int tsecondInt = Int32.Parse(tsecond); // to :00


                string fir1 = decimalHours[0].ToString();
                string fir2 = decimalHours[1].ToString();
                //firstComplete = fir1 + fir2; suspended temporarily
                if (ffirstInt == tfirstInt && fsecondInt > tsecondInt)
                    firstComplete = "24";
                else
                    firstComplete = fir1 + fir2;
                int firr = Int32.Parse(fir1 + fir2);

                string sec1 = decimalHours[3].ToString();
                int sec11 = Int32.Parse(sec1);
                string sec2 = decimalHours[4].ToString();
                int sec22 = Int32.Parse(sec2);
                string union = sec1 + sec2;
                int junior = Int32.Parse(union);
                int num = Int32.Parse(union);
                if (sec11 > 1 && sec22 == 0) // skipped
                {
                    //                int secondReal = (junior * 60)/100;
                    //                String abc = Integer.toString(secondReal);
                    //                fine = abc;
                    int secondReal = (junior * 60) / 100;
                    string rob = secondReal.ToString();
                    if (rob.Length < 5)
                    {
                        Regex regOne = new Regex(@"\d.\d");
                        Match matchOne = regOne.Match(rob);

                        Regex regTwo = new Regex(@"\\.\d");
                        Match matchTwo = regTwo.Match(rob);

                        Regex regThree = new Regex(@"\d\\.");
                        Match matchThree = regThree.Match(rob);

                        Regex regFour = new Regex(@"\d.(\d+)");
                        Match matchFour = regFour.Match(rob);

                        Regex regFive = new Regex(@"(\d+).\d");
                        Match matchFive = regFive.Match(rob);

                        if (matchOne.Success)
                        {
                            rob = "0" + rob;
                            rob = rob + "0";
                        }
                        if (matchTwo.Success)
                        {
                            rob = rob + "0";
                        }
                        if (matchThree.Success)
                        {
                            rob = "0" + rob;
                        }
                        if (matchFour.Success)
                        {
                            rob = rob.Substring(0, 4);
                            rob = "0" + rob;
                        }
                        if (matchFive.Success)
                        {
                            rob = rob + "0";
                        }
                    }
                    fine = rob;
                }
                else // got it
                {
                    int finee = 0;
                    int fromPart = 0;
                    int toPart = 0;
                    String tak = "00000";                    
                    if (String.Equals(ffirst01, tfirst01))
                    {
                        if (fsecondInt > tsecondInt)
                        {
                            fromPart = Int32.Parse(fsecond);
                            toPart = Int32.Parse(tsecond);
                            smallMinute = (fromPart - toPart).ToString();
                        }
                        else if (fsecondInt < tsecondInt)
                        {
                            fromPart = Int32.Parse(fsecond);
                            toPart = Int32.Parse(tsecond);
                            smallMinute = (toPart - fromPart).ToString();
                        }
                        else
                        {
                            fromPart = Int32.Parse(fsecond);
                            toPart = Int32.Parse(tsecond);
                            smallMinute = (fromPart - toPart).ToString();
                        }
                        if(smallMinute.Length == 1) // skipped
                        {
                            smallMinute = "0" + smallMinute;
                        }
                    }
                    else if (tsecondInt > fsecondInt) // for minutes :00 // s
                    {
                        decimal boss = (decimal) tsecondInt - fsecondInt;
                        if (boss < 10) // skipped
                        {
                            smallMinute = "0" + boss.ToString();
                        }
                        else // got it
                        {
                            smallMinute = (tsecondInt - fsecondInt).ToString();
                        }                        
                    }
                    else if (tsecondInt < fsecondInt)
                    {
                        decimal boss = (decimal) fsecondInt - tsecondInt;
                        if (boss < 10) // skipped
                        {
                            smallMinute = "0" + boss.ToString();
                        }
                        else // got it
                        {
                            smallMinute = (fsecondInt - tsecondInt).ToString();
                        }
                    }
                    else // g
                    {
                        decimal secondRealElse = (decimal)(junior * 60) / 100;
                        secondRealElse = Convert.ToDecimal(String.Format("{0:0.0}", secondRealElse));

                        tak = secondRealElse.ToString();
                    }

                    if (tak.Length < 5) // g
                    {
                        Regex regOne = new Regex("^\\d\\.\\d$");
                        Match matchOne = regOne.Match(tak);

                        Regex regTwo = new Regex("^\\.\\d$");
                        Match matchTwo = regTwo.Match(tak);

                        Regex regThree = new Regex("^\\d\\.$");
                        Match matchThree = regThree.Match(tak);

                        Regex regFour = new Regex("^\\d\\.(\\d+)$");
                        Match matchFour = regFour.Match(tak);

                        Regex regFive = new Regex("^(\\d+)\\.\\d$");
                        Match matchFive = regFive.Match(tak);

                        if (matchOne.Success)
                        {
                            tak = "0" + tak;
                            tak = tak + "0";
                        }
                        else if (matchTwo.Success)
                        {
                            tak = tak + "0";
                        }
                        else if (matchThree.Success)
                        {
                            tak = "0" + tak;
                        }
                        else if (matchFour.Success)
                        {
                            tak = tak.Substring(0, 4);
                            tak = "0" + tak;
                        }
                        else if (matchFive.Success) // g
                        {
                            tak = tak + "0";
                        }
                    }
                    String doc = tak[3].ToString();
                    int checkNum = Int32.Parse(doc);
                    if (checkNum > 5) // skipped
                    {
                        String unz = tak[0].ToString();
                        String unz2 = tak[1].ToString();
                        finee = Int32.Parse(unz + unz2);
                        finee = finee + 1;
                    }
                    else // got it
                    {
                        if (fsecondInt == 00) // s
                        {
                            finee = Int32.Parse(tsecond);
                        }
                        else // g
                        {
                            //if(tak[0] != 0 && tak[1] != 0)
                                finee = int.Parse(tak[0].ToString() + tak[1].ToString());

                        }
                    }
                    String abc = finee.ToString();
                    if (String.Equals(abc, "0")) // s
                    {
                        if (String.Equals(ffirst01, tfirst01)) // s
                        {
                            abc = smallMinute;
                        }
                        else if (tsecondInt > fsecondInt) // g
                        {
                            abc = smallMinute;
                        }
                        else if (tsecondInt < fsecondInt)
                        {
                            abc = smallMinute;
                        }
                        else
                        {
                            abc = abc + "0";
                        }
                    }
                    else if (abc.Length != 2) // s
                    {
                        Regex regOne = new Regex(@"[0]+[1-9]");
                        Match matchOne = regOne.Match(tsecond);

                        if (fsecondInt == 00 && matchOne.Success)
                        {
                            abc = "0" + abc;
                        }
                        else if (fsecond[0] == tsecond[0])
                        {
                            abc = tsecond[0].ToString() + tsecond[1].ToString();
                        }
                        else if (String.Equals(ffirst01, tfirst01))
                        {
                            abc = "0" + abc;
                        }
                        else
                        {
                            abc = abc + "0";
                        }
                    }
                    fine = abc;
                }
                passOrFail = firstComplete + ":" + fine;
            }
            else
            {
                //Result.errorDisplay = true;
                passOrFail = "err_0"; // an error occurred 0x01
            }
            return passOrFail;
        }
    }
}
