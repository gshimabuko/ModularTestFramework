using OpenQA.Selenium;

namespace TestApplication.Pages
{
    public class TestApplicationLoginPage : BasePage
    {
        private IWebDriver _driver;
        private IWebElement username => _driver.FindElement(By.Name("Email"));
        private IWebElement password => _driver.FindElement(By.Name("Password"));
        private IWebElement loginButton => _driver.FindElement(By.ClassName("btn-default"));
        public TestApplicationLoginPage(IWebDriver driver) => _driver = driver;
        public void LoginToApplication(string sUsername, string sPassword)
        {
            cmnElement.SetText(username, sUsername);
            cmnElement.SetText(password, sPassword);
            cmnElement.ClickElement(loginButton);
        }
    }
}