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

namespace PulseDonations.PageObjects.Hamper
{
    public class LinkHamperPage
    {
        //DriverSetup
        private IWebDriver driver;
        public LinkHamperPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.CssSelector, Using = ".button1")]
        private IWebElement createNewDonorButton;

        [FindsBy(How = How.Name, Using = "batchSerial")]
        private IWebElement hamperNumber;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Link Hamper Number ']")]
        private IWebElement linkHamperButton;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='batchSerialNumber'] input")]
        private IList<IWebElement> dataLabels;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='batchStatus'] input")]
        private IList<IWebElement> statusLabels;

        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='Close']")]
        private IList<IWebElement> closeButtons;

        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='View Transactions']")]
        private IList<IWebElement> viewTransactionButtons;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='transactionNumber'] input")]
        private IList<IWebElement> serialNumberLabels;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='BatchNumber']")]
        private IWebElement formHamperNumber;

        [FindsBy(How = How.Id, Using = "inputPin")]
        private IWebElement pinCode;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()='OK']]")]
        private IWebElement okButton;

        [FindsBy(How = How.CssSelector, Using = "div[aria-label='Success']")]
        private IWebElement successToast;






        //Methods
        public void linkNewHamper()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));


            //Generate Hamper Code
            Random generator = new Random();
            string randSerialNumber = generator.Next(10000000, 99999999).ToString("D8");
            string HamperCode = randSerialNumber;
            ConfigurationManager.AppSettings["HamperCode"] = HamperCode;
            TestContext.Progress.WriteLine(HamperCode);


            //Pulse Donations 
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-title-text")));
            hamperNumber.SendKeys(HamperCode);
            wait.Until(ExpectedConditions.ElementToBeClickable(linkHamperButton));
            linkHamperButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()=' Actions ']")));
            Thread.Sleep(TimeSpan.FromSeconds(10));

            string? TableHamperNumber = null;

            foreach (var cell in dataLabels)
            {
                if (cell.GetAttribute("value") == HamperCode)
                {
                    TableHamperNumber = cell.GetAttribute("value");
                    break;
                }
            }
            Assert.AreEqual(HamperCode, TableHamperNumber);

            string solutionDir = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
            string dateFolder = DateTime.Now.ToString("dd-MM-yyyy");
            string hamperCodesDir = Path.Combine(solutionDir, "HamperCodes", dateFolder);
            Directory.CreateDirectory(hamperCodesDir);

            string HamperCreationTime = DateTime.Now.ToString("HHmmss");
            ConfigurationManager.AppSettings["HamperCreationTime"] = HamperCreationTime;
            string selectedEnvKey = ConfigurationManager.AppSettings["selectedEnv"];

            string filePath = Path.Combine(hamperCodesDir, $"{selectedEnvKey}_{HamperCreationTime}_{HamperCode}.txt");

            TestContext.Progress.WriteLine($"Hamper file created: {filePath}");
        }

        public void closeHamper()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string HamperCode = ConfigurationManager.AppSettings["HamperCode"];
            string HamperCreationTime = ConfigurationManager.AppSettings["HamperCreationTime"];
            string selectedEnvKey = ConfigurationManager.AppSettings["selectedEnv"];


            //Pulse Donations 
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-title-text")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()=' Actions ']")));

            string? TableHamperNumber = null;
            string? TableHamperStatus = null;

            TableHamperNumber = dataLabels[0].GetAttribute("value");
            TableHamperStatus = statusLabels[0].GetAttribute("value");

            Assert.AreEqual(HamperCode, TableHamperNumber);
            Assert.AreEqual("Open", TableHamperStatus);

            wait.Until(ExpectedConditions.ElementToBeClickable(closeButtons[0]));
            closeButtons[0].Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            formHamperNumber.SendKeys(HamperCode);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            pinCode.SendKeys(TechPin);
            okButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            TableHamperStatus = statusLabels[0].GetAttribute("value");
            Assert.AreEqual("InTransit", TableHamperStatus);

            wait.Until(ExpectedConditions.ElementToBeClickable(viewTransactionButtons[0]));
            viewTransactionButtons[0].Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));

            string solutionDir = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
            string dateFolder = DateTime.Now.ToString("dd-MM-yyyy");
            string hamperCodesDir = Path.Combine(solutionDir, "HamperCodes", dateFolder);
            string filePath = Path.Combine(hamperCodesDir, $"{selectedEnvKey}_{HamperCreationTime}_{HamperCode}.txt");

            foreach (var serial in serialNumberLabels)
            {
                string serialNo = serial.GetAttribute("value");
                TestContext.Progress.WriteLine($"Appending serial number: {serialNo}");
                File.AppendAllText(filePath, serialNo + Environment.NewLine);
            }
        }
    }
}


