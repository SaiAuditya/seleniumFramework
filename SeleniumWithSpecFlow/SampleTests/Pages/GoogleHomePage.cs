using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
//using OpenQA.Selenium.Support.UI;
//using DotNetSe
using System;
using System.Threading;

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

            Thread.Sleep(2000);
        }

        public IWebElement SearchField
        {
            get
            {
                IWebElement textbox;
                WebDriverWait waits = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

                waits.IgnoreExceptionTypes(typeof(NoSuchElementException));
                waits.IgnoreExceptionTypes(typeof(ElementNotSelectableException));

                /*
                textbox = waits.Until(SeleniumExtras
                    .WaitHelpers
                    .ExpectedConditions
                    .ElementIsVisible((By.Name(SEARCH_TEXT_BOX_NAME))));
                    */

                //there is another way using function delegate
                //delegate parameters and return value = new delegate parameters return value of passed parameters
                //delegate is onthe fly function generator
                Func<IWebDriver,IWebElement>checkForvisibilityOfWebElement = new Func<IWebDriver, IWebElement>((IWebDriver Driver) =>
                {
                    IWebElement textBoxDelegate = Driver.FindElement(By.Name(SEARCH_TEXT_BOX_NAME));
                    if (textBoxDelegate.Displayed)
                        return textBoxDelegate;
                    else
                        return null;
                }); 


                textbox = waits.Until(checkForvisibilityOfWebElement);
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
