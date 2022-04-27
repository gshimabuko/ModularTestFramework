using NUnit.Framework;
using CommonLibs.Implementation;
using TestApplicationTests.Tests;

namespace TestApplicationTests.tests
{
    public class LoginPageTests : BaseTests
    {
        [Test]
        public void VerifyLoginTest()
        {
            loginPage.LoginToApplication("test@example.com","Test@12345");
        }
    }
}