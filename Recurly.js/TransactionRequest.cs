using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Recurly.js
{
    public enum Currency
    {
        USD,
        GBP,
        EUR
    }
    public class TransactionRequest
    {
        public int AmountInCents { get; set; }
        public Currency CurrencyCode { get; set; }
        public string Description { get; set; }

        public string ToSignableString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetEncodedKey("amount_in_cents"));
            sb.Append(AmountInCents);
            sb.Append("&");
            sb.Append(GetEncodedKey("currency"));
            sb.Append(CurrencyCode.ToString());
            if (!String.IsNullOrEmpty(Description))
            {
                sb.Append("&");
                sb.Append(GetEncodedKey("description"));
                sb.Append(HttpUtility.UrlEncode(Description));
            }
            return sb.ToString();
        }
        private string GetEncodedKey(string key)
        {
            return HttpUtility.UrlEncode("transaction[" + key + "]") + "=";
        }

    }
}
