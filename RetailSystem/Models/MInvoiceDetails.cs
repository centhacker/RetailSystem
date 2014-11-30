using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MInvoiceDetails
    {
        public string id { get; set; }
        public string InvoiceId { get; set; }
        public string OrderId { get; set; }
        public string VendorId { get; set; }
        public string Customer { get; set; }

    }
}