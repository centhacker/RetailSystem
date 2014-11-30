using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

using System.Web.UI;
namespace RetailSystem.Classes
{
    public class CRevertInventory
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int RevertOrderTransaction(int OrderId)
        {
            try
            {
                List<Models.MSaleTransactions> Transactions = new List<Models.MSaleTransactions>();
                Classes.CSaleTransations cs = new CSaleTransations();
                Transactions = cs.GetAll();
                Transactions = (from o in Transactions
                                where o.OrderId == OrderId.ToString()
                                select o).ToList();
                foreach (var item in Transactions)
                {
                    RevertSingleTransaction(item.id);
                }

                //deleting orders line
                var OrderLine = from o in obj.OrderLines
                                where o.OrderId == OrderId
                                select o;
                foreach (var item in OrderLine)
                {
                    obj.OrderLines.DeleteOnSubmit(item);
                }
                obj.SubmitChanges();

                //deleting order
                var Orders = from o in obj.Orders
                             where o.id == OrderId
                             select o;
                foreach (var item in Orders)
                {
                    obj.Orders.DeleteOnSubmit(item);
                }
                obj.SubmitChanges();
                return 1;
            }
            catch
            {
                //return 0;
                return -1;

            }
        }


        public int RevertOrderTransaction(int OrderId, int Units, int ProductId)
        {
            try
            {
                string PaymentId = string.Empty, PaymentLineId = string.Empty;
                string CashAccount = string.Empty, BankAccount = string.Empty;
                List<Models.MSaleTransactions> Transactions = new List<Models.MSaleTransactions>();
                Classes.CSaleTransations cs = new CSaleTransations();
                Transactions = cs.GetAll();
                Transactions = (from o in Transactions
                                where o.OrderId == OrderId.ToString() && o.ProductID == ProductId.ToString()
                                select o).ToList();
                foreach (var item in Transactions)
                {
                    RevertSingleTransaction(item.id, Units, ProductId);
                }

                //updating orders line
                var OrderLine = from o in obj.OrderLines
                                where o.OrderId == OrderId && o.ProductId == ProductId
                                select o;


                foreach (var item in OrderLine)
                {
                    item.units = Units.ToString();
                }


                //payments
                var Pyid = (from o in obj.Payments
                            where o.OrderId == Convert.ToInt32(OrderId)
                            select o.id).FirstOrDefault();
                var PylId = (from o in obj.PaymentLines
                            where o.PaymentId == Pyid
                            select o.id).FirstOrDefault();

                //cash account



                //cash transaction

                //bank account 

                //bank transaction

                //inventory

                //inventory balance

                //transactions


                obj.SubmitChanges();


                return 1;
            }
            catch
            {
                //return 0;
                return -1;

            }
        }

