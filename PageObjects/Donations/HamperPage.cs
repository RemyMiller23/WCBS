using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.PageObjects.Donations
{
    public class HamperPage
    {
        //DriverSetup
        private IWebDriver driver;
        public HamperPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.Name, Using = "batchNumber")]
        private IWebElement hamperNumber;
        
        [FindsBy(How = How.Name, Using = "serialNumber")]
        private IWebElement serialNumber;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='transactionNumber']")]
        private IList<IWebElement> transactionInputs;

        [FindsBy(How = How.Id, Using = "SaveAndReturn")]
        private IWebElement saveAndReturnButton;

        [FindsBy(How = How.Id, Using = "SaveAndDefer")]
        private IWebElement saveAndDeferButton;

        [FindsBy(How = How.Id, Using = "SaveAndContinue")]
        private IWebElement saveAndContinueButton;

        [FindsBy(How = How.Id, Using = "inputSerial")]
        private IWebElement serialCode;

        [FindsBy(How = How.Id, Using = "inputPin")]
        private IWebElement pinCode;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' OK ']]")]
        private IWebElement okButton;

        [FindsBy(How = How.CssSelector, Using = "div[aria-label='Success']")]
        private IWebElement successToast;


        //Methods
        public void linkHamper()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string HamperCode = ConfigurationManager.AppSettings["HamperCode"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(hamperNumber));
            hamperNumber.SendKeys(HamperCode);
            wait.Until(ExpectedConditions.ElementToBeClickable(serialNumber));
            serialNumber.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            
            saveAndReturnButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
            

        }
    }
}

