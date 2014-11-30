using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MInventoryBalance
    {
        public DateTime date { get; set; }
        public int WareHouseId { get; set; }
        public string WareHouseName { get; set; }
        public string ProductName { get; set; }
        public int ProductsId { get; set; }
        public string PurchaseUnits { get; set; }
        public string PurchaseUnitsCost { get; set; }
        public string PurchaseTotal { get; set; }
        public string SaleUnits { get; set; }
        public string SaleUnitsCost { get; set; }
        public string SaleTotal { get; set; }
        public string BalanceUnits { get; set; }
        public string BalanceUnitsCost { get; set; }
        public string BalanceTotal { get; set; } 
    }
}