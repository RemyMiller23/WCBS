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
    public class AdverseEventPage
    {
        //DriverSetup
        private IWebDriver driver;
        public AdverseEventPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.CssSelector, Using = "mat-checkbox[formcontrolname='cbVasovagalEvent']")]
        private IWebElement vasovagalEventCheckbox;

        [FindsBy(How = How.CssSelector, Using = "mat-checkbox[formcontrolname='cbVenepunctureEvent']")]
        private IWebElement venepunctureEventCheckbox;

        [FindsBy(How = How.CssSelector, Using = "mat-checkbox[formcontrolname='cbOtherEvent']")]
        private IWebElement otherEventCheckbox;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddVasovagalEvent']")]
        private IWebElement vasovagalEvent;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Immediate - In donor centre']]")]
        private IWebElement immediate;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddVasovagalSeverity']")]
        private IWebElement vasovagalSeverity;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Severe - LOC greater than 60 sec']]")]
        private IWebElement severe;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddVasovagalInjury']")]
        private IWebElement vasovagalInjury;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Yes']]")]
        private IWebElement injuryYes;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddVasovagalPlaceOfTreatment']")]
        private IWebElement vasovagalPlaceOfTreatment;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Treatment at Donor Centre']]")]
        private IWebElement donorCentre;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddVenepunctureEvent']")]
        private IWebElement venepunctureEvent;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddVenepunctureSeverity']")]
        private IWebElement venepunctureSeverity;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Mild']]")]
        private IWebElement mild;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddVenepunctureInjury']")]
        private IWebElement venepunctureInjury;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' No']]")]
        private IWebElement injuryNo;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddVenepuncturePlaceOfTreatment']")]
        private IWebElement venepuncturePlaceOfTreatment;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Outside medical care (Not Centre)']]")]
        private IWebElement notCentre;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddOtherEvent']")]
        private IWebElement otherEvent;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Delayed - After leaving donor centre']]")]
        private IWebElement delayed;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddOtherEventSeverity']")]
        private IWebElement otherSeverity;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Moderate']]")]
        private IWebElement moderate;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddOtherEventInjury']")]
        private IWebElement otherInjury;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddOtherEventPlaceOfTreatment']")]
        private IWebElement otherPlaceOfTreatment;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Hospitalisation']]")]
        private IWebElement hospitalisation;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddDrugsAdministered']")]
        private IWebElement drugsAdministered;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Yes']]")]
        private IWebElement daYes;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='inDrugsAdministeredType']")]
        private IWebElement daType;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='inDrugsAdministeredLotNumber']")]
        private IWebElement daLotNumber;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='inDrugsAdministeredExpiry']")]
        private IWebElement daExpiryDate;
        
        [FindsBy(How = How.Id, Using = "btnAddDrugsAdministered")]
        private IWebElement daAddButton;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddIVTherapy']")]
        private IWebElement ivTherapy;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' Yes']]")]
        private IWebElement ivtYes;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='inIVTherapyType']")]
        private IWebElement ivtType;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='inIVTherapyLotNumber']")]
        private IWebElement ivtLotNumber;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='inIVTherapyExpiry']")]
        private IWebElement ivtExpiryDate;

        [FindsBy(How = How.Id, Using = "btnAddIVTherapy")]
        private IWebElement ivtAddButton;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='inBloodPressure']")]
        private IWebElement bloodPressure;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='inComments']")]
        private IWebElement comments;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='lotNumber']")]
        private IList<IWebElement> dataLabels;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' Save ']]")]
        private IWebElement saveButton;

        [FindsBy(How = How.Id, Using = "SaveAndReturn")]
        private IWebElement saveAndReturnButton;

        [FindsBy(How = How.Id, Using = "inputSerial")]
        private IWebElement serialCode;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='Pin']")]
        private IWebElement pinCode;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()='OK']]")]
        private IWebElement okButton;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()='No']]")]
        private IWebElement noButton;

        [FindsBy(How = How.CssSelector, Using = "div[aria-label='Success']")]
        private IWebElement successToast;

        public void vasovagal()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string LotNumber1 = ConfigurationManager.AppSettings["LotNumber1"];
            string LotNumber2 = ConfigurationManager.AppSettings["LotNumber2"];
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string ExpiryDate = ConfigurationManager.AppSettings["ExpiryDate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            wait.Until(ExpectedConditions.ElementToBeClickable(vasovagalEventCheckbox));
            vasovagalEventCheckbox.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(vasovagalEvent));
            vasovagalEvent.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(immediate));
            immediate.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(vasovagalSeverity));
            vasovagalSeverity.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(severe));
            severe.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(vasovagalInjury));
            vasovagalInjury.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(injuryYes));
            injuryYes.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(vasovagalPlaceOfTreatment));
            vasovagalPlaceOfTreatment.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(donorCentre));
            donorCentre.Click();

           
            string[] labels = { "Sweating ", "Dizziness ", "Nausea", "Pallor", "Vomiting ", "Cold feelings ", "Pins & Needles ",
                "Loss of consciousness ", "Convulsive syncope", "Loss of sphincter control " };

            foreach (var item in labels)
            {
                var checkbox = driver.FindElement(By.XPath($"//mat-checkbox[.//span[text()='{item}']]"));

                if (checkbox.GetAttribute("aria-checked") != "true")
                {
                    var label = checkbox.FindElement(By.CssSelector(".mat-checkbox-inner-container"));
                    wait.Until(ExpectedConditions.ElementToBeClickable(label));
                    label.Click();
                }
            }

            
            wait.Until(ExpectedConditions.ElementToBeClickable(drugsAdministered));
            drugsAdministered.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(daYes));
            daYes.Click(); 
            wait.Until(ExpectedConditions.ElementToBeClickable(daType));
            daType.SendKeys("DATest");
            wait.Until(ExpectedConditions.ElementToBeClickable(daLotNumber));
            daLotNumber.SendKeys(LotNumber1);
            wait.Until(ExpectedConditions.ElementToBeClickable(daExpiryDate));
            daExpiryDate.SendKeys(ExpiryDate);
            actions.SendKeys(Keys.Tab).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(daAddButton));
            daAddButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            string? tableLotNumber1 = null;

            foreach (var cell in dataLabels)
            {


                if (cell.Text == LotNumber1)
                {
                    tableLotNumber1 = cell.Text;
                    break;
                }
            }
            Assert.AreEqual(LotNumber1, tableLotNumber1);


            wait.Until(ExpectedConditions.ElementToBeClickable(ivTherapy));
            ivTherapy.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ivtYes));
            ivtYes.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ivtType));
            ivtType.SendKeys("IVTTest");
            wait.Until(ExpectedConditions.ElementToBeClickable(ivtLotNumber));
            ivtLotNumber.SendKeys(LotNumber2);
            wait.Until(ExpectedConditions.ElementToBeClickable(ivtExpiryDate));
            ivtExpiryDate.SendKeys(ExpiryDate);
            actions.SendKeys(Keys.Tab).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(ivtAddButton));
            ivtAddButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            string? tableLotNumber2 = null;

            foreach (var cell in dataLabels)
            {


                if (cell.Text == LotNumber2)
                {
                    tableLotNumber2 = cell.Text;
                    break;
                }
            }
            Assert.AreEqual(LotNumber2, tableLotNumber2);

            wait.Until(ExpectedConditions.ElementToBeClickable(bloodPressure));
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(comments));
            comments.SendKeys("Test Comments");

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndReturnButton));
            saveAndReturnButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
            
        }

        public void venepuncture()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string LotNumber1 = ConfigurationManager.AppSettings["LotNumber1"];
            string LotNumber2 = ConfigurationManager.AppSettings["LotNumber2"];
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string ExpiryDate = ConfigurationManager.AppSettings["ExpiryDate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            wait.Until(ExpectedConditions.ElementToBeClickable(venepunctureEventCheckbox));
            venepunctureEventCheckbox.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(venepunctureEvent));
            venepunctureEvent.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(immediate));
            immediate.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(venepunctureSeverity));
            venepunctureSeverity.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(mild));
            mild.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(venepunctureInjury));
            venepunctureInjury.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(injuryNo));
            injuryNo.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(venepuncturePlaceOfTreatment));
            venepuncturePlaceOfTreatment.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(notCentre));
            notCentre.Click();


            string[] labels = { "Delayed bleeding", "Nerve irritation", "Tendon Injury ", "Painful arm ", "Nerve Injury ", "Arterial puncture", "Haematoma "};

            foreach (var item in labels)
            {
                var checkbox = driver.FindElement(By.XPath($"//mat-checkbox[.//span[text()='{item}']]"));

                if (checkbox.GetAttribute("aria-checked") != "true")
                {
                    var label = checkbox.FindElement(By.CssSelector(".mat-checkbox-inner-container"));
                    wait.Until(ExpectedConditions.ElementToBeClickable(label));
                    label.Click();
                }
            }

            wait.Until(ExpectedConditions.ElementToBeClickable(bloodPressure));
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(comments));
            comments.SendKeys("Test Comments");

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndReturnButton));
            saveAndReturnButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);

        }

        public void other()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string LotNumber1 = ConfigurationManager.AppSettings["LotNumber1"];
            string LotNumber2 = ConfigurationManager.AppSettings["LotNumber2"];
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string ExpiryDate = ConfigurationManager.AppSettings["ExpiryDate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            wait.Until(ExpectedConditions.ElementToBeClickable(otherEventCheckbox));
            otherEventCheckbox.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(otherEvent));
            otherEvent.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(delayed));
            delayed.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(otherSeverity));
            otherSeverity.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(moderate));
            moderate.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(otherInjury));
            otherInjury.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(injuryYes));
            injuryYes.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(otherPlaceOfTreatment));
            otherPlaceOfTreatment.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hospitalisation));
            hospitalisation.Click();


            string[] labels = { " Citrate Reaction", " Haemolysis ", " Generalised Allergic Reaction ", "Medical eg.Stroke, Heart attack" };

            foreach (var item in labels)
            {
                var checkbox = driver.FindElement(By.XPath($"//mat-checkbox[.//span[text()='{item}']]"));

                if (checkbox.GetAttribute("aria-checked") != "true")
                {
                    var label = checkbox.FindElement(By.CssSelector(".mat-checkbox-inner-container"));
                    wait.Until(ExpectedConditions.ElementToBeClickable(label));
                    label.Click();
                }
            }


            wait.Until(ExpectedConditions.ElementToBeClickable(drugsAdministered));
            drugsAdministered.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(daYes));
            daYes.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(daType));
            daType.SendKeys("DATest");
            wait.Until(ExpectedConditions.ElementToBeClickable(daLotNumber));
            daLotNumber.SendKeys(LotNumber1);
            wait.Until(ExpectedConditions.ElementToBeClickable(daExpiryDate));
            daExpiryDate.SendKeys(ExpiryDate);
            actions.SendKeys(Keys.Tab).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(daAddButton));
            daAddButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            string? tableLotNumber1 = null;

            foreach (var cell in dataLabels)
            {


                if (cell.Text == LotNumber1)
                {
                    tableLotNumber1 = cell.Text;
                    break;
                }
            }
            Assert.AreEqual(LotNumber1, tableLotNumber1);


            wait.Until(ExpectedConditions.ElementToBeClickable(ivTherapy));
            ivTherapy.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ivtYes));
            ivtYes.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ivtType));
            ivtType.SendKeys("IVTTest");
            wait.Until(ExpectedConditions.ElementToBeClickable(ivtLotNumber));
            ivtLotNumber.SendKeys(LotNumber2);
            wait.Until(ExpectedConditions.ElementToBeClickable(ivtExpiryDate));
            ivtExpiryDate.SendKeys(ExpiryDate);
            actions.SendKeys(Keys.Tab).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(ivtAddButton));
            ivtAddButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            string? tableLotNumber2 = null;

            foreach (var cell in dataLabels)
            {


                if (cell.Text == LotNumber2)
                {
                    tableLotNumber2 = cell.Text;
                    break;
                }
            }
            Assert.AreEqual(LotNumber2, tableLotNumber2);

            wait.Until(ExpectedConditions.ElementToBeClickable(bloodPressure));
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(comments));
            comments.SendKeys("Test Comments");

            wait.Until(ExpectedConditions.ElementToBeClickable(saveAndReturnButton));
            saveAndReturnButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);

        }
    }
}
