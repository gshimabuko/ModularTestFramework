using CommonLibs.Implementation;
using TestApplication.Pages;
using NUnit.Framework;
namespace TestApplicationTests.Tests
{
    public class BaseTests
    {
        public CommonDriver CmnDriver;
        public TestApplicationLoginPage loginPage;
        string url = "https://localhost:44385/Account/Login";
        [SetUp]
        public void Setup()
        {
            CmnDriver = new CommonDriver("chrome");
            CmnDriver.NavigateToFirstUrl(url);
            loginPage = new TestApplicationLoginPage(CmnDriver.Driver);
        }
        [TearDown]
        public void TearDown()
        {
            CmnDriver.CloseAllBrowserWindows();
        }
    }
}