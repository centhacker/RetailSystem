using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MInvoices
    {
        public string id { get; set; }
        public string InvoiceType { get; set; }
        public string InvoiceTotal { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string FiscalYearId { get; set; }
    }
}