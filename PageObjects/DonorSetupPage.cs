using Bogus;
using Bogus.DataSets;
using Newtonsoft.Json.Bson;
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
        public void getExistingDonorDetails()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Random generator = new Random();
            var faker = new Faker("en");

            string[] initials = {
            "a", "b", "c", "d", "f", "g", "h", "j", "k","l", "m", "n", "p", "r", "s","t"
            };

            string[] prefix_cell_list =
            {
                "060", "061", "062", "063", "064", "065", "066", "067", "068", "069",
                "071", "072", "073", "074", "076", "077", "078", "079",
                "081", "082", "083", "084"
            };

            string[] prefix_landline_list =
            {
                "010", "011", "012", "013", "014", "015", "016", "017", "018",
                "021", "022", "023", "027", "028",
                "031", "032", "033", "034", "035", "036", "039",
                "040", "041", "042", "043", "044", "045", "046", "047", "048", "049",
                "051", "053", "054", "056", "057", "058"
            };

            string IronConfig = generator.Next(0, 2).ToString("D1");
            string BatchNumber = generator.Next(10000000, 99999999).ToString("D8");
            string randSerialNumber = generator.Next(10000000, 99999999).ToString("D8");
            string FirstInital = faker.PickRandom(initials);
            string SecondInital = faker.PickRandom(initials);
            string randDay = generator.Next(1, 28).ToString("D2");
            string randMonth = generator.Next(1, 12).ToString("D2");
            string randYear = generator.Next(1985, 2005).ToString("D4");
            string DOB = $"{randDay}/{randMonth}/{randYear}";
            string ExpiryDate = DateTime.Today.ToString("dd/MM/yyyy");
            string prefix_cell = faker.PickRandom(prefix_cell_list);
            string suffix_cell = faker.Phone.PhoneNumber("#######");
            string prefix_landline = faker.PickRandom(prefix_landline_list);
            string suffix_landline = faker.Phone.PhoneNumber("#######");
            string PhoneNumber = prefix_cell + suffix_cell;
            string LandlineNumber = prefix_landline + suffix_landline;
            string randLotNumber1 = generator.Next(10000000, 99999999).ToString("D8");
            string randLotNumber2 = generator.Next(10000000, 99999999).ToString("D8");
            string randLotNumber3 = generator.Next(10000000, 99999999).ToString("D8");

            ConfigurationManager.AppSettings["IronConfig"] = IronConfig;
            ConfigurationManager.AppSettings["BatchNumber"] = BatchNumber;
            ConfigurationManager.AppSettings["ExpiryDate"] = ExpiryDate;
            ConfigurationManager.AppSettings["SerialNumber"] = randSerialNumber;
            ConfigurationManager.AppSettings["FirstInital"] = FirstInital;
            ConfigurationManager.AppSettings["SecondInital"] = SecondInital;
            ConfigurationManager.AppSettings["DOB"] = DOB;
            ConfigurationManager.AppSettings["PhoneNumber"] = PhoneNumber;
            ConfigurationManager.AppSettings["LandlineNumber"] = LandlineNumber;
            ConfigurationManager.AppSettings["LotNumber1"] = randLotNumber1;
            ConfigurationManager.AppSettings["LotNumber2"] = randLotNumber2;
            ConfigurationManager.AppSettings["LotNumber3"] = randLotNumber3;

            
            
            TestContext.Progress.WriteLine("Iron Config: " + IronConfig);
            TestContext.Progress.WriteLine("Batch Number: " + BatchNumber);
            TestContext.Progress.WriteLine("Expiry Date: " + ExpiryDate);
            TestContext.Progress.WriteLine("Serial Number: " + randSerialNumber);
            TestContext.Progress.WriteLine("First Inital: " + FirstInital);
            TestContext.Progress.WriteLine("Second Initial: " + SecondInital);
            TestContext.Progress.WriteLine("DOB: " + DOB);
            TestContext.Progress.WriteLine("Phone Number: " + PhoneNumber);
            TestContext.Progress.WriteLine("Landline Number: " + LandlineNumber);
            TestContext.Progress.WriteLine("Lot Number 1: " + randLotNumber1);
            TestContext.Progress.WriteLine("Lot Number 2: " + randLotNumber2);
            TestContext.Progress.WriteLine("Lot Number 3: " + randLotNumber3);
        }

        public void getDonorDetails()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Random random = new Random();
            var faker = new Faker("en");

            //Array Variables
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

            string[] prefix_cell_list =
            {
                "060", "061", "062", "063", "064", "065", "066", "067", "068", "069",
                "071", "072", "073", "074", "076", "077", "078", "079",
                "081", "082", "083", "084"
            };

            string[] prefix_landline_list =
            {
                "010", "011", "012", "013", "014", "015", "016", "017", "018",
                "021", "022", "023", "027", "028",
                "031", "032", "033", "034", "035", "036", "039",
                "040", "041", "042", "043", "044", "045", "046", "047", "048", "049",
                "051", "053", "054", "056", "057", "058"
            };

            //dynamic Variables
            string DonorGender = random.Next(0, 2).ToString("D1");
            string IronConfig = random.Next(0, 2).ToString("D1");
            string BatchNumber = random.Next(10000000, 99999999).ToString("D8");
            string randAge = random.Next(18, 55).ToString("D2");
            string randYear = random.Next(1985, 2005).ToString("D4");
            string randMonth = random.Next(1, 12).ToString("D2");
            string randDay = random.Next(1, 28).ToString("D2");
            string randPostalCode = random.Next(1, 9999).ToString("D4");
            string randSerialNumber = random.Next(10000000, 99999999).ToString("D8");
            string LastName = faker.Name.LastName();
            string prefix_cell = faker.PickRandom(prefix_cell_list);
            string suffix_cell = faker.Phone.PhoneNumber("#######");
            string prefix_landline = faker.PickRandom(prefix_landline_list);
            string suffix_landline = faker.Phone.PhoneNumber("#######");
            string PhoneNumber = prefix_cell + suffix_cell;
            string LandlineNumber = prefix_landline + suffix_landline;
            string StreetAddress = faker.Address.StreetAddress();
            string Suburb = faker.PickRandom(suburbs);
            string PostCode = randPostalCode;
            string DOB = $"{randDay}/{randMonth}/{randYear}";
            string ExpiryDate = DateTime.Today.ToString("dd/MM/yyyy");
            string CurrentTime = DateTime.Now.ToString("HHmmss");


            //ID Number Generation Setup
            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.Navigate().GoToUrl(@"https://www.axonwireless.com/toolbox/sa-id-number-generator/");
            wait.Until(ExpectedConditions.ElementToBeClickable(age));
            age.Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(age));
            age.SendKeys(randAge);
            wait.Until(ExpectedConditions.ElementToBeClickable(month));
            month.Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(month));
            month.SendKeys(randMonth);
            wait.Until(ExpectedConditions.ElementToBeClickable(day));
            day.Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(day));
            day.SendKeys(randDay);

            //Deteremine if Male/Female
            if (DonorGender == "0")
            {
                TestContext.Progress.WriteLine("Selected Male Donor");
                wait.Until(ExpectedConditions.ElementToBeClickable(genderDropdown));
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
                        Assert.Fail("ID Generation Failed");
                    }

                }

                string ID = SAID.Text;
                if (ID.Length > 13)
                {
                    ID = ID.Substring(0, 13);
                }
                ConfigurationManager.AppSettings["IDNumber"] = ID;
                TestContext.Progress.WriteLine("ID: " + ID);
                driver.Close();

                getMaleCustomerDetails();
            }
            else
            {
                TestContext.Progress.WriteLine("Selected Female Donor");
                wait.Until(ExpectedConditions.ElementToBeClickable(genderDropdown));
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
                        Assert.Fail("ID Generation Failed");
                    }

                }

                string ID = SAID.Text;
                if (ID.Length > 13)
                {
                    ID = ID.Substring(0, 13);
                }
                ConfigurationManager.AppSettings["IDNumber"] = ID;
                TestContext.Progress.WriteLine("ID: " + ID);
                driver.Close();

                getFemaleCustomerDetails();
            }


            //Final Variables
            ConfigurationManager.AppSettings["DonorGender"] = DonorGender;
            ConfigurationManager.AppSettings["IronConfig"] = IronConfig;
            ConfigurationManager.AppSettings["BatchNumber"] = BatchNumber;
            ConfigurationManager.AppSettings["Surname"] = LastName;
            ConfigurationManager.AppSettings["PhoneNumber"] = PhoneNumber;
            ConfigurationManager.AppSettings["LandlineNumber"] = LandlineNumber;
            ConfigurationManager.AppSettings["StreetAddress"] = StreetAddress;
            ConfigurationManager.AppSettings["Suburb"] = Suburb;
            ConfigurationManager.AppSettings["PostalCode"] = PostCode;
            ConfigurationManager.AppSettings["SerialNumber"] = randSerialNumber;
            ConfigurationManager.AppSettings["DOB"] = DOB;
            ConfigurationManager.AppSettings["ExpiryDate"] = ExpiryDate;
            ConfigurationManager.AppSettings["CurrentTime"] = CurrentTime;


            //Print Variables
            TestContext.Progress.WriteLine("Donor Gender: " + DonorGender);
            TestContext.Progress.WriteLine("Iron Config: " + IronConfig);
            TestContext.Progress.WriteLine("Batch Number: " + BatchNumber);
            TestContext.Progress.WriteLine("Last Name: " + LastName);
            TestContext.Progress.WriteLine("Phone Number: " + PhoneNumber);
            TestContext.Progress.WriteLine("Landline Number: " + LandlineNumber);
            TestContext.Progress.WriteLine("Street Address: " + StreetAddress);
            TestContext.Progress.WriteLine("Suburb: " + Suburb);
            TestContext.Progress.WriteLine("Postal Code: " + PostCode);
            TestContext.Progress.WriteLine("Serial Number: " + randSerialNumber);
            TestContext.Progress.WriteLine("DOB: " + DOB);
            TestContext.Progress.WriteLine("Expiry Date: " + ExpiryDate);
            TestContext.Progress.WriteLine("Current Time: " + CurrentTime);

        }

        public void getForeignDonorDetails()
        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Random random = new Random();
            var faker = new Faker("en");

            //Array Variables
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

            string[] prefix_cell_list =
            {
                "060", "061", "062", "063", "064", "065", "066", "067", "068", "069",
                "071", "072", "073", "074", "076", "077", "078", "079",
                "081", "082", "083", "084"
            };

            string[] prefix_landline_list =
            {
                "010", "011", "012", "013", "014", "015", "016", "017", "018",
                "021", "022", "023", "027", "028",
                "031", "032", "033", "034", "035", "036", "039",
                "040", "041", "042", "043", "044", "045", "046", "047", "048", "049",
                "051", "053", "054", "056", "057", "058"
            };

            //dynamic Variables
            string DonorGender = random.Next(0, 2).ToString("D1");
            string IronConfig = random.Next(0, 2).ToString("D1");
            string BatchNumber = random.Next(10000000, 99999999).ToString("D8");
            string randAge = random.Next(18, 55).ToString("D2");
            string randYear = random.Next(1985, 2005).ToString("D4");
            string randMonth = random.Next(1, 12).ToString("D2");
            string randDay = random.Next(1, 28).ToString("D2");
            string randPostalCode = random.Next(1, 9999).ToString("D4");
            string randSerialNumber = random.Next(10000000, 99999999).ToString("D8");
            string LastName = faker.Name.LastName();
            string prefix_cell = faker.PickRandom(prefix_cell_list);
            string suffix_cell = faker.Phone.PhoneNumber("#######");
            string prefix_landline = faker.PickRandom(prefix_landline_list);
            string suffix_landline = faker.Phone.PhoneNumber("#######");
            string PhoneNumber = prefix_cell + suffix_cell;
            string LandlineNumber = prefix_landline + suffix_landline;
            string StreetAddress = faker.Address.StreetAddress();
            string Suburb = faker.PickRandom(suburbs);
            string PostCode = randPostalCode;
            string DOB = $"{randDay}/{randMonth}/{randYear}";
            string ExpiryDate = DateTime.Today.ToString("dd/MM/yyyy");
            string CurrentTime = DateTime.Now.ToString("HHmmss");
            string IDTrailer = random.Next(100000000, 999999999).ToString("D9");
            


            //Deteremine if Male/Female
            if (DonorGender == "0")
            {
                TestContext.Progress.WriteLine("Selected Male Donor");
                getMaleCustomerDetails();
            }
            else
            {
                TestContext.Progress.WriteLine("Selected Female Donor");
                getFemaleCustomerDetails();
            }


            //Final Variables
            ConfigurationManager.AppSettings["DonorGender"] = DonorGender;
            ConfigurationManager.AppSettings["IronConfig"] = IronConfig;
            ConfigurationManager.AppSettings["BatchNumber"] = BatchNumber;
            ConfigurationManager.AppSettings["Surname"] = LastName;
            ConfigurationManager.AppSettings["PhoneNumber"] = PhoneNumber;
            ConfigurationManager.AppSettings["LandlineNumber"] = LandlineNumber;
            ConfigurationManager.AppSettings["StreetAddress"] = StreetAddress;
            ConfigurationManager.AppSettings["Suburb"] = Suburb;
            ConfigurationManager.AppSettings["PostalCode"] = PostCode;
            ConfigurationManager.AppSettings["SerialNumber"] = randSerialNumber;
            ConfigurationManager.AppSettings["DOB"] = DOB;
            ConfigurationManager.AppSettings["ExpiryDate"] = ExpiryDate;
            ConfigurationManager.AppSettings["CurrentTime"] = CurrentTime;



            //Print Variables
            TestContext.Progress.WriteLine("Donor Gender: " + DonorGender);
            TestContext.Progress.WriteLine("Iron Config: " + IronConfig);
            TestContext.Progress.WriteLine("Batch Number: " + BatchNumber);
            TestContext.Progress.WriteLine("Last Name: " + LastName);
            TestContext.Progress.WriteLine("Phone Number: " + PhoneNumber);
            TestContext.Progress.WriteLine("Landline Number: " + LandlineNumber);
            TestContext.Progress.WriteLine("Street Address: " + StreetAddress);
            TestContext.Progress.WriteLine("Suburb: " + Suburb);
            TestContext.Progress.WriteLine("Postal Code: " + PostCode);
            TestContext.Progress.WriteLine("Serial Number: " + randSerialNumber);
            TestContext.Progress.WriteLine("DOB: " + DOB);
            TestContext.Progress.WriteLine("Expiry Date: " + ExpiryDate);
            TestContext.Progress.WriteLine("Current Time: " + CurrentTime);


            //ID config
            string dobYear = randYear.Substring(randYear.Length - 2);
            string ID = $"{dobYear}{randMonth}{randDay}{IDTrailer}";
            ConfigurationManager.AppSettings["IDNumber"] = ID;
            TestContext.Progress.WriteLine("ID: " + ID);
        }


        public void getMaleCustomerDetails()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Random random = new Random();
            var faker = new Faker("en");

            //dynamic Variables
            double value = Math.Round(random.NextDouble() * (14.5 - 13.5) + 13.5, 1);
            string Hemoglobin = value.ToString("F1");
            string FirstName = faker.Name.FirstName(Bogus.DataSets.Name.Gender.Male);
            string MiddleName = faker.Name.FirstName(Bogus.DataSets.Name.Gender.Male);
            string Email = FirstName + "@myspy.com";
            string OutlierHemoglobin = "12.5";

            //Final Variables
            ConfigurationManager.AppSettings["FirstName"] = FirstName;
            ConfigurationManager.AppSettings["MiddleName"] = MiddleName;
            ConfigurationManager.AppSettings["Email"] = Email;
            ConfigurationManager.AppSettings["Hemoglobin"] = Hemoglobin;
            ConfigurationManager.AppSettings["OutlierHemoglobin"] = OutlierHemoglobin;

            //Print Variables
            TestContext.Progress.WriteLine("First Name: " + FirstName);
            TestContext.Progress.WriteLine("Middle Name: " + MiddleName);
            TestContext.Progress.WriteLine("Email: " + Email);
            TestContext.Progress.WriteLine("Hemoglobin: " + Hemoglobin);
            TestContext.Progress.WriteLine("OutlierHemoglobin: " + OutlierHemoglobin);

        }

        

        public void getFemaleCustomerDetails()

        {
            //GlobalVariables & Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Random random = new Random();
            var faker = new Faker("en");

            //dynamic Variables
            double value = Math.Round(random.NextDouble() * (13.5 - 12.5) + 12.5, 1);
            string Hemoglobin = value.ToString("F1");
            string FirstName = faker.Name.FirstName(Bogus.DataSets.Name.Gender.Female);
            string MiddleName = faker.Name.FirstName(Bogus.DataSets.Name.Gender.Female);
            string Email = FirstName + "@myspy.com";
            string OutlierHemoglobin = "11.5";

            //Final Variables
            ConfigurationManager.AppSettings["FirstName"] = FirstName;
            ConfigurationManager.AppSettings["MiddleName"] = MiddleName;
            ConfigurationManager.AppSettings["Email"] = Email;
            ConfigurationManager.AppSettings["Hemoglobin"] = Hemoglobin;
            ConfigurationManager.AppSettings["OutlierHemoglobin"] = OutlierHemoglobin;

            //Print Variables
            TestContext.Progress.WriteLine("First Name: " + FirstName);
            TestContext.Progress.WriteLine("Middle Name: " + MiddleName);
            TestContext.Progress.WriteLine("Email: " + Email);
            TestContext.Progress.WriteLine("Hemoglobin: " + Hemoglobin);
            TestContext.Progress.WriteLine("OutlierHemoglobin: " + OutlierHemoglobin);
        }

        public void getClinicDetails()
        {
            //GlobalVariables & Waits
            Random generator = new Random();

            //dynamic Variables
            string randVehicleRegistration = generator.Next(0, 999999).ToString("D6");
            string randTrailerRegistration = generator.Next(0, 999999).ToString("D6");
            string randHCSerialNumber1 = generator.Next(10000000, 99999999).ToString("D8");
            string randHCSerialNumber2 = generator.Next(10000000, 99999999).ToString("D8");
            string randCuvettesLot = generator.Next(10000000, 99999999).ToString("D8");
            string randDBPMSerialNumber = generator.Next(10000000, 99999999).ToString("D8");
            string randBPLot = generator.Next(10000000, 99999999).ToString("D8");
            string randDPLot = generator.Next(10000000, 99999999).ToString("D8");
            string randSTLot = generator.Next(10000000, 99999999).ToString("D8");
            string randHFSerialNumber = generator.Next(10000000, 99999999).ToString("D8");
            string randSPBatchNumber = generator.Next(10000000, 99999999).ToString("D8");
            string VehicleRegistration = "CAA" + randVehicleRegistration;
            string TrailerRegistration = "CAA" + randTrailerRegistration;

            //Final Variables
            ConfigurationManager.AppSettings["VehicleRegistration"] = VehicleRegistration;
            ConfigurationManager.AppSettings["TrailerRegistration"] = TrailerRegistration;
            ConfigurationManager.AppSettings["HCSerialNumber1"] = randHCSerialNumber1;
            ConfigurationManager.AppSettings["HCSerialNumber2"] = randHCSerialNumber2;
            ConfigurationManager.AppSettings["CuvettesLot"] = randCuvettesLot;
            ConfigurationManager.AppSettings["DBPMSerialNumber"] = randDBPMSerialNumber;
            ConfigurationManager.AppSettings["BPLot"] = randBPLot;
            ConfigurationManager.AppSettings["DPLot"] = randDPLot;
            ConfigurationManager.AppSettings["STLot"] = randSTLot;
            ConfigurationManager.AppSettings["HFSerialNumber"] = randHFSerialNumber;
            ConfigurationManager.AppSettings["SPBatchNumber"] = randSPBatchNumber;

            //Print Variables
            TestContext.Progress.WriteLine("VehicleRegistration: " + VehicleRegistration);
            TestContext.Progress.WriteLine("TrailerRegistration: " + TrailerRegistration);
            TestContext.Progress.WriteLine("HCSerialNumber1: " + randHCSerialNumber1);
            TestContext.Progress.WriteLine("HCSerialNumber2: " + randHCSerialNumber2);
            TestContext.Progress.WriteLine("CuvettesLot: " + randCuvettesLot);
            TestContext.Progress.WriteLine("DBPMSerialNumber: " + randDBPMSerialNumber);
            TestContext.Progress.WriteLine("BPLot: " + randBPLot);
            TestContext.Progress.WriteLine("DPLot: " + randDPLot);
            TestContext.Progress.WriteLine("STLot: " + randSTLot);
            TestContext.Progress.WriteLine("HFSerialNumber: " + randHFSerialNumber);
            TestContext.Progress.WriteLine("SPBatchNumber: " + randSPBatchNumber);

        }
    }
}
