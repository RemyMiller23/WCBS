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
    [Order(5)]
    [AllureNUnit]
    [Category("Recon")]
    [Category("Regression")]
    [AllureSuite("Recon Test Cases")]
    public class Recon:Setup
    {
        [Test]
        [Category("Smoke")]
        [Order(1)]
        [Retry(2)]
        public void OverallAttendance()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Recon (Overall Attendance) Test ----------------");
            POM.login.standard();
            POM.home.donorAttendance();
            POM.donorAttendance.overallAttendanceRecord();
        }

        [Test]
        [Category("Smoke")]
        [Order(2)]
        [Retry(2)]
        public void DeferralAttendance()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Recon (Deferral Attendance) Test ----------------");
            POM.login.standard();
            POM.home.donorAttendance();
            POM.donorAttendance.defferalAttendanceRecord();
        }

        [Test]
        [Category("Smoke")]
        [Order(3)]
        [Retry(2)]
        public void DailyAttendanceStats()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Recon (Daily Attendance Stats) Test ----------------");
            POM.login.standard();
            POM.home.reports();
            POM.reports.dailyAttendanceStats();
        }

        [Test]
        [Category("Smoke")]
        [Order(4)]
        [Retry(2)]
        public void DailyAttendanceDetails()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Recon (Daily Attendance Details) Test ----------------");
            POM.login.standard();
            POM.home.reports();
            POM.reports.dailyAttendanceDetails();
        }

        [Test]
        [Category("Smoke")]
        [Order(5)]
        [Retry(2)]
        public void HaemovigilanceStats()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Recon (Haemovigilance Stats) Test ----------------");
            POM.login.standard();
            POM.home.reports();
            POM.reports.haemovigilanceStats();
        }

        [Test]
        [Category("Smoke")]
        [Order(6)]
        [Retry(2)]
        public void HaemovigilanceDetails()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Recon (Haemovigilance Details) Test ----------------");
            POM.login.standard();
            POM.home.reports();
            POM.reports.haemovigilanceDetails();
        }

        [Test]
        [Order(7)]
        [Retry(2)]
        public void DigitalQuestionnaireStats()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Recon (Digital Questionnaire Stats) Test ----------------");
            POM.login.standard();
            POM.home.reports();
            POM.reports.dailyDigitalQuestionnaireStats();
        }

        [Test]
        [Order(8)]
        [Retry(2)]
        public void DigitalQuestionnaireDetails()
        {
            // ---------------- Pulse Donations ----------------
            TestContext.Progress.WriteLine("---------------- Starting Recon (Digital Questionnaire Details) Test ----------------");
            POM.login.standard();
            POM.home.reports();
            POM.reports.dailyDigitalQuestionnaireDetails();
        }
    }
}
