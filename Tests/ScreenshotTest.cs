using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.Tests
{
    public class ScreenshotTest
    {
        public class ScreenshotTests
        {
            [Test]
            public void TakeScreenshotManually()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://example.com");

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
}
