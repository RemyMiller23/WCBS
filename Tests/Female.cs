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
    [AllureSuite("Positive E2E Female Test Cases")]
    public class Female : Setup
    {
        [Test]
        [Order(1)]
        [Category("Regression")]
        [Category("Female")]
        [Category("Smoke")]
        [Retry(2)]
        public void ACreateHamper()
        {
            // ---------------- Pulse Donations ----------------
            POM.login.standard();
            POM.home.hamper();
            POM.linkHamper.linkNewHamper();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Category("Smoke")]
        [Retry(2)]
        public void WholeBloodDryPack()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.wholeBloodDryPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void WholeBloodQuadPack()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.wholeBloodQuadPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void TherapeuticsDryPack()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.therapeuticsDryPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Category("Smoke")]
        [Retry(2)]
        public void TherapeuticsQuadPack()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.therapeuticsQuadPack();
            POM.linking.linkWBT();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void BloodSampleTests_FBC()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.bstFBC();
            POM.linking.linkBST1();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void BloodSampleTests_HepatitisQuery()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.bstHepatitisQuery();
            POM.linking.linkBST3();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void BloodSampleTests_TestOnly()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.bstTestOnly();
            POM.linking.linkTestOnly();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void BloodSampleTests_Reagents()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.bstReagents();
            POM.linking.linkBST3();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void BloodSampleTests_Counselling()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.bstCounselling();
            POM.linking.linkBST4();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void BloodSampleTests_ConvalescentPlasma()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.bstConvalescentPlasma();
            POM.linking.linkBST8();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void BloodSampleTests_Virology()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.bstVirology();
            POM.linking.linkBST4();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void BloodSampleTests_LookBack()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.bstLookBack();
            POM.linking.linkBST3();
            POM.donation.donateSample();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void Apheresis_PlasmaPack()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.apheresisPlasmaPack();
            POM.linking.linkASP();
            POM.donation.donateHemoFlowBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }

        [Test]
        [Category("Regression")]
        [Category("Female")]
        [Retry(2)]
        public void SourcePlasma_SP()
        {
            // ---------------- Pulse Donations ----------------
            POM.donorSetup.getFemaleCustomerDetails();
            POM.login.standard();
            POM.home.donations();
            POM.findADonor.createNewDonor();
            POM.registration.updateFemalePersonalInformation();
            POM.testing.updatePostiveTestingInformation();
            POM.interview.sourcePlasmaSP();
            POM.linking.linkASP();
            POM.donation.donateHaemoneticsBlood();
            POM.hamper.linkHamper();
            POM.home.audit();
            POM.audit.auditHamperLinking();
        }
    }
}
