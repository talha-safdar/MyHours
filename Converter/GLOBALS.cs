using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * class used for storing global variables
 */
namespace MyHours.Converter
{
    public static class GLOBALS
    {
        public static string fromEntHours = "HH";
        public static string fromEntMinutes = "mm";

        public static string toEntHours = "HH";
        public static string toEntMinutes = "mm";

        public static string fromEntGlobal = "";
        public static string toEntGlobal = "";

        public static bool errorDisplay = false;
        public static string digitFormat = "";

        public static string payEntPound = "";
        public static string payEntPence = "";
        public static string payEntGlobal = "";
    }
}
