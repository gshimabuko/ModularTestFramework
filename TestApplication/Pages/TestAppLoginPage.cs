using OpenQA.Selenium;

namespace TestApplication.Pages
{
    public class TestAppLoginPage : BasePage
    {
        
        private IWebElement username => _driver.FindElement(By.Name("Email"));
        private IWebElement password => _driver.FindElement(By.Name("Password"));
        private IWebElement loginButton => _driver.FindElement(By.ClassName("btn-default"));
        private IWebElement facebookButton => _driver.FindElement(By.Id("Facebook"));
        private IWebElement invalidLogin => _driver.FindElement(By.XPath("//*[contains(text(),'Invalid')]"));
        public TestAppLoginPage(IWebDriver driver) => _driver = driver;
        public void LoginToApplication(string sUsername, string sPassword)
        {
            cmnElement.SetText(username, sUsername);
            cmnElement.SetText(password, sPassword);
            cmnElement.ClickElement(loginButton);
        }
        public void LoginToApplication(string social)
        {
            if(social.Equals("facebook"))
            {
                cmnElement.ClickElement(facebookButton);
            }
        }
        
        public string GetFailedLoginWarning()
        {
            return invalidLogin.Text;
        }
    }
}