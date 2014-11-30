using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MCashTransactions
    {
        public int id { get; set; }
        public int CashAccountId { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Description { get; set; }
        public string Total { get; set; }
        public int TransactionId { get; set; }
        public int OrderId { get; set; }
        public string TransactionType { get; set; }
        public int FiscalYearId { get; set; }
        public string eDate { get; set; }
        public int WareHouseId { get; set; }
        public string UserId { get; set; }

    }
}