using System.Globalization;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace TestApplication.Pages
{
    public class TestAppCategoriesPage : BasePage
    {
        private IWebElement newCategoryButton => _driver.FindElement(By.LinkText("Create New"));
        private IWebElement categoryName => _driver.FindElement(By.Id("name"));
        private IWebElement total => _driver.FindElement(By.Id("total"));
        private IWebElement dropdown => _driver.FindElement(By.Id("categoryType"));
        private IWebElement createButton => _driver.FindElement(By.XPath("//input[@value='Create']"));
        private int waitTime = 1000;
        
        public TestAppCategoriesPage(IWebDriver driver) => _driver = driver;
        public bool CreateNewCategory(string name, decimal total, string type)
        {
            cmnElement.ClickElement(newCategoryButton);
            Thread.Sleep(waitTime);
            SelectElement select = new SelectElement(dropdown);
            cmnElement.SetText(this.categoryName, name);
            cmnElement.SetText(this.total, total.ToString(CultureInfo.InvariantCulture));
            select.SelectByText(type);
            cmnElement.ClickElement(createButton);
            Thread.Sleep(waitTime);
            return checkCategoryCreation(name);
        }
        public bool checkCategoryCreation(string name)
        {
            IWebElement createdCategory = _driver.FindElement(By.XPath($"//*[contains(text(),\"{name}\")]"));
            return (createdCategory.Text.Equals(name));
        }
    }
}