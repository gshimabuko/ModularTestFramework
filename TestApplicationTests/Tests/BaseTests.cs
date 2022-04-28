using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using CommonLibs.Implementation;
using TestApplication.Pages;
using Microsoft.Extensions.Configuration;
namespace TestApplicationTests.Tests
{
    public class BaseTests
    {
        public CommonDriver CmnDriver;
        public TestAppLoginPage loginPage;
        public ActionTargets action;
        public IAlert alert;
        private IConfigurationRoot _configuration;
        
        string url;
        string currentProjectDirectory;
        string currentSolutionDirectory;
        string reportFilename;

        [OneTimeSetUp] 
        public void preSetup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            currentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            _configuration = new ConfigurationBuilder().AddJsonFile($"{currentProjectDirectory}/config/appSettings.json").Build();
        }
        [SetUp]
        public void Setup()
        {
            string browserType = _configuration["browserType"];
            CmnDriver = new CommonDriver(browserType);
            url = _configuration["baseUrl"];
            
            loginPage = new TestAppLoginPage(CmnDriver.Driver);
            CmnDriver.NavigateToFirstUrl(url);
        }
        [TearDown]
        public void TearDown()
        {
            CmnDriver.CloseAllBrowserWindows();
        }
    }
}