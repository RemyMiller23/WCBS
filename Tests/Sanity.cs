using Allure.NUnit;
using Allure.NUnit.Attributes;
using PulseDonations.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//namespace PulseDonations.Tests
//{
//    [AllureNUnit]
//    [AllureSuite("Sanity Test Cases")]
//    public class Sanity : Setup
//    {
//        [Test]
//        [Order(1)]
//        //[Retry(2)]
//        public void ACreateHamper()
//        {
//            // ---------------- Pulse Donations ----------------
//            POM.login.standard();
//            POM.home.hamper();
//            POM.linkHamper.linkNewHamper();
//        }
//        [Test]
//        [Retry(2)]
//        public void MaleE2ETest()
//        {
//            // ---------------- Pulse Donations ----------------
//            POM.donorSetup.getMaleCustomerDetails();
//            POM.login.standard();
//            POM.home.donations();
//            POM.findADonor.createNewDonor();
//            POM.registration.updateMalePersonalInformation();
//            POM.testing.updatePostiveTestingInformation();
//            POM.interview.wholeBloodDryPack();
//            POM.linking.linkWBT();
//            POM.donation.donateHemoFlowBlood();
//            POM.hamper.linkHamper();
//            POM.home.audit();
//            POM.audit.auditHamperLinking();
//        }

//        [Test]
//        //[Retry(2)]
//        public void FemaleE2ETest()
//        {
//            // ---------------- Pulse Donations ----------------
//            POM.donorSetup.getFemaleCustomerDetails();
//            POM.login.standard();
//            POM.home.donations();
//            POM.findADonor.createNewDonor();
//            POM.registration.updateFemalePersonalInformation();
//            POM.testing.updatePostiveTestingInformation();
//            POM.interview.wholeBloodDryPack();
//            POM.linking.linkWBT();
//            POM.donation.donateHemoFlowBlood();
//            POM.hamper.linkHamper();
//            POM.home.audit();
//            POM.audit.auditHamperLinking();
//        }
//    }
//}
