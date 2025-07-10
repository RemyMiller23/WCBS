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
    public class interviewPage
    {
        //DriverSetup
        private IWebDriver driver;
        public interviewPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.Name, Using = "blood_Pressure")]
        private IWebElement bloodPressure;

        [FindsBy(How = How.Name, Using = "iron_tablet")]
        private IWebElement ironTabletButton;

        [FindsBy(How = How.XPath, Using = "//span[text()=' No']")]
        private IWebElement no;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Yes']")]
        private IWebElement yes;

        [FindsBy(How = How.Name, Using = "pulse")]
        private IWebElement pulseButton;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Regular']")]
        private IWebElement regular;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Irregular']")]
        private IWebElement irregular;

        [FindsBy(How = How.Name, Using = "bpm")]
        private IWebElement bpm; 

        [FindsBy(How = How.Name, Using = "noteMedical")]
        private IWebElement medicalNote; 

        [FindsBy(How = How.Name, Using = "category")]
        private IWebElement categoryButton;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Whole Blood Donation ']")]
        private IWebElement wholeBloodDonation;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Therapeutics ']")]
        private IWebElement therapeutics;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Blood Samples/Tests ']")]
        private IWebElement bloodSamplesTests;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Apheresis ']")]
        private IWebElement apheresis;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Source Plasma ']")]
        private IWebElement sourcePlasma;

        [FindsBy(How = How.Name, Using = "pack")]
        private IWebElement packButton;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Quad Pack ']")]
        private IWebElement quadPack;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Dry Pack ']")]
        private IWebElement dryPack;

        [FindsBy(How = How.XPath, Using = "//span[text()=' FBC ']")]
        private IWebElement fbc;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Hepatitis Query ']")]
        private IWebElement hepatitisQuery;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Test Only ']")]
        private IWebElement testOnly;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Reagents ']")]
        private IWebElement reagents;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Counselling ']")]
        private IWebElement counselling;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Convalescent Plasma - Pre Assessment ']")]
        private IWebElement convalescentPlasmaPreAssessment;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Virology ']")]
        private IWebElement virology;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Look Back ']")]
        private IWebElement lookBack;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Plasma Pack ']")]
        private IWebElement plasmaPack;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Source Plasma + 5 ml SST Gel ']")]
        private IWebElement sourcePlasma5mlSSTGel;

        [FindsBy(How = How.Name, Using = "comments")]
        private IWebElement commentsButton;

        [FindsBy(How = How.XPath, Using = "//span[text()=' None ']")]
        private IWebElement none;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Att: Blood Grouping ']")]
        private IWebElement attBloodGrouping;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Discard Unit ']")]
        private IWebElement discardUnit;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Insufficient ']")]
        private IWebElement insufficient;

        [FindsBy(How = How.Id, Using = "addTestPack")]
        private IWebElement addTestPack;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='category']")]
        private IWebElement tableCategory;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='pack']")]
        private IWebElement tablePack;

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

        [FindsBy(How = How.CssSelector, Using = "div[aria-label='Success']")]
        private IWebElement successToast;

        



        //Methods
        public void wholeBloodDryPack()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(wholeBloodDonation));
            wholeBloodDonation.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(dryPack));
            dryPack.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);


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

        public void wholeBloodQuadPack()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(wholeBloodDonation));
            wholeBloodDonation.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(quadPack));
            quadPack.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void therapeuticsDryPack()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(therapeutics));
            therapeutics.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(dryPack));
            dryPack.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void therapeuticsQuadPack()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(therapeutics));
            therapeutics.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(quadPack));
            quadPack.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void bstFBC()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bloodSamplesTests));
            bloodSamplesTests.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(fbc));
            fbc.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void bstHepatitisQuery()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bloodSamplesTests));
            bloodSamplesTests.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hepatitisQuery));
            hepatitisQuery.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void bstTestOnly()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bloodSamplesTests));
            bloodSamplesTests.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(testOnly));
            testOnly.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void bstReagents()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bloodSamplesTests));
            bloodSamplesTests.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(reagents));
            reagents.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void bstCounselling()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bloodSamplesTests));
            bloodSamplesTests.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(counselling));
            counselling.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void bstConvalescentPlasma()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bloodSamplesTests));
            bloodSamplesTests.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(convalescentPlasmaPreAssessment));
            convalescentPlasmaPreAssessment.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void bstVirology()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bloodSamplesTests));
            bloodSamplesTests.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(virology));
            virology.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void bstLookBack()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bloodSamplesTests));
            bloodSamplesTests.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(lookBack));
            lookBack.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void apheresisPlasmaPack()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(apheresis));
            apheresis.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(plasmaPack));
            plasmaPack.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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

        public void sourcePlasmaSP()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);
            string BloodPressure = ConfigurationManager.AppSettings["BloodPressure"];
            string IDNumber = ConfigurationManager.AppSettings["IDNumber"];
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string Surname = ConfigurationManager.AppSettings["Surname"];
            string SerialNumber = ConfigurationManager.AppSettings["SerialNumber"];
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HeartRate = ConfigurationManager.AppSettings["HeartRate"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));

            //Donor Personal info And BP & Pulse
            bloodPressure.SendKeys(BloodPressure);
            wait.Until(ExpectedConditions.ElementToBeClickable(ironTabletButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ironTabletButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(no));
            no.Click();
            pulseButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(regular));
            regular.Click();
            bpm.SendKeys(HeartRate);
            medicalNote.SendKeys("Test");
            Thread.Sleep(2000);

            //Test Pack Solution
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-header-row")));
            wait.Until(ExpectedConditions.ElementToBeClickable(categoryButton));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            categoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(sourcePlasma));
            sourcePlasma.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(packButton));
            packButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(sourcePlasma5mlSSTGel));
            sourcePlasma5mlSSTGel.Click();
            commentsButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(none));
            none.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(addTestPack));
            addTestPack.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-cell")));
            ConfigurationManager.AppSettings["Category"] = tableCategory.Text;
            ConfigurationManager.AppSettings["Pack"] = tablePack.Text;
            TestContext.Progress.WriteLine(tableCategory.Text);
            TestContext.Progress.WriteLine(tablePack.Text);

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
