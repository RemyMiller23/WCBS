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
    public class DonationPage
    {
        //DriverSetup
        private IWebDriver driver;
        public DonationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='Setup']")]
        private IWebElement setupIcon;
        
        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='Remove Needle']")]
        private IWebElement removeNeedleIcon;

        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='Samples']")]
        private IWebElement samplesIcon;

        [FindsBy(How = How.Id, Using = "cleanBed")]
        private IWebElement cleanBedIcon;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='Pin']")]
        private IWebElement bedPin;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' Confirm Bed Cleaned ']]")]
        private IWebElement confirmBedCleanedButto;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='hemoFlowID']")]
        private IWebElement hemoFlowID;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='haemoniticsID']")]
        private IWebElement haemoniticsID;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='SerialNumber']")] 
        private IWebElement formSerialNumber;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='startTime']")]
        private IWebElement startTime;

        [FindsBy(How = How.CssSelector, Using = "mat-icon[mattooltip='Open Scanner']")]
        private IWebElement startTimeIcon;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='endTime']")]
        private IWebElement endTime;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='hemoflowWeight']")]
        private IWebElement hemoFlowWeight;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='plasmaProductVolume']")]
        private IWebElement plasmaProductVolume;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='Pin']")]
        private IWebElement formPin;

        [FindsBy(How = How.Name, Using = "hemoflowId")]
        private IWebElement donationHemoFlowID;

        [FindsBy(How = How.Name, Using = "hemoflowWeight")]
        private IWebElement donationHemoFlowWeight;

        [FindsBy(How = How.Name, Using = "haemoneticsId")]
        private IWebElement donationHaemoneticsID;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='SerialNumber']")]
        private IWebElement sampleSerialNumber;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='Pin']")]
        private IWebElement samplePinCode;

        [FindsBy(How = How.Name, Using = "sample_tube")]
        private IList<IWebElement> sampleTubeSerials;

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

        [FindsBy(How = How.CssSelector, Using = "div[aria-label='Success']")]
        private IWebElement bedToast;


        //Methods
        public void donateHemoFlowBlood()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string HemoFlowID = ConfigurationManager.AppSettings["HemoFlowID"];
            string HeomFlowWeight = ConfigurationManager.AppSettings["HemoFlowWeight"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"]; 

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(setupIcon));
            setupIcon.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hemoFlowID));
            hemoFlowID.SendKeys(HemoFlowID);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(SerialNumber).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Enter).Perform();
            //actions.SendKeys(Keys.Tab).Perform();
            
            //for (int i = 0; i < 13; i++)
            //{ 
            //actions.SendKeys(Keys.Up).Perform();
            //}

            actions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(formPin));
            formPin.SendKeys(TechPin);
            okButton.Click();

            wait.Until(driver =>
            {
                string value = donationHemoFlowID.GetAttribute("value");
                return !string.IsNullOrEmpty(value);
            });
            string DonationHemoFlowID = donationHemoFlowID.GetAttribute("value");
            Assert.AreEqual(HemoFlowID, DonationHemoFlowID );

            wait.Until(ExpectedConditions.ElementToBeClickable(removeNeedleIcon));
            removeNeedleIcon.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(SerialNumber).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Enter).Perform();
            //actions.SendKeys(Keys.Tab).Perform();
            //actions.SendKeys(Keys.Up).Perform();
            //Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(HeomFlowWeight).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(TechPin).Perform();
            okButton.Click();
            //wait.Until(ExpectedConditions.ElementToBeClickable(hemoFlowWeight)); //failing here consitently on piepline
            //hemoFlowWeight.SendKeys(HeomFlowWeight);
            //wait.Until(ExpectedConditions.ElementToBeClickable(formPin));
            //formPin.SendKeys(TechPin);

            wait.Until(driver =>
            {
                string value = donationHemoFlowWeight.GetAttribute("value");
                return !string.IsNullOrEmpty(value);
            });
            string DonationHemoFlowWeight = donationHemoFlowWeight.GetAttribute("value");
            Assert.AreEqual(HeomFlowWeight,DonationHemoFlowWeight);

            wait.Until(ExpectedConditions.ElementToBeClickable(cleanBedIcon));
            cleanBedIcon.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            wait.Until(ExpectedConditions.ElementToBeClickable(bedPin));
            bedPin.SendKeys(TechPin);
            wait.Until(ExpectedConditions.ElementToBeClickable(okButton));
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            //string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
            

        }

        public void donateSample()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string HemoFlowID = ConfigurationManager.AppSettings["HemoFlowID"];
            string HeomFlowWeight = ConfigurationManager.AppSettings["HemoFlowWeight"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(samplesIcon));
            samplesIcon.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            sampleSerialNumber.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            samplePinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(cleanBedIcon));
            cleanBedIcon.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            wait.Until(ExpectedConditions.ElementToBeClickable(bedPin));
            bedPin.SendKeys(TechPin);
            wait.Until(ExpectedConditions.ElementToBeClickable(okButton));
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            //string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);

        }

        public void donateHaemoneticsBlood()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string HemoFlowID = ConfigurationManager.AppSettings["HemoFlowID"];
            string HeomFlowWeight = ConfigurationManager.AppSettings["HemoFlowWeight"];
            string CurrentTime = ConfigurationManager.AppSettings["CurrentTime"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(setupIcon));
            setupIcon.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(haemoniticsID));
            haemoniticsID.SendKeys(HemoFlowID);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(SerialNumber).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Enter).Perform();
            actions.SendKeys(Keys.Up).Perform();
            actions.SendKeys(Keys.Enter).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(formPin));
            formPin.SendKeys(TechPin);
            okButton.Click();

            wait.Until(driver =>
            {
                string value = donationHaemoneticsID.GetAttribute("value");
                return !string.IsNullOrEmpty(value);
            });
            string DonationHaemoneticsID = donationHaemoneticsID.GetAttribute("value");
            Assert.AreEqual(HemoFlowID, DonationHaemoneticsID);


            wait.Until(ExpectedConditions.ElementToBeClickable(plasmaProductVolume));
            plasmaProductVolume.SendKeys(HeomFlowWeight);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(HeomFlowWeight).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(CurrentTime).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(HeomFlowWeight).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(HeomFlowWeight).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys("1").Perform();

            wait.Until(ExpectedConditions.ElementToBeClickable(removeNeedleIcon));
            removeNeedleIcon.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(formPin));
            formPin.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(cleanBedIcon));
            cleanBedIcon.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            wait.Until(ExpectedConditions.ElementToBeClickable(bedPin));
            bedPin.SendKeys(TechPin);
            wait.Until(ExpectedConditions.ElementToBeClickable(okButton));
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            //string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }
    }
}
