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
        [Test]
        public void VerifyLoginTest3()
        {
            extentReportUtils.createATestCase("Verify Login Page Test 3");
            extentReportUtils.addTestLog(Status.Info, "Performing Login");
            loginPage.LoginToApplication("facebook");
            Thread.Sleep(3000);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            //string expectedTitle = "Log in - My ASP.NET Application";
            string expectedTitle = "Log into Facebook | Facebook";
            string actualTitle = CmnDriver.GetPageTitle();
            Assert.AreEqual(expectedTitle,actualTitle);
        }
        [Test]
        public void VerifyAccessRestriction1()
        {
            extentReportUtils.createATestCase("Verify Access Restriction Test 1");
            extentReportUtils.addTestLog(Status.Info, "Trying to go to Accounts View");
            loginPage.GoToView("Accounts");
            Thread.Sleep(3000);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedURL = $"{url}?ReturnUrl=%2FFinancialAccounts";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;
            Assert.AreEqual(expectedURL,actualURL);
        }
        [Test]
        public void VerifyAccessRestriction2()
        {
            string view = "Categories";
            extentReportUtils.createATestCase("Verify Access Restriction Test 1");
            extentReportUtils.addTestLog(Status.Info, "Trying to go to Accounts View");
            loginPage.GoToView(view);
            Thread.Sleep(3000);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedURL = $"{url}?ReturnUrl=%2F{view}";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;
            Assert.AreEqual(expectedURL,actualURL);
        }
        [Test]
        public void VerifyAccessRestriction3()
        {
            string view = "IncomeRecords";
            extentReportUtils.createATestCase("Verify Access Restriction Test 1");
            extentReportUtils.addTestLog(Status.Info, "Trying to go to Accounts View");
            loginPage.GoToView("Income Records");
            Thread.Sleep(3000);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedURL = $"{url}?ReturnUrl=%2F{view}";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;
            Assert.AreEqual(expectedURL,actualURL);
        }
        [Test]
        public void VerifyAccessRestriction4()
        {
            string view = "ExpensesRecords";
            extentReportUtils.createATestCase("Verify Access Restriction Test 1");
            extentReportUtils.addTestLog(Status.Info, "Trying to go to Accounts View");
            loginPage.GoToView("Expenses Records");
            Thread.Sleep(3000);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedURL = $"{url}?ReturnUrl=%2F{view}";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;
            Assert.AreEqual(expectedURL,actualURL);
        }
        [Test]
        public void VerifyAccessRestriction5()
        {
            string view = "Transfer";
            extentReportUtils.createATestCase("Verify Access Restriction Test 1");
            extentReportUtils.addTestLog(Status.Info, "Trying to go to Accounts View");
            loginPage.GoToView(view);
            Thread.Sleep(3000);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedURL = $"{url}?ReturnUrl=%2F{view}";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;
            Assert.AreEqual(expectedURL,actualURL);
        }
    }
}