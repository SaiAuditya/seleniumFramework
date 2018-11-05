using System.Threading;
using Framework.WebTesting;
using OpenQA.Selenium;

namespace Framework.Drivers
{
    public class DriverFactory
    {
        private static ThreadLocal<object> storedDriver = new ThreadLocal<object>();


        public static DriverType GetDriver<DriverType>()
        {
            return (DriverType)DriverStored;
        }

        public static object DriverStored
        {
            get
            {
                if (storedDriver == null)
                    return null;
                else
                    return storedDriver.Value;
            }
            set
            {
                storedDriver.Value = value;
            }
        }

        public static void InitDriver(BrowserType browser, Configuration config = null)
        {
            config = config ?? new Configuration();
            switch (browser)
            {
                case BrowserType.Chrome:
                    ChromeDriverWeb chrmoedriverInstance = new ChromeDriverWeb();
                    chrmoedriverInstance.InitDriver(config);
                    DriverStored = chrmoedriverInstance.Driver;
                    break;

                case BrowserType.FireFox:
                    FireFoxDriverWeb firefoxdriverInstance = new FireFoxDriverWeb();
                    firefoxdriverInstance.InitDriver(config);
                    DriverStored = firefoxdriverInstance.Driver;
                    break;

                case BrowserType.InternetExplorer:
                    InternetExplorerDriverWeb iedriverInstance = new InternetExplorerDriverWeb();
                    iedriverInstance.InitDriver(config);
                    DriverStored = iedriverInstance.Driver;
                    break;
            }

        }

        public static void CloseDriver()
        {
            IWebDriver driver = (IWebDriver)DriverStored;
            driver.Quit();
            DriverStored = null;
        }
    }
}