using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CViewClasses
    {
        public class COrderViewOfPayment
        {

            DB.DBContextDataContext obj = new DB.DBContextDataContext();
            public List<Models.MOrderViewOfPayment> ShowOrderSalesOfPayment()
            {
                List<Models.MOrderViewOfPayment> Get = new List<Models.MOrderViewOfPayment>();

                return Get;
            }

            public List<Models.MOrderViewOfPayment> ShowOrderPurchaseOfPayment()
            {
                List<Models.MOrderViewOfPayment> Get = new List<Models.MOrderViewOfPayment>();


                return Get;
            }

        }

        public class CViewCashInHand
        {
            DB.DBContextDataContext obj = new DB.DBContextDataContext();



            public List<Models.MViewModels.MViewCashInHand> GetAll(int fiscalYeadId)
            {
                List<Models.MViewModels.MViewCashInHand> Get = new List<Models.MViewModels.MViewCashInHand>();
                Models.MViewModels.MViewCashInHand mvm = new Models.MViewModels.MViewCashInHand();
                Classes.CInventory ci = new CInventory();
                Classes.CWareHouse cw = new CWareHouse();
                List<Models.MInventory> Inventory = new List<Models.MInventory>();
                Inventory = ci.GetAll();
                Inventory = (from o in Inventory
                             where Convert.ToInt32(o.FiscalYearld) == fiscalYeadId
                             select o).ToList();
                for (int i = 0; i < Inventory.Count; i++)
                {
                    string ProductName;
                    string ProductCode;
                    string ProductTag1;
                    string ProductTag2;
                    string Units;
                    string PerUnitCost;
                    string Total;
                    string WareHouseName;
                    Classes.CProducts cp = new CProducts();
                    int ProductId = 0;
                    ProductId = Convert.ToInt32(Inventory[i].ProductId);
                    List<Models.MProducts> Products = new List<Models.MProducts>();
                    Products = cp.GetAllbyid(ProductId);
                    if (Products.Count() != 0)
                    {
                        mvm = new Models.MViewModels.MViewCashInHand();
                        int WareHouseId = 0;

                        WareHouseId = Convert.ToInt32(Inventory[i].WareHouseld);
                        WareHouseName = cw.GetWareHouseNameById(WareHouseId);
                        ProductName = Products[0].Name;
                        ProductCode = Products[0].ProductCode;
                        ProductTag1 = Products[0].tag1;
                        ProductTag2 = Products[0].tag2;
                        Units = Inventory[i].Quantity.ToString();
                        PerUnitCost = Inventory[i].Cost;
                        Total = (Convert.ToSingle(Units) * Convert.ToSingle(PerUnitCost)).ToString();
                        //object 
                        mvm.PerUnitCost = PerUnitCost;
                        mvm.ProductCode = ProductCode;
                        mvm.ProductName = ProductName;
                        mvm.ProductTag1 = ProductTag1;
                        mvm.ProductTag2 = ProductTag2;
                        mvm.Total = Total;
                        mvm.Units = Units;
                        mvm.WareHouseName = WareHouseName;
                        Get.Add(mvm);
                    }

                }
                return Get;
            }

        }

        public class CViewRecievable
        {
            DB.DBContextDataContext obj = new DB.DBContextDataContext();
            public List<Models.MViewModels.MViewRecievables> GetAll()
            {
                List<Models.MViewModels.MViewRecievables> Get = new List<Models.MViewModels.MViewRecievables>();
                var query = from o in obj.Payments
                            where o.PaymentType == Common.Constants.PaymentTypes.Partial.ToString()
                            && o.ClientId != -1 && o.OrderId != 0 && o.VendorId == -1
                            select o;
                Classes.CClients cc = new CClients();
                Classes.COrders co = new COrders();
                string clientName = string.Empty;
                string orderName = string.Empty;
                foreach (var item in query)
                {
                    clientName = cc.ReturnClientNameById(item.ClientId.ToString());
                    orderName = co.GetOrderNameById(item.OrderId.ToString());

                }
                return Get;
            }
        }

        public class CViewPayable
        {
            DB.DBContextDataContext obj = new DB.DBContextDataContext();
            public List<Models.MViewModels.MViewRecievables> GetAll()
            {
                List<Models.MViewModels.MViewRecievables> Get = new List<Models.MViewModels.MViewRecievables>();
                var query = from o in obj.Payments
                            where o.PaymentType == Common.Constants.PaymentTypes.Partial.ToString()
                            && o.VendorId != -1 && o.OrderId != 0 && o.ClientId == -1
                            select o;
                return Get;
            }
        }

        public class CViewAccountsEndingBalance
        {
            DB.DBContextDataContext obj = new DB.DBContextDataContext();

            public List<Models.MViewModels.MViewEndingAccountsBalance> GetAll()
            {
                List<Models.MViewModels.MViewEndingAccountsBalance> Get = new List<Models.MViewModels.MViewEndingAccountsBalance>();
                Classes.CBankOfAccount cb = new CBankOfAccount();
                List<Models.MBankAccount> BankAccount = new List<Models.MBankAccount>();
                BankAccount = cb.GetAll();
                for (int i = 0; i < BankAccount.Count; i++)
                {
                    string AccountNumber = string.Empty;
                    string Debit = string.Empty;
                    string Credit = string.Empty;
                    AccountNumber = BankAccount[i].accountNumber + "-" + BankAccount[i].Accounttitle;
                    if (Convert.ToSingle(BankAccount[i].Balance) < 0)
                    {
                        Debit = BankAccount[i].Balance.ToString();
                        Credit = "0";
                    }
                    else
                    {
                        Credit = BankAccount[i].Balance.ToString();
                        Debit = "0";
                    }
                    Models.MViewModels.MViewEndingAccountsBalance mv = new Models.MViewModels.MViewEndingAccountsBalance();
                    mv.Accounts = AccountNumber;
                    mv.Debit = Debit;
                    mv.Crerdit = Credit;
                    Get.Add(mv);
                }

                return Get;
            }
        }

        public class CViewItemProfatibilityReport
        {
            DB.DBContextDataContext obj = new DB.DBContextDataContext();

            public List<Models.MViewModels.MItemProfatibilityReport> GetAll(DateTime fromDate, DateTime toDate)
            {
                #region Class Objects
                Classes.CSaleTransations ct = new CSaleTransations();
                Classes.CWareHouse cw = new CWareHouse();
                Classes.CProducts cp = new CProducts();

                #endregion

                #region Models
                Models.MSaleTransactions mt = new Models.MSaleTransactions();
                Models.MViewModels.MItemProfatibilityReport mii = new Models.MViewModels.MItemProfatibilityReport();
                #endregion

                #region Lists
                List<Models.MViewModels.MItemProfatibilityReport> ItemProfatiblity = new List<Models.MViewModels.MItemProfatibilityReport>();
                List<Models.MSaleTransactions> Transactions = new List<Models.MSaleTransactions>();
                List<string> Products = new List<string>();
                #endregion

                #region Logic
                float totalUnits = 0;
                Transactions = ct.GetAll();

                //filtering for only deductions
                Transactions = (from o in Transactions
                                where o.transactionType == Common.Constants.SaleTransactions.Deduction.ToString()
                                && Convert.ToDateTime(o.date) >= fromDate && Convert.ToDateTime(o.date) <= toDate
                                select o).ToList();
                totalUnits = (from o in Transactions select Convert.ToSingle(o.units)).Sum();
                Products = (from o in Transactions select o.ProductID).Distinct().ToList();
                for (int i = 0; i < Products.Count; i++)
                {
                    mii = new Models.MViewModels.MItemProfatibilityReport();
                    List<Models.MSaleTransactions> ProductWise = new List<Models.MSaleTransactions>();
                    ProductWise = (from o in Transactions where o.ProductID == Products[i] select o).ToList();
                    string ProductName = cp.GetProductNameWithTagsById(Convert.ToInt32(Products[i]));

                    float CostPrice = (from a in ProductWise
                                       where a.ProductID == Products[i]
                                       select Convert.ToSingle(a.CostPrice)).Sum();
                    float Revenue = (from a in ProductWise
                                     where a.ProductID == Products[i]
                                     select Convert.ToSingle(a.SalePrice)).Sum();
                    float units = (from a in ProductWise
                                   where a.ProductID == Products[i]
                                   select Convert.ToSingle(a.units)).Sum();
                    CostPrice = CostPrice * units;
                    Revenue = Revenue * units;
                    float Difference = Revenue - CostPrice;
                    float totalCost = Transactions.Select(o => Convert.ToSingle(o.units)).Sum();
                    float Percentage = (units / totalUnits) * 100;
                    mii.Inventory = ProductName;
                    mii.WareHouse = "Remaining";
                    mii.ActualCost = CostPrice.ToString();
                    mii.ActualRevenue = Revenue.ToString();
                    mii.Diff = Difference.ToString();
                    mii.UnitsSold = units.ToString();
                    mii.Percent = Percentage.ToString() + "%";
                    ItemProfatiblity.Add(mii);
                }
                #endregion
                return ItemProfatiblity;
            }
        }

        public class CViewGeneralJournal
        {

            DB.DBContextDataContext obj = new DB.DBContextDataContext();
            private List<Models.MViewModels.MGenericEnum> Accounts = new List<Models.MViewModels.MGenericEnum>();




            public List<Models.MViewModels.MGeneralJournal> GetAll()
            {
                List<Models.MViewModels.MGeneralJournal> gj = new List<Models.MViewModels.MGeneralJournal>();
                Classes.CJournal cj = new CJournal();
                Models.MViewModels.MGeneralJournal mg = new Models.MViewModels.MGeneralJournal();
                List<Models.MJournal> Get = new List<Models.MJournal>();

                Dictionary<int, string> Accounts = new Dictionary<int, string>();
                foreach (Common.Constants.Accounts.ChartOfAccounts
                    item in
                    (Common.Constants.Accounts.ChartOfAccounts[])
                    Enum.GetValues(typeof(Common.Constants.Accounts.ChartOfAccounts)))
                {
                    Accounts.Add((int)item, item.ToString());
                }
                Get = cj.GetAll();
                foreach (var item in Get)
                {
                    mg = new Models.MViewModels.MGeneralJournal();
                    mg.AccountId = item.acc_id;
                    string AccountName = (from o in Accounts
                                          where o.Key == Convert.ToInt32(item.acc_id)
                                          select o.Value.ToString())
                                          .FirstOrDefault();
                    mg.AccountName = AccountName;
                    if (item.type == Common.Constants.Accounts.Type.Credit.ToString())
                    {
                        mg.Credit = item.amount.ToString();
                        mg.Debit = "0";

                    }
                    else
                    {
                        mg.Debit = item.amount;
                        mg.Credit = "0";
                    }
                    mg.Description = item.des;
                    mg.Date = item.e_date;
                    gj.Add(mg);

                }

                return gj;
            }
        }

        public class CViewTrialBalance
        {
            DB.DBContextDataContext obj = new DB.DBContextDataContext();

            public List<Models.MViewModels.MViewTrialBalance> GetAll(DateTime fromDate, DateTime toDate)
            {
                List<Models.MViewModels.MViewTrialBalance> TrialBalance = new List<Models.MViewModels.MViewTrialBalance>();
                List<Models.MViewModels.MGeneralJournal> Journal = new List<Models.MViewModels.MGeneralJournal>();
                Models.MViewModels.MViewTrialBalance mtb = new Models.MViewModels.MViewTrialBalance();
                List<Models.MViewModels.MGenericEnum> Accounts = new List<Models.MViewModels.MGenericEnum>();
                Classes.CViewClasses.CViewGeneralJournal cvj = new CViewGeneralJournal();
                Journal = cvj.GetAll();
                Journal = (from o in Journal
                           where Convert.ToDateTime(o.Date) >= fromDate && Convert.ToDateTime(o.Date) <= toDate
                           select o).ToList();
                foreach (Common.Constants.Accounts.ChartOfAccounts
                    item in
                    (Common.Constants.Accounts.ChartOfAccounts[])
                    Enum.GetValues(typeof(Common.Constants.Accounts.ChartOfAccounts)))
                {
                    Models.MViewModels.MGenericEnum mge = new Models.MViewModels.MGenericEnum();
                    mge.Value = (int)item;
                    mge.Name = item.ToString();
                    Accounts.Add(mge);
                }

                for (int i = 0; i < Accounts.Count; i++)
                {
                    mtb = new Models.MViewModels.MViewTrialBalance();
                    mtb.AccountId = Accounts[i].Value.ToString();
                    mtb.AccountName = Accounts[i].Name;
                    float Debit = (from o in Journal
                                   where o.AccountId == Accounts[i].Value.ToString()
                                   select Convert.ToSingle(o.Debit)).Sum();
                    float Credit = (from o in Journal
                                    where o.AccountId == Accounts[i].Value.ToString()
                                    select Convert.ToSingle(o.Credit)).Sum();
                    float EndingBalance = Debit - Credit;
                    if (EndingBalance < 0)
                    {
                        mtb.Credit = Decimal.Parse(EndingBalance.ToString(), System.Globalization.NumberStyles.Float);
                        mtb.Debit = 0;
                    }
                    else
                    {
                        mtb.Debit = Decimal.Parse(EndingBalance.ToString(), System.Globalization.NumberStyles.Float);
                        mtb.Credit = 0;
                    }

                    TrialBalance.Add(mtb);
                }


                return TrialBalance;
            }
        }

        public class CViewTransactions
        {
            DB.DBContextDataContext obj = new DB.DBContextDataContext();

            public List<Models.MViewModels.MViewTransactions> GetAll()
            {
                List<Models.MViewModels.MViewTransactions> Transactions = new List<Models.MViewModels.MViewTransactions>();
                List<Models.MSaleTransactions> AllTransactions = new List<Models.MSaleTransactions>();
                Models.MViewModels.MViewTransactions mvv = new Models.MViewModels.MViewTransactions();
                Classes.CProducts cp = new CProducts();
                Classes.CSaleTransations cst = new CSaleTransations();
                Classes.CWareHouse cw = new CWareHouse();
                AllTransactions = cst.GetAll();
                AllTransactions = (from o in AllTransactions select o).OrderBy(o => o.date).ToList();
                for (int i = 0; i < AllTransactions.Count; i++)
                {
                    mvv = new Models.MViewModels.MViewTransactions();
                    string ProductId = AllTransactions[i].ProductID;
                    string ProductName = cp.GetProductNameWithTagsById(Convert.ToInt32(ProductId));
                    string WareHouseId = AllTransactions[i].WareHouseId;
                    string WareHouseName = cw.GetWareHouseNameById(Convert.ToInt32(WareHouseId));
                    mvv.TransactionId = AllTransactions[i].id.ToString();
                    mvv.Date = AllTransactions[i].date.ToShortDateString();
                    mvv.Product = ProductName;
                    mvv.Type = AllTransactions[i].transactionType;
                    mvv.Units = AllTransactions[i].units;
                    mvv.WareHouse = WareHouseName;
                    mvv.OrderId = AllTransactions[i].OrderId;
                    mvv.WareHouseId = WareHouseId;
                    Transactions.Add(mvv);
                }
                return Transactions;
            }
        }

        public class CViewPaidSalary
        {
            DB.DBContextDataContext obj = new DB.DBContextDataContext();
            public List<Models.MViewModels.MviewPaidSalary> GetAll()
            {
                List<Models.MViewModels.MviewPaidSalary> PaidSalary = new List<Models.MViewModels.MviewPaidSalary>();
                List<Models.MPaidSalary> Salary = new List<Models.MPaidSalary>();
                Classes.CEmployees ce = new CEmployees();
                Classes.CPaidSalary cp = new CPaidSalary();
                Salary = cp.GetAll();

                for (int i = 0; i < Salary.Count; i++)
                {
                    Models.MViewModels.MviewPaidSalary mp = new Models.MViewModels.MviewPaidSalary();
                    string EmployeeName = ce.GetEmployeeNameById(Convert.ToInt32(Salary[i].EmployeeId));
                    mp.EmployeeName = EmployeeName;
                    mp.Date = Salary[i].DatePaid;
                    mp.Month = Salary[i].MonthPaid;
                    mp.Amount = Salary[i].Paid;
                    mp.WareHouseId = Salary[i].SalaryId;
                    PaidSalary.Add(mp);
                }
                return PaidSalary;
            }
        }

        public class CViewCashAccountBalanceSheet
        {
            DB.DBContextDataContext obj = new DB.DBContextDataContext();

            public List<Models.MViewModels.MViewCashAccountBalanceSheet> GetAll(string AccountType)
            {
                List<Models.MViewModels.MViewCashAccountBalanceSheet> Get = new List<Models.MViewModels.MViewCashAccountBalanceSheet>();
                Models.MViewModels.MViewCashAccountBalanceSheet mvt = new Models.MViewModels.MViewCashAccountBalanceSheet();
                List<Models.MCashTransactions> CashTransactions = new List<Models.MCashTransactions>();
                List<Models.MCashAccount> CashAccounts = new List<Models.MCashAccount>();
                Classes.CCashTransaction cct = new CCashTransaction();
                Classes.CCashAccount cca = new CCashAccount();
                Classes.CUsers cu = new CUsers();
                CashAccounts = cca.GetAll();
                CashTransactions = cct.GetAll();
                Get.Clear();
                switch (AccountType)
                {
                    case "Personal":
                        {
                            var joined = from ct in CashTransactions
                                         join ca in CashAccounts
                                             on ct.CashAccountId equals ca.id
                                         where ca.AccountType == Common.Constants.CashAccountTypes.Personal.ToString()
                                         select ct;

                            foreach (var item in joined)
                            {
                                mvt = new Models.MViewModels.MViewCashAccountBalanceSheet();
                                string AccountName = cca.GetAccountNameById(item.CashAccountId);
                                string UserName = cu.GetUserNameById(Convert.ToInt32(item.UserId));
                                mvt.AccountId = AccountName;
                                mvt.Balance = item.Total;
                                mvt.Credit = item.Credit;
                                mvt.Debit = item.Debit;
                                mvt.Description = item.Description;
                                mvt.TransactionBy = UserName;
                                mvt.Date = item.eDate;
                                Get.Add(mvt);
                            }
                            break;
                        }
                    case "Vendor":
                        {
                            var joined = from ct in CashTransactions
                                         join ca in CashAccounts
                                             on ct.CashAccountId equals ca.id
                                         where ca.AccountType == Common.Constants.CashAccountTypes.Vendor.ToString()
                                         select ct;

                            foreach (var item in joined)
                            {
                                mvt = new Models.MViewModels.MViewCashAccountBalanceSheet();
                                string AccountName = cca.GetAccountNameById(item.CashAccountId);
                                string UserName = cu.GetUserNameById(Convert.ToInt32(item.UserId));
                                mvt.AccountId = AccountName;
                                mvt.Balance = item.Total;
                                mvt.Credit = item.Credit;
                                mvt.Debit = item.Debit;
                                mvt.Description = item.Description;
                                mvt.TransactionBy = UserName;
                                mvt.Date = item.eDate;
                                Get.Add(mvt);
                            }
                            break;
                        }
                    case "Client":
                        {
                            var joined = from ct in CashTransactions

                                         join ca in CashAccounts
                                             on ct.CashAccountId equals ca.id
                                         where ca.AccountType == Common.Constants.CashAccountTypes.Client.ToString()
                                         select ct;

                            foreach (var item in joined)
                            {
                                mvt = new Models.MViewModels.MViewCashAccountBalanceSheet();
                                string AccountName = cca.GetAccountNameById(item.CashAccountId);
                                string UserName = cu.GetUserNameById(Convert.ToInt32(item.UserId));
                                mvt.AccountId = AccountName;
                                mvt.Balance = item.Total;
                                mvt.Credit = item.Credit;
                                mvt.Debit = item.Debit;
                                mvt.Description = item.Description;
                                mvt.TransactionBy = UserName;
                                mvt.Date = item.eDate;
                                Get.Add(mvt);
                            }
                            break;
                        }
                    default:
                        break;
                }


                return Get;
            }
        }

        public class CViewOrderDetails
        {
            DB.DBContextDataContext obj = new DB.DBContextDataContext();

            public List<Models.MViewModels.MViewOrders> GetAll(string OrderType)
            {
                List<Models.MViewModels.MViewOrders> OrderDetails = new List<Models.MViewModels.MViewOrders>();
                List<Models.MOrders> Orders = new List<Models.MOrders>();
                Classes.COrders co = new COrders();
                Classes.CClients ccl = new CClients();
                Classes.CVendor cv = new CVendor();
                Orders = co.GetAll();
                switch (OrderType)
                {
                    case "Clients":
                        {
                            Orders = Orders.Where(o => o.venorld == "-1").ToList();
                            for (int i = 0; i < Orders.Count; i++)
                            {

                                Models.MViewModels.MViewOrders mod = new Models.MViewModels.MViewOrders();
                                string ClientName = string.Empty;
                                if (Orders[i].ClientId != "-1")
                                {
                                    ClientName = ccl.ReturnClientNameById(Orders[i].ClientId);
                                }

                                mod.ClientName = ClientName;
                                mod.Installments = Orders[i].Installments;
                                mod.InstallmentsDueDate = Orders[i].InstallmentDueDate;
                                mod.OrderCost = Orders[i].TotalCost;
                                mod.OrderDescription = Orders[i].OrderDescription;
                                mod.OrderId = Orders[i].id;
                                mod.OrderName = Orders[i].OrderName;
                                mod.OrderNo = Orders[i].OrdersNo;
                                mod.VendorName = string.Empty;
                                mod.WareHouseId = Orders[i].WareHouseId;
                                mod.ModeOfPayment = Orders[i].ModeOfPayment;
                                mod.GrantorName = Orders[i].GrantorName;
                                OrderDetails.Add(mod);
                            }
                            break;
                        }
                    case "Vendors":
                        {
                            Orders = Orders.Where(o => o.ClientId == "-1").ToList();
                            for (int i = 0; i < Orders.Count; i++)
                            {

                                Models.MViewModels.MViewOrders mod = new Models.MViewModels.MViewOrders();
                                string VendorName = string.Empty;

                                if (Orders[i].venorld != "-1")
                                {
                                    VendorName = cv.GetVendorNameById(Orders[i].venorld);
                                }
                                mod.ClientName = string.Empty;
                                mod.Installments = Orders[i].Installments;
                                mod.InstallmentsDueDate = Orders[i].InstallmentDueDate;
                                mod.OrderCost = Orders[i].TotalCost;
                                mod.OrderDescription = Orders[i].OrderDescription;
                                mod.OrderId = Orders[i].id;
                                mod.OrderName = Orders[i].OrderName;
                                mod.OrderNo = Orders[i].OrdersNo;
                                mod.VendorName = VendorName;
                                mod.WareHouseId = Orders[i].WareHouseId;
                                OrderDetails.Add(mod);
                            }
                            break;
                        }
                    default:
                        break;
                }


                return OrderDetails;
            }

            public List<Models.MViewModels.MViewOrderDetails> GetAllDetails(int OrderId)
            {
                List<Models.MViewModels.MViewOrderDetails> OrderDetails = new List<Models.MViewModels.MViewOrderDetails>();
                List<Models.MOrdersLine> OrderLine = new List<Models.MOrdersLine>();
                Models.MViewModels.MViewOrderDetails mvo = new Models.MViewModels.MViewOrderDetails();
                Classes.COrderOnline coo = new COrderOnline();
                Classes.COrders co = new COrders();
                Classes.CProducts cp = new CProducts();
                OrderLine = coo.GetAll();
                OrderLine = OrderLine.Where(o => o.OrderId == OrderId.ToString()).ToList();
                for (int i = 0; i < OrderLine.Count; i++)
                {
                    mvo = new Models.MViewModels.MViewOrderDetails();
                    string CurrentProductPrice = string.Empty, ProductName = string.Empty;
                    ProductName = cp.GetProductNameWithTagsById(Convert.ToInt32(OrderLine[i].ProductId));
                    string OrderType = co.ReturnOrderTypeById(OrderId);
                    switch (OrderType)
                    {
                        case "Client":
                            {
                                CurrentProductPrice = cp.ReturnSalePrice(Convert.ToInt32(OrderLine[i].ProductId));
                                break;
                            }
                        case "Vendor":
                            {
                                CurrentProductPrice = cp.ReturnCostPrice(Convert.ToInt32(OrderLine[i].ProductId));
                                break;
                            }
                        default:
                            break;
                    }
                    mvo.CurrentProductPrice = CurrentProductPrice;
                    mvo.OrderProductPrice = OrderLine[i].SalePrice;
                    mvo.ProductCost = OrderLine[i].totalProductCost;
                    mvo.ProductName = ProductName;
                    mvo.Units = OrderLine[i].unit;
                    OrderDetails.Add(mvo);
                }
                return OrderDetails;
            }


            public List<Models.MViewModels.MViewPaymentHistory> GetPaymentHistory(int OrderId)
            {
                List<Models.MViewModels.MViewPaymentHistory> PaymentHistory = new List<Models.MViewModels.MViewPaymentHistory>();
                List<Models.MPayments> Payments = new List<Models.MPayments>();
                List<Models.PaymentLine> PaymentsLine = new List<Models.PaymentLine>()
                    , tempPaymentsLine = new List<Models.PaymentLine>();
                Classes.CPayment cp = new CPayment();
                Classes.CPaymentLine cpl = new CPaymentLine();
                Classes.CBankOfAccount cb = new CBankOfAccount();
                Classes.CCashAccount cca = new CCashAccount();
                Payments = cp.GetAll();
                Payments = Payments.Where(o => o.OrderId == OrderId).ToList();
                PaymentsLine = cpl.GetAll();
                for (int i = 0; i < Payments.Count; i++)
                {
                    tempPaymentsLine.Clear();
                    tempPaymentsLine = PaymentsLine.Where(o => o.PaymentId == Payments[i].id).ToList();
                    float CummulativePayment = 0;
                    for (int j = 0; j < tempPaymentsLine.Count; j++)
                    {
                        Models.MViewModels.MViewPaymentHistory ph = new Models.MViewModels.MViewPaymentHistory();
                        string AccountName = string.Empty;
                        if (tempPaymentsLine[j].ModeOfPayment == Common.Constants.ModeOfPayment.Cheque.ToString())
                        {
                            AccountName = cb.GetAccountNumberAccountTileById(tempPaymentsLine[j].BankId);
                        }
                        if (tempPaymentsLine[j].ModeOfPayment == Common.Constants.ModeOfPayment.Cash.ToString())
                        {
                            AccountName = cca.GetAccountNameById(tempPaymentsLine[j].BankId);
                        }
                        ph.AccountName = AccountName;
                        ph.ChequeNumber = tempPaymentsLine[j].Cheque;
                        ph.Date = tempPaymentsLine[j].Date;
                        ph.ModeOfPayment = tempPaymentsLine[j].ModeOfPayment;
                        ph.PaidAmount = tempPaymentsLine[j].PaidAmount;
                        CummulativePayment += Convert.ToSingle(tempPaymentsLine[j].PaidAmount);
                        ph.CummulativePayment = CummulativePayment.ToString();
                        PaymentHistory.Add(ph);

                    }
                }
                return PaymentHistory;
            }
        }



    }
}