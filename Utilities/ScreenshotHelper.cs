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
            string selectedEnvKey = System.Configuration.ConfigurationManager.AppSettings["selectedEnv"];

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            string solutionDir = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
            string dateFolder = DateTime.Now.ToString("dd-MM-yyyy");
            string screenshotsDir = Path.Combine(solutionDir, "Screenshots", dateFolder);
            Directory.CreateDirectory(screenshotsDir);

            string filePath = Path.Combine(screenshotsDir, $"{selectedEnvKey}_{TestContext.CurrentContext.Test.Name}_{DateTime.Now:ddMMyyyy_HHmmss}.png");

            File.WriteAllBytes(filePath, screenshot.AsByteArray);

            TestContext.Progress.WriteLine($"🔍 Screenshot saved: {filePath}");
        }
    }
}
