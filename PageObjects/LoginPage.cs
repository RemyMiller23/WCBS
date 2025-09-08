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
        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='username']")]
        private IWebElement username;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='password']")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='techPin']")]
        private IWebElement userTechPin;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='panelcode']")]
        private IWebElement panelCodeButton;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[contains(text(), 'AJJ')]]")]
        private IWebElement panelCode;

        

        //[FindsBy(How = How.Id, Using = "mat-input-0")]
        //private IWebElement username;

        //[FindsBy(How = How.Id, Using = "mat-input-1")]
        //private IWebElement password;

        //[FindsBy(How = How.Id, Using = "mat-input-2")]
        //private IWebElement userTechPin;

        //[FindsBy(How = How.Id, Using = "mat-select-0")]
        //private IWebElement panelCodeButton;

        //[FindsBy(How = How.Id, Using = "mat-option-1")]
        //private IWebElement panelCode;

        [FindsBy(How = How.CssSelector, Using = ".mat-focus-indicator")]
        private IWebElement loginButton;




        //Methods
        public void standard()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            WebDriverWait errorWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string FE = ConfigurationManager.AppSettings["PulseDonationsUI"];
            string adUsername = ConfigurationManager.AppSettings["Username"];
            string adPassword = ConfigurationManager.AppSettings["Password"];
            string techPin = ConfigurationManager.AppSettings["TechPin"];

            driver.SwitchTo().Window(FE);

            try {
                wait.Until(ExpectedConditions.ElementToBeClickable(username));
                username.SendKeys(adUsername);
                wait.Until(ExpectedConditions.ElementToBeClickable(password));
                password.SendKeys(adPassword);
                wait.Until(ExpectedConditions.ElementToBeClickable(userTechPin));
                userTechPin.SendKeys(techPin);
                wait.Until(ExpectedConditions.ElementToBeClickable(panelCodeButton));
                panelCodeButton.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                wait.Until(ExpectedConditions.ElementToBeClickable(panelCode));
                panelCode.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(loginButton));
                loginButton.Click();
            }
            catch(WebDriverTimeoutException)
            {
                try
                {
                    driver.Navigate().Refresh();
                    wait.Until(ExpectedConditions.ElementToBeClickable(username));
                    username.SendKeys(adUsername);
                    wait.Until(ExpectedConditions.ElementToBeClickable(password));
                    password.SendKeys(adPassword);
                    wait.Until(ExpectedConditions.ElementToBeClickable(userTechPin));
                    userTechPin.SendKeys(techPin);
                    wait.Until(ExpectedConditions.ElementToBeClickable(panelCodeButton));
                    panelCodeButton.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    wait.Until(ExpectedConditions.ElementToBeClickable(panelCode));
                    panelCode.Click();
                    wait.Until(ExpectedConditions.ElementToBeClickable(loginButton));
                    loginButton.Click();
                }
                catch (WebDriverTimeoutException)
                {
                    Assert.Fail("No Panel Codes are available to be selected");
                }
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                errorWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-label[contains(text(), 'Techpin not allowed to access Pulse')]")));
                TestContext.Progress.WriteLine("Access problem - Techpin");
                Assert.Fail("Techpin not allowed to access Pulse, contact system administrator");
            }

            catch (WebDriverTimeoutException)
            {
                
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".PanelCode")));
            }
            catch (WebDriverTimeoutException)
            {
                TestContext.Progress.WriteLine("Panel Code Issue");
                Assert.Fail("No Panel codes loaded due to slow response times from server");
            }
            
        }
    }
}