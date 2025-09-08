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

namespace PulseDonations.PageObjects.Donations
{
    public class TestingPage
    {
        //DriverSetup
        private IWebDriver driver;
        public TestingPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement firstName;

        [FindsBy(How = How.Name, Using = "iD_Passport")]
        private IWebElement idNumber;

        [FindsBy(How = How.Name, Using = "surname")]
        private IWebElement surname;

        [FindsBy(How = How.Name, Using = "HB")]
        private IWebElement hemoglobin;

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

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='Pin']")]
        private IWebElement formPin;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' OK ']]")]
        private IWebElement okButton;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()='No']]")]
        private IWebElement noButton;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()='Yes']]")]
        private IWebElement yesButton;

        [FindsBy(How = How.CssSelector, Using = "div[aria-label='Success']")]
        private IWebElement successToast;




        //Methods
        public void updateExistingTestingInformation()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string Hemoglobin = ConfigurationManager.AppSettings["Hemoglobin"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            wait.Until(ExpectedConditions.ElementToBeClickable(hemoglobin));
            hemoglobin.SendKeys(Hemoglobin);
            firstName.Click();

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
        public void updatePostiveTestingInformation()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string Hemoglobin = ConfigurationManager.AppSettings["Hemoglobin"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            wait.Until(driver =>
            {string value = firstName.GetAttribute("value");
                return !string.IsNullOrEmpty(value);
            });

            string pulseFirstName = firstName.GetAttribute("value");
            string pulseSurname = surname.GetAttribute("value");
            string pulseIDNumber = idNumber.GetAttribute("value");

            Assert.AreEqual(FirstName, pulseFirstName);
            Assert.AreEqual(Surname, pulseSurname);
            Assert.AreEqual(IDNumber, pulseIDNumber);

            hemoglobin.SendKeys(Hemoglobin);
            firstName.Click();

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

        public void negativeOtherDeferralTestingInformation()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string Hemoglobin = ConfigurationManager.AppSettings["Hemoglobin"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            wait.Until(driver =>
            {
                string value = firstName.GetAttribute("value");
                return !string.IsNullOrEmpty(value);
            });

            string pulseFirstName = firstName.GetAttribute("value");
            string pulseSurname = surname.GetAttribute("value");
            string pulseIDNumber = idNumber.GetAttribute("value");

            Assert.AreEqual(FirstName, pulseFirstName);
            Assert.AreEqual(Surname, pulseSurname);
            Assert.AreEqual(IDNumber, pulseIDNumber);

            hemoglobin.SendKeys(Hemoglobin);
            firstName.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndDeferButton));

            saveAndDeferButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            formPin.SendKeys(TechPin);
            okButton.Click();

        }

        public void negativeLowHBDeferralTestingInformation()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string OutlierHemoglobin = ConfigurationManager.AppSettings["OutlierHemoglobin"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            wait.Until(driver =>
            {
                string value = firstName.GetAttribute("value");
                return !string.IsNullOrEmpty(value);
            });

            string pulseFirstName = firstName.GetAttribute("value");
            string pulseSurname = surname.GetAttribute("value");
            string pulseIDNumber = idNumber.GetAttribute("value");

            Assert.AreEqual(FirstName, pulseFirstName);
            Assert.AreEqual(Surname, pulseSurname);
            Assert.AreEqual(IDNumber, pulseIDNumber);

            hemoglobin.SendKeys(OutlierHemoglobin);
            firstName.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(noButton));
                noButton.Click();
            }
            catch (WebDriverTimeoutException) 
            { 
            
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndDeferButton));

            saveAndDeferButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            formPin.SendKeys(TechPin);
            okButton.Click();

        }
    }
}
