using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MTransactionDetail
    {
        public string id { get; set; }
        public string TransactionId { get; set; }
        public string ProductId { get; set; }
        public string FormWareHouseId { get; set; }
        public string ToWareHouseId { get; set; }
        public string TransactionQuantity { get; set; }
        public string transactionCost { get; set; }
        public string TotalCost { get; set; }
        public string eDate { get; set; }

    }
}