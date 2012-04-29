using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Recurly.js
{
    public class RecurlyTransaction
    {
        public enum TransactionStatus
        {
            [XmlEnum("failed")]
            Failed,
            [XmlEnum("success")]
            Success,
            [XmlEnum("void")]
            Void
        }
        public enum TransactionAction
        {
            [XmlEnum("purchase")]
            Purchase,
            [XmlEnum("refund")]
            Refund,
            [XmlEnum("authorization")]
            Authorization
        }
        [XmlElement("uuid")]
        public string Uuid { get; set; }
        [XmlElement("action")]
        public TransactionAction Action { get; set; }
        [XmlElement("amount_in_cents")]
        public int AmountInCents { get; set; }
        [XmlElement("tax_in_cents")]
        public int TaxInCents { get; set; }
        [XmlElement("currency")]
        public string Currency { get; set; }
        [XmlElement("status")]
        public TransactionStatus Status { get; set; }
        /// <summary>
        /// Payment reference from payment gateway
        /// </summary>
        [XmlElement("reference")]
        public string Reference { get; set; }
        [XmlElement("recurring")]
        public bool Recurring { get; set; }
        [XmlElement("test")]
        public bool Test { get; set; }
        [XmlElement("details")]
        public RecurlyTransactionDetails Details { get; set; }

    }
}
