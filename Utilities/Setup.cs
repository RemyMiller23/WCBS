using AngleSharp;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Client;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using PulseDonations.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace PulseDonations.Utilities
{
    public class Setup
    {
        //Setup for all cases
        public IWebDriver driver;
        public PageObjectManager POM;
        [SetUp]

        public void StartBrowser()

        {
            String globalBrowserName = ConfigurationManager.AppSettings["browser"];
            BrowserSelector(globalBrowserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Url = "https://spulseqa.wpbts.org.za/login/authenticate";
            string FE = driver.CurrentWindowHandle;
            ConfigurationManager.AppSettings["AviserUI"] = FE;
            POM = new PageObjectManager(driver);
            POM.InitializePageObjects();
        }


        public IWebDriver getDriver()
        {
            return driver;
        }

        public void BrowserSelector(string browserName)
        {

            var FOptions = new FirefoxOptions();
            FOptions.PageLoadStrategy = PageLoadStrategy.Eager;

            var COptions = new ChromeOptions();
            COptions.PageLoadStrategy = PageLoadStrategy.Eager;

            var EOptions = new EdgeOptions();
            EOptions.PageLoadStrategy = PageLoadStrategy.Eager;




            switch (browserName)
            {

                case "FireFox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver(FOptions);
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(COptions);
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver(EOptions);
                    break;

            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenshotHelper.CaptureScreenshot(driver);
            }

            if (driver != null)
            {
                try
                {
                    driver.Quit();
                    driver.Dispose();
                }
                catch (Exception ex)
                {
                    TestContext.Progress.WriteLine("Error closing browser: " + ex.Message);
                }
            }
        }


    }
}