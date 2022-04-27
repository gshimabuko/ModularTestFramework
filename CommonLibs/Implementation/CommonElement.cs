using OpenQA.Selenium;

namespace CommonLibs.Implementation
{
    public class CommonElement
    {
        public void ClickElement(IWebElement element) => element.Click();
        public void ClearText(IWebElement element) => element.Clear();
        public void SetText(IWebElement element, string textToPass) => element.SendKeys(textToPass);
        public bool IsElementDisplayed(IWebElement element) => element.Displayed;
        public bool IsElementSelected(IWebElement element) => element.Selected;
        public bool IsElementEnabled(IWebElement element) => element.Enabled;
    }
}