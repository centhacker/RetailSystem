using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MBankAccount
    {
        public string id { get; set; }
        public string BankId { get; set; }
        public String accountNumber { get; set; }
        public string Accounttitle { get; set; }
        public string AccountHolderId { get; set; }
        public string OpeningBalance { get; set; }
        public string Balance { get; set; }
        public string BeginDate { get; set; }
        public string WareHouseId { get; set; }

    }
}