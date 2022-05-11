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
            Thread.Sleep(waitTime);
            string expectedTitle = "Home Page - My ASP.NET Application";
            string actualTitle = CmnDriver.GetPageTitle();
            Assert.AreEqual(expectedTitle,actualTitle);
        }
        [Test]
        public void VerifyLoginFail()
        {
            extentReportUtils.createATestCase("Verify Login Fail");
            extentReportUtils.addTestLog(Status.Info, "Performing Login");
            loginPage.LoginToApplication("test@example.com","Test@1234");
            Thread.Sleep(waitTime);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedTitle = "Log in - My ASP.NET Application";
            string expectedWarning = "Invalid login attempt.";
            string actualTitle = CmnDriver.GetPageTitle();
            
            //Assert.AreEqual(expectedTitle,actualTitle);
            //Assert.AreEqual(expectedWarning,loginPage.GetFailedLoginWarning());
            Assert.IsTrue( (expectedTitle.Equals(actualTitle)) && ( expectedWarning.Equals( loginPage.GetFailedLoginWarning() ) ) );
        }
        [Test]
        public void VerifySocialLogin()
        {
            extentReportUtils.createATestCase("Verify Social Login");
            extentReportUtils.addTestLog(Status.Info, "Performing Login");
            loginPage.LoginToApplication("facebook");
            Thread.Sleep(waitTime);
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
            Thread.Sleep(waitTime);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedURL = $"{loginURL}?ReturnUrl=%2FFinancialAccounts";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;
            Assert.AreEqual(expectedURL,actualURL);
        }
        [Test]
        public void VerifyAccessRestriction2()
        {
            string view = "Categories";
            extentReportUtils.createATestCase("Verify Access Restriction Test 1");
            extentReportUtils.addTestLog(Status.Info, "Trying to go to Categories View");
            loginPage.GoToView(view);
            Thread.Sleep(waitTime);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedURL = $"{loginURL}?ReturnUrl=%2F{view}";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;
            Assert.AreEqual(expectedURL,actualURL);
        }
        [Test]
        public void VerifyAccessRestriction3()
        {
            string view = "IncomeRecords";
            extentReportUtils.createATestCase("Verify Access Restriction Test 1");
            extentReportUtils.addTestLog(Status.Info, "Trying to go to Income Records View");
            loginPage.GoToView("Income Records");
            Thread.Sleep(waitTime);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedURL = $"{loginURL}?ReturnUrl=%2F{view}";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;
            Assert.AreEqual(expectedURL,actualURL);
        }
        [Test]
        public void VerifyAccessRestriction4()
        {
            string view = "ExpenseRecords";
            extentReportUtils.createATestCase("Verify Access Restriction Test 1");
            extentReportUtils.addTestLog(Status.Info, "Trying to go to Expenses View");
            loginPage.GoToView("Expenses Records");
            Thread.Sleep(waitTime);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedURL = $"{loginURL}?ReturnUrl=%2F{view}";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;
            Assert.AreEqual(expectedURL,actualURL);
        }
        [Test]
        public void VerifyAccessRestriction5()
        {
            string view = "Transfers";
            extentReportUtils.createATestCase("Verify Access Restriction Test 1");
            extentReportUtils.addTestLog(Status.Info, "Trying to go to Transfers View");
            loginPage.GoToView("Transfer");
            Thread.Sleep(waitTime);
            //string expectedTitle = "Home Page - My ASP.NET Application";
            string expectedURL = $"{loginURL}?ReturnUrl=%2F{view}";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;
            Assert.AreEqual(expectedURL,actualURL);
        }
        
    }
}