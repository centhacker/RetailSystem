using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MTrialBalance
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public float Debit { get; set; }
        public float credit { get; set; }
    }
}