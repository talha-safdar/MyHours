using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyHours.Converter.Calculation
{
    class CalculateToPay : ICalculation
    {
        public string calculate(string decimalHours, string payHours, string payText)
        {
            decimal hours = decimal.Parse(payHours);
            decimal pay = decimal.Parse(payText);
            decimal money = pay * hours;
            String output = Convert.ToString(money);
            output = output.Substring(0, output.Length);

            Regex regOne = new Regex(@"^\d+\.\d{1}$");
            Match matchOne = regOne.Match(output);

            Regex regTwo = new Regex(@"^\d+\.\d+");
            Match matchTwo = regTwo.Match(output);

            Regex regThree = new Regex(@"^\d+\.\d\d$");
            Match matchThree = regThree.Match(output);

            if (matchOne.Success)
            {
                output = output + "0";
            }
            if (matchTwo.Success)
            {
                while (!matchThree.Success)
                {
                    output = output.Substring(0, output.Length - 1);
                    matchThree = regThree.Match(output);
                }
            }
            return output;
        }
    }
}
