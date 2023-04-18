using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHours.Converter
{
    class Converter : ICalculation
    {
        ICalculation iCalculation;
        public Converter(ICalculation iCalculation)
        {
            this.iCalculation = iCalculation;
        }

        public string calculate(string decimalHours, string from, string to)
        {
            throw new NotImplementedException();
        }
    }
}
