using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.PageObjects.DonorAttendance
{
    public class DonorAttendancePage
    {
        //DriverSetup
        private IWebDriver driver;
        public DonorAttendancePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='Search']")]
        private IWebElement searchButton;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='totalDonors']")]
        private IList<IWebElement> dataLabels;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='deferredDonorsTotal']")]
        private IWebElement defferedDonors;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='donorAttendance']")]
        private IWebElement totalDonors;


        

        







        //Methods
        public void overallAttendanceRecord()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-title-text")));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchButton));
            searchButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-cell[normalize-space(text())='Underweight']")));

            string donorsTotal = totalDonors.GetAttribute("value");
            int.TryParse(donorsTotal, out int donorsTotalValue);
            Assert.GreaterOrEqual(donorsTotalValue, 8);
        }

        public void defferalAttendanceRecord()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-title-text")));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchButton));
            searchButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-cell[normalize-space(text())='Underweight']")));


            string? totalDefferal = null;
            int defferedSum = 0;

            foreach (var cell in dataLabels)
            {
                totalDefferal = cell.Text;
                int.TryParse(totalDefferal, out int value);
                defferedSum += value;
            }
            
            string defferedDonorsTotal = defferedDonors.GetAttribute("value");
            int.TryParse(defferedDonorsTotal, out int defferedDonorsTotalValue);
            Assert.AreEqual(defferedDonorsTotalValue, defferedSum);
        }

        
    }
}
