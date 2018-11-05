using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        }

        public IWebElement SearchField
        {
            get
            {
                return Driver.FindElement(By.Name(SEARCH_TEXT_BOX_NAME));
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
