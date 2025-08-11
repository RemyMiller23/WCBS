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

namespace PulseDonations.PageObjects
{
    public class HomePage
    {
        //DriverSetup
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Home')]")]
        private IWebElement homeMenuItem;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Clinic')]")]
        private IWebElement clinicMenuItem;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Donations')]")]
        private IWebElement donationsMenuItem;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Audit')]")]
        private IWebElement auditMenuItem;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Reports')]")]
        private IWebElement reportsMenuItem;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Clinic Setup')]")]
        private IWebElement clinicSetupMenuItem;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Donor Attendance')]")]
        private IWebElement donorAttendanceMenuItem;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Hamper')]")]
        private IWebElement hamperMenuItem;






        //Methods
        public void clinicSetup()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            
            wait.Until(ExpectedConditions.ElementToBeClickable(clinicMenuItem));
            Thread.Sleep(TimeSpan.FromSeconds(5));
            clinicMenuItem.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(clinicSetupMenuItem));
            clinicSetupMenuItem.Click();
        }

        public void donorAttendance()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementToBeClickable(clinicMenuItem));
            clinicMenuItem.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(donorAttendanceMenuItem));
            donorAttendanceMenuItem.Click();
        }

        public void hamper()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementToBeClickable(clinicMenuItem));
            clinicMenuItem.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hamperMenuItem));
            hamperMenuItem.Click();
        }

        public void donations()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementToBeClickable(donationsMenuItem));
            donationsMenuItem.Click();
        }

        public void audit()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementToBeClickable(auditMenuItem));
            auditMenuItem.Click();
        }

        public void reports()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementToBeClickable(reportsMenuItem));
            reportsMenuItem.Click();
        }

        public void home()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementToBeClickable(homeMenuItem));
            homeMenuItem.Click();
        }

    }
}
