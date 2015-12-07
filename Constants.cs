using System;

namespace Saucey_Selenium
{
    /// <summary>contains constants used by the tests such as the user name and password for the sauce labs</summary>
    internal static class Constants
    {
        /// <summary>name of the sauce labs account that will be used</summary>
        internal readonly static string SAUCE_LABS_ACCOUNT_NAME = System.Environment.GetEnvironmentVariable("SAUCE_USERNAME");
        /// <summary>account key for the sauce labs account that will be used</summary>
        internal readonly static string SAUCE_LABS_ACCOUNT_KEY = System.Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");


    }
}
