using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security;

namespace Recurly.js
{
    public class RecurlyJs
    {
        private readonly string _privateKey;
        public RecurlyJs(string privateKey)
        {
            _privateKey = privateKey;
        }
        private string GenerateNonce()
        {
            return Guid.NewGuid().ToString();
        }
        public string SignString(string valuesToSign)
        {
            StringBuilder fullStringBuilder = new StringBuilder();
            fullStringBuilder.Append("nonce=");
            fullStringBuilder.Append(GenerateNonce());
            fullStringBuilder.Append("&");
            fullStringBuilder.Append(valuesToSign);
            fullStringBuilder.Append("timestamp=");
            fullStringBuilder.Append(DateTimeToUnixTimestamp(DateTime.UtcNow));
            string stringToSign = fullStringBuilder.ToString();
            fullStringBuilder.Insert(0,"|");
            fullStringBuilder.Insert(0, GetHmacHash(stringToSign));
            return fullStringBuilder.ToString();
        }

        public double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }
        public string GetHmacHash(string stringToSign)
        {
            var enc = Encoding.ASCII;
            HMACSHA1 hmac = new HMACSHA1(enc.GetBytes(_privateKey.ToString()));
            hmac.Initialize();

            byte[] buffer = enc.GetBytes(stringToSign);
            return BitConverter.ToString(hmac.ComputeHash(buffer)).Replace("-", "").ToLower();
        }
    }
}
