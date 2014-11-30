using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MInventory
    {
        public string id { get; set; }
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProducyTag1 { get; set; }
        public string ProductTag2 { get; set; }
        public string WareHouseld { get; set; }
        public string WareHouseName { get; set; }
        public string Cost { get; set; }
        public string Quantity { get; set; }
        public string FiscalYearld { get; set; }
        public DateTime Date { get; set; }
        public float TotalProductCost { get; set; }
        public float TotalCost { get; set; }
        public float TotalUnits { get; set; }
    }
}