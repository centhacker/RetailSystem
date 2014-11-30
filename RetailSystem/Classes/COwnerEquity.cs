using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class COwnerEquity
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        public int Save(Models.MOwnerEquity model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "COwnerEquity";
            try
            {

                DB.OwnerEquity bs = new DB.OwnerEquity();
                bs.OldCapital = Convert.ToDouble(model.OldCapital);
                bs.newcapital = Convert.ToDouble(model.newcapital);
                bs.netincome = Convert.ToDouble(model.netincome);
                bs.ow = Convert.ToDouble(model.ow);
                bs.finalcapital = Convert.ToDouble(model.finalcapital);
                bs.fromDate = Convert.ToDateTime(model.fromDate);
                bs.toDate = Convert.ToDateTime(model.toDate);

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values OldCapital[" + model.OldCapital + "] newcapital[" + model.newcapital + "] netincome[" + model.netincome + "] ow[" + model.ow + "] finalcapital [ " + model.finalcapital + "] fromDate[" + model.fromDate + " ] toDate[ " + model.toDate + " ]");
                obj.OwnerEquities.InsertOnSubmit(bs);
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