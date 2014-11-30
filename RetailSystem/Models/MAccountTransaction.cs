using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MAccountTransaction
    {
        public string id { get; set; }
        public string AccountId { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Description { get; set; }
        public string Total { get; set; }
        public string CurrentTransaction { get; set; }
        public string Transactiontype { get; set; }
        public string FiscalYearId { get; set; }
        public DateTime eDate { get; set; }
        public string WareHouseId { get; set; }
    }

    public class MAccountTransactionsView
    {

        public string AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountTitle { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Description { get; set; }
        public string Total { get; set; }
        public string CurrentTransaction { get; set; }
        public string Transactiontype { get; set; }
        public string FiscalYearId { get; set; }
        public string eDate { get; set; }
        public string WareHouseId { get; set; }
    }
}