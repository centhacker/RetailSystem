using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MPayments
    {
        public int id { get; set; }
        public int ClientId { get; set; }
        public int VendorId { get; set; }
        public int OrderId { get; set; }
        public int TransactionId { get; set; }
        public string TotalCost { get; set; }
        public string Paid { get; set; }
        public string PaymentType { get; set; }
        public string Paymentstate { get; set; }

    }

    public class MOrderViewOfPayment
    {
        public string PaymentId { get; set; }
        public string OrderId { get; set; }
        public string OrderCode { get; set; }
        public string OrderName { get; set; }
        public string TotalCost { get; set; }
        public string VendorId { get; set; }
        public string ClientId { get; set; }
        public string VendorName { get; set; }
        public string ClientName { get; set; }
        public string PaidAmount { get; set; }
        public string OrderDate { get; set; }

    }
}