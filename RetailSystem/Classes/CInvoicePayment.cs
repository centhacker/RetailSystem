using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CInvoicePayment
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MInvoicePayment model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoicePayment";
            try
            {

                DB.InvoicePayment bs = new DB.InvoicePayment();
                bs.id = Convert.ToInt32(model.id);
                bs.InvoiceId = Convert.ToInt32(model.InvoiveId);
                bs.Payment = model.PaymentId;
                bs.Total = model.Total;
                bs.Remaining = model.Remaining;
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoiceId[" + model.InvoiveId + "] Payment[" + model.PaymentId + "] Total[" + model.Total + "] Remaining[ " + model.Remaining + " ]");
                obj.InvoicePayments.InsertOnSubmit(bs);
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
        public int Update(Models.MInvoicePayment model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoicePayment";
            try
            {
                var query = from o in obj.InvoicePayments where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.InvoiceId = Convert.ToInt32(model.InvoiveId);
                    item.Payment = model.PaymentId;
                    item.Total = model.Total;
                    item.Remaining = model.Remaining;
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoiceId[" + model.InvoiveId + "] Payment[" + model.PaymentId + "] Total[" + model.Total + "] Remaining[ " + model.Remaining + " ]");
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
        public int Delete(Models.MInvoicePayment model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoicePayment";
            try
            {
                var query = from o in obj.InvoicePayments where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.InvoicePayments.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoiceId[" + model.InvoiveId + "] Payment[" + model.PaymentId + "] Total[" + model.Total + "] Remaining[ " + model.Remaining + " ]");
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
        public List<Models.MInvoicePayment> GetAll()
        {
            List<Models.MInvoicePayment> model = new List<Models.MInvoicePayment>();
            var query = from o in obj.InvoicePayments select o;
            foreach (var item in query)
            {
                Models.MInvoicePayment m = new Models.MInvoicePayment();
                m.id = Convert.ToString(item.id);
                m.InvoiveId = Convert.ToString(item.InvoiceId);
                m.PaymentId = item.Payment;
                m.Total = item.Total;
                m.Remaining = item.Remaining;
                model.Add(m);
            }

            return model;
        }
        public List<Models.MInvoicePayment> GetAllbyid(int id)
        {
            List<Models.MInvoicePayment> model = new List<Models.MInvoicePayment>();
            var query = from o in obj.InvoicePayments where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MInvoicePayment m = new Models.MInvoicePayment();
                m.id = Convert.ToString(item.id);
                m.InvoiveId = Convert.ToString(item.InvoiceId);
                m.PaymentId = item.Payment;
                m.Total = item.Total;
                m.Remaining = item.Remaining;
                model.Add(m);
            }

            return model;
        }


    }
}