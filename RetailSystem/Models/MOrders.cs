using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MOrders
    {
        public string id { get; set; }
        public string OrdersNo { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public string Orderdate { get; set; }
        public string deliverydate { get; set; }
        public string TotalCost { get; set; }
        public string OrderType { get; set; }
        public string WareHouseId { get; set; }
        public string ClientId { get; set; }
        public string venorld { get; set; }
        public string FiscalYearld { get; set; }
        public string eDate { get; set; }
        public string Installments { get; set; }
        public string InstallmentDueDate { get; set; }
        public string ModeOfPayment { get; set; }
        public string GrantorName { get; set; }
    }
}