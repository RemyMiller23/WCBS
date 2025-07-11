using Allure.NUnit;
using Allure.NUnit.Attributes;
using PulseDonations.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.Tests
{
    [AllureNUnit]
    [AllureSuite("Negative Test Cases")]
    public class Negative : Setup
    {
        [Test]
        [Category("Negative")]
        //[Category("Active")]
        //[Retry(2)]
        public void ShortTermDefferal()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getMaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateMalePersonalInformation();
            POM.testing.negativeShortTermDeferralTestingInformation();
            POM.deferrals.shortTermDeferral();
        }

        [Test]
        [Category("Negative")]
        //[Category("Active")]
        //[Retry(2)]
        public void MalariaDefferal()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getMaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateMalePersonalInformation();
            POM.testing.negativeOtherDeferralTestingInformation();
            POM.deferrals.malariaDeferral();
        }

        [Test]
        [Category("Negative")]
        //[Category("Active")]
        //[Retry(2)]
        public void LifestyleDefferal()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getMaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateMalePersonalInformation();
            POM.testing.negativeOtherDeferralTestingInformation();
            POM.deferrals.lifestyleDeferral();
        }

        [Test]
        [Category("Negative")]
        //[Category("Active")]
        //[Retry(2)]
        public void SurgicalDefferal()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getMaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateMalePersonalInformation();
            POM.testing.negativeOtherDeferralTestingInformation();
            POM.deferrals.surgicalDeferral();
        }

        [Test]
        [Category("Negative")]
        //[Category("Active")]
        //[Retry(2)]
        public void MedicalDefferal()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getMaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateMalePersonalInformation();
            POM.testing.negativeMedicalDeferralTestingInformation();
            POM.deferrals.medicalDeferral();
        }

        
    }
}
