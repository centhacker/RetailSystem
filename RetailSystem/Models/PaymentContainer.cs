using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class PaymentContainer
    {
        public int id { get; set; }
        public int PaymentId { get; set; }
        public int BankId { get; set; }
        public string AmountRemaning { get; set; }

    }
}