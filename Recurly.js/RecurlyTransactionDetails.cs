using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Recurly.js
{
    public class RecurlyTransactionDetails
    {
        [XmlElement("account")]
        public RecurlyAccountDetail Account { get; set; }
    }
    public class RecurlyAccountDetail
    {
        [XmlElement("account_code")]
        public string AccountCode { get; set; }

        [XmlElement("first_name")]
        public string FirstName { get; set; }

        [XmlElement("last_name")]
        public string LastName { get; set; }

        [XmlElement("company")]
        public string Company { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }
    }
}
