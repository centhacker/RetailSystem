using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class PaymentLine
    {
        public int id { get; set; }
        public int PaymentId { get; set; }
        public int BankId { get; set; }
        public string PaidAmount { get; set; }
        public string RemainingAmount { get; set; }
        public string Date { get; set; }
        public string CumulativeAmount { get; set; }
        public string ModeOfPayment { get; set; }
        public string Cheque { get; set; }
    }
}