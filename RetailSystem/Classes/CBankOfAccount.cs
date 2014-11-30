using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CBankOfAccount
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();


        public int ReturnLastAccountId()
        {
            int AccountId = -1;
            try
            {
                var query = obj.BankAccounts.OrderByDescending(u => u.id).FirstOrDefault();
                AccountId = Convert.ToInt32(query.id);
                return AccountId;

            }
            catch
            {

                return -1;
            }

        }

        public int Save(Models.MBankAccount model)
        {
            Common.Logger l = new Common.Logger();
          //  string ClassName = "CBankAccount";
            try
            {

                DB.BankAccount bs = new DB.BankAccount();
                bs.id = Convert.ToInt32(model.id);
                bs.BankId = Convert.ToInt32(model.BankId);
                bs.AccountNumber = model.accountNumber;
                bs.AccountTitle = model.Accounttitle;
                bs.AccountHolderId = model.AccountHolderId;
                bs.BeginDate = model.BeginDate;
                bs.OpeningBalance = model.OpeningBalance;
                bs.Balance = model.Balance;
                bs.WareHouseId = Convert.ToInt32(model.WareHouseId);
                //l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] BankId[" + model.BankId + "] AccountNumber[" + model.accountNumber + "] AccountTitle[" + model.Accounttitle + "] AccountHolderId [ " + model.AccountHolderId + "] BeginDate [ " + model.BeginDate + " ] ");
                obj.BankAccounts.InsertOnSubmit(bs);
                obj.SubmitChanges();


                Classes.CJournal cj = new CJournal();
                DB.Journal j = new DB.Journal();
                j.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.OwnerEquity);
                j.amount = Convert.ToSingle(bs.OpeningBalance);
                j.des = "Opened Bank Account with name[" + bs.AccountTitle + "] ";
                j.e_date = Convert.ToDateTime(bs.BeginDate);
                j.type = Common.Constants.Accounts.Type.Credit.ToString();
                obj.Journals.InsertOnSubmit(j);
                obj.SubmitChanges();

                j = new DB.Journal();
                j.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.Cash);
                j.amount = Convert.ToSingle(bs.OpeningBalance);
                j.des = "Opened Bank Account with name[" + bs.AccountTitle + "] ";
                j.e_date = Convert.ToDateTime(bs.BeginDate);
                j.type = Common.Constants.Accounts.Type.Debit.ToString();
                obj.Journals.InsertOnSubmit(j);
                obj.SubmitChanges();

                //l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Inserted Successfully");
                return 1;
            }
            catch 
            {
                //l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
                return -1;
            }

        }
        public int Update(Models.MBankAccount model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CBankAccounts";
            try
            {
                var query = from o in obj.BankAccounts where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.BankId = Convert.ToInt32(model.BankId);
                    item.AccountNumber = model.accountNumber;
                    item.AccountTitle = model.Accounttitle;
                    item.AccountHolderId = model.AccountHolderId;
                    item.BeginDate = model.BeginDate;
                }
                //l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] BankId[" + model.BankId + "] AccountNumber[" + model.accountNumber + "] AccountTitle[" + model.Accounttitle + "] AccountHolderId [ " + model.AccountHolderId + "] BeginDate [ " + model.BeginDate + " ] ");
                obj.SubmitChanges();
                // //l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Updated Successfully");
                return 1;
            }
            catch 
            {
                //l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
                return -1;
            }
        }
        public int Delete(Models.MBank model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CBankAccount";
            try
            {
                var query = from o in obj.BankAccounts where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.BankAccounts.DeleteOnSubmit(item);
                }
                //l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] BankId[" + model.BankId + "] AccountNumber[" + model.accountNumber + "] AccountTitle[" + model.Accounttitle + "] AccountHolderId [ " + model.AccountHolderId + "] BeginDate [ " + model.BeginDate + " ] ");
                obj.SubmitChanges();
                //l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Deleted Successfully");
                return 1;

            }
            catch (Exception ex)
            {
                //l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
                return -1;
            }
        }

        public string GetAccountNumberAccountTileById(int AccountId)
        {
            var query = (from o in obj.BankAccounts
                         where o.id == AccountId
                         select o).FirstOrDefault();
            if (query != null)
            {
                return (query.AccountNumber + "-" + query.AccountTitle).ToString();
            }
            return string.Empty;
        }

        public int SetNewAccountTotal(int AccountId, float NewTotal)
        {
            try
            {
                var query = from o in obj.BankAccounts where o.id == AccountId select o;
                foreach (var item in query)
                {
                    item.Balance = NewTotal.ToString();
                }
                obj.SubmitChanges();
                return 1;

            }
            catch (Exception)
            {

                return -1;
            }
        }

        public float ReturnTotalOfAccountById(int AccountId)
        {
            float Total = 0;
            var query = (from o in obj.BankAccounts where o.id == AccountId select o.Balance).FirstOrDefault();
            if (query.Count() != 0)
            {
                Total = Convert.ToSingle(query.ToString());
                return Total;
            }
            else
            {
                return Total;
            }
        }

        public List<Models.MBankAccount> GetAll()
        {
            List<Models.MBankAccount> model = new List<Models.MBankAccount>();
            var query = from o in obj.BankAccounts select o;
            foreach (var item in query)
            {
                Models.MBankAccount m = new Models.MBankAccount();
                m.id = Convert.ToString(item.id);
                m.BankId = Convert.ToString(item.BankId);
                m.accountNumber = item.AccountNumber;
                m.Accounttitle = item.AccountTitle;
                m.AccountHolderId = item.AccountHolderId;
                m.OpeningBalance = item.OpeningBalance;
                m.Balance = item.Balance;
                m.BeginDate = item.BeginDate;
                m.WareHouseId = Convert.ToString(item.WareHouseId);
                model.Add(m);
            }

            return model;
        }
        public List<Models.MBankAccount> GetAllbyid(int id)
        {
            List<Models.MBankAccount> model = new List<Models.MBankAccount>();
            var query = from o in obj.BankAccounts where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MBankAccount m = new Models.MBankAccount();
                m.id = Convert.ToString(item.id);
                m.BankId = Convert.ToString(item.BankId);
                m.accountNumber = item.AccountNumber;
                m.Accounttitle = item.AccountTitle;
                m.AccountHolderId = item.AccountHolderId;
                m.BeginDate = item.BeginDate;
                model.Add(m);
            }

            return model;
        }


    }
}