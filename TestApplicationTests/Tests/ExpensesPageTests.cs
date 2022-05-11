using NUnit.Framework;
using System.Threading;
using AventStack.ExtentReports;
using System;

namespace TestApplicationTests.Tests
{
    public class ExpensesPageTests : BaseTests
    {
        //[Test]
        public void VerifyExpensesCreation()
        {
            int testState = 0;
            extentReportUtils.createATestCase("Verify Income Record Creation");
            extentReportUtils.addTestLog(Status.Info, "Performing Login");
            loginPage.LoginToApplication("test@example.com","Test@12345");
            Thread.Sleep(waitTime);
            string expectedTitle = "Home Page - My ASP.NET Application";
            string actualTitle = CmnDriver.GetPageTitle();
            DateTime TestDate = DateTime.Now;
            string TestTime = TestDate.ToString("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss");
            if(expectedTitle.Equals(actualTitle))
            {
                extentReportUtils.addTestLog(Status.Info, "Login Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "Login Failed");
                testState += 1;
            }

            extentReportUtils.addTestLog(Status.Info, "Trying to go to Income View");
            loginPage.GoToView("Accounts");
            Thread.Sleep(waitTime);
            string expectedURL = $"{url}/FinancialAccounts";
            //string expectedTitle = "Log into Facebook | Facebook";
            string actualURL = CmnDriver.Driver.Url;

            if(expectedURL.Equals(actualURL))
            {
                extentReportUtils.addTestLog(Status.Info, "First View Navigation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "First View Navigation Failed");
                testState += 2;
            }

             extentReportUtils.addTestLog(Status.Info, "Trying to Create an Account");
            if(accountsPage.CreateNewAccount($"Conta Income Record Test {TestTime}", 0, "USD"))
            {
                extentReportUtils.addTestLog(Status.Info, "Account Creation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "Account Creation Failed");
                testState += 4;
            }

            accountsPage.GoToView("Categories");
            Thread.Sleep(waitTime);
            expectedURL = $"{url}/Categories";
            actualURL = CmnDriver.Driver.Url;

            if(expectedURL.Equals(actualURL))
            {
                extentReportUtils.addTestLog(Status.Info, "Second View Navigation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "Second View Navigation Failed");
                testState += 8;
            }

            extentReportUtils.addTestLog(Status.Info, "Trying to Create an Income Category");
            if(categoriesPage.CreateNewCategory($"Category Income Record Test {TestTime}", 0, "Income"))
            {
                extentReportUtils.addTestLog(Status.Info, "Income Category Creation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "First Income Category Creation Failed");
                testState += 16;
            }
            incomePage.GoToView("Income Records");
            Thread.Sleep(waitTime);
            expectedURL = $"{url}/IncomeRecords";
            actualURL = CmnDriver.Driver.Url;

            if(expectedURL.Equals(actualURL))
            {
                extentReportUtils.addTestLog(Status.Info, "Third View Navigation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "Third View Navigation Failed");
                testState += 32;
            }

            extentReportUtils.addTestLog(Status.Info, "Trying to Create an Income Record");
            bool incomeRecordCreationValidation1 = incomePage.CreateNewIncomeRecord(100, $"Income Record Test {TestTime}", TestDate, $"Category Income Record Test {TestTime}", $"Conta Income Record Test {TestTime}");
            incomePage.GoToView("Accounts");
            Thread.Sleep(waitTime);
            bool incomeRecordCreationValidation2 = incomePage.checkAccountDetails(100, $"Income Record Test {TestTime}", $"Category Income Record Test {TestTime}", $"Conta Income Record Test {TestTime}");
            if (incomeRecordCreationValidation1 && incomeRecordCreationValidation2)
            {
                extentReportUtils.addTestLog(Status.Info, "First Income Record Creation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "First Income Record Creation Failed");
                testState += 64;
            }
            incomePage.GoToView("Income Records");
            extentReportUtils.addTestLog(Status.Info, "Trying to Create an Income Record");
            if(incomePage.CreateNewIncomeRecord(100, $"Income Record Test {TestTime}_2", TestDate, $"Category Income Record Test {TestTime}", $"Conta Income Record Test {TestTime}"))
            {
                extentReportUtils.addTestLog(Status.Info, "Second Income Record Creation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "Second Income Category Creation Failed");
                testState += 128;
            }
            
            extentReportUtils.addTestLog(Status.Info, "Trying to Create an Income Record");
            if(incomePage.CreateNewIncomeRecord(100, $"Income Record Test {TestTime}_3", TestDate, $"Category Income Record Test {TestTime}", $"Conta Income Record Test {TestTime}"))
            {
                extentReportUtils.addTestLog(Status.Info, "Second Income Record Creation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "Second Income Category Creation Failed");
                testState += 256;
            }
            if (testState == 0)
            {
                extentReportUtils.addTestLog(Status.Info, "All Steps Passed");
                Assert.Pass();
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, $"Some Steps Failed. Error code is{testState}");
                Assert.Fail();
            }
            
        }
    }
}