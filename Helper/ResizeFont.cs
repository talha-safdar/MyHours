using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHours.Helper
{
    public static class ResizeFont
    {
        public static int resizeFont(String total)
        {
            int fontSize = 50;
            int size = total.Length;
            if (size > 9 && size <= 10)
            {
                fontSize = 40;
            }
            if (size > 11 && size <= 15)
            {
                fontSize = 32;
            }
            else if (size > 15 && size <= 16)
            {
                fontSize = 29;
            }
            else if (size > 16 && size <= 17)
            {
                fontSize = 27;
            }
            else if (size > 17 && size <= 19)
            {
                fontSize = 23;
            }
            else if (size > 19)
            {
                fontSize = 19;
            }

            return fontSize;
        }
    }
}
