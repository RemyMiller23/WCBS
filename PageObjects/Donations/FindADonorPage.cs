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




        //Methods
        public void createNewDonor()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-title-text")));
            createNewDonorButton.Click();
            
        }
    }
}
