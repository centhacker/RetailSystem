using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MSaleTransactions
    {
        public int id { get; set; }
        public string ProductID { get; set; }
        public string WareHouseId { get; set; }
        public string OrderId { get; set; }
        public string CostPrice { get; set; }
        public string SalePrice { get; set; }
        public string units { get; set; }
        public string transactionType { get; set; }
        public string clientID { get; set; }
        public string VendorID { get; set; }
        public DateTime date { get; set; }
        public string Discount { get; set; }
        
    }
}