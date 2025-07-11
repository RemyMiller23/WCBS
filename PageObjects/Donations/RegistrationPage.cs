using Bogus.DataSets;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PulseDonations.Utilities;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.PageObjects.Donations
{
    public class RegistrationPage
    {
        //DriverSetup
        private IWebDriver driver;
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.Name, Using = "iD_Passport")]
        private IWebElement idNumber;

        [FindsBy(How = How.Name, Using = "address_Line1")]
        private IWebElement addressLine1;

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement email;

        [FindsBy(How = How.CssSelector, Using = "[aria-label='Title']")]
        private IWebElement titleButton;

        [FindsBy(How = How.XPath, Using = "//span[text()=' MR ']")]
        private IWebElement mr;

        [FindsBy(How = How.XPath, Using = "//span[text()=' MS ']")]
        private IWebElement mrs;

        [FindsBy(How = How.Name, Using = "address_Line2")]
        private IWebElement addressLine2;

        [FindsBy(How = How.Name, Using = "contact_Number")]
        private IWebElement contactNumber;

        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement firstName;

        [FindsBy(How = How.CssSelector, Using = "[aria-label='Language']")]
        private IWebElement languageButton;

        [FindsBy(How = How.XPath, Using = "//span[text()=' English ']")]
        private IWebElement english;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Afrikaans ']")]
        private IWebElement afrikaans;

        [FindsBy(How = How.Name, Using = "address_Line3")]
        private IWebElement addressLine3;

        [FindsBy(How = How.Name, Using = "cell_Number")]
        private IWebElement cellNumber;

        [FindsBy(How = How.Name, Using = "middle_Name")]
        private IWebElement middleName;

        [FindsBy(How = How.CssSelector, Using = "[aria-label='Sex at Birth']")]
        private IWebElement sexAtBirthButton;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Male ']")]
        private IWebElement male;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Female ']")]
        private IWebElement female;

        [FindsBy(How = How.Name, Using = "address_Line4")]
        private IWebElement addressLine4;

        [FindsBy(How = How.CssSelector, Using = "[aria-label='Preferred Panel']")]
        private IWebElement preferredPanelButton;

        [FindsBy(How = How.XPath, Using = "//span[text()=' AJJ - REAGENTS ']")]
        private IWebElement ajjPanel;

        [FindsBy(How = How.Name, Using = "surname")]
        private IWebElement surname;

        [FindsBy(How = How.Name, Using = "postal_Code")]
        private IWebElement postalCode;

        [FindsBy(How = How.Name, Using = "communication_Method_Email")]
        private IWebElement emailCheckbox;

        [FindsBy(How = How.Name, Using = "communication_Method_SMS")]
        private IWebElement smsCheckbox;

        [FindsBy(How = How.Name, Using = "communication_Method_Phone")]
        private IWebElement phoneCheckbox;

        [FindsBy(How = How.Name, Using = "communication_Method_Whatsapp")]
        private IWebElement whatsappCheckbox;

        [FindsBy(How = How.CssSelector, Using = "[aria-label='Stats Code']")]
        private IWebElement statusCodeButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='White ']")]
        private IWebElement white;

        [FindsBy(How = How.XPath, Using = "//span[text()='Black ']")]
        private IWebElement black;

        [FindsBy(How = How.XPath, Using = "//span[text()='Coloured ']")]
        private IWebElement coloured;

        [FindsBy(How = How.XPath, Using = "//span[text()='Asian ']")]
        private IWebElement asian;

        [FindsBy(How = How.Name, Using = "popi_compliance")]
        private IWebElement popiComplianceCheckbox;

        [FindsBy(How = How.Name, Using = "hseq")]
        private IWebElement hardcopySEQCheckbox;

        [FindsBy(How = How.CssSelector, Using = ".cancel")]
        private IWebElement cancelButton;

        [FindsBy(How = How.Id, Using = "SaveAndReturn")]
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

        [FindsBy(How = How.XPath, Using = "//mat-error[contains(text(), 'Invalid ID Number.')]")]
        private IWebElement idError;

        [FindsBy(How = How.CssSelector, Using = "div[aria-label='Success']")]
        private IWebElement successToast;











        //Methods
       
        public void updateMalePersonalInformation()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            WebDriverWait errorWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string ID = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string MiddleName = ConfigurationManager.AppSettings["MiddleName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string Email = ConfigurationManager.AppSettings["Email"];
            string PhoneNumber = ConfigurationManager.AppSettings["PhoneNumber"];
            string StreetAddress = ConfigurationManager.AppSettings["StreetAddress"];
            string Suburb = ConfigurationManager.AppSettings["Suburb"];
            string PostalCode = ConfigurationManager.AppSettings["PostalCode"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            idNumber.SendKeys(ID);
            addressLine1.SendKeys(StreetAddress);
            email.SendKeys(Email);


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-error[contains(text(), 'ID Number already in use.')]")));
                TestContext.Progress.WriteLine("ID error exists");
                ScreenshotHelper.CaptureScreenshot(driver);
                Assert.Fail("Duplicate ID used");
            }

            catch (WebDriverTimeoutException)
            {

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


            titleButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(mr));
            mr.Click();
            addressLine2.SendKeys(Suburb);
            contactNumber.SendKeys(PhoneNumber);

            firstName.SendKeys(FirstName);
            languageButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(english));
            english.Click();
            addressLine3.SendKeys("Cape Town");
            cellNumber.SendKeys(PhoneNumber);


            middleName.SendKeys(MiddleName);
            sexAtBirthButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(male));
            male.Click();
            addressLine4.SendKeys("South Africa");
            preferredPanelButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ajjPanel));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ajjPanel.Click();

            surname.SendKeys(Surname);
            postalCode.SendKeys(PostalCode);

            emailCheckbox.Click();
            smsCheckbox.Click();
            phoneCheckbox.Click();
            whatsappCheckbox.Click();

            statusCodeButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(black));
            black.Click();

            popiComplianceCheckbox.Click();
            hardcopySEQCheckbox.Click();

            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-label[contains(text(), 'Serial Number is in use by another Donor')]")));
                TestContext.Progress.WriteLine("Serial error exists");
                ScreenshotHelper.CaptureScreenshot(driver);
                Assert.Fail("Duplicate Serial Number used");
            }

            catch (WebDriverTimeoutException)
            {

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
            


        }

        public void updateFemalePersonalInformation()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            WebDriverWait errorWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string ID = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string MiddleName = ConfigurationManager.AppSettings["MiddleName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string Email = ConfigurationManager.AppSettings["Email"];
            string PhoneNumber = ConfigurationManager.AppSettings["PhoneNumber"];
            string StreetAddress = ConfigurationManager.AppSettings["StreetAddress"];
            string Suburb = ConfigurationManager.AppSettings["Suburb"];
            string PostalCode = ConfigurationManager.AppSettings["PostalCode"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            idNumber.SendKeys(ID);
            addressLine1.SendKeys(StreetAddress);
            email.SendKeys(Email);


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-error[contains(text(), 'ID Number already in use.')]")));
                TestContext.Progress.WriteLine("ID error exists");
                ScreenshotHelper.CaptureScreenshot(driver);
                Assert.Fail("Duplicate ID used");
            }

            catch (WebDriverTimeoutException)
            {

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


            titleButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(mrs));
            mrs.Click();
            addressLine2.SendKeys(Suburb);
            contactNumber.SendKeys(PhoneNumber);

            firstName.SendKeys(FirstName);
            languageButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(afrikaans));
            afrikaans.Click();
            addressLine3.SendKeys("Cape Town");
            cellNumber.SendKeys(PhoneNumber);


            middleName.SendKeys(MiddleName);
            sexAtBirthButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(female));
            female.Click();
            addressLine4.SendKeys("South Africa");
            preferredPanelButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ajjPanel));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ajjPanel.Click();

            surname.SendKeys(Surname);
            postalCode.SendKeys(PostalCode);

            emailCheckbox.Click();
            smsCheckbox.Click();
            phoneCheckbox.Click();
            whatsappCheckbox.Click();

            statusCodeButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(coloured));
            coloured.Click();

            popiComplianceCheckbox.Click();
            hardcopySEQCheckbox.Click();

            saveAndContinueButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-label[contains(text(), 'Serial Number is in use by another Donor')]")));
                TestContext.Progress.WriteLine("Serial error exists");
                ScreenshotHelper.CaptureScreenshot(driver);
                Assert.Fail("Duplicate Serial Number used");
            }

            catch (WebDriverTimeoutException)
            {

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
            
        }
    }
}
