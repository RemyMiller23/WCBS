using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PulseDonations.Utilities;

namespace PulseDonations.PageObjects.Audit
{
    public class AuditPage
    {
        //DriverSetup
        private IWebDriver driver;
        public AuditPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='ScanSerial']")]
        private IWebElement serialNumber;

        [FindsBy(How = How.Name, Using = "donor_Code")]
        private IWebElement donorCode;
        
        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='Search']")]
        private IWebElement searchIcon;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='action']")]
        private IList<IWebElement> dataLabels;

        //[FindsBy(How = How.XPath, Using = "//div[contains(@class, 'mat-form-field-infix') and .//input[@placeholder='Category']]")]
        //private IWebElement packValue;




        //Methods
        public void auditHamperLinking()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string HamperCode = ConfigurationManager.AppSettings["HamperCode"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string Category = ConfigurationManager.AppSettings["Category"];
            string Pack = ConfigurationManager.AppSettings["Pack"];


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            serialNumber.SendKeys(SerialNumber);
            searchIcon.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            try
            {
                wait.Until(driver =>
                {
                    string value = donorCode.FindElement(By.XPath("..")).Text;
                    return !string.IsNullOrEmpty(value);
                });

                string PreDonorCode = donorCode.FindElement(By.XPath("..")).Text;
                string DonorCode = PreDonorCode.Replace("Donor Code", "").Trim();
                TestContext.Progress.WriteLine("Donor Code: " + DonorCode);
            }
            catch (WebDriverTimeoutException)
            {
                TestContext.Progress.WriteLine("Donor Code Did NOT Generate");
                ScreenshotHelper.CaptureScreenshot(driver);
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


            string? HamperStep = null;

            foreach (var cell in dataLabels)
            {
                if (cell.Text.Trim() == "Hamper")
                {
                    HamperStep = cell.Text.Trim();
                    break;
                }
            }

            //string auditHamperCode = hamperCode.GetAttribute("value");
            //TestContext.Progress.WriteLine("audit hamper code: "+auditHamperCode);
            Assert.That(HamperStep, Is.EqualTo("Hamper"));
        }
    }
}
