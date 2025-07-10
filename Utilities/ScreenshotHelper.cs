using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.Utilities
{
    public static class ScreenshotHelper
    {
        public static void CaptureScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            string screenshotsDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Screenshots");
            Directory.CreateDirectory(screenshotsDir);

            string filePath = Path.Combine(screenshotsDir, $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

            // Save as raw bytes to .png — avoids ScreenshotImageFormat
            File.WriteAllBytes(filePath, screenshot.AsByteArray);

            TestContext.Progress.WriteLine($"🔍 Screenshot saved: {filePath}");


        }
    }
}
