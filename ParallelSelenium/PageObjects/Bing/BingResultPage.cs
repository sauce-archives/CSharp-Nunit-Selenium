using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.PageObjects;

namespace ParallelSelenium.PageObjects.Bing
{
    class BingResultPage : BingSearchPage
    {
        public BingResultPage(IWebDriver driver, string query): base(driver)
        {
            this.webDriver = driver;
            if (!this.webDriver.Title.StartsWith(query))
            {
                throw new InvalidElementStateException("This is not the result page!");
            }
        }

    }
}
