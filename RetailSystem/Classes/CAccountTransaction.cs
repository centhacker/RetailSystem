using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CAccountTransaction
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        public int Save(Models.MAccountTransaction model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CAccounttransaction";
            try
            {

                DB.AccountTransaction bs = new DB.AccountTransaction();
                // bs.id = int.Parse(model.id);
                bs.AccountId = int.Parse(model.AccountId);
                bs.Total = model.Total;
                bs.Debit = model.Debit;
                bs.Credit = model.Credit;
                bs.Description = model.Description;
                bs.CurrentTransaction = model.CurrentTransaction;
                bs.TransactionType = model.Transactiontype;
                bs.FiscalYearId = int.Parse(model.FiscalYearId);
                bs.eDate = model.eDate;

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] AccountId[" + model.AccountId + "] Total[" + model.Total + "] CurrentTransaction[" + model.CurrentTransaction + "] TransactionType [ " + model.Transactiontype + " ] FiscalYearId [ " + model.FiscalYearId + " ] eDate [" + model.eDate + " ]");
                obj.AccountTransactions.InsertOnSubmit(bs);
                obj.SubmitChanges();
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Inserted Successfully");
                return 1;
            }
            catch (Exception ex)
            {
                l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
                return -1;
            }
        }
        public int Update(Models.MAccountTransaction model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CAccounttransaction";
            try
            {
                var query = from o in obj.AccountTransactions where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.AccountId = Convert.ToInt32(model.AccountId);
                    item.Total = model.Total;
                    item.CurrentTransaction = model.CurrentTransaction;
                    item.TransactionType = model.Transactiontype;
                    item.FiscalYearId = Convert.ToInt32(model.FiscalYearId);
                    item.eDate = model.eDate;
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] AccountId[" + model.AccountId + "] Total[" + model.Total + "] CurrentTransaction[" + model.CurrentTransaction + "] TransactionType [ " + model.Transactiontype + " ] FiscalYearId [ " + model.FiscalYearId + " ] eDate [" + model.eDate + " ]");
                obj.SubmitChanges();
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Updated Successfully");
                return 1;
            }
            catch (Exception ex)
            {
                l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
                return -1;
            }
        }
        public int Delete(Models.MAccountTransaction model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CAccounttransaction";
            try
            {
                var query = from o in obj.AccountTransactions where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.AccountTransactions.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] AccountId[" + model.AccountId + "] Total[" + model.Total + "] CurrentTransaction[" + model.CurrentTransaction + "] TransactionType [ " + model.Transactiontype + " ] FiscalYearId [ " + model.FiscalYearId + " ] eDate [" + model.eDate + " ]");
                obj.SubmitChanges();
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Deleted Successfully");
                return 1;
            }
            catch (Exception ex)
            {
                l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
                return -1;
            }
        }
        public List<Models.MAccountTransaction> GetAll()
        {
            List<Models.MAccountTransaction> model = new List<Models.MAccountTransaction>();
            var query = from o in obj.AccountTransactions select o;
            foreach (var item in query)
            {
                Models.MAccountTransaction m = new Models.MAccountTransaction();
                m.id = Convert.ToString(item.id);
                m.AccountId = Convert.ToString(item.AccountId);
                m.Total = item.Total;
                m.Debit = item.Debit;
                m.Credit = item.Credit;
                m.Description = item.Description;
                m.CurrentTransaction = item.CurrentTransaction;
                m.Transactiontype = item.TransactionType;
                m.FiscalYearId = Convert.ToString(item.FiscalYearId);
                m.eDate = Convert.ToDateTime(Convert.ToString(item.eDate));
                model.Add(m);
            }

            return model;
        }
        public List<Models.MAccountTransaction> GetAllbyid(int id)
        {
            List<Models.MAccountTransaction> model = new List<Models.MAccountTransaction>();
            var query = from o in obj.AccountTransactions where (o.id) == id select o;
            foreach (var item in query)
            {
                Models.MAccountTransaction m = new Models.MAccountTransaction();
                m.id = Convert.ToString(item.id);
                m.AccountId = Convert.ToString(item.AccountId);
                m.Total = item.Total;
                m.Debit = item.Debit;
                m.Credit = item.Credit;
                m.Description = item.Description;
                m.CurrentTransaction = item.CurrentTransaction;
                m.Transactiontype = item.TransactionType;
                m.FiscalYearId = Convert.ToString(item.FiscalYearId);
                m.eDate = Convert.ToDateTime(Convert.ToString(item.eDate));
                model.Add(m);
            }

            return model;
        }


        public List<Models.MAccountTransactionsView> GetAllViewAccounts()
        {

            Classes.CBankOfAccount cab = new CBankOfAccount();
            List<Models.MAccountTransactionsView> GetAccounts = new List<Models.MAccountTransactionsView>();
            var query = from o in obj.AccountTransactions select o;

            foreach (var item in query)
            {
                Models.MAccountTransactionsView mav = new Models.MAccountTransactionsView();
                mav.AccountId = item.AccountId.ToString();
                string[] AccountDetails = cab.GetAccountNumberAccountTileById(Convert.ToInt32(item.AccountId)).ToString().Split('-');
                mav.AccountNumber = AccountDetails[0];
                mav.AccountTitle = AccountDetails[1];
                mav.Credit = Common.DynamicCaller.ConvertToDouble(item.Credit.ToString()).ToString();
                mav.Debit = Common.DynamicCaller.ConvertToDouble(item.Debit.ToString()).ToString();
                mav.Description = item.Description;
                mav.Total = Common.DynamicCaller.ConvertToDouble(item.Total.ToString()).ToString();
                mav.eDate = item.eDate.ToString();
                mav.FiscalYearId = item.FiscalYearId.ToString();
                GetAccounts.Add(mav);
            }
            return GetAccounts;
        }

    }
}