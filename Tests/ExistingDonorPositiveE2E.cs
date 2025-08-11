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
    [Order(2)]
    [AllureNUnit]
    [Category("Existing")]
    [AllureSuite("Negative Test Cases")]
    public class ExistingDonorPositiveE2E:Setup
    {

        [Test]
        [Category("Regression")]
        [Category("Hamper")]
        [Order(1)]
        [Retry(2)]
        public void EDOpenHamper()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Open Hamper Test ----------------");
            POM.login.standard();
            POM.home.hamper();
            POM.linkHamper.linkNewHamper();
        }

        [Test]
        [Category("Regression")]
        [Category("Hamper")]
        [Order(2)]
        [Retry(2)]
        public void EDWholeBloodDryPack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor WholeBlood (Dry Pack) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.wholeBloodDryPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Smoke")]
        [Order(3)]
        [Retry(2)]
        public void EDWholeBloodQuadPack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor WholeBlood (Quad Pack) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.wholeBloodQuadPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Smoke")]
        [Category("Hamper")]
        [Order(4)]
        [Retry(2)]
        public void EDTherapeuticsDryPack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Therapeutics (Dry Pack) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.therapeuticsDryPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Order(5)]
        [Retry(2)]
        public void EDTherapeuticsQuadPack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Therapeutics (Quad Pack) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.therapeuticsQuadPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Smoke")]
        [Category("Hamper")]
        [Order(6)]
        [Retry(2)]
        public void EDBloodSampleTests_FBC()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Blood/Sample Tests (FBC) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstFBC();
            POM.linking.linkBST1();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Order(7)]
        [Retry(2)]
        public void EDBloodSampleTests_HepatitisQuery()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Blood/Sample Tests (Hepatitis Query) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstHepatitisQuery();
            POM.linking.linkBST3();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Hamper")]
        [Order(8)]
        [Retry(2)]
        public void EDBloodSampleTests_TestOnly()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Blood/Sample Tests (Test Only) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstTestOnly();
            POM.linking.linkTestOnly();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Order(9)]
        [Retry(2)]
        public void EDBloodSampleTests_Reagents()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Blood/Sample Tests (Reagents) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstReagents();
            POM.linking.linkBST3();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Order(10)]
        [Retry(2)]
        public void EDBloodSampleTests_Counselling()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Blood/Sample Tests (Counselling) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
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
        public void EDBloodSampleTests_ConvalescentPlasma()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Blood/Sample Tests (Convalescent Plasma) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
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
        public void EDBloodSampleTests_Virology()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Blood/Sample Tests (Virology) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
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
        public void EDBloodSampleTests_LookBack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Blood/Sample Tests (LookBack) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.bstLookBack();
            POM.linking.linkBST3();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Order(14)]
        [Retry(2)]
        public void EDApheresis_PlasmaPack()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Apheresis (Plasma Pack) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.apheresisPlasmaPack();
            POM.linking.linkASP();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Order(15)]
        [Retry(2)]
        public void EDSourcePlasma_SP()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Source Plasma (Source Plasma) Test ----------------");
            POM.donorSetup.getExistingDonorDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.findADonorDonation();
            POM.registration.genderIdentification();
            POM.testing.updateExistingTestingInformation();
            POM.interview.donorPersonalInfo();
            POM.interview.sourcePlasmaSP();
            POM.linking.linkASP();
            POM.donation.donateHaemoneticsBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Hamper")]
        [Category("Smoke")]
        [Order(16)]
        [Retry(2)]
        public void EDCloseHamper()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Existing Donor Close Hamper Test ----------------");
            POM.login.standard();
            POM.home.hamper();
            POM.linkHamper.closeHamper();
        }
    }

}
