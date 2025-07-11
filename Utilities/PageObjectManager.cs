using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PulseDonations.PageObjects;
using PulseDonations.PageObjects.Audit;
using PulseDonations.PageObjects.Donations;
using PulseDonations.PageObjects.Hamper;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.Utilities
{
    public class PageObjectManager
    {

        //DriverSetup
        private IWebDriver driver;
        public PageObjectManager(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        public DonorSetupPage donorSetup { get; set; }
        public LoginPage login { get; private set; }
        public HomePage home {  get; private set; }
        public FindADonorPage findADonor { get; private set; }
        public RegistrationPage registration { get; private set; }
        public TestingPage testing { get; private set; }
        public interviewPage interview { get; private set; }
        public LinkingPage linking { get; private set; }
        public DonationPage donation { get; set; }
        public HamperPage hamper { get; set; }
        public AuditPage audit { get; set; }
        public LinkHamperPage linkHamper { get; set; }
        public DeferralsPage deferrals { get; set; }




        //Methods
        public void InitializePageObjects()

        {
            donorSetup = new DonorSetupPage(driver);
            login = new LoginPage(driver);
            home = new HomePage(driver);
            findADonor = new FindADonorPage(driver);
            registration = new RegistrationPage(driver);
            testing = new TestingPage(driver);
            interview = new interviewPage(driver);
            linking = new LinkingPage(driver);
            donation = new DonationPage(driver);
            hamper = new HamperPage(driver);
            audit = new AuditPage(driver);
            linkHamper = new LinkHamperPage(driver);
            deferrals = new DeferralsPage(driver);
        }
    }
}