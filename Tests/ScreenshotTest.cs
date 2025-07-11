using Allure.NUnit;
using Allure.NUnit.Attributes;
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
        [TestFixture]
        [AllureNUnit]
        [AllureSuite("Screenshot Test Cases")]
        public class ScreenshotTests
        {
            [Test]
            [Category("A")]
            public void TakeScreenshotManually()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://example.com");

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                string solutionDir = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
                string dateFolder = DateTime.Now.ToString("dd-MM-yyyy");
                string screenshotsDir = Path.Combine(solutionDir, "Screenshots", dateFolder);
                Directory.CreateDirectory(screenshotsDir);

                string filePath = Path.Combine(screenshotsDir, $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:ddMMyyyy_HHmmss}.png");

                File.WriteAllBytes(filePath, screenshot.AsByteArray);

                TestContext.Progress.WriteLine($"🔍 Screenshot saved: {filePath}");
                driver.Quit();
            }
        }
    }
}
