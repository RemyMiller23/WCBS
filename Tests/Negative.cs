using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using PulseDonations.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.Tests
{
    [TestFixture]
    [Order(3)]
    [Category("Negative")]
    [Category("Regression")]
    [AllureSuite("Negative Test Cases")]
    public class Negative : Setup
    {
        [Test]
        [Order(1)]
        [Retry(2)]
        public void ShortTermDefferal()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Negative Defferal (Short Term) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.negativeOtherDeferralTestingInformation();
            POM.deferrals.shortTermDeferral();
        }

        [Test]
        [Order(2)]
        [Retry(2)]
        public void MalariaDefferal()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Negative Defferal (Malaria) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.negativeOtherDeferralTestingInformation();
            POM.deferrals.malariaDeferral();
        }

        [Test]
        [Order(3)]
        [Retry(2)]
        public void LifestyleDefferal()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Negative Defferal (Lifestyle) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.negativeOtherDeferralTestingInformation();
            POM.deferrals.lifestyleDeferral();
        }

        [Test]
        [Order(4)]
        [Retry(2)]
        public void SurgicalDefferal()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Negative Defferal (Surgical) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.negativeOtherDeferralTestingInformation();
            POM.deferrals.surgicalDeferral();
        }

        [Test]
        [Order(5)]
        [Retry(2)]
        public void MedicalDefferal()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Negative Defferal (Medical) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.negativeOtherDeferralTestingInformation();
            POM.deferrals.medicalDeferral();
        }

        [Test]
        [Category("Smoke")]
        [Order(6)]
        [Retry(2)]
        public void LowHBDefferal()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Negative Defferal (Low HemoGlobin) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.negativeLowHBDeferralTestingInformation();
            POM.deferrals.lowHBDeferral();
        }

        [Test]
        [Order(7)]
        [Retry(2)]
        public void TravelHistoryDefferal()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Negative Defferal (Travel Hostory) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.negativeOtherDeferralTestingInformation();
            POM.deferrals.travelHistoryDeferral();
        }

        [Test]
        [Category("Smoke")]
        [Order(8)]
        [Retry(2)]
        public void UnderweightDefferal()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Negative Defferal (Underweight) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.negativeOtherDeferralTestingInformation();
            POM.deferrals.underWeightDeferral();
        }

        [Test]
        [Category("Smoke")]
        [Order(9)]
        [Retry(2)]
        public void VasovagalHaemovigilance()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Negative Haemovigilance (Vasovagal) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorHaemovigilance();
            POM.adverseEvent.vasovagal();
        }

        [Test]
        [Category("Smoke")]
        [Order(10)]
        [Retry(2)]
        public void VenepunctureHaemovigilance()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Negative Haemovigilance (Venepuncture) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorHaemovigilance();
            POM.adverseEvent.venepuncture();
        }

        [Test]
        [Category("Smoke")]
        [Order(11)]
        [Retry(2)]
        public void OtherHaemovigilance()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Negative Haemovigilance (Other) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorHaemovigilance();
            POM.adverseEvent.other();
        }
    }
}
