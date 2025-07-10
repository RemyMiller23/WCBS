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

namespace PulseDonations.PageObjects.Hamper
{
    public class LinkHamperPage
    {
        //DriverSetup
        private IWebDriver driver;
        public LinkHamperPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.CssSelector, Using = ".button1")]
        private IWebElement createNewDonorButton;

        [FindsBy(How = How.Name, Using = "batchSerial")]
        private IWebElement hamperNumber;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Link Hamper Number ']")]
        private IWebElement linkHamperButton;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='batchSerialNumber'] input")]
        private IList<IWebElement> dataLabels;





        //Methods
        public void linkNewHamper()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));


            //Generate Hamper Code
            Random generator = new Random();
            string randSerialNumber = generator.Next(10000000, 99999999).ToString("D8");
            string HamperCode = randSerialNumber;
            ConfigurationManager.AppSettings["HamperCode"] = HamperCode;
            TestContext.Progress.WriteLine(HamperCode);


            //Pulse Donations 
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-title-text")));
            hamperNumber.SendKeys(HamperCode);
            wait.Until(ExpectedConditions.ElementToBeClickable(linkHamperButton));
            linkHamperButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()=' Actions ']")));
            Thread.Sleep(TimeSpan.FromSeconds(10));

            string? TableHamperNumber = null;

            foreach (var cell in dataLabels)
            {
                if (cell.GetAttribute("value") == HamperCode)
                {
                    TableHamperNumber = cell.GetAttribute("value");
                    break;
                }
            }
            Assert.AreEqual(HamperCode, TableHamperNumber);
        }
    }
}


