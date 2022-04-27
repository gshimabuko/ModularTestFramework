using OpenQA.Selenium;

namespace TestApplication.Pages
{
    public class TestAppLoginPage : BasePage
    {
        private IWebDriver _driver;
        private IWebElement username => _driver.FindElement(By.Name("uid"));
        private IWebElement password => _driver.FindElement(By.Name("password"));
        private IWebElement loginButton => _driver.FindElement(By.Name("btnLogin"));
        public TestAppLoginPage(IWebDriver driver) => _driver = driver;
        public void LoginToApplication(string sUsername, string sPassword)
        {
            cmnElement.SetText(username, sUsername);
            cmnElement.SetText(password, sPassword);
            cmnElement.ClickElement(loginButton);
        }
    }
}