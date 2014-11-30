using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CInvoiceItems
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MInvoiceItems model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoicedetailId";
            try
            {

                DB.InvoiceItem bs = new DB.InvoiceItem();
                bs.id = Convert.ToInt32(model.id);
                bs.InvoicedetailId = Convert.ToInt32(model.InvoiceDetailId);
                bs.ProductId = Convert.ToInt32(model.ProductId);
                bs.ProductCost = model.ProductCost;
                
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoicedetailId[" + model.InvoiceDetailId + "] ProductId[" + model.ProductId + "] ProductCost[" + model.ProductCost + "]");
                obj.InvoiceItems.InsertOnSubmit(bs);
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
        public int Update(Models.MInvoiceItems model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoicedetailId";
            try
            {
                var query = from o in obj.InvoiceItems where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.InvoicedetailId = Convert.ToInt32(model.InvoiceDetailId);
                    item.ProductId = Convert.ToInt32(model.ProductId);
                    item.ProductCost = model.ProductCost;
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoicedetailId[" + model.InvoiceDetailId + "] ProductId[" + model.ProductId + "] ProductCost[" + model.ProductCost + "]");
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
        public int Delete(Models.MInvoiceItems model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInvoicedetailId";
            try
            {
                var query = from o in obj.InvoiceItems where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.InvoiceItems.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] InvoicedetailId[" + model.InvoiceDetailId + "] ProductId[" + model.ProductId + "] ProductCost[" + model.ProductCost + "]");
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

        public List<Models.MInvoiceItems> GetAll()
        {
            List<Models.MInvoiceItems> model = new List<Models.MInvoiceItems>();
            var query = from o in obj.InvoiceItems select o;
            foreach (var item in query)
            {
                Models.MInvoiceItems m = new Models.MInvoiceItems();
                m.id = Convert.ToString(item.id);
                m.InvoiceDetailId = Convert.ToString(item.InvoicedetailId);
                m.ProductId = Convert.ToString(item.ProductId);
                m.ProductCost = item.ProductCost;
                model.Add(m);
            }

            return model;
        }
        public List<Models.MInvoiceItems> GetAllbyid(int id)
        {
            List<Models.MInvoiceItems> model = new List<Models.MInvoiceItems>();
            var query = from o in obj.InvoiceItems where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MInvoiceItems m = new Models.MInvoiceItems();
                m.id = Convert.ToString(item.id);
                m.InvoiceDetailId = Convert.ToString(item.InvoicedetailId);
                m.ProductId = Convert.ToString(item.ProductId);
                m.ProductCost = item.ProductCost;
                model.Add(m);
            }

            return model;
        }

    }
}