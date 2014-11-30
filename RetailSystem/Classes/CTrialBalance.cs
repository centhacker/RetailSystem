using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CTrialBalance
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MTrialBalance model)           
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CTrialBalance";
            try
            {

                DB.TrialBalance bs = new DB.TrialBalance();
                bs.AccountId = model.AccountId;
                bs.AccountName = model.AccountName;
                bs.Debit = model.Debit;
                bs.Credit = model.credit;

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values Accountid[" + model.AccountId + "] AccountName[" + model.AccountName + "] Debit[" + model.Debit + "] Credit[" + model.credit + "]");
                obj.TrialBalances.InsertOnSubmit(bs);
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
    }
}