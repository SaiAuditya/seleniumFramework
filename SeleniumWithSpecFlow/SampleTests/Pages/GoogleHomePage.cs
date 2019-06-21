using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
//using OpenQA.Selenium.Support.UI;
//using DotNetSe
using System;


namespace Framework.SampleTests.Pages
{
    public class GoogleHomePage
    {
        private IWebDriver _driver;
        private const string SEARCH_TEXT_BOX_NAME = "q";
        private const string GOOGLE_SEARCH_BUTTON_NAME = "btnK";
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

        public GoogleHomePage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        public IWebElement SearchField
        {
            get
            {
                WebDriverWait waits = new WebDriverWait(Driver,TimeSpan.FromSeconds(30));
                IWebElement textbox;
                textbox= waits.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.Name(SEARCH_TEXT_BOX_NAME))));
                return textbox;
            }
        }

        public IWebElement SearchButton
        {
            get
            {
                return Driver.FindElement(By.Name(GOOGLE_SEARCH_BUTTON_NAME));
            }
        }

        public void EnterSearchKeyword(string keyword)
        {
            SearchField.SendKeys(keyword);
            SearchField.SendKeys(Keys.Escape);
        }

        public void ClickSearch()
        {
            SearchButton.Submit();
        }

    }
}
