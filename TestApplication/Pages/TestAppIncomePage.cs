using System.Globalization;
using OpenQA.Selenium;
using System.Threading;
using System;
using OpenQA.Selenium.Support.UI;

namespace TestApplication.Pages
{
    public class TestAppIncomePage : BasePage
    {
        private IWebElement newAccountButton => _driver.FindElement(By.LinkText("Create New"));
        private IWebElement ammount => _driver.FindElement(By.Id("ammount"));
        private IWebElement details => _driver.FindElement(By.Id("details"));
        private IWebElement date => _driver.FindElement(By.Id("date"));
        private IWebElement dropdownCat => _driver.FindElement(By.Id("categoryID"));
        private IWebElement dropdownAcc => _driver.FindElement(By.Id("financialAccountID"));
        private IWebElement createButton => _driver.FindElement(By.XPath("//input[@value='Create']"));
        private int waitTime = 1000;
        
        public TestAppIncomePage(IWebDriver driver) => _driver = driver;
        public bool CreateNewIncomeRecord(decimal value, string details, DateTime date, string category, string account)
        {
            cmnElement.ClickElement(newAccountButton);
            Thread.Sleep(waitTime);
            SelectElement selectCat = new SelectElement(dropdownCat);
            SelectElement selectAcc = new SelectElement(dropdownAcc);
            cmnElement.SetText(this.ammount, value.ToString(CultureInfo.InstalledUICulture));
            cmnElement.SetText(this.details, details);
            cmnElement.SetText(this.date, date.ToShortDateString());
            selectCat.SelectByText(category);
            selectAcc.SelectByText(account);
            cmnElement.ClickElement(createButton);
            Thread.Sleep(waitTime);
            return checkIncomeRecordCreation(value, details, category, account);
        }
        public bool checkIncomeRecordCreation(decimal value, string details, string category, string account)
        {
            IWebElement createdRecordAccount = _driver.FindElement(By.XPath($"//td[contains(text(),\"{details}\")]/../td[1]"));
            IWebElement createdRecordCategory = _driver.FindElement(By.XPath($"//td[contains(text(),\"{details}\")]/../td[2]"));
            IWebElement createdRecordAmmount = _driver.FindElement(By.XPath($"//td[contains(text(),\"{details}\")]/../td[3]"));
            IWebElement createdRecord = _driver.FindElement(By.XPath($"//td[contains(text(),\"{details}\")]/../td[4]"));
            bool test1 = createdRecord.Text.Equals( details );
            bool test2 = createdRecordAccount.Text.Equals( account );
            bool test3 = createdRecordCategory.Text.Equals( category );
            bool test4 = Convert.ToDecimal(createdRecordAmmount.Text) == value;
            return( ( test1 ) && ( test2 ) && ( test3 ) && ( test4 ) );
        }
        public bool checkAccountDetails(decimal value, string details, string category, string account)
        {
            IWebElement createdAccountDetails = _driver.FindElement(By.XPath($"//*[contains(text(),\"{account}\")]/../td[4]/a[2]"));
            cmnElement.ClickElement(createdAccountDetails);
            Thread.Sleep(waitTime+2000);
            IWebElement createdRecordAmmount = _driver.FindElement(By.XPath($"//td[contains(text(),\"{details}\")]/../td[2]"));
            IWebElement createdRecordCategory = _driver.FindElement(By.XPath($"//td[contains(text(),\"{details}\")]/../td[3]"));
            
            IWebElement createdRecordDetails = _driver.FindElement(By.XPath($"//td[contains(text(),\"{details}\")]/../td[4]"));

            bool test1 = Convert.ToDecimal(createdRecordAmmount.Text)==( value );
            bool test2 = createdRecordCategory.Text.Equals( category );
            bool test3 = createdRecordDetails.Text.Equals( details );
            
            return( ( test1 ) && ( test2 ) && ( test3 ) );
        }
        public bool checkCategoryDetails(decimal value, string details, string category, string account)
        {
            IWebElement createdCategoryDetails = _driver.FindElement(By.XPath($"//*[contains(text(),\"{category}\")]/../td[4]/a[2]"));
            cmnElement.ClickElement(createdCategoryDetails);
            Thread.Sleep(waitTime+2000);
            IWebElement createdRecordAmmount = _driver.FindElement(By.XPath($"//td[contains(text(),\"{details}\")]/../td[2]"));
            IWebElement createdRecordAccount = _driver.FindElement(By.XPath($"//td[contains(text(),\"{details}\")]/../td[3]"));
            
            IWebElement createdRecordDetails = _driver.FindElement(By.XPath($"//td[contains(text(),\"{details}\")]/../td[4]"));

            bool test1 = Convert.ToDecimal(createdRecordAmmount.Text)==( value );
            bool test2 = createdRecordAccount.Text.Equals( account );
            bool test3 = createdRecordDetails.Text.Equals( details );
            
            return( ( test1 ) && ( test2 ) && ( test3 ) );
        }
    }
}