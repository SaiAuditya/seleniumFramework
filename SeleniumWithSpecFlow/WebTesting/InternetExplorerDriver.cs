using Framework.Drivers;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;

namespace Framework.WebTesting
{
    public class InternetExplorerDriverWeb : IDrivers
    {
        
        public string FOLDER_PATH
        {
            get;set;
        }
        public object DesiredCapabilities
        {
            get
            {
                InternetExplorerOptions opts = new InternetExplorerOptions();
                opts.EnsureCleanSession = true;
                opts.RequireWindowFocus = false;
                opts.IgnoreZoomLevel = false;
                opts.IntroduceInstabilityByIgnoringProtectedModeSettings = false;
                opts.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Top;
                return opts;
            }
        }

        public object Driver
        {
            get;set;
        }

        public object DriverServices
        {
            get
            {
                InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService(FOLDER_PATH);
                service.HideCommandPromptWindow = false;
                return service;
            }
        }

        public void InitDriver(Configuration config)
        {
            FOLDER_PATH = config.DRIVER_EXE_FOLDER;
            config.DesiredCapabilities = config.DesiredCapabilities ?? DesiredCapabilities;
            config.DriverServices = config.DriverServices ?? DriverServices;
            IWebDriver driver = new InternetExplorerDriver((InternetExplorerDriverService)config.DriverServices, (InternetExplorerOptions)config.DesiredCapabilities, TimeSpan.FromSeconds(60));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(config.PageLoadTimeout);
            driver.Navigate().GoToUrl(config.START_URL);
            Driver = driver;
        }
    }
}
