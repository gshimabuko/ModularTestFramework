using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
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
        string url;
        string currentProjectDirectory;
        string currentSolutionDirectory;
        string reportFilename;

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
            
            loginPage = new TestAppLoginPage(CmnDriver.Driver);
            CmnDriver.NavigateToFirstUrl(url);
        }
        [TearDown]
        public void TearDown()
        {
            CmnDriver.CloseAllBrowserWindows();
        }
        [OneTimeTearDown]
        public void PostCleanUp()
        {
            extentReportUtils.flushReport();
        }
    }
}