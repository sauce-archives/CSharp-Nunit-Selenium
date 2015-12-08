using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ParallelSelenium.PageObjects.Bing
{
    class BingSearchPage : PageBase
    {
        public static readonly Uri URL = new Uri("https://www.bing.com");

        [FindsBy(How = How.Id, Using = "sb_form_q")]
        public IWebElement queryField { get; set; }

        [FindsBy(How = How.Id, Using = "sb_form_go")]
        public IWebElement searchButton { get; set; }
        public BingSearchPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            if (!this.webDriver.Url.Contains(URL.ToString()))
            {
                throw new InvalidElementStateException("This is not the search page");
            }

            this.title = this.webDriver.Title;

            PageFactory.InitElements(this.webDriver, this);
        }

        public BingResultPage search(string query)
        {
            this.queryField.SendKeys(query);
            this.searchButton.Click();
            System.Threading.Thread.Sleep(4000);
            // Even if i create a NUnit test for this
            // Issue with page loading still occures when I try and return new object
            BingResultPage resultPage = new BingResultPage(webDriver, query);
            return resultPage;
        }
    }

}
