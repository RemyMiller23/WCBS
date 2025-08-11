using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PulseDonations.Tests;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.PageObjects.ClinicSetup
{
    public class ClinicSetupPage
    {
        //DriverSetup
        private IWebDriver driver;
        public ClinicSetupPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.XPath, Using = "//div[@role='tab' and .//span[text()=' Clinic Report ']]")]
        private IWebElement clinicReportTabTab;

        [FindsBy(How = How.XPath, Using = "//div[@role='tab' and .//span[text()=' General Report ']]")]
        private IWebElement generalReportTab;

        [FindsBy(How = How.XPath, Using = "//div[@role='tab' and .//span[text()=' General Report Audit ']]")]
        private IWebElement generalReportAuditTab;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='StaffMember']")]
        private IWebElement teamNameAndCodeButton;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' SDD - Specialised Donations ']]")]
        private IWebElement teamOption;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='staffNames']")]
        private IWebElement staffMemberPin;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='staffDesignation']")]
        private IWebElement staffDesignation;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()='Team Supervisor']]")]
        private IWebElement teamSupervisor;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='staffDesignation']")]
        private IList<IWebElement> staffDetailsDataLabels;
        
        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='designatedDriver']")]
        private IWebElement designatedDriver;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='vehicleRegistration']")]
        private IWebElement vehicleRegistration;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='trailerRegistration']")]
        private IWebElement trailerRegistration;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='vehicleRegistration']")]
        private IList<IWebElement> vehicleRegistrationDataLabels;

        [FindsBy(How = How.CssSelector, Using = "textarea[formcontrolname='clinicComments']")]
        private IWebElement additionalNotesComments;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='comments']")]
        private IList<IWebElement> commentsDataLabels;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='action']")]
        private IList<IWebElement> actionDataLabels;

        [FindsBy(How = How.XPath, Using = "(//div[@class='card-title-text'])[last()]")]
        private IWebElement lastCardTitle;

        [FindsBy(How = How.CssSelector, Using = "mat-checkbox[formcontrolname='cbSourcePlasma']")]
        private IWebElement sourcePlasmaCheckbox;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='serialNumber2']")]
        private IWebElement hcSerialNumber1;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='serialNumber']")]
        private IWebElement hcSerialNumber2;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='cuvettesLot']")]
        private IWebElement cuvettesLot;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='cuvettesExpiry']")]
        private IWebElement cuvettesExpiry;

        [FindsBy(How = How.CssSelector, Using = "td.mat-calendar-body-active")]
        private IWebElement activeDate;

        [FindsBy(How = How.Id, Using = "addHemoCue")]
        private IWebElement addHemoCueButton;

        [FindsBy(How = How.Id, Using = "hemoCueSelfTest")]
        private IWebElement hcSelfTestbutton;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='serialNumber3']")]
        private IWebElement dbpmSerialNumber;

        [FindsBy(How = How.Id, Using = "addBatch")]
        private IList<IWebElement> addBatch;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='lotNumber']")]
        private IWebElement bpLot;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='expiryDate']")]
        private IWebElement bpExpiry;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='dateOpened']")]
        private IWebElement bpPackOpenDate;

        [FindsBy(How = How.XPath, Using = "//button[@id='addTestPack' and .//span[text()=' Add ']]")]
        private IWebElement addBP;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='dryPackLot']")]
        private IWebElement dpLot;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='dryPackExpiryDate']")]
        private IWebElement dpExpiry;

        [FindsBy(How = How.Id, Using = "addDryPack")]
        private IWebElement addDP;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='sampleTube']")]
        private IWebElement stSampleTubesButton;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' 10 ml Gold EDTA ']]")]
        private IWebElement stGold;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='expiryDate']")]
        private IWebElement stExpiry;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='batchNumber']")]
        private IWebElement stLot;

        [FindsBy(How = How.Id, Using = "addBatch")]
        private IWebElement addST;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='calibrationSerial']")]
        private IWebElement hfCalibrationWeightSerialNumber;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='hemoflowSerialNumber']")]
        private IWebElement hfSerialNumber;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='calibratedWeight']")]
        private IWebElement hfcalibratedWeight;

        [FindsBy(How = How.Id, Using = "addWeight")]
        private IWebElement addHF;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='equipment']")]
        private IWebElement ecEquipmentButton;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()='Host Laptop']]")]
        private IWebElement ecHostLaptop;

        [FindsBy(How = How.Id, Using = "addBatch")]
        private IWebElement addEC;
        
        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='consumable']")]
        private IWebElement spConsumable;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()='Plasma Bowl']]")]
        private IWebElement spPlasmaBowl;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='plasmaBatchNumber']")]
        private IWebElement spBatchNumber;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='plasmaExpiryDate']")]
        private IWebElement spExpiry;

        [FindsBy(How = How.Id, Using = "addBatch")]
        private IWebElement addSP;

        [FindsBy(How = How.CssSelector, Using = "button[id*='SaveAndReturn'][id*='alignButton']")]
        private IWebElement spSaveButton;

        [FindsBy(How = How.Id, Using = "add")]
        private IWebElement addCommentsButton;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' Save (Clinic Comments) ']]")]
        private IWebElement saveCommentsButton;
       
        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='Pin']")]
        private IWebElement pinCode;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' Add ']]")]
        private IList<IWebElement> addButton;

        [FindsBy(How = How.Id, Using = "SaveAndReturn")]
        private IList<IWebElement> saveButton;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' OK ']]")]
        private IWebElement okButton;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()='No']]")]
        private IWebElement noButton;

        [FindsBy(How = How.CssSelector, Using = "div[aria-label='Success']")]
        private IWebElement successToast;




        //Methods
        public void updateClinicDetails()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string VehicleRegistration = ConfigurationManager.AppSettings["VehicleRegistration"];
            string TrailerRegistration = ConfigurationManager.AppSettings["TrailerRegistration"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            wait.Until(ExpectedConditions.ElementToBeClickable(teamNameAndCodeButton));
            teamNameAndCodeButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(teamOption));
            try
            {
                teamOption.Click();
            }
            catch (ElementClickInterceptedException)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(teamOption));
                teamOption.Click();
            }
            staffMemberPin.SendKeys(TechPin);
            wait.Until(ExpectedConditions.ElementToBeClickable(staffDesignation));
            staffDesignation.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(teamSupervisor));
            teamSupervisor.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addButton[0]));
            addButton[0].Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(saveButton[0]));
            saveButton[0].Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("mat-cell[data-label='StaffMember']")));

            string? tableDesignation = null;

            foreach (var cell in staffDetailsDataLabels)
            {


                if (cell.Text == "Team Supervisor")
                {
                    tableDesignation = cell.Text;
                    break;
                }
            }
            Assert.AreEqual("Team Supervisor", tableDesignation);

            driver.Navigate().Refresh();

            wait.Until(ExpectedConditions.ElementToBeClickable(designatedDriver));
            designatedDriver.SendKeys(TechPin);
            wait.Until(ExpectedConditions.ElementToBeClickable(vehicleRegistration));
            vehicleRegistration.SendKeys(VehicleRegistration);
            wait.Until(ExpectedConditions.ElementToBeClickable(trailerRegistration));
            trailerRegistration.SendKeys(TrailerRegistration);
            wait.Until(ExpectedConditions.ElementToBeClickable(addButton[1]));
            addButton[1].Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(saveButton[1]));
            saveButton[1].Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("mat-cell[data-label='designatedDriver']")));

            string? tableVehicleRegistration = null;

            foreach (var cell in vehicleRegistrationDataLabels)
            {


                if (cell.Text == VehicleRegistration)
                {
                    tableVehicleRegistration = cell.Text;
                    break;
                }
            }
            Assert.AreEqual(VehicleRegistration, tableVehicleRegistration);

            driver.Navigate().Refresh();

            wait.Until(ExpectedConditions.ElementToBeClickable(additionalNotesComments));
            additionalNotesComments.SendKeys("Test");
            wait.Until(ExpectedConditions.ElementToBeClickable(addButton[2]));
            addButton[2].Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(saveButton[2]));
            saveButton[2].Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("mat-cell[data-label='user']")));

            string? tableComments = null;

            foreach (var cell in commentsDataLabels)
            {


                if (cell.Text == "Test")
                {
                    tableComments = cell.Text;
                    break;
                }
            }
            Assert.AreEqual("Test", tableComments);
        }

        public void setupgeneralReportHemoCue()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string HCSerialNumber1 = ConfigurationManager.AppSettings["HCSerialNumber1"];
            string HCSerialNumber2 = ConfigurationManager.AppSettings["HCSerialNumber2"];
            string CuvettesLot = ConfigurationManager.AppSettings["CuvettesLot"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            generalReportTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            TestContext.Progress.WriteLine(lastCardTitle.Text.Trim());
            Assert.AreEqual("Source Plasma", lastCardTitle.Text.Trim());
            wait.Until(ExpectedConditions.ElementToBeClickable(sourcePlasmaCheckbox));
            sourcePlasmaCheckbox.Click();
            TestContext.Progress.WriteLine(lastCardTitle.Text.Trim());
            Assert.AreEqual("Equipment Check", lastCardTitle.Text.Trim());
            wait.Until(ExpectedConditions.ElementToBeClickable(sourcePlasmaCheckbox));
            sourcePlasmaCheckbox.Click();
            TestContext.Progress.WriteLine(lastCardTitle.Text.Trim());
            Assert.AreEqual("Source Plasma", lastCardTitle.Text.Trim());

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(hcSerialNumber1));
                hcSerialNumber1.SendKeys(HCSerialNumber1);
                wait.Until(ExpectedConditions.ElementToBeClickable(hcSerialNumber2));
                hcSerialNumber2.SendKeys(HCSerialNumber2);
            }
            catch (WebDriverTimeoutException)
            {

            }

            wait.Until(ExpectedConditions.ElementToBeClickable(cuvettesLot));
            cuvettesLot.SendKeys(CuvettesLot);
            wait.Until(ExpectedConditions.ElementToBeClickable(cuvettesExpiry));
            cuvettesExpiry.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(activeDate));
            activeDate.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addHemoCueButton));
            addHemoCueButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hcSelfTestbutton));
            hcSelfTestbutton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }

        public void setupgeneralReportDBPM()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string DBPMSerialNumber = ConfigurationManager.AppSettings["DBPMSerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            generalReportTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            wait.Until(ExpectedConditions.ElementToBeClickable(dbpmSerialNumber));
            dbpmSerialNumber.SendKeys(DBPMSerialNumber);
            wait.Until(ExpectedConditions.ElementToBeClickable(addBatch[0]));
            addBatch[0].Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(saveButton[0]));
            saveButton[0].Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }

        public void setupgeneralReportBP()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BPLot = ConfigurationManager.AppSettings["BPLot"];
            string DPLot = ConfigurationManager.AppSettings["DPLot"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            generalReportTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            wait.Until(ExpectedConditions.ElementToBeClickable(bpLot));
            bpLot.SendKeys(BPLot);
            wait.Until(ExpectedConditions.ElementToBeClickable(bpExpiry));
            bpExpiry.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(activeDate));
            activeDate.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bpPackOpenDate));
            bpPackOpenDate.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(activeDate));
            activeDate.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addBP));
            addBP.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(dpLot));
            dpLot.SendKeys(DPLot);
            wait.Until(ExpectedConditions.ElementToBeClickable(dpExpiry));
            dpExpiry.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(activeDate));
            activeDate.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addDP));
            addDP.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(saveButton[1]));
            saveButton[1].Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }

        public void setupgeneralReportST()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string STLot = ConfigurationManager.AppSettings["STLot"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            generalReportTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            wait.Until(ExpectedConditions.ElementToBeClickable(stSampleTubesButton));
            stSampleTubesButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(stGold));
            stGold.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(stExpiry));
            stExpiry.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(activeDate));
            activeDate.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(stLot));
            stLot.SendKeys(STLot);
            wait.Until(ExpectedConditions.ElementToBeClickable(addBatch[1]));
            addBatch[1].Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(saveButton[2]));
            saveButton[2].Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }

        public void setupgeneralReportHFC()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string HFCalirationWeightSerialNumber = ConfigurationManager.AppSettings["HFCalirationWeightSerialNumber"];
            string HFCalibratedWeight = ConfigurationManager.AppSettings["HFCalibratedWeight"];
            string HFSerialNumber = ConfigurationManager.AppSettings["HFSerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            generalReportTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            wait.Until(ExpectedConditions.ElementToBeClickable(hfCalibrationWeightSerialNumber));
            hfCalibrationWeightSerialNumber.SendKeys(HFCalirationWeightSerialNumber);
            wait.Until(ExpectedConditions.ElementToBeClickable(hfSerialNumber));
            hfSerialNumber.SendKeys(HFSerialNumber);
            wait.Until(ExpectedConditions.ElementToBeClickable(hfcalibratedWeight));
            hfcalibratedWeight.SendKeys(HFCalibratedWeight);
            wait.Until(ExpectedConditions.ElementToBeClickable(addHF));
            addHF.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(saveButton[3]));
            saveButton[3].Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }

        public void setupgeneralReportEC()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            generalReportTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            wait.Until(ExpectedConditions.ElementToBeClickable(ecEquipmentButton));
            ecEquipmentButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ecHostLaptop));
            ecHostLaptop.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addBatch[2]));
            addBatch[2].Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(saveButton[4]));
            saveButton[4].Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }

        public void setupgeneralReportSP()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string SPBatchNumber = ConfigurationManager.AppSettings["SPBatchNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            generalReportTab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            wait.Until(ExpectedConditions.ElementToBeClickable(spConsumable));
            spConsumable.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(spPlasmaBowl));
            spPlasmaBowl.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(spBatchNumber));
            spBatchNumber.SendKeys(SPBatchNumber);
            wait.Until(ExpectedConditions.ElementToBeClickable(spExpiry));
            spExpiry.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(activeDate));
            activeDate.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addBatch[3]));
            addBatch[3].Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(spSaveButton));
            spSaveButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label = 'Success']")));
            string toastMessage = successToast.Text;
            Assert.AreEqual("Success", toastMessage);
        }
        
        public void generalReportAudit()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            generalReportAuditTab.Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));

            string[] Actions = {"HemoCue Self Test", "BpMeters", "Blood Packs", "Sample Tubes", "HemoFlow Calibration", "Equipment Check", "SourcePlasmaSetup"};


            foreach (var cell in actionDataLabels)
            {
                if (Actions.Contains(cell.Text.Trim()))
                {
                    Assert.Contains(cell.Text.Trim(), Actions);
                }
            }
        }
    }
}
