using OpenQA.Selenium;
using System;

namespace Framework.SampleTests.Pages
{
    public class GoogleSearchResultsPage
    {
        private IWebDriver _driver;

        IWebDriver Driver
        {
            get
            {
                return _driver;
            }

            set
            {
                _driver = value;
            }
        }

        public GoogleSearchResultsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement ResultLink(string ResultLinkText)
        {
            return Driver.FindElement(By.PartialLinkText(ResultLinkText));
        }

        public bool VerifyResultLink(string ResultLinkText)
        {
            try
            {
                ResultLink(ResultLinkText).Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
