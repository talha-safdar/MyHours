using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHours.Converter
{
    interface ICalculation
    {
        String calculate(String decimalHours, String from, String to);
    }
}
