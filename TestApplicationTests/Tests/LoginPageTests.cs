using NUnit.Framework;
using CommonLibs.Implementation;

namespace TestApplicationTests.tests
{
    public class LoginPageTests
    {
        [Test]
        public void Test1()
        {
            CommonDriver CmnDriver = new CommonDriver("chrome");
            CmnDriver.NavigateToFirstUrl("http://demo.guru99.com/v4");
        }
    }
}