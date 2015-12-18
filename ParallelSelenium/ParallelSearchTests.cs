using System;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using ParallelSelenium.PageObjects.Bing;
using ParallelSelenium.Utils;

namespace ParallelSelenium
{
    [TestFixture("chrome", "46", "Windows 7", "", "")]
    [TestFixture("internet explorer", "11", "Windows 7", "", "")]
    [TestFixture("firefox", "41", "Windows 7", "", "")]
    [TestFixture("chrome", "30", "Windows 7", "", "")]
    [TestFixture("internet explorer", "9", "Windows 7", "", "")]
    [TestFixture("firefox", "30", "Windows 7", "", "")]
    [TestFixture("chrome", "38", "Windows 7", "", "")]
    [TestFixture("internet explorer", "10", "Windows 7", "", "")]
    [TestFixture("firefox", "35", "Windows 7", "", "")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ParallelSearchTests
    {
        private IWebDriver driver;
        private String browser;
        private String version;
        private String os;
        private String deviceName;
        private String deviceOrientation;

        public ParallelSearchTests(String browser, String version, String os, String deviceName, String deviceOrientation)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
            this.deviceName = deviceName;
            this.deviceOrientation = deviceOrientation;
        }

        [SetUp]
        public void Init()
        {
            /* Web proxy setup to be used with the underlying Rest requests.
            **/
            /*
            WebProxy iProxy = new WebProxy("192.168.1.159:808", true);
            iProxy.UseDefaultCredentials = true;
            iProxy.Credentials = new NetworkCredential("test", "hello123");
            WebRequest.DefaultWebProxy = iProxy;
            */
            String seleniumUri = "http://{0}:{1}/wd/hub";
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Version, version);
            capabilities.SetCapability(CapabilityType.Platform, os);
            capabilities.SetCapability("deviceName", deviceName);
            capabilities.SetCapability("deviceOrientation", deviceOrientation);
            //Sauce Connect setup.
            //Requires a named tunnel.
            if (Constants.tunnelId != null)
            {
                capabilities.SetCapability("tunnel-identifier", Constants.tunnelId);
            }
            if(Constants.buildTag != null)
            {
                capabilities.SetCapability("build", Constants.buildTag);
            }
            if(Constants.seleniumRelayPort != null && Constants.seleniumRelayHost != null)
            {
                seleniumUri = String.Format(seleniumUri, Constants.seleniumRelayHost, Constants.seleniumRelayPort);
            } else {
                seleniumUri = "http://ondemand.saucelabs.com:80/wd/hub";
            }
            capabilities.SetCapability("username", Constants.sauceUser);
            capabilities.SetCapability("accessKey", Constants.sauceKey);
            capabilities.SetCapability("name", 
            String.Format("{0}:{1}: [{2}]",
            TestContext.CurrentContext.Test.ClassName,
            TestContext.CurrentContext.Test.MethodName,
            TestContext.CurrentContext.Test.Properties.Get("Description")));
            driver = new CustomRemoteWebDriver(new Uri(seleniumUri), capabilities, TimeSpan.FromSeconds(600));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [Test, Property("Description", "Searching for \"hello!\" on Bing.")]
        public void BingSearchHello()
        {
            //this code is repeated below intentionally.
            //Feel free to modify and experiment.
            string query = "hello!";
            driver.Navigate().GoToUrl(BingSearchPage.URL);
            BingSearchPage searchPage = new BingSearchPage(driver);
            BingResultPage resultPage = searchPage.search(query);
            Assert.IsTrue(resultPage.title.StartsWith(query),
                String.Format("Title: {0} does not start with query: {1}!", resultPage.title, query));
        }

        [Test, Property("Description", "Searching for \"bye!\" on Bing.")]
        public void BingSearchBye()
        {
            string query = "bye!";
            driver.Navigate().GoToUrl(BingSearchPage.URL);
            BingSearchPage searchPage = new BingSearchPage(driver);
            BingResultPage resultPage = searchPage.search(query);
            Assert.IsTrue(resultPage.title.StartsWith(query),
                String.Format("Title: {0} does not start with query: {1}!", resultPage.title, query));
        }

        [TearDown]
        public void Cleanup()
        {
            bool passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            try
            {
                // Logs the result to Sauce Labs
                ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                Console.WriteLine(String.Format("SauceOnDemandSessionID={0} job-name={1}", ((CustomRemoteWebDriver)driver).getSessionId(), TestContext.CurrentContext.Test.MethodName));
                // Terminates the remote webdriver session
                driver.Quit();
            }
        }
    }
}
