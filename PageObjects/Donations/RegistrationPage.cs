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
        [FindsBy(How = How.Name, Using = "foreign_Donor")]
        private IWebElement foreignDonorCheckbox;

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

        [FindsBy(How = How.Name, Using = "dob")]
        private IWebElement dateOfBirth;

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

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'AJJ')]")]
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

        [FindsBy(How = How.Id, Using = "SaveAndContinue")]
        private IWebElement existingSaveAndContinueButton;

        [FindsBy(How = How.Id, Using = "inputSerial")]
        private IWebElement serialCode;

        [FindsBy(How = How.Id, Using = "inputPin")]
        private IWebElement pinCode;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' OK ']]")]
        private IWebElement okButton;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' Authorise ']]")]
        private IWebElement authoriseButton;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='reason']")]
        private IWebElement reason;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()='Reinstate inactive donor']]")]
        private IWebElement reasonOption;

        [FindsBy(How = How.CssSelector, Using = "textarea[formcontrolname='comment']")]
        private IWebElement authoriseComment;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='Pin']")]
        private IWebElement authorisePin;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()='OK']]")]
        private IWebElement authoriseOkButton;

        [FindsBy(How = How.XPath, Using = "//mat-error[contains(text(), 'ID Number.')]")]
        private IWebElement idError;

        [FindsBy(How = How.CssSelector, Using = "div[aria-label='Success']")]
        private IWebElement successToast;

        [FindsBy(How = How.XPath, Using = "//mat-select[@formcontrolname='gender']//span[contains(@class, 'mat-select-value-text')]//span")]
        private IWebElement selectedGender;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()='Yes']]")]
        private IWebElement yesButton;










        //Methods
        public void genderIdentification()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Random generator = new Random();

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("iD_Passport")));
                string DonorGender = selectedGender.Text;
                TestContext.Progress.WriteLine("Sex at Birth: " + DonorGender);

                if (DonorGender == "Male")
                {
                    TestContext.Progress.WriteLine("Male Donor");
                    double value = Math.Round(generator.NextDouble() * (14.5 - 13.5) + 13.5, 1);
                    string Hemoglobin = value.ToString("F1");
                    ConfigurationManager.AppSettings["Hemoglobin"] = Hemoglobin;
                    TestContext.Progress.WriteLine(Hemoglobin);
                    updateMaleExistingDonor();
                }
                else
                {
                    TestContext.Progress.WriteLine("Female Donor");
                    double value = Math.Round(generator.NextDouble() * (13.5 - 12.5) + 12.5, 1);
                    string Hemoglobin = value.ToString("F1");
                    ConfigurationManager.AppSettings["Hemoglobin"] = Hemoglobin;
                    TestContext.Progress.WriteLine(Hemoglobin);
                    updateFemaleExistingDonor();
                }

                ConfigurationManager.AppSettings["DonorGender"] = DonorGender;
            }

            catch (NoSuchElementException)
            {
                TestContext.Progress.WriteLine("No Existing Donor information");
                Assert.Fail("No Existing Donor information loaded due to slow server speeds");
            }
            
        }

        public void updateNewDonorInformation()
        {
            //GlobalVariables & Waits
            Random random = new Random();
            string DonorGender = ConfigurationManager.AppSettings["DonorGender"];


            if (DonorGender == "0")
            {
                TestContext.Progress.WriteLine("Male Donor");
                updateMalePersonalInformation();
            }
            else
            {
                TestContext.Progress.WriteLine("Female Donor");
                updateFemalePersonalInformation();
            }
        }

        public void updateForeignDonorInformation()
        {
            //GlobalVariables & Waits
            Random random = new Random();
            string DonorGender = ConfigurationManager.AppSettings["DonorGender"];


            if (DonorGender == "0")
            {
                TestContext.Progress.WriteLine("Male Donor");
                updateMaleForeignDonor();
            }
            else
            {
                TestContext.Progress.WriteLine("Female Donor");
                updateFemaleForeignDonor();
            }
        }

        // Existing Donors
        public void updateMaleExistingDonor()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            WebDriverWait errorWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string PhoneNumber = ConfigurationManager.AppSettings["PhoneNumber"];
            string LandlineNumber = ConfigurationManager.AppSettings["LandlineNumber"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(hardcopySEQCheckbox));
                hardcopySEQCheckbox.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(cellNumber));
                cellNumber.Clear();
                cellNumber.SendKeys(PhoneNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(contactNumber));
                contactNumber.Clear();
                contactNumber.SendKeys(LandlineNumber);
            }

            catch (ElementClickInterceptedException)
            {
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
                    wait.Until(ExpectedConditions.ElementToBeClickable(yesButton));
                    yesButton.Click();
                    wait.Until(ExpectedConditions.ElementToBeClickable(hardcopySEQCheckbox));
                    hardcopySEQCheckbox.Click();
                    wait.Until(ExpectedConditions.ElementToBeClickable(cellNumber));
                    cellNumber.Clear();
                    cellNumber.SendKeys(PhoneNumber);
                    wait.Until(ExpectedConditions.ElementToBeClickable(contactNumber));
                    contactNumber.Clear();
                    contactNumber.SendKeys(LandlineNumber);
                }
                catch (WebDriverTimeoutException)
                {
                    Assert.Fail();
                }
            }


            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(existingSaveAndContinueButton));
                existingSaveAndContinueButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(authoriseButton));
                authoriseButton.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
                wait.Until(ExpectedConditions.ElementToBeClickable(reason));
                reason.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(reasonOption));
                reasonOption.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(authoriseComment));
                authoriseComment.SendKeys("Test");
                wait.Until(ExpectedConditions.ElementToBeClickable(authorisePin));
                authorisePin.SendKeys(TechPin);
                wait.Until(ExpectedConditions.ElementToBeClickable(authoriseOkButton));
                authoriseOkButton.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(existingSaveAndContinueButton));
                existingSaveAndContinueButton.Click();
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-error[contains(text(), 'This field is required')]")));
                TestContext.Progress.WriteLine("ID data sync issue");
                Assert.Fail("ID Data sync issue where no ID is found for existing Donor");
            }

            catch (WebDriverTimeoutException)
            {

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

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

        public void updateFemaleExistingDonor()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            WebDriverWait errorWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string PhoneNumber = ConfigurationManager.AppSettings["PhoneNumber"];
            string LandlineNumber = ConfigurationManager.AppSettings["LandlineNumber"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(hardcopySEQCheckbox));
                hardcopySEQCheckbox.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(cellNumber));
                cellNumber.Clear();
                cellNumber.SendKeys(PhoneNumber);
                wait.Until(ExpectedConditions.ElementToBeClickable(contactNumber));
                contactNumber.Clear();
                contactNumber.SendKeys(LandlineNumber);
            }

            catch (ElementClickInterceptedException)
            {
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
                    wait.Until(ExpectedConditions.ElementToBeClickable(yesButton));
                    yesButton.Click();
                    wait.Until(ExpectedConditions.ElementToBeClickable(hardcopySEQCheckbox));
                    hardcopySEQCheckbox.Click();
                    wait.Until(ExpectedConditions.ElementToBeClickable(cellNumber));
                    cellNumber.Clear();
                    cellNumber.SendKeys(PhoneNumber);
                    wait.Until(ExpectedConditions.ElementToBeClickable(contactNumber));
                    contactNumber.Clear();
                    contactNumber.SendKeys(LandlineNumber);
                }
                catch (WebDriverTimeoutException)
                {
                    Assert.Fail();
                }

            }

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(existingSaveAndContinueButton));
                existingSaveAndContinueButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(authoriseButton));
                authoriseButton.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
                wait.Until(ExpectedConditions.ElementToBeClickable(reason));
                reason.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(reasonOption));
                reasonOption.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(authoriseComment));
                authoriseComment.SendKeys("Test");
                wait.Until(ExpectedConditions.ElementToBeClickable(authorisePin));
                authorisePin.SendKeys(TechPin);
                wait.Until(ExpectedConditions.ElementToBeClickable(authoriseOkButton));
                authoriseOkButton.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(existingSaveAndContinueButton));
                existingSaveAndContinueButton.Click();
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-error[contains(text(), 'This field is required')]")));
                TestContext.Progress.WriteLine("ID data sync issue");
                Assert.Fail("ID Data sync issue where no ID is found for existing Donor");
            }

            catch (WebDriverTimeoutException)
            {

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

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

        // New Donors
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
            string LandlineNumber = ConfigurationManager.AppSettings["LandlineNumber"];
            string StreetAddress = ConfigurationManager.AppSettings["StreetAddress"];
            string Suburb = ConfigurationManager.AppSettings["Suburb"];
            string PostalCode = ConfigurationManager.AppSettings["PostalCode"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            wait.Until(ExpectedConditions.ElementToBeClickable(idNumber));
            idNumber.SendKeys(ID);
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine1));
            addressLine1.SendKeys(StreetAddress);
            wait.Until(ExpectedConditions.ElementToBeClickable(email));
            email.SendKeys(Email);

            wait.Until(ExpectedConditions.ElementToBeClickable(titleButton));
            titleButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(mr));
            mr.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine2));
            addressLine2.SendKeys(Suburb);
            wait.Until(ExpectedConditions.ElementToBeClickable(contactNumber));
            contactNumber.SendKeys(LandlineNumber);

            wait.Until(ExpectedConditions.ElementToBeClickable(firstName));
            firstName.SendKeys(FirstName);
            wait.Until(ExpectedConditions.ElementToBeClickable(languageButton));
            languageButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(english));
            english.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine3));
            addressLine3.SendKeys("Cape Town");
            wait.Until(ExpectedConditions.ElementToBeClickable(cellNumber));
            cellNumber.SendKeys(PhoneNumber);

            wait.Until(ExpectedConditions.ElementToBeClickable(middleName));
            middleName.SendKeys(MiddleName);
            wait.Until(ExpectedConditions.ElementToBeClickable(sexAtBirthButton));
            sexAtBirthButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(male));
            male.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine4));
            addressLine4.SendKeys("South Africa");
            wait.Until(ExpectedConditions.ElementToBeClickable(preferredPanelButton));
            preferredPanelButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ajjPanel));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ajjPanel.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(surname));
            surname.SendKeys(Surname);
            wait.Until(ExpectedConditions.ElementToBeClickable(postalCode));
            postalCode.SendKeys(PostalCode);

            wait.Until(ExpectedConditions.ElementToBeClickable(emailCheckbox));
            emailCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(smsCheckbox));
            smsCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(phoneCheckbox));
            phoneCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(whatsappCheckbox));
            whatsappCheckbox.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(statusCodeButton));
            statusCodeButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(black));
            black.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(popiComplianceCheckbox));
            popiComplianceCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hardcopySEQCheckbox));
            hardcopySEQCheckbox.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-error[contains(text(), 'ID Number')]")));
                TestContext.Progress.WriteLine("ID error exists");
                Assert.Fail("Duplicate ID used");
            }

            catch (WebDriverTimeoutException)
            {

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
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
            string LandlineNumber = ConfigurationManager.AppSettings["LandlineNumber"];
            string StreetAddress = ConfigurationManager.AppSettings["StreetAddress"];
            string Suburb = ConfigurationManager.AppSettings["Suburb"];
            string PostalCode = ConfigurationManager.AppSettings["PostalCode"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            wait.Until(ExpectedConditions.ElementToBeClickable(idNumber));
            idNumber.SendKeys(ID);
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine1));
            addressLine1.SendKeys(StreetAddress);
            wait.Until(ExpectedConditions.ElementToBeClickable(email));
            email.SendKeys(Email);

            wait.Until(ExpectedConditions.ElementToBeClickable(titleButton));
            titleButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(mrs));
            mrs.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine2));
            addressLine2.SendKeys(Suburb);
            wait.Until(ExpectedConditions.ElementToBeClickable(contactNumber));
            contactNumber.SendKeys(LandlineNumber);

            wait.Until(ExpectedConditions.ElementToBeClickable(firstName));
            firstName.SendKeys(FirstName);
            wait.Until(ExpectedConditions.ElementToBeClickable(languageButton));
            languageButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(afrikaans));
            afrikaans.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine3));
            addressLine3.SendKeys("Cape Town");
            wait.Until(ExpectedConditions.ElementToBeClickable(cellNumber));
            cellNumber.SendKeys(PhoneNumber);

            wait.Until(ExpectedConditions.ElementToBeClickable(middleName));
            middleName.SendKeys(MiddleName);
            wait.Until(ExpectedConditions.ElementToBeClickable(sexAtBirthButton));
            sexAtBirthButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(female));
            female.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine4));
            addressLine4.SendKeys("South Africa");
            wait.Until(ExpectedConditions.ElementToBeClickable(preferredPanelButton));
            preferredPanelButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ajjPanel));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ajjPanel.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(surname));
            surname.SendKeys(Surname);
            wait.Until(ExpectedConditions.ElementToBeClickable(postalCode));
            postalCode.SendKeys(PostalCode);

            wait.Until(ExpectedConditions.ElementToBeClickable(emailCheckbox));
            emailCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(smsCheckbox));
            smsCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(phoneCheckbox));
            phoneCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(whatsappCheckbox));
            whatsappCheckbox.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(statusCodeButton));
            statusCodeButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(coloured));
            coloured.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(popiComplianceCheckbox));
            popiComplianceCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hardcopySEQCheckbox));
            hardcopySEQCheckbox.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-error[contains(text(), 'ID Number')]")));
                TestContext.Progress.WriteLine("ID error exists");
                Assert.Fail("Duplicate ID used");
            }

            catch (WebDriverTimeoutException)
            {
                
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
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

        //Foreigners
        public void updateMaleForeignDonor()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            WebDriverWait errorWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string ID = ConfigurationManager.AppSettings["IDNumber"];
            string DOB = ConfigurationManager.AppSettings["DOB"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string MiddleName = ConfigurationManager.AppSettings["MiddleName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string Email = ConfigurationManager.AppSettings["Email"];
            string PhoneNumber = ConfigurationManager.AppSettings["PhoneNumber"];
            string LandlineNumber = ConfigurationManager.AppSettings["LandlineNumber"];
            string StreetAddress = ConfigurationManager.AppSettings["StreetAddress"];
            string Suburb = ConfigurationManager.AppSettings["Suburb"];
            string PostalCode = ConfigurationManager.AppSettings["PostalCode"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            wait.Until(ExpectedConditions.ElementToBeClickable(foreignDonorCheckbox));
            foreignDonorCheckbox.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            wait.Until(ExpectedConditions.ElementToBeClickable(idNumber));
            idNumber.SendKeys(ID);
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine1));
            addressLine1.SendKeys(StreetAddress);
            wait.Until(ExpectedConditions.ElementToBeClickable(email));
            email.SendKeys(Email);

            wait.Until(ExpectedConditions.ElementToBeClickable(titleButton));
            titleButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(mr));
            mr.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(dateOfBirth));
            dateOfBirth.SendKeys(DOB);
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine2));
            addressLine2.SendKeys(Suburb);

            wait.Until(ExpectedConditions.ElementToBeClickable(firstName));
            firstName.SendKeys(FirstName);
            wait.Until(ExpectedConditions.ElementToBeClickable(languageButton));
            languageButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(english));
            english.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine3));
            addressLine3.SendKeys("Cape Town");
            wait.Until(ExpectedConditions.ElementToBeClickable(cellNumber));
            cellNumber.SendKeys(PhoneNumber);

            wait.Until(ExpectedConditions.ElementToBeClickable(middleName));
            middleName.SendKeys(MiddleName);
            wait.Until(ExpectedConditions.ElementToBeClickable(sexAtBirthButton));
            sexAtBirthButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(male));
            male.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine4));
            addressLine4.SendKeys("South Africa");
            wait.Until(ExpectedConditions.ElementToBeClickable(preferredPanelButton));
            preferredPanelButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ajjPanel));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ajjPanel.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(surname));
            surname.SendKeys(Surname);
            wait.Until(ExpectedConditions.ElementToBeClickable(postalCode));
            postalCode.SendKeys(PostalCode);

            wait.Until(ExpectedConditions.ElementToBeClickable(emailCheckbox));
            emailCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(smsCheckbox));
            smsCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(phoneCheckbox));
            phoneCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(whatsappCheckbox));
            whatsappCheckbox.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(statusCodeButton));
            statusCodeButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(black));
            black.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(popiComplianceCheckbox));
            popiComplianceCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hardcopySEQCheckbox));
            hardcopySEQCheckbox.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-error[contains(text(), 'ID Number')]")));
                TestContext.Progress.WriteLine("ID error exists");
                Assert.Fail("Duplicate ID used");
            }

            catch (WebDriverTimeoutException)
            {

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
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

        public void updateFemaleForeignDonor()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            WebDriverWait errorWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string ID = ConfigurationManager.AppSettings["IDNumber"];
            string DOB = ConfigurationManager.AppSettings["DOB"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string MiddleName = ConfigurationManager.AppSettings["MiddleName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string Email = ConfigurationManager.AppSettings["Email"];
            string PhoneNumber = ConfigurationManager.AppSettings["PhoneNumber"];
            string LandlineNumber = ConfigurationManager.AppSettings["LandlineNumber"];
            string StreetAddress = ConfigurationManager.AppSettings["StreetAddress"];
            string Suburb = ConfigurationManager.AppSettings["Suburb"];
            string PostalCode = ConfigurationManager.AppSettings["PostalCode"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            wait.Until(ExpectedConditions.ElementToBeClickable(foreignDonorCheckbox));
            foreignDonorCheckbox.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            wait.Until(ExpectedConditions.ElementToBeClickable(idNumber));
            idNumber.SendKeys(ID);
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine1));
            addressLine1.SendKeys(StreetAddress);
            wait.Until(ExpectedConditions.ElementToBeClickable(email));
            email.SendKeys(Email);

            wait.Until(ExpectedConditions.ElementToBeClickable(titleButton));
            titleButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(mrs));
            mrs.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(dateOfBirth));
            dateOfBirth.SendKeys(DOB);
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine2));
            addressLine2.SendKeys(Suburb);

            wait.Until(ExpectedConditions.ElementToBeClickable(firstName));
            firstName.SendKeys(FirstName);
            wait.Until(ExpectedConditions.ElementToBeClickable(languageButton));
            languageButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(afrikaans));
            afrikaans.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine3));
            addressLine3.SendKeys("Cape Town");
            wait.Until(ExpectedConditions.ElementToBeClickable(cellNumber));
            cellNumber.SendKeys(PhoneNumber);

            wait.Until(ExpectedConditions.ElementToBeClickable(middleName));
            middleName.SendKeys(MiddleName);
            wait.Until(ExpectedConditions.ElementToBeClickable(sexAtBirthButton));
            sexAtBirthButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(female));
            female.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addressLine4));
            addressLine4.SendKeys("South Africa");
            wait.Until(ExpectedConditions.ElementToBeClickable(preferredPanelButton));
            preferredPanelButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ajjPanel));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ajjPanel.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(surname));
            surname.SendKeys(Surname);
            wait.Until(ExpectedConditions.ElementToBeClickable(postalCode));
            postalCode.SendKeys(PostalCode);

            wait.Until(ExpectedConditions.ElementToBeClickable(emailCheckbox));
            emailCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(smsCheckbox));
            smsCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(phoneCheckbox));
            phoneCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(whatsappCheckbox));
            whatsappCheckbox.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(statusCodeButton));
            statusCodeButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(coloured));
            coloured.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(popiComplianceCheckbox));
            popiComplianceCheckbox.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hardcopySEQCheckbox));
            hardcopySEQCheckbox.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-error[contains(text(), 'ID Number')]")));
                TestContext.Progress.WriteLine("ID error exists");
                Assert.Fail("Duplicate ID used");
            }

            catch (WebDriverTimeoutException)
            {

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndContinueButton));
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
