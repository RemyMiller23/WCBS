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
    [AllureNUnit]
    [AllureSuite("Non Functional Test Cases")]
    public class NonFunctional:Setup
    {

        [Test]
        [Order(1)]
        [Category("NonFunctional")]
        [Retry(2)]
        public void ACreateHamper()
        {
            // ---------------- Pulse Donations ----------------
            POM.login.standard();
            POM.home.hamper();
            POM.linkHamper.linkNewHamper();
        }
    }
}
