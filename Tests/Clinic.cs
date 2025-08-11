using Allure.NUnit;
using Allure.NUnit.Attributes;
using System;
using PulseDonations.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.Tests
{
    [TestFixture]
    [Order(4)]
    [Category("Clinic")]
    [Category("Regression")]
    [AllureSuite("Clinic Test Cases")]
    public class Clinic:Setup
    {
        [Test]
        [Category("Smoke")]
        [Order(1)]
        [Retry(2)]
        public void SetupClinicReport()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Setup Clinic Report Test ----------------");
            POM.donorSetup.getClinicDetails();
            POM.login.standard();
            POM.home.clinicSetup();
            POM.clinicSetup.updateClinicDetails();


        }

        [Test]
        [Category("Smoke")]
        [Order(2)]
        [Retry(2)]
        public void SetupGeneralReport()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Setup Clinic General Report Test ----------------");
            POM.donorSetup.getClinicDetails();
            POM.login.standard();
            POM.home.clinicSetup();
            POM.clinicSetup.setupgeneralReportHemoCue();
            POM.home.clinicSetup();
            POM.clinicSetup.setupgeneralReportDBPM();
            POM.home.clinicSetup();
            POM.clinicSetup.setupgeneralReportBP();
            POM.home.clinicSetup();
            POM.clinicSetup.setupgeneralReportST();
            POM.home.clinicSetup();
            POM.clinicSetup.setupgeneralReportHFC();
            POM.home.clinicSetup();
            POM.clinicSetup.setupgeneralReportEC();
            POM.home.clinicSetup();
            POM.clinicSetup.setupgeneralReportSP();
        }

        [Test]
        [Category("Smoke")]
        [Order(3)]
        [Retry(2)]
        public void GeneralReportAudit()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Clinic General Report Audit Test ----------------");
            POM.donorSetup.getClinicDetails();
            POM.login.standard();
            POM.home.clinicSetup();
            POM.clinicSetup.generalReportAudit();
        }
    }
}
 