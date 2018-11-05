using NUnit.Framework;
using Framework.Drivers;
using Framework.SampleTests.Pages;
using OpenQA.Selenium;

namespace Framework.SampleTests.Tests
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.FireFox)]
    [TestFixture(BrowserType.FireFox)]
    // [TestFixture(BrowserType.InternetExplorer)]
    [Parallelizable(ParallelScope.Self)]
    public class GoogleSearchTests
    {
        BrowserType browser;
        public GoogleSearchTests(BrowserType type)
        {
            browser = type;
        }


        [SetUp]
        public void InitAutomationFramework()
        {
            DriverFactory.InitDriver(browser);
        }
        [Test]
        public void WhenEnterSearchTextInGoogleHomePageAndClickOnSearch_ThenSearchShouldDisplay()
        {
            //Google home page
            GoogleHomePage home = new GoogleHomePage(DriverFactory.GetDriver<IWebDriver>());
            home.EnterSearchKeyword("google");
            home.ClickSearch();
            //google search results page
            GoogleSearchResultsPage results = new GoogleSearchResultsPage(DriverFactory.GetDriver<IWebDriver>());
            results.VerifyResultLink("google");
        }
        [TearDown]
        public void CleanBrowserSessions()
        {
            DriverFactory.CloseDriver();
        }
        

    }
}
