using NUnit.Framework;
using System.Threading;
using AventStack.ExtentReports;
using CommonLibs.Utils;

namespace TestApplicationTests.Tests
{
    public class AccountsPageTests : BaseTests
    {
        [Test]
        public void VerifyFinancialAccountCreation()
        {
            int testState = 0;
            extentReportUtils.createATestCase("Verify Financial Account Creation");
            extentReportUtils.addTestLog(Status.Info, "Performing Login");
            loginPage.LoginToApplication("test@example.com","Test@12345");
            Thread.Sleep(waitTime);
            string expectedTitle = "Home Page - My ASP.NET Application";
            string actualTitle = CmnDriver.GetPageTitle();
            if(expectedTitle.Equals(actualTitle))
            {
                extentReportUtils.addTestLog(Status.Info, "Login Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "Login Failed");
                testState += 1;
            }

            extentReportUtils.addTestLog(Status.Info, "Trying to go to Accounts View");
            loginPage.GoToView("Accounts");
            Thread.Sleep(waitTime);
            string expectedURL = $"{url}?/FinancialAccounts";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;

            if(expectedURL.Equals(actualURL))
            {
                extentReportUtils.addTestLog(Status.Info, "View Navigation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "View Navigation Failed");
                testState += 2;
            }

            extentReportUtils.addTestLog(Status.Info, "Trying to Create an Account");
            if(accountsPage.CreateNewAccount("Conta C6 Bank", 0, "USD"))
            {
                extentReportUtils.addTestLog(Status.Info, "First Account Creation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "First Account Creation Failed");
                testState += 4;
            }
            
            if(accountsPage.CreateNewAccount("Conta Bradesco", 0, "BRL"))
            {
                extentReportUtils.addTestLog(Status.Info, "Second Account Creation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "Second Account Creation Failed");
                testState += 8;
            }
            if (testState == 0)
            {
                extentReportUtils.addTestLog(Status.Info, "All Tests Passed");
                Assert.Pass();
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, $"Some Tests Failed. Error code is{testState}");
                Assert.Pass();
            }
            
        }
    }
}