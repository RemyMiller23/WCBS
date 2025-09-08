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
    [TestFixture]
    [Order(1)]
    [AllureNUnit]
    [Category("New")]
    
    [AllureSuite("Positive E2E Test Cases")]
    public class NewDonorPositiveE2E : Setup
    {
        [Test]
        [Category("Regression")]
        [Category("Smoke")]
        [Category("OnceOff")]
        [Category("Propser")]
        [Order(1)]
        [Retry(5)]
        public void NDOpenHamper()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Open Hamper Test ----------------");
            POM.login.standard();
            POM.home.hamper();
            POM.linkHamper.linkNewHamper();
        }

        [Test]
        [Category("Smoke")]
        [Category("Propser")]
        [Order(2)]
        [Retry(2)]
        public void NDWholeBloodDryPack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor WholeBlood (Dry Pack) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.wholeBloodDryPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("OnceOff")]
        [Order(3)]
        [Retry(2)]
        public void NDWholeBloodQuadPack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor WholeBlood (Quad Pack) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.wholeBloodQuadPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Order(4)]
        [Retry(2)]
        public void NDTherapeuticsDryPack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Therapeutics (Dry Pack) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.therapeuticsDryPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Smoke")]
        [Category("OnceOff")]
        [Category("Propser")]
        [Order(5)]
        [Retry(2)]
        public void NDTherapeuticsQuadPack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Therapeutics (Quad Pack) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.therapeuticsQuadPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Order(6)]
        [Retry(2)]
        public void NDBloodSampleTests_FBC()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Blood Samples Test (FBC) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstFBC();
            POM.linking.linkBST1();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Order(7)]
        [Retry(2)]
        public void NDBloodSampleTests_HepatitisQuery()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Blood Samples Test (Hepatitis Query) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstHepatitisQuery();
            POM.linking.linkBST3();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Smoke")]
        [Category("OnceOff")]
        [Category("Propser")]
        [Order(8)]
        [Retry(2)]
        public void NDBloodSampleTests_TestOnly()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Blood Samples Test (Test Only) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstTestOnly();
            POM.linking.linkTestOnly();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Order(9)]
        [Retry(2)]
        public void NDBloodSampleTests_Reagents()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Blood Samples Test (Reagent) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstReagents();
            POM.linking.linkBST3();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Order(10)]
        [Retry(2)]
        public void NDBloodSampleTests_Counselling()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Blood Samples Test (Counselling) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstCounselling();
            POM.linking.linkBST4();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Order(11)]
        [Retry(2)]
        public void NDBloodSampleTests_ConvalescentPlasma()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Blood Samples Test (Convalescent Plasma) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstConvalescentPlasma();
            POM.linking.linkBST8();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Order(12)]
        [Retry(2)]
        public void NDBloodSampleTests_Virology()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Blood Samples Test (Virology) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstVirology();
            POM.linking.linkBST4();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Order(13)]
        [Retry(2)]
        public void NDBloodSampleTests_LookBack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Blood Samples Test (LookBack) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstLookBack();
            POM.linking.linkBST3();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Smoke")]
        [Order(14)]
        [Retry(2)]
        public void NDApheresis_PlasmaPack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Apheresis (Plasma Pack) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.apheresisPlasmaPack();
            POM.linking.linkASP();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Smoke")]
        [Order(15)]
        [Retry(2)]
        public void NDSourcePlasma_SP()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Source Plasma (Source Plasma) Test ----------------");
            POM.donorSetup.getDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateNewDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.sourcePlasmaSP();
            POM.linking.linkASP();
            POM.donation.donateHaemoneticsBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Smoke")]
        [Order(16)]
        [Retry(2)]
        public void NDForeigner()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor (Foreigner) Test ----------------");
            POM.donorSetup.getForeignDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateForeignDonorInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.wholeBloodQuadPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("OnceOff")]
        [Order(17)]
        [Retry(2)]
        public void NDCloseHamper()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting New Donor Close Hamper Test ----------------");
            POM.login.standard();
            POM.home.hamper();
            POM.linkHamper.closeHamper();
        }
    }
}
