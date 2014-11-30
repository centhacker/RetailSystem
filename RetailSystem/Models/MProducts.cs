using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MProducts
    {
        public string id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string tag1 { get; set; }
        public string tag2 { get; set; }
        public string tag3 { get; set; }
        public string SalePrice { get; set; }
        public string CostPrice { get; set; }
        public string Manufacturer { get; set; }
        public string description { get; set; }
        public string Vendorld { get; set; }
        public string VendorName {get;set;}
        public string FiscalYearld { get; set; }
        public string eDate { get; set; }
        public string WareHouseId { get; set; }
    }
}