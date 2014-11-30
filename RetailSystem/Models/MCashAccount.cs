using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MCashAccount
    {
        public int id { get; set; }
        public string CashAccountName { get; set; }
        public int WareHouseId { get; set; }
        public string OpeningBalance { get; set; }
        public string BeginDate { get; set; }
        public string AccountType { get; set; }
        public int ClientId { get; set; }
        public int VendorId { get; set; }

    }
}