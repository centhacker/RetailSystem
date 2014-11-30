using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CCashAccount
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();



        public int Save(Models.MCashAccount model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CAccounttransaction";
            try
            {

                DB.CashAccount bs = new DB.CashAccount();

                bs.CashAccountName = model.CashAccountName;
                bs.WareHouseId = model.WareHouseId;
                bs.OpeningBalance = model.OpeningBalance;
                bs.BeginDate = model.BeginDate;
                bs.ClientId = model.ClientId;
                bs.VendorId = model.VendorId;
                bs.AccountType = model.AccountType;
                //  l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] AccountId[" + model.AccountId + "] Total[" + model.Total + "] CurrentTransaction[" + model.CurrentTransaction + "] TransactionType [ " + model.Transactiontype + " ] FiscalYearId [ " + model.FiscalYearId + " ] eDate [" + model.eDate + " ]");
                obj.CashAccounts.InsertOnSubmit(bs);
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


        public int SetNewAccountTotal(int AccountId, float AccountTotal)
        {
            try
            {
                var query = (from o in obj.CashAccounts
                             where o.id == AccountId
                             select o);
                foreach (var item in query)
                {
                    item.OpeningBalance = AccountTotal.ToString();
                }
                obj.SubmitChanges();
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public float ReturnTotalOfCashAccount(int AccountId)
        {
            // float AccountTotal = 0;
            var query = (from o in obj.CashAccounts
                         where o.id == AccountId
                         select o.OpeningBalance).FirstOrDefault();
            return Convert.ToSingle(query);
        }


        public int Update(Models.MCashAccount model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CAccounttransaction";
            try
            {


                var query = from o in obj.CashAccounts
                            where o.id == model.id
                            select
                            o;
                foreach (var item in query)
                {

                    item.CashAccountName = model.CashAccountName;
                    item.WareHouseId = model.WareHouseId;
                    item.OpeningBalance = model.OpeningBalance;
                    item.BeginDate = model.BeginDate;
                    item.ClientId = model.ClientId;
                    item.VendorId = model.VendorId;
                }


                //  l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] AccountId[" + model.AccountId + "] Total[" + model.Total + "] CurrentTransaction[" + model.CurrentTransaction + "] TransactionType [ " + model.Transactiontype + " ] FiscalYearId [ " + model.FiscalYearId + " ] eDate [" + model.eDate + " ]");

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

        public int GetLastAccountId()
        {
            int retVal = -1;
            try
            {
                var query = obj.CashAccounts.OrderByDescending(o => o.id).FirstOrDefault();
                retVal = Convert.ToInt32(query.id);
            }
            catch (Exception)
            {

                //dance baby
            }
            return retVal;
        }
        public List<Models.MCashAccount> GetAll()
        {
            List<Models.MCashAccount> model = new List<Models.MCashAccount>();
            var query = from o in obj.CashAccounts select o;
            foreach (var item in query)
            {
                Models.MCashAccount m = new Models.MCashAccount();

                m.id = Convert.ToInt32(item.id);
                m.CashAccountName = item.CashAccountName;
                m.WareHouseId = Convert.ToInt32(item.WareHouseId);
                m.OpeningBalance = item.OpeningBalance;
                m.BeginDate = item.BeginDate;
                m.ClientId = Convert.ToInt32(item.ClientId);
                m.VendorId = Convert.ToInt32(item.VendorId);
                m.AccountType = item.AccountType;

                model.Add(m);
            }

            return model;
        }
        public List<Models.MCashAccount> GetAllbyid(int id)
        {
            List<Models.MCashAccount> model = new List<Models.MCashAccount>();
            var query = from o in obj.CashAccounts where (o.id) == id select o;
            foreach (var item in query)
            {
                Models.MCashAccount m = new Models.MCashAccount();

                m.id = Convert.ToInt32(item.id);
                m.CashAccountName = item.CashAccountName;
                m.WareHouseId = Convert.ToInt32(item.WareHouseId);
                m.OpeningBalance = item.OpeningBalance;
                m.BeginDate = item.BeginDate;

                model.Add(m);
            }

            return model;
        }

        public string GetAccountNameById(int id)
        {

            var query = (from o in obj.CashAccounts where (o.id) == id select o.CashAccountName).FirstOrDefault();


            return Convert.ToString(query);
        }
    }
}