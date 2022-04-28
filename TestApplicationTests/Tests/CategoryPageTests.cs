using NUnit.Framework;
using System.Threading;
using AventStack.ExtentReports;
using CommonLibs.Utils;

namespace TestApplicationTests.Tests
{
    public class CategoryPageTests : BaseTests
    {
        [Test]
        public void VerifyCategoryCreation()
        {
            int testState = 0;
            extentReportUtils.createATestCase("Verify Categories Creation");
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

            extentReportUtils.addTestLog(Status.Info, "Trying to go to Category View");
            loginPage.GoToView("Categories");
            Thread.Sleep(waitTime);
            string expectedURL = $"{url}/Categories";
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

            extentReportUtils.addTestLog(Status.Info, "Trying to Create an Income Category");
            if(categoriesPage.CreateNewCategory("Salario", 0, "Income"))
            {
                extentReportUtils.addTestLog(Status.Info, "First Income Category Creation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "First Income Category Creation Failed");
                testState += 4;
            }
            
            if(categoriesPage.CreateNewCategory("Bonus", 0, "Income"))
            {
                extentReportUtils.addTestLog(Status.Info, "Second Income Category Creation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "Second Income Category Creation Failed");
                testState += 8;
            }
            if(categoriesPage.CreateNewCategory("Comida", 0, "Expense"))
            {
                extentReportUtils.addTestLog(Status.Info, "First Expense Category Creation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "First Expense Category Creation Failed");
                testState += 16;
            }
            
            if(categoriesPage.CreateNewCategory("Bar", 0, "Expense"))
            {
                extentReportUtils.addTestLog(Status.Info, "Second Expense Category Creation Ok");
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, "Second Expense Category Creation Failed");
                testState += 32;
            }
            if (testState == 0)
            {
                extentReportUtils.addTestLog(Status.Info, "All Steps Passed");
                Assert.Pass();
            }
            else
            {
                extentReportUtils.addTestLog(Status.Info, $"Some Steps Failed. Error code is{testState}");
                Assert.Pass();
            }
            
        }
    }
}