using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Utility.Extentions
{
    public static class StringExtention
    {
        public static string Pluralize(this string singular)
        {
            if (singular.EndsWith("s") || singular.EndsWith("x") || singular.EndsWith("z") || singular.EndsWith("ch") || singular.EndsWith("sh"))
            {
                return singular + "es";
            }
            else if (singular.EndsWith("y"))
            {
                return singular.Remove(singular.Length - 1) + "ies";
            }
            else
            {
                return singular + "s";
            }
        }
    }
}