        public int RevertSingleTransaction(int TransactionId)
        {

            try
            {


                var TransactionType = (from o in obj.Transaction1s
                                       where o.id == TransactionId
                                       select o.TransactionType).FirstOrDefault();
                var AmountPaid = (from o in obj.Payments
                                  where o.TransactionId == TransactionId
                                  select o.Paid).FirstOrDefault();
                var ProductId = (from o in obj.Transaction1s
                                 where o.id == TransactionId
                                 select o.ProductID).FirstOrDefault();
                var Units = (from o in obj.Transaction1s
                             where o.id == TransactionId
                             select o.units).FirstOrDefault();
                var PaymentId = (from o in obj.Payments
                                 where o.TransactionId == TransactionId
                                 select o.id).FirstOrDefault();
                var AccountId = (from o in obj.PaymentLines
                                 where o.PaymentId == Convert.ToInt32(PaymentId)
                                 select o.BankId).FirstOrDefault();
                var DataPaymentLine = from o in obj.PaymentLines
                                      where o.PaymentId == Convert.ToInt32(PaymentId)
                                      select o;

                //deleting Payment lines
                foreach (var item in DataPaymentLine)
                {
                    obj.PaymentLines.DeleteOnSubmit(item);
                }
                obj.SubmitChanges();

                //deleting Payments
                Classes.CPayment cp = new CPayment();
                Models.MPayments mp = new Models.MPayments();
                mp.id = Convert.ToInt32(PaymentId);
                cp.Delete(mp);



                Classes.CInventory ci = new CInventory();
                List<Models.MInventory> Inventory = new List<Models.MInventory>();
                Inventory = ci.GetAll();
                switch (TransactionType.ToString())
                {
                    case "Addition":
                        {
                            Classes.CBankOfAccount cb = new CBankOfAccount();

                            if (AccountId != null)
                            {
                                //Reverting Account
                                float OldTotal = cb.ReturnTotalOfAccountById(Convert.ToInt32(AccountId));
                                float NewTotal = OldTotal + Convert.ToSingle(AmountPaid);
                                cb.SetNewAccountTotal(Convert.ToInt32(AccountId), NewTotal);

                                //Add Revert Account Transaction
                                Classes.CAccountTransaction cat = new CAccountTransaction();
                                Models.MAccountTransaction mat = new Models.MAccountTransaction();
                                mat.AccountId = AccountId.ToString();
                                mat.Credit = AmountPaid.ToString();
                                mat.Debit = "0";
                                mat.Description = "Reverted Purchase Transaction";
                                mat.eDate = DateTime.Now;
                                mat.FiscalYearId = (from o in obj.AccountTransactions
                                                    where o.CurrentTransaction == TransactionId.ToString()
                                                    select o.FiscalYearId.ToString()).FirstOrDefault();
                                mat.Total = cb.ReturnTotalOfAccountById(Convert.ToInt32(AccountId)).ToString();
                                mat.Transactiontype = "Credit";

                                cat.Save(mat);

                            }



                            //Reverting Inventory
                            float oldUnits = (from o in Inventory
                                              where o.ProductId == (ProductId).ToString()
                                              select Convert.ToSingle(o.Quantity)).FirstOrDefault();
                            float newUnits = oldUnits - Convert.ToSingle(Units);

                            var query = from o in obj.Inventories
                                        where o.ProductId == Convert.ToInt32(ProductId)
                                        select o;
                            foreach (var item in query)
                            {
                                item.Quantity = newUnits.ToString();
                            }
                            obj.SubmitChanges();

                            //deletin Transaction
                            var transactions = from o in obj.Transaction1s
                                               where o.id == TransactionId
                                               select o;
                            foreach (var item in transactions)
                            {
                                obj.Transaction1s.DeleteOnSubmit(item);
                            }
                            obj.SubmitChanges();
                            break;
                        }
                    case "Deduction":
                        {
                            Classes.CBankOfAccount cb = new CBankOfAccount();

                            if (AccountId != null)
                            {

                                //Reverting Account
                                float OldTotal = cb.ReturnTotalOfAccountById(Convert.ToInt32(AccountId));
                                float NewTotal = OldTotal - Convert.ToSingle(AmountPaid);
                                cb.SetNewAccountTotal(Convert.ToInt32(AccountId), NewTotal);

                                //Add Revert Account Transaction
                                Classes.CAccountTransaction cat = new CAccountTransaction();
                                Models.MAccountTransaction mat = new Models.MAccountTransaction();
                                mat.AccountId = AccountId.ToString();
                                mat.Credit = "0";
                                mat.Debit = AmountPaid.ToString();
                                mat.Description = "Reverted Sale Transaction";
                                mat.eDate = DateTime.Now;
                                mat.FiscalYearId = (from o in obj.AccountTransactions
                                                    where o.CurrentTransaction == TransactionId.ToString()
                                                    select o.FiscalYearId.ToString()).FirstOrDefault();
                                mat.Total = cb.ReturnTotalOfAccountById(Convert.ToInt32(AccountId)).ToString();
                                mat.Transactiontype = "Credit";

                                cat.Save(mat);
                            }


                            //Reverting Inventory
                            float oldUnits = (from o in Inventory
                                              where o.ProductId == (ProductId).ToString()
                                              select Convert.ToSingle(o.Quantity)).FirstOrDefault();
                            float newUnits = oldUnits + Convert.ToSingle(Units);

                            var query = from o in obj.Inventories
                                        where o.ProductId == Convert.ToInt32(ProductId)
                                        select o;
                            foreach (var item in query)
                            {
                                item.Quantity = newUnits.ToString();
                            }
                            obj.SubmitChanges();


                            //deletin Transaction
                            var transactions = from o in obj.Transaction1s
                                               where o.id == TransactionId
                                               select o;
                            foreach (var item in transactions)
                            {
                                obj.Transaction1s.DeleteOnSubmit(item);
                            }
                            obj.SubmitChanges();
                            break;
                        }
                    default:
                        break;
                }

                return 1;
            }
            catch
            {

                return -1;
            }
        }

