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
    public class LoginPage
    {

        //DriverSetup
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.Id, Using = "mat-input-0")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "mat-input-1")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "mat-input-2")]
        private IWebElement userTechPin;

        [FindsBy(How = How.Id, Using = "mat-select-0")]
        private IWebElement panelCodeButton;

        [FindsBy(How = How.Id, Using = "mat-option-1")]
        private IWebElement panelCode;

        [FindsBy(How = How.CssSelector, Using = ".mat-focus-indicator")]
        private IWebElement loginButton;




        //Methods
        public void standard()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string FE = ConfigurationManager.AppSettings["PulseDonationsUI"];
            string adUsername = ConfigurationManager.AppSettings["Username"];
            string adPassword = ConfigurationManager.AppSettings["Password"];
            string techPin = ConfigurationManager.AppSettings["TechPin"];

            driver.SwitchTo().Window(FE);

            username.SendKeys(adUsername);
            password.SendKeys(adPassword);
            userTechPin.SendKeys(techPin);
            panelCodeButton.Click();
            panelCode.Click();
            loginButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".PanelCode")));
        }
    }
}