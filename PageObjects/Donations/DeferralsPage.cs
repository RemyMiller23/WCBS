using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.PageObjects.Donations
{
    public class DeferralsPage
    {
        //DriverSetup
        private IWebDriver driver;
        public DeferralsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.Name, Using = "//mat-checkbox[.//span[contains(text(),' Short Term ')]]//input[@type='checkbox']")]
        private IWebElement shorttermCheckbox;

        [FindsBy(How = How.Name, Using = "cbMalaria")]
        private IWebElement malariaCheckbox;

        [FindsBy(How = How.Name, Using = "cbLifestyle")]
        private IWebElement lifestyleCheckbox;

        [FindsBy(How = How.Name, Using = "cbSurgical")]
        private IWebElement surgicalCheckbox;

        [FindsBy(How = How.XPath, Using = "//mat-checkbox[.//span[contains(text(),' Medical ')]]//input[@type='checkbox']")]
        private IWebElement medicalCheckbox;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='resignationReason']")]
        private IList<IWebElement> dataLabels; 

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='resignationCode']")]
        private IList<IWebElement> lifestyledataLabels;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='malariaRisk']")]
        private IList<IWebElement> malariadataLabels;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='malaria_risk']")]
        private IWebElement malariaRiskButton;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='malaria_additional_notes']")]
        private IWebElement malariaComments;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' MAR - Visited Malaria Area ']]")]
        private IWebElement mar;

        [FindsBy(How = How.Id, Using = "addMalariaDeferral")]
        private IWebElement malariaAddButton;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='lifestyle_deferral_code']")]
        private IWebElement lifestyleResignationCode;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()='HRD - HIGH RISK DONOR']]")]
        private IWebElement hrd;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='lifestyle_additional_notes']")]
        private IWebElement lifestyleComments;

        [FindsBy(How = How.Id, Using = "addLifestyleDeferral")]
        private IWebElement lifestyleAddButton;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='surgical_deferral_reason']")]
        private IWebElement surgicalDefferalReasonButton;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Electrolysis ']]")]
        private IWebElement electrolysis;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='surgical_deferral_code']")]
        private IWebElement surgicalDefferalCodeButton;

        [FindsBy(How = How.XPath, Using = "//mat-option//p[contains(text(), ' PD60 - H/RISK ')]")]
        private IWebElement resignationCode;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='surgical_additional_notes']")]
        private IWebElement surgicalComments;

        [FindsBy(How = How.Id, Using = "addSurgicalDeferral")]
        private IWebElement surgicalAddButton;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' Save ']]")]
        private IWebElement saveButton;

        [FindsBy(How = How.Id, Using = "inputSerial")]
        private IWebElement serialCode;

        [FindsBy(How = How.Id, Using = "inputPin")]
        private IWebElement pinCode;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' OK ']]")]
        private IWebElement okButton;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()='No']]")]
        private IWebElement noButton;

        [FindsBy(How = How.CssSelector, Using = "div[aria-label='Success']")]
        private IWebElement successToast;




        //Methods
        public void shortTermDeferral()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            string ticked = shorttermCheckbox.GetAttribute("aria-checked");
            Assert.That(ticked, Is.EqualTo("true"));

            string? TableDeferralReason = null;

            foreach (var cell in dataLabels)
            {


                if (cell.Text == "Low HB")
                {
                    TableDeferralReason = cell.Text;
                    break;
                }
            }
            Assert.AreEqual("Low HB", TableDeferralReason);

            saveButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }

        public void malariaDeferral()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementToBeClickable(malariaCheckbox));
            malariaCheckbox.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(malariaRiskButton));
            malariaRiskButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(mar));
            mar.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            malariaComments.SendKeys("Test");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            malariaAddButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            string? TableDeferralReason = null;

            foreach (var cell in malariadataLabels)
            {


                if (cell.Text == "MAR")
                {
                    TableDeferralReason = cell.Text;
                    break;
                }
            }
            Assert.AreEqual("MAR", TableDeferralReason);

            saveButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);

            noButton.Click();
        }

        public void lifestyleDeferral()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementToBeClickable(lifestyleCheckbox));
            lifestyleCheckbox.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(lifestyleResignationCode));
            lifestyleResignationCode.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hrd));
            hrd.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            lifestyleComments.SendKeys("Test");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            lifestyleAddButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            string? TableDeferralReason = null;

            foreach (var cell in lifestyledataLabels)
            {


                if (cell.Text == "HRD")
                {
                    TableDeferralReason = cell.Text;
                    break;
                }
            }
            Assert.AreEqual("HRD", TableDeferralReason);

            saveButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }

        public void surgicalDeferral()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementToBeClickable(surgicalCheckbox));
            surgicalCheckbox.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(surgicalDefferalReasonButton));
            surgicalDefferalReasonButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(electrolysis));
            electrolysis.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(surgicalDefferalCodeButton));
            surgicalDefferalCodeButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(resignationCode));
            resignationCode.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            actions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            surgicalComments.SendKeys("Test");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            surgicalAddButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            string? TableDeferralReason = null;

            foreach (var cell in dataLabels)
            {


                if (cell.Text == "Electrolysis")
                {
                    TableDeferralReason = cell.Text;
                    break;
                }
            }
            Assert.AreEqual("Electrolysis", TableDeferralReason);

            saveButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            serialCode.SendKeys(SerialNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }

        public void medicalDeferral()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            string ticked = medicalCheckbox.GetAttribute("aria-checked");
            Assert.That(ticked, Is.EqualTo("true"));

            string? TableDeferralReason = null;

            foreach (var cell in dataLabels)
            {
                
                
                if (cell.Text == "Low HB")
                {
                    TableDeferralReason = cell.Text;
                    break;
                }
            }
            Assert.AreEqual("Low HB", TableDeferralReason);

            saveButton.Click();
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
