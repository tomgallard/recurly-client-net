using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using RestSharp;

namespace Recurly.js
{
    public class RecurlyJs
    {
        private const string _baseUrl = "https://api.recurly.com/v2/";
        private readonly string _privateKey;
        private readonly string _apiKey;
        public RecurlyJs(string privateKey,string apiKey)
        {
            _privateKey = privateKey;
            _apiKey= apiKey;
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
            fullStringBuilder.Append("&timestamp=");
            fullStringBuilder.Append(DateTimeToUnixTimestamp(DateTime.UtcNow));
            string stringToSign = fullStringBuilder.ToString();
            fullStringBuilder.Insert(0,"|");
            fullStringBuilder.Insert(0, GetHmacHash(stringToSign));
            return fullStringBuilder.ToString();
        }

        public long DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (long)(dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }
        public string GetHmacHash(string stringToSign)
        {
            var enc = Encoding.ASCII;
            HMACSHA1 hmac = new HMACSHA1(enc.GetBytes(_privateKey.ToString()));
            hmac.Initialize();

            byte[] buffer = enc.GetBytes(stringToSign);
            return BitConverter.ToString(hmac.ComputeHash(buffer)).Replace("-", "").ToLower();
        }

        public RecurlyInvoice VerifyToken(string token)
        {
            RestClient reqclient = new RestClient(_baseUrl);
            RestRequest request = new RestRequest("recurly_js/result/{token}",Method.GET);
            request.AddParameter("token",token,ParameterType.UrlSegment);
        //    reqclient.AddDefaultHeader("Accept", "application/xml");
            reqclient.AddDefaultHeader("Authorization", AuthorizationHeaderValue);
            var resp = reqclient.Execute<RecurlyInvoice>(request);
            return resp.Data;
        }

        private string AuthorizationHeaderValue
        {
            get
            {
                        return "Basic " +
                            Convert.ToBase64String(Encoding.UTF8.GetBytes(_apiKey));

            }
        }
    }
}
