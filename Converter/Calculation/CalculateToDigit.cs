using MyHours.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyHours.Converter.Calculation
{
    class CalculateToDigit : ICalculation
    {
        public string calculate(string decimalHours, string from, string to)
        {
            decimal resultt = 0;
            decimal f = 0;
            decimal t = 0;
            int firsttt = 0;
            int secondCheck = 0;
            int secondCheckOne = 0;
            string tafter = "";
            string rsultt = "";

            // from
            String ffirst1 = from[0].ToString();
            String ffirst2 = from[1].ToString();
            String fsecond1 = from[3].ToString();
            String fsecond2 = from[4].ToString();
            String ffirst = ffirst1 + ffirst2; // from 00:
            String fsecond = fsecond1 + fsecond2; // from :00
            String fromm = ffirst + fsecond;

            if (ffirst.Equals("00"))
            {
                ffirst = "00";
            }

            // to
            String tfirst1 = to[0].ToString();
            String tfirst2 = to[1].ToString();
            String tsecond1 = to[3].ToString();
            String tsecond2 = to[4].ToString();
            String tfirst = tfirst1 + tfirst2; // to 00:
            String tsecond = tsecond1 + tsecond2; // to :00
            String tto = tfirst + tsecond;

            int fFirst = int.Parse(ffirst); // from 00:
            int tFirst = int.Parse(tfirst); // to 00:

            int fSecond = int.Parse(fsecond); // from 00:
            int tSecond = int.Parse(tsecond); // from 00:

            if (tfirst.Equals("00"))
            {
                tfirst = "24";
            }

            // calculate
            // from
            if (!fsecond.Equals("00") || !tsecond.Equals("00"))
            {
                if (!fsecond.Equals("00") && !tsecond.Equals("00"))
                {
                    int fnowSecond = Int32.Parse(fsecond);
                    int tnowSecond = Int32.Parse(tsecond);

                    decimal fromSecond = (decimal)fnowSecond / 60; // to be added as second for 'from'
                    decimal toSecond = (decimal)tnowSecond / 60; // to be added as second for 'from'

                    String fafter = fromSecond.ToString();
                    fafter = fafter.Substring(2);

                    tafter = toSecond.ToString();
                    tafter = tafter.Substring(2);


                    decimal first = Decimal.Parse(ffirst + "." + fafter);
                    decimal second = Decimal.Parse(tfirst + "." + tafter);
                    if (second > first)
                        resultt = second - first; // another bug :(
                    else
                        resultt = first - second;
                }
                else if (!fsecond.Equals("00") || !tsecond.Equals("00"))
                {
                    if (!fsecond.Equals("00"))
                    {
                        int fnowSecond = Int32.Parse(fsecond);
                        decimal fromSecond = (decimal)fnowSecond / 60; // to be added as second for 'from'
                        String fafter = fromSecond.ToString();
                        fafter = fafter.Substring(2);
                        f = Decimal.Parse(ffirst + "." + fafter);

                        int secondd = Int32.Parse(tfirst); // bug here when e.g. 15:15 to 05:00

                        if(fFirst < tFirst || fFirst == tFirst)
                            resultt = secondd - f;
                        else
                            resultt = f - secondd;
                    }
                    else if (!tsecond.Equals("00"))
                    {
                        int tnowSecond = Int32.Parse(tsecond);
                        decimal toSecond = (decimal)tnowSecond / 60; // to be added as second for 'from'

                        tafter = toSecond.ToString();
                        tafter = tafter.Substring(2);
                        t = Decimal.Parse(tfirst + "." + tafter);

                        firsttt = Int32.Parse(ffirst);
                        if(t > firsttt)
                            resultt = t - firsttt;
                        else
                            resultt = firsttt - t;
                    }
                }
            }
            else
            {
                firsttt = Int32.Parse(ffirst);
                int secondd = Int32.Parse(tfirst);
                secondCheck = OvertimeSorter.overtimeSorter(tfirst);
                if (fFirst < tFirst)
                    resultt = secondd - firsttt;
                else if (secondd != secondCheck)
                {
                    resultt = secondCheck - firsttt;
                }
                else if(firsttt > secondd) // bug here 00:00 to 00:00
                    resultt = firsttt - secondd;
                else
                {
                    resultt = secondd;
                }                  
                
                String ab = resultt.ToString();
                //resultt = Convert.ToDouble(String.Format("{0:0.0}", resultt), CultureInfo.InvariantCulture);
                resultt = Convert.ToDecimal(String.Format("{0:0.0}", resultt));
            }
            String fine = "";
            secondCheck = OvertimeSorter.overtimeSorter(tfirst);
            if (fFirst > tFirst)
            {
                int rslt = 0;
                if (firsttt != 0)
                {
                    rslt = secondCheck - firsttt;
                }                    
                else
                {
                    rslt = secondCheck - fFirst;
                }                    
                rsultt = rslt.ToString();
                string tt = tafter.ToString();
                if(tt.Length != 0)
                    rsultt = rsultt + "." + tt;
                else
                    rsultt = rsultt + "." + fsecond;
                fine = rsultt;
            }
            else
            {
                fine = resultt.ToString();
            }
            
            //Match one = Regex.Match(fine, "\\d\\.\\d");
            //Match two = Regex.Match(fine, "\\.\\d");
            //Match three = Regex.Match(fine, "\\d\\.");
            //Match four = Regex.Match(fine, "\\d\\.(\\d+)");
            //Match five = Regex.Match(fine, "(\\d+)\\.\\d");
            Regex regOne = new Regex("^\\d\\.\\d$");
            Match matchOne = regOne.Match(fine);

            Regex regTwo = new Regex("^\\.\\d$");
            Match matchTwo = regTwo.Match(fine);

            Regex regThree = new Regex("^\\d\\.$");
            Match matchThree = regThree.Match(fine);

            Regex regFour = new Regex("^\\d\\.(\\d+)$");
            Match matchFour = regFour.Match(fine);

            Regex regFive = new Regex("^(\\d+)\\.\\d$");
            Match matchFive = regFive.Match(fine);

            if (matchOne.Success)
            {
                fine = "0" + fine;
                fine = fine + "0";
            }

            else if (matchTwo.Success)
            {
                fine = fine + "0";
            }

            else if (matchThree.Success)
            {
                fine = "0" + fine;
            }
            else if (matchFour.Success)
            {
                fine = fine.Substring(0, 4);
                fine = "0" + fine;
            }
            else if (matchFive.Success)
            {
                fine = fine + "0";
            }
            else
            {
                fine = fine.Substring(0, 5);
            }
            if (fine.Length != 5)
            {
                fine = fine.Substring(0, 4);
            }
            return fine;
        }
    }
}
