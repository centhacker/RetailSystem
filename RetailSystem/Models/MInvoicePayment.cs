using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MInvoicePayment
    {
        public string id { get; set; }
        public string InvoiveId { get; set; }
        public string PaymentId { get; set; }
        public string Total { get; set; }
        public string Remaining { get; set; }
    }
}