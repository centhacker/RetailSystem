using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class Clnvoices
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MInvoices model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoices";
            try
            {

                DB.Invoice bs = new DB.Invoice();
                bs.id = Convert.ToInt32(model.id);
                bs.InvoiceType = model.InvoiceType;
                bs.InvoiceTotal = model.InvoiceTotal;
                bs.InvoiceDate = Convert.ToString(model.InvoiceDate);
                bs.FiscalYeadId = Convert.ToInt32(model.FiscalYearId);
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoiceType[" + model.InvoiceType + "] InvoiceTotal[" + model.InvoiceTotal + "] InvoiceDate[" + model.InvoiceDate + "] FiscalYearId [ " + model.FiscalYearId + "]");
                obj.Invoices.InsertOnSubmit(bs);
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
        public int Update(Models.MInvoices model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoices";
            try
            {
                var query = from o in obj.Invoices where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.InvoiceType = Convert.ToString(model.InvoiceType);
                    item.InvoiceTotal = model.InvoiceTotal;
                    item.InvoiceDate = Convert.ToString(model.InvoiceDate);
                    item.FiscalYeadId = Convert.ToInt32(model.FiscalYearId);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoiceType[" + model.InvoiceType + "] InvoiceTotal[" + model.InvoiceTotal + "] InvoiceDate[" + model.InvoiceDate + "] FiscalYearId [ " + model.FiscalYearId + "]");
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
        public int Delete(Models.MInvoices model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoices";
            try
            {
                var query = from o in obj.Invoices where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Invoices.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoiceType[" + model.InvoiceType + "] InvoiceTotal[" + model.InvoiceTotal + "] InvoiceDate[" + model.InvoiceDate + "] FiscalYearId [ " + model.FiscalYearId + "]");
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
        public List<Models.MInvoices> GetAll()
        {
            List<Models.MInvoices> model = new List<Models.MInvoices>();
            var query = from o in obj.Invoices select o;
            foreach (var item in query)
            {
                Models.MInvoices m = new Models.MInvoices();
                m.id = Convert.ToString(item.id);
                m.InvoiceType = item.InvoiceType;
                m.InvoiceTotal = item.InvoiceTotal;
                m.InvoiceDate = Convert.ToDateTime(item.InvoiceDate);
                m.FiscalYearId = Convert.ToString(item.FiscalYeadId);
                model.Add(m);
            }

            return model;
        }
        public List<Models.MInvoices> GetAllbyid(int id)
        {
            List<Models.MInvoices> model = new List<Models.MInvoices>();
            var query = from o in obj.Invoices where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MInvoices m = new Models.MInvoices();
                m.id = Convert.ToString(item.id);
                m.InvoiceType = item.InvoiceType;
                m.InvoiceTotal = item.InvoiceTotal;
                m.InvoiceDate = Convert.ToDateTime(item.InvoiceDate);
                m.FiscalYearId = Convert.ToString(item.FiscalYeadId);
                model.Add(m);
            }

            return model;
        }

    }
}