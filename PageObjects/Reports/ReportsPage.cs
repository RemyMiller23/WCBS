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

namespace PulseDonations.PageObjects.Reports
{
    public class ReportsPage
    {
        //DriverSetup
        private IWebDriver driver;
        public ReportsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddRegions']")]
        private IWebElement region;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[text()=' HQ ']]")]
        private IWebElement hq;

        [FindsBy(How = How.CssSelector, Using = "mat-select[formcontrolname='ddPanels']")]
        private IWebElement selectPanel;

        [FindsBy(How = How.XPath, Using = "//mat-option[.//span[contains(text(), 'AJJ')]]")]
        private IWebElement ajj;

        [FindsBy(How = How.CssSelector, Using = "i[mattooltip='Search']")]
        private IWebElement searchIconButton;

        [FindsBy(How = How.XPath, Using = "//div[@role='tab' and .//span[text()=' Daily Attendance Stats ']]")]
        private IWebElement dailyAttendanceStatsTab;

        [FindsBy(How = How.XPath, Using = "//div[@role='tab' and .//span[text()=' Daily Attendance Detail ']]")]
        private IWebElement dailyAttendanceDetailTab;

        [FindsBy(How = How.XPath, Using = "//div[@role='tab' and .//span[text()=' Haemovigilance Stats ']]")]
        private IWebElement haemovigilanceStatsTab;

        [FindsBy(How = How.XPath, Using = "//div[@role='tab' and .//span[text()=' Haemovigilance Detail ']]")]
        private IWebElement haemovigilanceDetailsTab;

        [FindsBy(How = How.XPath, Using = "//div[@role='tab' and .//span[text()=' Daily Digital Questionnaire Stats ']]")]
        private IWebElement dailyDigitalQuestionnaireStatsTab;

        [FindsBy(How = How.XPath, Using = "//div[@role='tab' and .//span[text()=' Digital Questionnaire Detail ']]")]
        private IWebElement dailyDigitalQuestionnaireDetailTab;

        [FindsBy(How = How.XPath, Using = "(//mat-cell[@data-label='total'])[1]")]
        private IWebElement dailyAttendanceStatsDonationTotal;

        [FindsBy(How = How.XPath, Using = "(//mat-cell[@data-label='total'])[last()]")]
        private IWebElement dailyAttendanceStatsDefferalTotal;

        [FindsBy(How = How.XPath, Using = "(//mat-cell[@data-label='total'])[last()]")]
        private IWebElement haemovigilanceStatsTotal;

        [FindsBy(How = How.CssSelector, Using = "mat-cell[data-label='donorName']")]
        private IList<IWebElement> DonorNameDataLabels;



        //Methods
        public void dailyAttendanceStats()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            dailyAttendanceStatsTab.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(region));
            region.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hq));
            hq.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(driver => selectPanel.GetAttribute("aria-disabled") == "false");
            wait.Until(ExpectedConditions.ElementToBeClickable(selectPanel));
            selectPanel.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ajj));
            ajj.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(searchIconButton));
            searchIconButton.Click();

            string firstTotalText = dailyAttendanceStatsDonationTotal.Text;
            int.TryParse(firstTotalText, out int firstTotalValue);
            Assert.Greater(firstTotalValue, 0);

            string lastTotalText = dailyAttendanceStatsDefferalTotal.Text;
            int.TryParse(lastTotalText, out int lastTotalValue);
            Assert.Greater(lastTotalValue, 0);


        }

        public void dailyAttendanceDetails()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            dailyAttendanceDetailTab.Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(region));
            region.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hq));
            hq.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(driver => selectPanel.GetAttribute("aria-disabled") == "false");
            wait.Until(ExpectedConditions.ElementToBeClickable(selectPanel));
            selectPanel.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ajj));
            ajj.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(searchIconButton));
            searchIconButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            string? donorName = null;

            foreach (var cell in DonorNameDataLabels)
            {


                if (cell.Text != null)
                {
                    donorName = cell.Text;
                    break;
                }
            }
            Assert.IsNotNull(donorName);

        }

        public void haemovigilanceStats()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            haemovigilanceStatsTab.Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(region));
            region.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hq));
            hq.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(driver => selectPanel.GetAttribute("aria-disabled") == "false");
            wait.Until(ExpectedConditions.ElementToBeClickable(selectPanel));
            selectPanel.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ajj));
            ajj.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(searchIconButton));
            searchIconButton.Click();

            
            string lastTotalText = haemovigilanceStatsTotal.Text;
            int.TryParse(lastTotalText, out int lastTotalValue);
            Assert.Greater(lastTotalValue, 0);


        }

        public void haemovigilanceDetails()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            haemovigilanceDetailsTab.Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(region));
            region.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hq));
            hq.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(driver => selectPanel.GetAttribute("aria-disabled") == "false");
            wait.Until(ExpectedConditions.ElementToBeClickable(selectPanel));
            selectPanel.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(ajj));
            ajj.Click();
            actions.SendKeys(Keys.Escape).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(searchIconButton));
            searchIconButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            string? donorName = null;

            foreach (var cell in DonorNameDataLabels)
            {


                if (cell.Text != null)
                {
                    donorName = cell.Text;
                    break;
                }
            }
            Assert.IsNotNull(donorName);

        }

        public void dailyDigitalQuestionnaireStats()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            dailyDigitalQuestionnaireStatsTab.Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));

        }

        public void dailyDigitalQuestionnaireDetails()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actions = new Actions(driver);

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-tab-labels")));
            dailyDigitalQuestionnaireDetailTab.Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));

        }
    }
}
