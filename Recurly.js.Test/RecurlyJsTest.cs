using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recurly.js.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class RecurlyJsTest
    {
        [TestMethod]
        public void Sign_Transaction()
        {
            //Just checking for no errors here- not yet sure how we verify this,
            //unless we call into another way of signing and verify the two match
            TransactionRequest t = new TransactionRequest()
            {
                AmountInCents = 124,
                CurrencyCode = Currency.GBP,
                Description = "test description"
            };
            RecurlyJs signer = new RecurlyJs("testkey","testapi");
            var signedString = signer.SignString(t.ToSignableString());
        }
    }
}
