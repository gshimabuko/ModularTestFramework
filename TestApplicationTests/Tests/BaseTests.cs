using System;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using CommonLibs.Implementation;
using TestApplication.Pages;
using Microsoft.Extensions.Configuration;
using CommonLibs.Utils;
using AventStack.ExtentReports;

namespace TestApplicationTests.Tests
{
    public class BaseTests
    {
        public CommonDriver CmnDriver;
        public TestAppLoginPage loginPage;
        public ActionTargets action;
        public IAlert alert;
        private IConfigurationRoot _configuration;
        public ExtentReportUtils extentReportUtils;
        
        public string url;
        string currentProjectDirectory;
        string currentSolutionDirectory;
        string reportFilename;

        ScreenshotUtils screenshot;


        [OneTimeSetUp] 
        public void preSetup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            currentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            currentSolutionDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            reportFilename = $"{currentSolutionDirectory}/reports/TestApplicationTestReport.html";

            extentReportUtils = new ExtentReportUtils(reportFilename);
            _configuration = new ConfigurationBuilder().AddJsonFile($"{currentProjectDirectory}/config/appSettings.json").Build();
            
        }
        [SetUp]
        public void Setup()
        {
            extentReportUtils.createATestCase("Setup");
            string browserType = _configuration["browserType"];
            CmnDriver = new CommonDriver(browserType);
            url = _configuration["baseUrl"];

            extentReportUtils.addTestLog(Status.Info, $"Browser Type: {browserType}");
            extentReportUtils.addTestLog(Status.Info, $"Base url: {url}");
            
            Actions action = new Actions(CmnDriver.Driver);
            loginPage = new TestAppLoginPage(CmnDriver.Driver);
            CmnDriver.NavigateToFirstUrl(url);
            screenshot = new ScreenshotUtils(CmnDriver.Driver);
        }
        [TearDown]
        public void TearDown()
        {
            string currentExecutionTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss");
            string screenshotFilename = $"{currentSolutionDirectory}/screenshots/test-{currentExecutionTime}.jpeg";
            if(TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                extentReportUtils.addTestLog(Status.Fail, "One or more steps failed");
            }
            screenshot.CaptureAndSaveScreenshot(screenshotFilename);
            extentReportUtils.addScreenshot(screenshotFilename);
            CmnDriver.CloseAllBrowserWindows();
        }
        [OneTimeTearDown]
        public void PostCleanUp()
        {
            extentReportUtils.flushReport();
        }
    }
}