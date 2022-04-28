using System;
using System.IO;
using OpenQA.Selenium;

namespace CommonLibs.Utils
{
    public class ScreenshotUtils
    {
        ITakesScreenshot camera;

        public ScreenshotUtils(IWebDriver driver)
        {
            camera = (ITakesScreenshot) driver;
        }

        public void CaptureAndSaveScreenshot(string filename)
        {
            _ = filename.Trim();
            if(File.Exists(filename))
            {
                throw new Exception("File already exists!");
            }
            Screenshot screenshot = camera.GetScreenshot();
            screenshot.SaveAsFile(filename);
        }
    }
}