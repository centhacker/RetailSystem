using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CTransaction
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MTransaction model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CTransaction";
            try
            {

                DB.Transaction bs = new DB.Transaction();
                bs.id = int.Parse(model.id);
                bs.TransactionDetails = model.TransactionDetails;
                bs.TransactionType = model.TransactionType;
                bs.OrderId = int.Parse(model.OrderId);
                bs.ClientId = int.Parse(model.ClientId);
                bs.VendorId = int.Parse(model.FiscalYearId);
                bs.eDate = Convert.ToDateTime(model.eDate);

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] TransactionDetail[" + model.TransactionDetails + "] TransactionType[" + model.TransactionType + "] OrderId[" + model.OrderId + "] ClientId[ " + model.ClientId + " ] VendorId[ " + model.VendorId + " ] FiscalYearId[ " + model.FiscalYearId + " ] eDate [ " + model.eDate + " ]");
                obj.Transactions.InsertOnSubmit(bs);
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
        public int Update(Models.MTransaction model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CTransaction";
            try
            {
                var query = from o in obj.Transactions where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.id = int.Parse(model.id);
                    item.TransactionDetails = model.TransactionDetails;
                    item.TransactionType = model.TransactionType;
                    item.OrderId = int.Parse(model.OrderId);
                    item.ClientId = int.Parse(model.ClientId);
                    item.VendorId = int.Parse(model.VendorId);
                    item.FiscalYearId = int.Parse(model.FiscalYearId);
                    item.eDate = Convert.ToDateTime(model.eDate);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] TransactionDetail[" + model.TransactionDetails + "] TransactionType[" + model.TransactionType + "] OrderId[" + model.OrderId + "] ClientId[ " + model.ClientId + " ] VendorId[ " + model.VendorId + " ] FiscalYearId[ " + model.FiscalYearId + " ] eDate [ " + model.eDate + " ]");
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
        public int Delete(Models.MTransaction model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CTransaction";
            try
            {
                var query = from o in obj.Transactions where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Transactions.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] TransactionDetail[" + model.TransactionDetails + "] TransactionType[" + model.TransactionType + "] OrderId[" + model.OrderId + "] ClientId[ " + model.ClientId + " ] VendorId[ " + model.VendorId + " ] FiscalYearId[ " + model.FiscalYearId + " ] eDate [ " + model.eDate + " ]");
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
        public List<Models.MTransaction> GetAll()
        {
            List<Models.MTransaction> model = new List<Models.MTransaction>();
            var query = from o in obj.Transactions select o;
            foreach (var item in query)
            {
                Models.MTransaction m = new Models.MTransaction();
                m.id = Convert.ToString(item.id);
                m.TransactionDetails = item.TransactionDetails;
                m.TransactionType = item.TransactionType;
                m.OrderId = Convert.ToString(item.OrderId);
                m.ClientId = Convert.ToString(item.ClientId);
                m.VendorId = Convert.ToString(item.VendorId);
                m.FiscalYearId = Convert.ToString(item.FiscalYearId);
                m.eDate = Convert.ToString(item.eDate);
                model.Add(m);
            }

            return model;
        }
        public List<Models.MTransaction> GetAllbyid(int id)
        {
            List<Models.MTransaction> model = new List<Models.MTransaction>();
            var query = from o in obj.Transactions where (o.id) == id select o;
            foreach (var item in query)
            {
                Models.MTransaction m = new Models.MTransaction();
                m.id = Convert.ToString(item.id);
                m.TransactionDetails = item.TransactionDetails;
                m.TransactionType = item.TransactionType;
                m.OrderId = Convert.ToString(item.OrderId);
                m.ClientId = Convert.ToString(item.ClientId);
                m.VendorId = Convert.ToString(item.VendorId);
                m.FiscalYearId = Convert.ToString(item.FiscalYearId);
                m.eDate = Convert.ToString(item.eDate);
                model.Add(m);
            }

            return model;
        }


    }
}