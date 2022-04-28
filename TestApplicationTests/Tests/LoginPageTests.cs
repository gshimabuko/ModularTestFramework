using NUnit.Framework;
using System.Threading;
using AventStack.ExtentReports;
using CommonLibs.Utils;

namespace TestApplicationTests.Tests
{
    public class LoginPageTests : BaseTests
    {
        [Test]
        public void VerifyLoginTest()
        {
            extentReportUtils.createATestCase("Verify Login Page Test");
            extentReportUtils.addTestLog(Status.Info, "Performing Login");
            loginPage.LoginToApplication("test@example.com","Test@12345");
            Thread.Sleep(3000);
            string expectedTitle = "Home Page - My ASP.NET Application";
            string actualTitle = CmnDriver.GetPageTitle();
            Assert.AreEqual(expectedTitle,actualTitle);
        }
        [Test]
        public void VerifyLoginTest2()
        {
            extentReportUtils.createATestCase("Verify Login Page Test 2");
            extentReportUtils.addTestLog(Status.Info, "Performing Login");
            loginPage.LoginToApplication("test@example.com","Test@1234");
            Thread.Sleep(3000);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedTitle = "Log in - My ASP.NET Application";
            string actualTitle = CmnDriver.GetPageTitle();
            Assert.AreEqual(expectedTitle,actualTitle);
        }
    }
}