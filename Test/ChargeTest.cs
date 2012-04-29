using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recurly.Test
{
    [TestClass]
    public class ChargeTest
    {
        [TestMethod]
        public void CreateCharge()
        {
            RecurlyAccount acct = Factories.NewAccount("Create Charge");
            acct.Create();

            RecurlyCharge charge = RecurlyCharge.ChargeAccount(acct.AccountCode, 512, "$5.12 test charge");
            Assert.IsNotNull(charge);
        }
    }
}
