using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PulseDonations.Utilities;
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
    public class LinkingPage
    {
        //DriverSetup
        private IWebDriver driver;
        public LinkingPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.XPath, Using = "//span[text()=' Donation Milestones ']")]
        private IWebElement donationsMilestonesTab;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Labelling ']")]
        private IWebElement labellingTab;

        [FindsBy(How = How.CssSelector, Using = ".mat-checkbox-layout")]
        private IWebElement issuedCheckbox;

        [FindsBy(How = How.Name, Using = "blood_bag")]
        private IWebElement bloodBagSerial;

        [FindsBy(How = How.Name, Using = "sample_tube")]
        private IList<IWebElement> sampleTubeSerials;

        [FindsBy(How = How.Id, Using = " Save & Return ")]
        private IWebElement saveAndReturnButton;

        [FindsBy(How = How.Id, Using = "SaveAndDefer")]
        private IWebElement saveAndDeferButton;

        [FindsBy(How = How.Id, Using = "SaveAndContine")]
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
        public void linkWBT()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(bloodBagSerial));
            bloodBagSerial.SendKeys(SerialNumber);

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[0]));
                sampleTubeSerials[0].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[1]));
                sampleTubeSerials[1].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[2]));
                sampleTubeSerials[2].SendKeys(SerialNumber);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(driver);
                Assert.Fail("sampleTubeSerials was not interactable: " + ex.Message);
            }
            
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            donationsMilestonesTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            issuedCheckbox.Click();


            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }

        public void linkBST1()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[0]));
                sampleTubeSerials[0].SendKeys(SerialNumber);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(driver);
                Assert.Fail("sampleTubeSerials was not interactable: " + ex.Message);
            }

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            donationsMilestonesTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            issuedCheckbox.Click();


            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);


        }

        public void linkBST3()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[0]));
                sampleTubeSerials[0].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[1]));
                sampleTubeSerials[1].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[2]));
                sampleTubeSerials[2].SendKeys(SerialNumber);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(driver);
                Assert.Fail("sampleTubeSerials was not interactable: " + ex.Message);
            }

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            donationsMilestonesTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            issuedCheckbox.Click();


            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);


        }

        public void linkBST4()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[0]));
                sampleTubeSerials[0].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[1]));
                sampleTubeSerials[1].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[2]));
                sampleTubeSerials[2].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[3]));
                sampleTubeSerials[3].SendKeys(SerialNumber);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(driver);
                Assert.Fail("sampleTubeSerials was not interactable: " + ex.Message);
            }

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            donationsMilestonesTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            issuedCheckbox.Click();


            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);


        }

        public void linkBST8()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[0]));
                sampleTubeSerials[0].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[1]));
                sampleTubeSerials[1].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[2]));
                sampleTubeSerials[2].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[3]));
                sampleTubeSerials[3].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[4]));
                sampleTubeSerials[4].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[5]));
                sampleTubeSerials[5].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[6]));
                sampleTubeSerials[6].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[7]));
                sampleTubeSerials[7].SendKeys(SerialNumber);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(driver);
                Assert.Fail("sampleTubeSerials was not interactable: " + ex.Message);
            }

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            donationsMilestonesTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            issuedCheckbox.Click();


            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);


        }

        public void linkTestOnly()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[0]));
                sampleTubeSerials[0].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[1]));
                sampleTubeSerials[1].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[2]));
                sampleTubeSerials[2].SendKeys(SerialNumber);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(driver);
                Assert.Fail("sampleTubeSerials was not interactable: " + ex.Message);
            }

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            donationsMilestonesTab.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);


        }

        public void linkASP()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            Thread.Sleep(TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(bloodBagSerial));
            bloodBagSerial.SendKeys(SerialNumber);

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[0]));
                sampleTubeSerials[0].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[1]));
                sampleTubeSerials[1].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[2]));
                sampleTubeSerials[2].SendKeys(SerialNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(sampleTubeSerials[3]));
                sampleTubeSerials[3].SendKeys(SerialNumber);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(driver);
                Assert.Fail("sampleTubeSerials was not interactable: " + ex.Message);
            }

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            donationsMilestonesTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            issuedCheckbox.Click();


            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);


        }
    }
}
