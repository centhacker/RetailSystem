using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CLedgers
    {

        DB.DBContextDataContext obj = new DB.DBContextDataContext();


        public int Save(Models.MLedgers model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CLedgers";
            try
            {
                DB.Ledger bs = new DB.Ledger();
                bs.type = model.type;
                bs.e_date = Convert.ToDateTime(model.e_date);
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values type[" + model.type + "] e_date[" + model.e_date + "] ");
                obj.Ledgers.InsertOnSubmit(bs);
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