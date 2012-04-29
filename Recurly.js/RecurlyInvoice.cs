using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Recurly.js
{
    public class RecurlyInvoice
    {
        [XmlElement("uuid")]
        public string Uuid { get; set; }
        [XmlElement("state")]
        public string State { get; set; }
        [XmlElement("invoice_number")]
        public string InvoiceNumber { get; set; }
        [XmlElement("vat_number")]
        public string VatNumber { get; set; }
        [XmlElement("subtotal_in_cents")]
        public int SubtotalInCents { get; set; }
        [XmlElement("tax_in_cents")]
        public int TaxInCents { get; set; }
        [XmlElement("total_in_cents")]
        public int TotalInCents { get; set; }
        [XmlElement("currency")]
        public string Currency { get; set; }
        [XmlElement("created_at")]
        public DateTime CreatedAt { get; set; }

        [XmlElement("transactions")]
        public List<RecurlyTransaction> Transactions { get; set; }
        
    }
}
