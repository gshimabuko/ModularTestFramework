using CommonLibs.Implementation;
using OpenQA.Selenium;

namespace TestApplication.Pages
{
    public class BasePage
    {
        public CommonElement cmnElement;
        private IWebElement viewButton;
        public IWebDriver _driver;
        public BasePage()
        {
            cmnElement = new CommonElement();
        }
        public void GoToView(String destinationView)
        {
            viewButton = _driver.FindElement(By.PartialLinkText(destinationView));
            cmnElement.ClickElement(viewButton);
        }      
    }
}