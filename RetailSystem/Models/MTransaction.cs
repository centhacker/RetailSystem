using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MTransaction
    {
        public string id { get; set; }
        public string TransactionDetails { get; set; }
        public string TransactionType { get; set; }
        public string OrderId { get; set; }
        public string ClientId { get; set; }
        public string VendorId { get; set; }
        public string FiscalYearId { get; set; }
        public string eDate { get; set; }
    }
}