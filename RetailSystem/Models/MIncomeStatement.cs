using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MIncomeStatement
    {
        public string Type { get; set; }
        public string Accountid { get; set; }
        public string AccountName { get; set; }
        public string value { get; set; }
        public float NetProfit { get; set; }
    }
}