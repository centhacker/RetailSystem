using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CCashTransaction
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        public int Save(Models.MCashTransactions model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CAccounttransaction";
            try
            {

                DB.CashTransaction bs = new DB.CashTransaction();
                bs.CashAccountId = Convert.ToInt32(model.CashAccountId);
                bs.Debit = model.Debit;
                bs.Credit = model.Credit;
                bs.Description = model.Description;
                bs.Total = model.Total;
                bs.TransactionId = model.TransactionId;
                bs.OrderId = model.OrderId;
                bs.TransactionType = model.TransactionType;
                bs.FiscalYearId = model.FiscalYearId;
                bs.eDate = Convert.ToDateTime(model.eDate);
                bs.WareHouseId = model.WareHouseId;
                bs.UserId = Convert.ToInt32(model.UserId); 
                obj.CashTransactions.InsertOnSubmit(bs);
                obj.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
                return -1;
            }
        }

        public List<Models.MCashTransactions> GetAll()
        {
            List<Models.MCashTransactions> model = new List<Models.MCashTransactions>();
            var query = from o in obj.CashTransactions select o;
            foreach (var item in query)
            {
                Models.MCashTransactions m = new Models.MCashTransactions();
                m.id = item.id;
                m.CashAccountId = Convert.ToInt32(item.CashAccountId);
                m.Debit = item.Debit;
                m.Credit = item.Credit;
                m.Description = item.Description;
                m.Total = item.Total;
                m.TransactionId = Convert.ToInt32(item.TransactionId);
                m.OrderId = Convert.ToInt32(item.OrderId);
                m.TransactionType = item.TransactionType;
                m.FiscalYearId = Convert.ToInt32(item.FiscalYearId);
                m.eDate = Convert.ToDateTime(item.eDate).ToShortDateString();
                m.WareHouseId = Convert.ToInt32(item.WareHouseId);
                m.UserId = Convert.ToString(item.UserId);
                model.Add(m);
            }

            return model;
        }
        public List<Models.MCashTransactions> GetAllbyid(int id)
        {
            List<Models.MCashTransactions> model = new List<Models.MCashTransactions>();
            var query = from o in obj.CashTransactions where (o.id) == id select o;
            foreach (var item in query)
            {
                Models.MCashTransactions m = new Models.MCashTransactions();
                m.id = item.id;
                m.CashAccountId = Convert.ToInt32(item.CashAccountId);
                m.Debit = item.Debit;
                m.Credit = item.Credit;
                m.Description = item.Description;
                m.Total = item.Total;
                m.TransactionId = Convert.ToInt32(item.TransactionId);
                m.OrderId = Convert.ToInt32(item.OrderId);
                m.TransactionType = item.TransactionType;
                m.FiscalYearId = Convert.ToInt32(item.FiscalYearId);
                m.eDate = Convert.ToDateTime(item.eDate).ToShortDateString();
                m.WareHouseId = Convert.ToInt32(item.WareHouseId);

                model.Add(m);
            }

            return model;
        }
    }
}