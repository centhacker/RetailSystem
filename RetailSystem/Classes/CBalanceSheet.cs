using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CBalanceSheet
    {

        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        //insert
        //update
        //delete
        //getall
        //getallbyid

        public int Save(Models.MBalanceSheet model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CBalanceSheet";
            try
            {

                DB.BalanceSheet bs = new DB.BalanceSheet();
                bs.ACCOUNTID = model.AccountId;
                bs.ACCOUNTNAME = model.AccountName;
                bs.ACCOUNTTOTAL = model.AccountTtotal;
                bs.TYPE = model.Type;

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values Accountid[" + model.AccountId + "] AccountName[" + model.AccountName + "] AccountTotal[" + model.AccountTtotal + "] Type[" + model.Type + "]");
                obj.BalanceSheets.InsertOnSubmit(bs);
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

        public int Update(Models.MBalanceSheet model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CBalanceSheet";
            try
            {
                var query = from o in obj.BalanceSheets where o.ACCOUNTID == model.AccountId select o;
                
                foreach (var item in query)
                {
                    item.ACCOUNTNAME = model.AccountName;
                    item.ACCOUNTTOTAL = model.AccountTtotal;
                    item.TYPE = model.Type;
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values Accountid[" + model.AccountId + "] AccountName[" + model.AccountName + "] AccountTotal[" + model.AccountTtotal + "] Type[" + model.Type + "]");
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

        public int Delete(Models.MBalanceSheet model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CBalanceSheet";
            try
            {
                var query = from o in obj.BalanceSheets where o.ACCOUNTID == model.AccountId select o;
                foreach (var item in query)
                {
                    obj.BalanceSheets.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values Accountid[" + model.AccountId + "] AccountName[" + model.AccountName + "] AccountTotal[" + model.AccountTtotal + "] Type[" + model.Type + "]");
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


        public List<Models.MBalanceSheet> GetAll()
        {
            List<Models.MBalanceSheet> model = new List<Models.MBalanceSheet>();
            var query = from o in obj.BalanceSheets select o;
            foreach (var item in query)
            {
                Models.MBalanceSheet m = new Models.MBalanceSheet();
                m.AccountId = item.ACCOUNTID;
                m.AccountName = item.ACCOUNTNAME;
                m.AccountTtotal = Convert.ToSingle(item.ACCOUNTTOTAL);
                m.Type = item.TYPE;
                model.Add(m);
            }

            return model;
        }

        public List<Models.MBalanceSheet> GetAllbyid(int id)
        {
            List<Models.MBalanceSheet> model = new List<Models.MBalanceSheet>();
            var query = from o in obj.BalanceSheets where o.ACCOUNTID==id.ToString() select o;
            foreach (var item in query)
            {
                Models.MBalanceSheet m = new Models.MBalanceSheet();
                m.AccountId = item.ACCOUNTID;
                m.AccountName = item.ACCOUNTNAME;
                m.AccountTtotal = Convert.ToSingle(item.ACCOUNTTOTAL);
                m.Type = item.TYPE;
                model.Add(m);
            }

            return model;
        }


    }
}