using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSelenium
{
    public static class Constants
    {
        internal static string sauceUser = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
        internal static string sauceKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");
    }
}