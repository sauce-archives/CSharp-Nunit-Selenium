using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Remote;

namespace ParallelSelenium.Utils
{
    class SauceUtils
    {

        /**
         * Populates the <code>updates</code> map with the value of the system property/environment variable
         * with the following name:
         * <ol>
         *     <li>SAUCE_BAMBOO_BUILDNUMBER</li>
         *     <li>JENKINS_BUILD_NUMBER</li>
         *     <li>BUILD_TAG</li>
         *     <li>BUILD_NUMBER</li>
         *     <li>TRAVIS_BUILD_NUMBER</li>
         *     <li>CIRCLE_BUILD_NUM</li>
         * </ol>
         * @param updates String,Object pair containing job updates
         */
        public static void addBuildNumberToDesiredCapabilities(DesiredCapabilities caps)
        {
            //try Bamboo
            String buildNumber = Environment.GetEnvironmentVariable("SAUCE_BAMBOO_BUILDNUMBER");
            if (buildNumber == null || buildNumber == "")
            {
                //try Jenkins
                buildNumber = Environment.GetEnvironmentVariable("JENKINS_BUILD_NUMBER");
            }

            if (buildNumber == null || buildNumber == "")
            {
                //try BUILD_TAG
                buildNumber = Environment.GetEnvironmentVariable("BUILD_TAG");
            }

            if (buildNumber == null || buildNumber == "")
            {
                //try BUILD_NUMBER
                buildNumber = Environment.GetEnvironmentVariable("BUILD_NUMBER");
            }
            if (buildNumber == null || buildNumber == "")
            {
                //try TRAVIS_BUILD_NUMBER
                buildNumber = Environment.GetEnvironmentVariable("TRAVIS_BUILD_NUMBER");
            }
            if (buildNumber == null || buildNumber == "")
            {
                //try CIRCLE_BUILD_NUM
                buildNumber = Environment.GetEnvironmentVariable("CIRCLE_BUILD_NUM");
            }

            if (buildNumber != null && buildNumber != "")
            {
                caps.SetCapability("build", buildNumber);
            }

        }
    }
}