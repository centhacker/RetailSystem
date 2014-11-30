using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MDefaultCashAccounts
    {
        public int id { get; set; }
        public int DefaultPurchaseAccountId { get; set; }
        public int DefaultSalesAccountId { get; set; }
        public int WareHouseId { get; set; }
    }
}