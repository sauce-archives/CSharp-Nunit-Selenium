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
        internal static string tunnelId = Environment.GetEnvironmentVariable("TUNNEL_IDENTIFIER");
        internal static string seleniumRelayPort = Environment.GetEnvironmentVariable("SELENIUM_PORT");
        internal static string buildTag = Environment.GetEnvironmentVariable("BUILD_TAG");
        internal static string seleniumRelayHost = Environment.GetEnvironmentVariable("SELENIUM_HOST");

    }
}