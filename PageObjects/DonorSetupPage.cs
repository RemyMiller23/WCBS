using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PulseDonations.Utilities;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.PageObjects
{
    public class DonorSetupPage
    {

        //DriverSetup
        private IWebDriver driver;
        public DonorSetupPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //PageObjectFactory
        [FindsBy(How = How.Name, Using = "age")]
        private IWebElement age;

        [FindsBy(How = How.Name, Using = "month")]
        private IWebElement month;

        [FindsBy(How = How.Name, Using = "day")]
        private IWebElement day;

        [FindsBy(How = How.Name, Using = "gender")]
        private IWebElement genderDropdown;

        [FindsBy(How = How.Id, Using = "said_generate_object")]
        private IWebElement generateButton;

        [FindsBy(How = How.CssSelector, Using = "table.table-said-generator td")]
        private IWebElement SAID;



        //Methods
        public void getMaleCustomerDetails()

        {
            //GlobalVariables & Waits
            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.Navigate().GoToUrl(@"https://www.axonwireless.com/toolbox/sa-id-number-generator/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var faker = new Faker("en");
            string[] suburbs = {
            "Claremont", "Rondebosch", "Kenilworth", "Newlands", "Wynberg",
            "Constantia", "Bishopscourt", "Observatory", "Salt River", "Woodstock",
            "Mowbray", "Rosebank", "Tokai", "Plumstead", "Diep River", "Bergvliet",
            "Muizenberg", "Fish Hoek", "Kalk Bay", "Simon’s Town", "Noordhoek",
            "Hout Bay", "Sea Point", "Green Point", "Bantry Bay", "Camps Bay",
            "Clifton", "Gardens", "Tamboerskloof", "Bo-Kaap", "De Waterkant",
            "Table View", "Bloubergstrand", "Parklands", "Milnerton", "Century City",
            "Durbanville", "Bellville", "Brackenfell", "Goodwood", "Parow",
            "Kuils River", "Somerset West", "Strand", "Gordon’s Bay", "Stellenbosch",
            "Franschhoek", "Paarl", "Wellington", "Melkbosstrand"
            };




            //ID Number generator
            Random generator = new Random();
            string randAge = generator.Next(16, 55).ToString("D2");
            string randMonth = generator.Next(1, 12).ToString("D2");
            string randDay = generator.Next(1, 28).ToString("D2");



            //Execution
            age.Clear();
            age.SendKeys(randAge);
            month.Clear();
            month.SendKeys(randMonth);
            day.Clear();
            day.SendKeys(randDay);

            var select = new SelectElement(genderDropdown);
            select.SelectByText("Male");

            Thread.Sleep(TimeSpan.FromSeconds(5));


            try
            {
                generateButton.Click();

            }

            catch (ElementClickInterceptedException)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                try
                {
                    generateButton.Click();

                }
                catch
                {
                    TestContext.Progress.WriteLine("ID Generation Failed");
                    ScreenshotHelper.CaptureScreenshot(driver, TestContext.CurrentContext.Test.Name);
                    Assert.Fail("ID Generation Failed");
                }

            }


            string ID = SAID.Text;



            if (ID.Length > 13)
            {
                ID = ID.Substring(0, 13);
            }



            //dynamic Variables
            string randPostalCode = generator.Next(1, 9999).ToString("D4");
            string randSerialNumber = generator.Next(10000000, 99999999).ToString("D8");
            double value = Math.Round(generator.NextDouble() * (14.5 - 13.5) + 13.5, 1);
            string Hemoglobin = value.ToString("F1");
            string FirstName = faker.Name.FirstName(Bogus.DataSets.Name.Gender.Male);
            string MiddleName = faker.Name.FirstName(Bogus.DataSets.Name.Gender.Male);
            string LastName = faker.Name.LastName();
            string PhoneNumber = faker.Phone.PhoneNumber("083#######");
            string StreetAddress = faker.Address.StreetAddress();
            string Suburb = faker.PickRandom(suburbs);
            string PostCode = randPostalCode;
            string Email = FirstName+ "@myspy.com";



            //Final Variables
            ConfigurationManager.AppSettings["IDNumber"] = ID;
            ConfigurationManager.AppSettings["FirstName"] = FirstName;
            ConfigurationManager.AppSettings["MiddleName"] = MiddleName;
            ConfigurationManager.AppSettings["Surname"] = LastName;
            ConfigurationManager.AppSettings["Email"] = Email;
            ConfigurationManager.AppSettings["PhoneNumber"] = PhoneNumber;
            ConfigurationManager.AppSettings["StreetAddress"] = StreetAddress;
            ConfigurationManager.AppSettings["Suburb"] = Suburb;
            ConfigurationManager.AppSettings["PostalCode"] = PostCode;
            ConfigurationManager.AppSettings["SerialNumber"] = randSerialNumber;
            ConfigurationManager.AppSettings["Hemoglobin"] = Hemoglobin;


            TestContext.Progress.WriteLine(ID);
            TestContext.Progress.WriteLine(FirstName);
            TestContext.Progress.WriteLine(MiddleName);
            TestContext.Progress.WriteLine(LastName);
            TestContext.Progress.WriteLine(Email);
            TestContext.Progress.WriteLine(PhoneNumber);
            TestContext.Progress.WriteLine(StreetAddress);
            TestContext.Progress.WriteLine(Suburb);
            TestContext.Progress.WriteLine(PostCode);
            TestContext.Progress.WriteLine(randSerialNumber);
            TestContext.Progress.WriteLine(Hemoglobin);



            driver.Close();
        }

        

        public void getFemaleCustomerDetails()

        {
            //GlobalVariables & Waits
            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.Navigate().GoToUrl(@"https://www.axonwireless.com/toolbox/sa-id-number-generator/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var faker = new Faker("en");
            string[] suburbs = {
            "Claremont", "Rondebosch", "Kenilworth", "Newlands", "Wynberg",
            "Constantia", "Bishopscourt", "Observatory", "Salt River", "Woodstock",
            "Mowbray", "Rosebank", "Tokai", "Plumstead", "Diep River", "Bergvliet",
            "Muizenberg", "Fish Hoek", "Kalk Bay", "Simon’s Town", "Noordhoek",
            "Hout Bay", "Sea Point", "Green Point", "Bantry Bay", "Camps Bay",
            "Clifton", "Gardens", "Tamboerskloof", "Bo-Kaap", "De Waterkant",
            "Table View", "Bloubergstrand", "Parklands", "Milnerton", "Century City",
            "Durbanville", "Bellville", "Brackenfell", "Goodwood", "Parow",
            "Kuils River", "Somerset West", "Strand", "Gordon’s Bay", "Stellenbosch",
            "Franschhoek", "Paarl", "Wellington", "Melkbosstrand"
            };




            //ID Number generator
            Random generator = new Random();
            string randAge = generator.Next(16, 55).ToString("D2");
            string randMonth = generator.Next(1, 12).ToString("D2");
            string randDay = generator.Next(1, 28).ToString("D2");



            //Execution
            age.Clear();
            age.SendKeys(randAge);
            month.Clear();
            month.SendKeys(randMonth);
            day.Clear();
            day.SendKeys(randDay);

            var select = new SelectElement(genderDropdown);
            select.SelectByText("Female");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            try
            {
                generateButton.Click();
                
            }

            catch (ElementClickInterceptedException)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                try
                {
                    generateButton.Click();

                }
                catch
                {
                    TestContext.Progress.WriteLine("ID Generation Failed");
                    ScreenshotHelper.CaptureScreenshot(driver, TestContext.CurrentContext.Test.Name);
                    Assert.Fail("ID Generation Failed");
                }
                
            }

            string ID = SAID.Text;



            if (ID.Length > 13)
            {
                ID = ID.Substring(0, 13);
            }



            //dynamic Variables
            string randPostalCode = generator.Next(1, 9999).ToString("D4");
            string randSerialNumber = generator.Next(10000000, 99999999).ToString("D8");
            double value = Math.Round(generator.NextDouble() * (13.5 - 12.5) + 12.5, 1);
            string Hemoglobin = value.ToString("F1");
            string FirstName = faker.Name.FirstName(Bogus.DataSets.Name.Gender.Female);
            string MiddleName = faker.Name.FirstName(Bogus.DataSets.Name.Gender.Female);
            string LastName = faker.Name.LastName();
            string PhoneNumber = faker.Phone.PhoneNumber("083#######");
            string StreetAddress = faker.Address.StreetAddress();
            string Suburb = faker.PickRandom(suburbs);
            string PostCode = randPostalCode;
            string Email = FirstName + "@myspy.com";



            //Final Variables
            ConfigurationManager.AppSettings["IDNumber"] = ID;
            ConfigurationManager.AppSettings["FirstName"] = FirstName;
            ConfigurationManager.AppSettings["MiddleName"] = MiddleName;
            ConfigurationManager.AppSettings["Surname"] = LastName;
            ConfigurationManager.AppSettings["Email"] = Email;
            ConfigurationManager.AppSettings["PhoneNumber"] = PhoneNumber;
            ConfigurationManager.AppSettings["StreetAddress"] = StreetAddress;
            ConfigurationManager.AppSettings["Suburb"] = Suburb;
            ConfigurationManager.AppSettings["PostalCode"] = PostCode;
            ConfigurationManager.AppSettings["SerialNumber"] = randSerialNumber;
            ConfigurationManager.AppSettings["Hemoglobin"] = Hemoglobin;


            TestContext.Progress.WriteLine(ID);
            TestContext.Progress.WriteLine(FirstName);
            TestContext.Progress.WriteLine(MiddleName);
            TestContext.Progress.WriteLine(LastName);
            TestContext.Progress.WriteLine(Email);
            TestContext.Progress.WriteLine(PhoneNumber);
            TestContext.Progress.WriteLine(StreetAddress);
            TestContext.Progress.WriteLine(Suburb);
            TestContext.Progress.WriteLine(PostCode);
            TestContext.Progress.WriteLine(randSerialNumber);
            TestContext.Progress.WriteLine(Hemoglobin);



            driver.Close();
        }
    }
}
