using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CInvocieDetails
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MInvoiceDetails model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoicedetail";
            try
            {

                DB.InvoiceDetail bs = new DB.InvoiceDetail();
                bs.id = Convert.ToInt32(model.id);
                bs.InvoiceId = Convert.ToInt32(model.InvoiceId);
                bs.OrderId = Convert.ToInt32(model.OrderId);
                bs.VendorId = Convert.ToInt32(model.VendorId);
                bs.CustomerId = Convert.ToInt32(model.Customer);
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoiceId[" + model.InvoiceId + "] OrderId[" + model.OrderId + "] VendorId[" + model.VendorId + "] CustomerId[ " + model.Customer + " ]");
                obj.InvoiceDetails.InsertOnSubmit(bs);
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
        public int Update(Models.MInvoiceDetails model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoicedetail";
            try
            {
                var query = from o in obj.InvoiceDetails where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.InvoiceId = Convert.ToInt32(model.InvoiceId);
                    item.OrderId = Convert.ToInt32(model.OrderId);
                    item.VendorId = Convert.ToInt32(model.VendorId);
                    item.CustomerId = Convert.ToInt32(model.Customer);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoiceId[" + model.InvoiceId + "] OrderId[" + model.OrderId + "] VendorId[" + model.VendorId + "] CustomerId[ " + model.Customer + " ]");
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
        public int Delete(Models.MInvoiceDetails model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoicedetail";
            try
            {
                var query = from o in obj.InvoiceDetails where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.InvoiceDetails.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoiceId[" + model.InvoiceId + "] OrderId[" + model.OrderId + "] VendorId[" + model.VendorId + "] CustomerId[ " + model.Customer + " ]");
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
        public List<Models.MInvoiceDetails> GetAll()
        {
            List<Models.MInvoiceDetails> model = new List<Models.MInvoiceDetails>();
            var query = from o in obj.InvoiceDetails select o;
            foreach (var item in query)
            {
                Models.MInvoiceDetails m = new Models.MInvoiceDetails();
                m.id = Convert.ToString(item.id);
                m.InvoiceId = Convert.ToString(item.InvoiceId);
                m.OrderId = Convert.ToString(item.OrderId);
                m.VendorId = Convert.ToString(item.VendorId);
                m.Customer = Convert.ToString(item.CustomerId);
                
                model.Add(m);
            }

            return model;
        }
        public List<Models.MInvoiceDetails> GetAllbyid(int id)
        {
            List<Models.MInvoiceDetails> model = new List<Models.MInvoiceDetails>();
            var query = from o in obj.InvoiceDetails where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MInvoiceDetails m = new Models.MInvoiceDetails();
                m.id = Convert.ToString(item.id);
                m.InvoiceId = Convert.ToString(item.InvoiceId);
                m.OrderId = Convert.ToString(item.OrderId);
                m.VendorId = Convert.ToString(item.VendorId);
                m.Customer = Convert.ToString(item.CustomerId);
                model.Add(m);
            }

            return model;
        }

    }
}