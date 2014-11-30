using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CIncomeStatement
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        public int Save(Models.MIncomeStatement model)
             {
            Common.Logger l = new Common.Logger();
            string ClassName = "CIncomeStatement";
            try
            {
                  DB.IncomeStatement bs = new DB.IncomeStatement();
                bs.Type = model.Type;
                bs.AccountId = model.Accountid;
                bs.AccountName = model.AccountName;
                bs.value = int.Parse(model.value);
                bs.NetProfit = model.NetProfit;
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values Type[" + model.Type + "] AccountId[" + model.Accountid + "] AccountName[" + model.AccountName + "] Value[" + model.value + "] NetProfit[" + model.NetProfit + " ]");

                obj.IncomeStatements.InsertOnSubmit(bs);
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