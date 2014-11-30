using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Common
{
    public static class Constants
    {
        #region Accounts Info
        /// <Accounting Rules>
        /// --------------------
        ///  Open Bank**
        ///  
        ///  Owner Equity : Credit
        ///  Cash : Debit
        ///  -------------------
        ///  Purchase Inventory  **     
        ///
        ///  Merchandise Inventory : Debit
        ///  Cash : Credit
        ///  -------------------
        ///  Sale Inventory **
        ///  
        ///  Cash : Debit
        ///  Sales : Credit
        ///  
        ///  CostOfGoodsSold = Debit
        ///  Merchandise Inventory = Credit
        ///  -------------------
        ///  Add Vendor Order **
        ///  
        ///  Merchandise Inventory : Debit
        ///  AccountsPayable : Credit
        ///  -------------------
        ///  Add Client Order **
        ///  
        ///  Accounts Recievable : Debit
        ///  Sales : Credit
        ///  
        ///  CostOfGoodsSold = Debit
        ///  Merchandise Inventory = Credit
        ///  -------------------
        ///  Payment to Vendor **
        ///  
        ///  Accounts Payable : Debit
        ///  Cash : Credit
        ///  -------------------
        ///  Payment to Client **
        ///  
        ///  Cash = Debit
        ///  Accounts Recievable : Credit
        ///  -------------------
        ///  Payroll **
        ///  
        ///  Wages Expense = Debit
        ///  Cash = Creit
        ///  -------------------
        ///  GeneralExpense **
        ///    
        ///  GeneralExpense = Debit
        ///  Cash = Creit
        ///  -------------------
        ///  Shop Expense **
        ///    
        ///  Shop Expense = Debit
        ///  Cash = Creit
        ///  -------------------
        ///  Owner Withdrawl
        ///    
        ///  Owner Withdrawl = Debit
        ///  Cash = Creit
        /// </Accounts>
        #endregion
        public static class Accounts
        {
            public enum Type
            {
                Debit = 1,
                Credit = -1
            }

            public enum ChartOfAccounts
            {
                #region Assets
                Cash = 1001,
                AccountsRecievalbes = 1002,
                MerchandiseInventory = 1003,
                SalesDiscount = 1004,
                PurchaseDiscount = 1005,
                #endregion

                #region Liability
                AccountsPayable = 2001,
                SalaryPaybale = 2002,
                #endregion

                #region Revenue
                SaleRevenue = 3001,
                OtherRevenue = 3002,
                CostOfGoodsSold = 3003,
                Sales = 3004,
                SalexTaxColledted = 3005,
                PurchaseTaxCollecetd = 3006,
                #endregion

                #region Expense
                GeneralExpense = 4001,
                SalaryExpense = 4002,
                ShopRentExpense = 4003,
                UtilityBillsExpense = 4004,
                Entertainment = 4005,

                #endregion

                #region OE
                OwnerEquity = 5001,
                OwnerWithdrawl = 5002
                #endregion

            }

            public enum Ledgers
            {
                Assets = 1,
                Liability = 2,
                Revenue = 3,
                Expense = 4,
                OwnerEquity = 5
            }
        }

     
        public enum ModeOfPayment
        {
            Cash = 1,
            Cheque =  2
        }

        public enum UserIdStatus
        {
            Approved = 1,
            NotApproved = 0,
            Pending = 3
        }

        public enum PaymentTypes
        {
            Full = 1,
            Partial = 0
        }
        public enum PaymentState
        {
            Paid = 1,
            PartiallyPaid = 0,
            NotPaid = -1
        }
        public enum TransactionStatus
        {
            Paid = 1,
            Credit = 0,
            Reverse = -1
        }

        public enum SaleTransactions
        {
            Addition = 1,
            Deduction = -1,
            Transfer = 0,
            Expense = 2
        }

        public enum Permissions
        {
            //Admin
            Admin = 33,
            AllRead = 31,
            AllReadWrite = 33,

            //Products - Setup
            ProductsRead = 111,
            ProductsWrite = 112,

            //Vendor - Setup
            VendorRead = 131,
            VendorWrite = 132,

            //Clients - Setup
            ClientsRead = 91,
            ClientsWrite = 92,

            //WareHouse - Setup
            WareHouseRead = 61,
            WareHouseWrite = 62,

            //BankAndAccounts - Setup
            BankAndAccountsRead = 71,
            BankAndAccountsWrite = 72,
            BankAndAccountsUse = 73,

             
            OpeningBalance  = 161,

            //Employee - Management
            EmployeeRead = 11,
            EmployeeWrite = 12,

            //Payroll - Management
            PayrollRead = 101,
            PayrollWrite = 102,

            //UserManagement - Management
            UserManagementRead = 121,
            UserManagementWrite = 122,



            //Orders - Transactions
            OrdersRead = 51,
            OrdersWrite = 52,

            //Inventory and Sales - Transactions
            InventoryRead = 21,
            SalesJournal = 22,
            GeneralJournalRead = 31,
            GeneralJournalWrite = 32,

            //Payments - Transactions
            PaymentsRead = 131,
            PaymentsWrite = 132,

            //Invoices & Reports - Reports
            ReporsRead = 141,

            //Expennse
            Expenses = 151,

            //Accounts - Accounts
            AccountsRead = 81,
            AccountsWrite = 82,



        }

        public enum CashAccountTypes
        {
            Vendor = 1,
            Client = 2,
            Personal = 3
        }
    }




}