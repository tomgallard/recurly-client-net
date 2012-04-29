using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recurly.Test
{
    [TestClass]
    public class BillingInfoTest
    {
        [TestMethod]
        public void UpdateBillingInfo()
        {
            RecurlyAccount acct = Factories.NewAccount("Update Billing Info");
            acct.Create();

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(acct);
            billingInfo.Update();
        }

        [TestMethod]
        public void LookupBillingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Billing Info");
            newAcct.Create();

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(newAcct);
            billingInfo.Update();

            RecurlyBillingInfo lookupBilling = RecurlyBillingInfo.Get(newAcct.AccountCode);
            Assert.AreEqual(billingInfo.Address1, lookupBilling.Address1);
            Assert.AreEqual(billingInfo.PostalCode, lookupBilling.PostalCode);
            Assert.IsTrue(!String.IsNullOrEmpty(billingInfo.CreditCard.CreditCardType));
        }

        [TestMethod]
        public void LookupMissingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Missing Billing Info");
            newAcct.Create();

            RecurlyBillingInfo billingInfo = RecurlyBillingInfo.Get(newAcct.AccountCode);
            Assert.IsNull(billingInfo);
        }

        [TestMethod]
        public void ClearBillingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Clear Billing Info");
            newAcct.Create();

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(newAcct);
            billingInfo.Update();

            billingInfo.ClearBillingInfo();
        }

        [TestMethod]
        public void CloseAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Close Account");
            acct.CloseAccount();
        }
    }
}