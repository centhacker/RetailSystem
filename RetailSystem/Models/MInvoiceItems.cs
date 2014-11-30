using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MInvoiceItems
    {
        public string id { get; set; }
        public string InvoiceDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductCost { get; set; }
    }
}