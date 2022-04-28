using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace CommonLibs.Utils
{
    public class ExtentReportUtils
    {
        private ExtentHtmlReporter extentHtmlReport;   
        private ExtentReports extentReports;
        private ExtentTest extentTest;  

        public ExtentReportUtils(string htmlReportFilename)
        {
            extentHtmlReport = new ExtentHtmlReporter(htmlReportFilename);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReport);
        }
        
        public void createATestCase(string testCaseName)
        {
            extentTest = extentReports.CreateTest(testCaseName);

        }
        
        public void addTestLog(Status status, string comment)
        {
            extentTest.Log(status, comment);
        }
        public void addScreenshot(string screenshotFilename)
        {
            extentTest.AddScreenCaptureFromPath(screenshotFilename);
        }
        public void flushReport()
        {
            extentReports.Flush();
        }
    }
}