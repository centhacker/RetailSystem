using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MOrdersLine
    {
        public string id { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string SalePrice { get; set; }
        public string unit { get; set; }
        public string totalProductCost { get; set; }
        public string eDate { get; set; }
    }
}