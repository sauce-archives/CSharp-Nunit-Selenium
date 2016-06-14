using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using PNUnit.Framework;
using ParallelSelenium.Utils;

namespace ParallelSelenium
{
    [TestFixture("chrome", "46", "Windows 7", "", "")]
    [TestFixture("internet explorer", "11", "Windows 7", "", "")]
    [TestFixture("firefox", "41", "Windows 7", "", "")]
    [TestFixture("chrome", "30", "Windows 7", "", "")]
    [TestFixture("firefox", "35", "Windows 7", "", "")]
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
        public ParallelSearchTests(String browser, String version, String os)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
            this.deviceName = null;
            this.deviceOrientation = null;
        }

        [SetUp]
        public void Init()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, browser);
            caps.SetCapability(CapabilityType.Version, version);
            caps.SetCapability(CapabilityType.Platform, os);
            if(deviceName != null)
                caps.SetCapability("deviceName", deviceName);
            if(deviceOrientation != null)
                caps.SetCapability("deviceOrientation", deviceOrientation);
            caps.SetCapability("username", Constants.sauceUser);
            caps.SetCapability("accessKey", Constants.sauceKey);
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

            SauceUtils.addBuildNumberToDesiredCapabilities(caps);

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps, TimeSpan.FromSeconds(600));
            String sessionId = ((RemoteWebDriver)driver).SessionId.ToString();
            Console.Out.WriteLine(string.Format("SauceOnDemandSessionID={0} job-name={1}", sessionId, TestContext.CurrentContext.Test.Name));
        }

        [Test]
        public void googleTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            StringAssert.Contains("Google", driver.Title);
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Sauce Labs");
            query.Submit();
        }

        [TearDown]
        public void CleanUp()
        {
            bool passed = TestContext.CurrentContext.Result.Status == TestStatus.Passed;
            try
            {
                // Logs the result to Sauce Labs
                ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                // Terminates the remote webdriver session
                driver.Quit();
            }
        }
    }
}