        public int RevertSingleTransaction(int TransactionId, int Units, int ProductId)
        {

            try
            {


                var TransactionType = (from o in obj.Transaction1s
                                       where o.id == TransactionId
                                       select o.TransactionType).FirstOrDefault();
                var PaymentId = (from o in obj.Payments
                                 where o.TransactionId == TransactionId
                                 select o.id).FirstOrDefault();
                var DataPaymentLine = from o in obj.PaymentLines
                                      where o.PaymentId == Convert.ToInt32(PaymentId)
                                      select o;
                var AccountType = (from o in obj.Payments
                                   join paymentLine in obj.PaymentLines
                                   on o.id equals paymentLine.PaymentId
                                   select paymentLine.ModeOfPayment);
                string AccountId = string.Empty;


                Classes.CPayment cp = new CPayment();
                Models.MPayments mp = new Models.MPayments();
                Classes.CInventory ci = new CInventory();
                List<Models.MInventory> Inventory = new List<Models.MInventory>();
                Classes.CProducts cpr = new CProducts();

                Inventory = ci.GetAll();
                string CostPrice = (from o in obj.Transaction1s
                                    where o.ProductID == ProductId
                                    && o.id == TransactionId
                                    select o.CostPrice).FirstOrDefault();
                string SalePrice = (from o in obj.Transaction1s
                                    where o.ProductID == ProductId
                                    && o.id == TransactionId
                                    select o.SalePrice).FirstOrDefault();
                switch (TransactionType)
                {
                    case "Addition":
                        {
                            //Reverting Inventory
                            float oldUnits = (from o in Inventory
                                              where o.ProductId == (ProductId).ToString()
                                              select Convert.ToSingle(o.Quantity)).FirstOrDefault();
                            float newUnits = oldUnits - Convert.ToSingle(Units);

                            var query = from o in obj.Inventories
                                        where o.ProductId == Convert.ToInt32(ProductId)
                                        select o;
                            foreach (var item in query)
                            {
                                item.Quantity = newUnits.ToString();
                            }
                            obj.SubmitChanges();


                            obj.SubmitChanges();
                            //checking for cash of bank account
                            if (Convert.ToString(AccountType) == Common.Constants.ModeOfPayment.Cash.ToString())
                            {
                                string Amount = (Convert.ToSingle(CostPrice) * Convert.ToSingle(Units)).ToString();
                                Classes.CBankOfAccount cba = new CBankOfAccount();
                                Classes.CAccountTransaction cat = new CAccountTransaction();
                                //Reverting Account
                                float OldTotal = cba.ReturnTotalOfAccountById(Convert.ToInt32(AccountId));
                                float NewTotal = OldTotal + Convert.ToSingle(Amount);
                                cba.SetNewAccountTotal(Convert.ToInt32(AccountId), NewTotal);

                                //Add Revert Account Transaction                              
                                Models.MAccountTransaction mat = new Models.MAccountTransaction();
                                mat.AccountId = AccountId.ToString();
                                mat.Credit = "0";
                                mat.Debit = Amount.ToString();
                                mat.Description = "Reverted Sale Transaction Product Id[" + ProductId + "] Units [" + Units + "]";
                                mat.eDate = DateTime.Now;
                                mat.FiscalYearId = (from o in obj.AccountTransactions
                                                    where o.CurrentTransaction == TransactionId.ToString()
                                                    select o.FiscalYearId.ToString()).FirstOrDefault();
                                mat.Total = cba.ReturnTotalOfAccountById(Convert.ToInt32(AccountId)).ToString();
                                mat.Transactiontype = "Credit";

                                cat.Save(mat);

                            }
                            else if (Convert.ToString(AccountType) == Common.Constants.ModeOfPayment.Cheque.ToString())
                            {
                                Classes.CCashAccount cca = new CCashAccount();
                                Classes.CCashTransaction cct = new CCashTransaction();
                                Models.MCashTransactions mct = new Models.MCashTransactions();
                                Models.MCashAccount mca = new Models.MCashAccount();
                                string Amount = (Convert.ToSingle(CostPrice) * Convert.ToSingle(Units)).ToString();
                                //Reverting Account
                                float OldTotal = cca.ReturnTotalOfCashAccount(Convert.ToInt32(AccountId));
                                float NewTotal = OldTotal + Convert.ToSingle(Amount);
                                //setting new total
                                cca.SetNewAccountTotal(Convert.ToInt32(AccountId), NewTotal);

                                mct.CashAccountId = Convert.ToInt32(AccountId);
                                mct.Credit = Amount;
                                mct.Debit = "0";
                                mct.Description = "Reverted Sale Transaction Product Id[" + ProductId + "] Units [" + Units + "]";
                                mct.eDate = DateTime.Now.ToShortDateString();
                                mct.FiscalYearId = Convert.ToInt32((from o in obj.CashTransactions
                                                                    where o.TransactionId == TransactionId
                                                                    select o.FiscalYearId).FirstOrDefault());
                                mct.OrderId = -1;
                                mct.TransactionId = -1;
                                mct.TransactionType = Common.Constants.TransactionStatus.Reverse.ToString();
                                mct.UserId = Convert.ToString((from o in obj.CashTransactions
                                                               where o.TransactionId == TransactionId
                                                               select o.UserId).FirstOrDefault());
                                mct.WareHouseId = Convert.ToInt32((from o in obj.CashTransactions
                                                                   where o.TransactionId == TransactionId
                                                                   select o.WareHouseId).FirstOrDefault());
                                cct.Save(mct);
                            }

                            break;
                        }
                    case "Deduction":
                        {
                            //Reverting Inventory
                            float oldUnits = (from o in Inventory
                                              where o.ProductId == (ProductId).ToString()
                                              select Convert.ToSingle(o.Quantity)).FirstOrDefault();
                            float newUnits = oldUnits + Convert.ToSingle(Units);

                            var query = from o in obj.Inventories
                                        where o.ProductId == Convert.ToInt32(ProductId)
                                        select o;
                            foreach (var item in query)
                            {
                                item.Quantity = newUnits.ToString();
                            }
                            obj.SubmitChanges();


                            //checking for cash of bank account
                            if (Convert.ToString(AccountType) == Common.Constants.ModeOfPayment.Cash.ToString())
                            {
                                string Amount = (Convert.ToSingle(CostPrice) * Convert.ToSingle(Units)).ToString();
                                Classes.CBankOfAccount cba = new CBankOfAccount();
                                Classes.CAccountTransaction cat = new CAccountTransaction();
                                //Reverting Account
                                float OldTotal = cba.ReturnTotalOfAccountById(Convert.ToInt32(AccountId));
                                float NewTotal = OldTotal - Convert.ToSingle(Amount);
                                cba.SetNewAccountTotal(Convert.ToInt32(AccountId), NewTotal);

                                //Add Revert Account Transaction                              
                                Models.MAccountTransaction mat = new Models.MAccountTransaction();
                                mat.AccountId = AccountId.ToString();
                                mat.Credit = "0";
                                mat.Debit = Amount.ToString();
                                mat.Description = "Reverted Sale Transaction Product Id[" + ProductId + "] Units [" + Units + "]";
                                mat.eDate = DateTime.Now;
                                mat.FiscalYearId = (from o in obj.AccountTransactions
                                                    where o.CurrentTransaction == TransactionId.ToString()
                                                    select o.FiscalYearId.ToString()).FirstOrDefault();
                                mat.Total = cba.ReturnTotalOfAccountById(Convert.ToInt32(AccountId)).ToString();
                                mat.Transactiontype = "Credit";

                                cat.Save(mat);
                            }
                            else if (Convert.ToString(AccountType) == Common.Constants.ModeOfPayment.Cheque.ToString())
                            {
                                Classes.CCashAccount cca = new CCashAccount();
                                Classes.CCashTransaction cct = new CCashTransaction();
                                Models.MCashTransactions mct = new Models.MCashTransactions();
                                Models.MCashAccount mca = new Models.MCashAccount();
                                string Amount = (Convert.ToSingle(CostPrice) * Convert.ToSingle(Units)).ToString();
                                //Reverting Account
                                float OldTotal = cca.ReturnTotalOfCashAccount(Convert.ToInt32(AccountId));
                                float NewTotal = OldTotal - Convert.ToSingle(Amount);
                                //setting new total
                                cca.SetNewAccountTotal(Convert.ToInt32(AccountId), NewTotal);


                                //cash account transation
                                mct.CashAccountId = Convert.ToInt32(AccountId);
                                mct.Credit = "0";
                                mct.Debit = Amount;
                                mct.Description = "Reverted Sale Transaction Product Id[" + ProductId + "] Units [" + Units + "]";
                                mct.eDate = DateTime.Now.ToShortDateString();
                                mct.FiscalYearId = Convert.ToInt32((from o in obj.CashTransactions
                                                                    where o.TransactionId == TransactionId
                                                                    select o.FiscalYearId).FirstOrDefault());
                                mct.OrderId = -1;
                                mct.TransactionId = -1;
                                mct.TransactionType = Common.Constants.TransactionStatus.Reverse.ToString();
                                mct.UserId = Convert.ToString((from o in obj.CashTransactions
                                                               where o.TransactionId == TransactionId
                                                               select o.UserId).FirstOrDefault());
                                mct.WareHouseId = Convert.ToInt32((from o in obj.CashTransactions
                                                                   where o.TransactionId == TransactionId
                                                                   select o.WareHouseId).FirstOrDefault());
                                cct.Save(mct);
                            }
                            break;
                        }
                    default:
                        break;
                }

                //deletin Transaction
                var transactions = from o in obj.Transaction1s
                                   where o.id == TransactionId
                                   select o;
                foreach (var item in transactions)
                {
                    obj.Transaction1s.DeleteOnSubmit(item);
                }
                //deleting Payment lines
                foreach (var item in DataPaymentLine)
                {

                    obj.PaymentLines.DeleteOnSubmit(item);
                }
                obj.SubmitChanges();
                //deleting payments
                mp.id = Convert.ToInt32(PaymentId);
                cp.Delete(mp);
                return 1;
            }
            catch
            {

                return -1;
            }
        }


        public List<Models.MRevertInventory.RevertConfirm> GetAllConfirm(int OrderId)
        {
            List<Models.MRevertInventory.RevertConfirm> RevertConfirm = new List<Models.MRevertInventory.RevertConfirm>();
            List<Models.MOrdersLine> OrdersLine = new List<Models.MOrdersLine>();
            Classes.COrderOnline coo = new COrderOnline();
            Classes.CProducts cp = new CProducts();
            OrdersLine = coo.GetAll();
            OrdersLine = OrdersLine.Where(o => o.OrderId == OrderId.ToString()).ToList();
            for (int i = 0; i < OrdersLine.Count; i++)
            {
                Models.MRevertInventory.RevertConfirm mrc = new Models.MRevertInventory.RevertConfirm();
                mrc.Price = OrdersLine[i].SalePrice;
                mrc.ProductId = OrdersLine[i].ProductId;
                mrc.ProductName = cp.GetProductNameWithTagsById(Convert.ToInt32(mrc.ProductId));
                mrc.Units = OrdersLine[i].unit;
                RevertConfirm.Add(mrc);
            }
            return RevertConfirm;
        }
    }
}