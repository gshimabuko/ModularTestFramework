using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;


namespace CommonLibs.Implementation
{
    public class CommonDriver
    {
        public IWebDriver Driver {get; private set;}
        public int PageLoadTimeout { private get => pageLoadTimeout; set => pageLoadTimeout = value; }
        public int ElementDetectionTimeout { private get => elementDetectionTimeout; set => elementDetectionTimeout = value; }
        
        private int pageLoadTimeout;
        private int elementDetectionTimeout;

        public CommonDriver(string browserType)
        {
            browserType = browserType.Trim();
            pageLoadTimeout = 60;
            elementDetectionTimeout = 10;

            if (browserType.Equals("chrome"))
            {
                Driver = new ChromeDriver();
            }
            else if (browserType.Equals("edge"))
            {
                Driver = new EdgeDriver();
            }
            else
            {
                throw new Exception($"Invalid Browser Type {browserType}");
            }
        }

        public void NavigateToFirstUrl(string url)
        {
            url = url.Trim();
            
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTimeout);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(elementDetectionTimeout);
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();
            Driver.Url = url;
        }
        public void CloseBrowserWindow()
        {
            if(Driver != null)
            {
                Driver.Close();
            }
        }
        public void CloseAllBrowserWindows()
        {
            if(Driver != null)
            {
                Driver.Quit();
            }
        }
        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}