using MyHours.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHours.Helper
{
    public static class CheckTimeLogic
    {
        public static bool checkTimeLogic(String from, String to)
        {
            from = from.Trim();
            to = to.Trim();
            string[] splitFrom = from.Split(':');
            string[] splitTo = to.Split(':');
            int fromH = Int32.Parse(splitFrom[0]);
            int fromM= Int32.Parse(splitFrom[1]);
            int toH = Int32.Parse(splitTo[0]);
            int toM = Int32.Parse(splitTo[1]);
            if(fromH == toH && toM == fromM)
            {
                GLOBALS.fromEntMinutes = fromM.ToString(); // hard coded bad one !!
                GLOBALS.toEntMinutes = toM.ToString();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
