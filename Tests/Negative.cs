using PulseDonations.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseDonations.Tests
{
    internal class Negative : Setup
    {

        [Test]
        [Order(1)]
        [Category("Negative")]
        [Category("Active")]
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
