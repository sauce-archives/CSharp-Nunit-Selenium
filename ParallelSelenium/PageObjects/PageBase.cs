using OpenQA.Selenium;


namespace ParallelSelenium.PageObjects
{
    class PageBase
    {
        protected IWebDriver webDriver;

        public string title { get; protected set; } 
    }
}
