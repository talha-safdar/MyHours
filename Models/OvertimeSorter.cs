using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHours.Models
{
    public static class OvertimeSorter
    {
        public static int overtimeSorter(String time)
        {
            Dictionary<string, string> hash = new Dictionary<string, string>();
            hash.Add("01", "25");
            hash.Add("02", "26");
            hash.Add("03", "27");
            hash.Add("04", "28");
            hash.Add("05", "29");
            hash.Add("06", "30");
            hash.Add("07", "31");
            hash.Add("08", "32");
            hash.Add("09", "33");
            hash.Add("10", "34");
            hash.Add("11", "35");
            hash.Add("12", "36");
            hash.Add("13", "37");
            hash.Add("14", "38");
            hash.Add("15", "39");
            hash.Add("16", "40");
            hash.Add("17", "41");
            hash.Add("18", "42");
            hash.Add("19", "43");
            hash.Add("20", "44");
            hash.Add("21", "45");
            hash.Add("22", "46");
            hash.Add("23", "47");

            if (hash.ContainsKey(time))
            {
                return int.Parse(hash[time]);
            }
            else
            {
                return int.Parse(time);
            }
        }
    }
}
