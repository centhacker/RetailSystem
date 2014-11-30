using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MViewModels
    {
        public class MViewCashInHand
        {
            public string ProductName { get; set; }
            public string ProductCode { get; set; }
            public string ProductTag1 { get; set; }
            public string ProductTag2 { get; set; }
            public string WareHouseName { get; set; }
            public string Units { get; set; }
            public string PerUnitCost { get; set; }
            public string Total { get; set; }


        }
        public class MViewRecievables
        {
            public string ClientName { get; set; }
            public string OrderName { get; set; }
            public string OrderDate { get; set; }
            public string AmountRecieved { get; set; }
            public string AmountPaid { get; set; }
            public string AmountTotal { get; set; }
        }
        public class MCalculateCashInBanks
        {
            public string BankName { get; set; }
            public string AccountNumber { get; set; }
            public string AccountTitle { get; set; }
            public string EndingBalance { get; set; }
        }
        public class MPaymentsOfVendors
        {
            public string ViewPayables { get; set; }
            public string OrderName { get; set; }
            public string OrderDate { get; set; }
            public string TotalAmount { get; set; }
            public string PaidAmount { get; set; }
        }
        public class MItemProfatibilityReport
        {
            public string Inventory { get; set; }
            public string WareHouse { get; set; }
            public string ActualCost { get; set; }
            public string ActualRevenue { get; set; }
            public string UnitsSold { get; set; }
            public string Diff { get; set; }
            public string Percent { get; set; }
        }
        public class MGeneralJournal
        {
            public string Date { get; set; }
            public string AccountId { get; set; }
            public string AccountName { get; set; }
            public string Description { get; set; }
            public string Debit { get; set; }
            public string Credit { get; set; }

        }
        public class MGenericEnum
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
        public class MViewTrialBalance
        {
            public string AccountName { get; set; }
            public string AccountId { get; set; }
            public decimal Debit { get; set; }
            public decimal Credit { get; set; }

        }
        public class MViewIncomeStatement
        {
            public string Accounts { get; set; }
            public string Revenue { get; set; }
            public string Expense { get; set; }
        }
        public class MViewBalanceSheet
        {
            public string Account { get; set; }
            public string Assets { get; set; }
            public string OE { get; set; }
        }
        public class MViewEndingAccountsBalance
        {
            public string Accounts { get; set; }
            public string Debit { get; set; }
            public string Crerdit { get; set; }
        }
        public class MViewAccountsTransactions
        {
            public string Accounts { get; set; }
            public string Debit { get; set; }
            public string Credit { get; set; }
            public string Description { get; set; }
        }
        public class MViewFiscalYearStatement
        {
            public string FiscalYear { get; set; }
            public string Revenue { get; set; }
            public string Expense { get; set; }
            public string EndingBalance { get; set; }
        }
        public class MViewTransactions
        {
            public string TransactionId { get; set; }
            public string Date { get; set; }
            public string WareHouse { get; set; }
            public string WareHouseId { get; set; }
            public string Product { get; set; }
            public string Units { get; set; }
            public string Type { get; set; }
            public string OrderId { get; set; }
        }
        public class MviewPaidSalary
        {
            public string EmployeeName { get; set; }
            public string Month { get; set; }
            public string Date { get; set; }
            public string Amount { get; set; }
            public string WareHouseId { get; set; }

        }
        public class MViewCashAccountBalanceSheet
        {
            public string AccountId { get; set; }
            public string Date { get; set; }
            public string Description { get; set; }
            public string Debit { get; set; }
            public string Credit { get; set; }
            public string Balance { get; set; }
            public string TransactionBy { get; set; }
        }
        public class MViewOrders
        {
            public string OrderId { get; set; }
            public string OrderNo { get; set; }
            public string OrderName { get; set; }
            public string OrderDescription { get; set; }
            public string VendorName { get; set; }
            public string ClientName { get; set; }
            public string OrderCost { get; set; }
            public string ModeOfPayment { get; set; }
            public string Installments { get; set; }
            public string InstallmentsDueDate { get; set; }
            public string WareHouseId { get; set; }
            public string GrantorName { get; set; }

        }
        public class MViewOrderDetails
        {
            public string ProductName { get; set; }
            public string CurrentProductPrice { get; set; }
            public string OrderProductPrice { get; set; }
            public string Units { get; set; }
            public string ProductCost { get; set; }
        }

        public class MViewPaymentHistory
        {
            public string Date { get; set; }
            public string AccountName { get; set; }
            public string PaidAmount { get; set; }
            public string ChequeNumber { get; set; }
            public string ModeOfPayment { get; set; }
            public string CummulativePayment { get; set; }
        }


    }


}