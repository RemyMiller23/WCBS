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
    public class FindADonorPage
    {

        //DriverSetup
        private IWebDriver driver;
        public FindADonorPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.CssSelector, Using = ".button1")]
        private IWebElement createNewDonorButton;

        [FindsBy(How = How.CssSelector, Using = ".mat-radio-button[value='DNS']")]
        private IWebElement dnsRadioButton;

        [FindsBy(How = How.Name, Using = "NameInput")]
        private IWebElement firstName;

        [FindsBy(How = How.Name, Using = "Surname")]
        private IWebElement surname;

        [FindsBy(How = How.Name, Using = "Dob")]
        private IWebElement dob;

        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='View/Edit']")]
        private IList<IWebElement> viewEditIcon;

        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='Donate']")]
        private IList<IWebElement> donationIcon;

        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='Adverse Event']")]
        private IList <IWebElement> adverseEventIcon;

        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='Deferral']")]
        private IList<IWebElement> deferralIcon;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()=' Search ']]")]
        private IWebElement searchButton;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='Pin']")]
        private IWebElement pinCode;

        [FindsBy(How = How.XPath, Using = "//button[.//span[text()='OK']]")]
        private IWebElement okButton;







        //Methods
        public void createNewDonor()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-title-text")));
            createNewDonorButton.Click();
            
        }

        public void findADonorDonation()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            WebDriverWait errorWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string FirstInital = ConfigurationManager.AppSettings["FirstInital"];
            string SecondInital = ConfigurationManager.AppSettings["SecondInital"];
            string DOB = ConfigurationManager.AppSettings["DOB"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-title-text")));
            dnsRadioButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(firstName));
            firstName.SendKeys(FirstInital);
            wait.Until(ExpectedConditions.ElementToBeClickable(surname));
            surname.SendKeys(SecondInital);
            wait.Until(ExpectedConditions.ElementToBeClickable(dob));
            dob.SendKeys(DOB);
            wait.Until(ExpectedConditions.ElementToBeClickable(searchButton));
            searchButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-label[contains(text(), 'Donor does not exist. Please try again.')]")));
                TestContext.Progress.WriteLine("No Donors available for initals and year provided");             
                Assert.Fail("No Donors available for initals and year provided");
            }

            catch (WebDriverTimeoutException)
            {

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            wait.Until(ExpectedConditions.ElementToBeClickable(donationIcon[0]));
            donationIcon[0].Click();

        }

        public void findADonorHaemovigilance()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string TechPin = ConfigurationManager.AppSettings["TechPin"];
            string FirstInital = ConfigurationManager.AppSettings["FirstInital"];
            string SecondInital = ConfigurationManager.AppSettings["SecondInital"];
            string DOB = ConfigurationManager.AppSettings["DOB"];

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-title-text")));
            dnsRadioButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(firstName));
            firstName.SendKeys(FirstInital);
            wait.Until(ExpectedConditions.ElementToBeClickable(surname));
            surname.SendKeys(SecondInital);
            wait.Until(ExpectedConditions.ElementToBeClickable(dob));
            dob.SendKeys(DOB);
            wait.Until(ExpectedConditions.ElementToBeClickable(searchButton));
            searchButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(adverseEventIcon[0]));
            adverseEventIcon[0].Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-dialog-title")));
            pinCode.SendKeys(TechPin);
            okButton.Click();

        }


    }
}
