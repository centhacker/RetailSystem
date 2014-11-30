using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MDefaultAccounts
    {
        public string Id { get; set; }
        public string DefaultPurchaseAccountId { get; set; }
        public string DefaultSaleAccountId { get; set; }
        public int WareHouseId { get; set; }

    }
}