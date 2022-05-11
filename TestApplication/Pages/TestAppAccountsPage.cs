using System.Globalization;
using OpenQA.Selenium;
using System.Threading;

namespace TestApplication.Pages
{
    public class TestAppAccountsPage : BasePage
    {
        private IWebElement newAccountButton => _driver.FindElement(By.LinkText("Create New"));
        private IWebElement accountName => _driver.FindElement(By.Id("name"));
        private IWebElement accountBalance => _driver.FindElement(By.Id("accountBalance"));
        private IWebElement currency => _driver.FindElement(By.Id("currency"));
        private IWebElement createButton => _driver.FindElement(By.XPath("//input[@value='Create']"));
        private int waitTime = 1000;
        
        public TestAppAccountsPage(IWebDriver driver) => _driver = driver;
        public bool CreateNewAccount(string name, decimal balance, string currency)
        {
            cmnElement.ClickElement(newAccountButton);
            Thread.Sleep(waitTime);
            cmnElement.SetText(this.accountName, name);
            cmnElement.SetText(this.accountBalance, balance.ToString(CultureInfo.InvariantCulture));
            cmnElement.SetText(this.currency, currency);
            cmnElement.ClickElement(createButton);
            Thread.Sleep(waitTime);
            return checkAccountCreation(name);
        }
        public bool checkAccountCreation(string name)
        {
            IWebElement createdAccount = _driver.FindElement(By.XPath($"//td[contains(text(),\"{name}\")]/../td[1]"));
            string retrievedText = createdAccount.Text;
            bool testCondition = retrievedText.Equals(name);
            return(testCondition);
        }
    }
}