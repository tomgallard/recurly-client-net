using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Recurly.Test
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void CreateAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Create Account");
            acct.Create();
        }

        [TestMethod]
        public void LookupAccount()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Account");
            newAcct.Create();

            RecurlyAccount acct = RecurlyAccount.Get(newAcct.AccountCode);
            Assert.IsNotNull(acct);
            Assert.AreEqual(acct.AccountCode, newAcct.AccountCode);
            Assert.IsTrue(!String.IsNullOrEmpty(acct.Email));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void FindNonExistantAccount()
        {
            RecurlyAccount acct = RecurlyAccount.Get("totallynotfound!@#$");
        }

        [TestMethod]
        public void UpdateAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Update Account");
            acct.Create();

            acct.LastName = "UpdateTest123";
            acct.Update();

            RecurlyAccount getAcct = RecurlyAccount.Get(acct.AccountCode);
            Assert.AreEqual(acct.LastName, getAcct.LastName);
        }

        [TestMethod]
        public void CloseAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Close Account");
            acct.Create();

            acct.CloseAccount();
        }
    }
}