using NUnit.Framework;
using CommonLibs.Implementation;
using TestApplicationTests.Tests;
using System.Threading;

namespace TestApplicationTests.tests
{
    public class LoginPageTests : BaseTests
    {
        [Test]
        public void VerifyLoginTest()
        {
            loginPage.LoginToApplication("test@example.com","Test@12345");
            Thread.Sleep(3000);
            string expectedTitle = "Home Page - My ASP.NET Application";
            Thread.Sleep(3000);
            string actualTitle = CmnDriver.GetPageTitle();
            Assert.AreEqual(expectedTitle,actualTitle);
        }
        [Test]
        public void VerifyLoginTest2()
        {
            loginPage.LoginToApplication("test@example.com","Test@1234");
            Thread.Sleep(3000);
            string expectedTitle = "Home Page - My ASP.NET Application";
            Thread.Sleep(3000);
            string actualTitle = CmnDriver.GetPageTitle();
            Assert.AreEqual(expectedTitle,actualTitle);
        }
    }
}