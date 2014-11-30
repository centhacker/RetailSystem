using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CProducts
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public string ReturnCostPrice(int ProductId)
        {
            string CostPrice = string.Empty;
            var query = (from o in obj.Products where o.id == Convert.ToInt32(ProductId) select o.costPrice).FirstOrDefault();
            if (query != null)
            {
                Classes.CVendor cv = new CVendor();
                CostPrice = (query.ToString());


            }
            return CostPrice;
        }

        public string ReturnSalePrice(int ProductId)
        {
            string CostPrice = string.Empty;
            var query = (from o in obj.Products where o.id == Convert.ToInt32(ProductId) select o.salePrice).FirstOrDefault();
            if (query != null)
            {
                Classes.CVendor cv = new CVendor();
                CostPrice = (query.ToString());


            }
            return CostPrice;
        }

        public string ReturnVendorName(string ProductsId)
        {
            string VendorName = string.Empty;
            var query = (from o in obj.Products where o.id == Convert.ToInt32(ProductsId) select o.VendorId).FirstOrDefault();
            if (query != null)
            {
                Classes.CVendor cv = new CVendor();
                VendorName = cv.GetVendorNameById(query.ToString()); 


            }
            return VendorName;
        }

        public string GetProductNameWithTagsById(int ProductId)
        {
            string ProductName = string.Empty;
            var query = from o in obj.Products where o.id == ProductId select o;
            foreach (var item in query)
            {
                ProductName = item.ProductCode + "-" + item.Name + "-" + item.tag1 + "-" + item.tag2;
            }
            return ProductName;
        }

        public string ReturnVendorId(string ProductsId)
        {
            string VendorId = string.Empty;
            var query = (from o in obj.Products where o.id == Convert.ToInt32(ProductsId) select o.VendorId).FirstOrDefault();
            if (query != null)
            {
                VendorId = query.ToString();


            }
            return VendorId;
        }

        public int Save(Models.MProducts model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CProducts";
            try
            {
                DB.Product bs = new DB.Product();
                //bs.id = int.Parse(model.id);
                bs.ProductCode = model.ProductCode;
                bs.Name = model.Name;
                bs.tag1 = model.tag1;
                bs.tag2 = model.tag1;
                bs.tag3 = model.tag3;
                bs.costPrice = model.CostPrice;
                bs.salePrice = model.SalePrice;
                bs.Manufacturer = model.Manufacturer;
                bs.Description = model.description;
                bs.VendorId = int.Parse(model.Vendorld);
                bs.FiscalYearId = Convert.ToInt32(model.FiscalYearld); 
                bs.eDate = DateTime.Now;
                bs.WareHouseId = Convert.ToInt32(model.WareHouseId);
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ProductCode[" + model.ProductCode + "] Name[" + model.Name + "] tag1[" + model.tag1 + "] tag2[ " + model.tag2 + "] tag3 [" + model.tag3 + " ] Manufacture[ " + model.Manufacturer + " ] Description [ " + model.description + "]  VendorId [ " + model.Vendorld + "] FiscalYearId [ " + model.FiscalYearld + "] eDate[ " + model.eDate + "]");
                obj.Products.InsertOnSubmit(bs);
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
        public int Update(Models.MProducts model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CProduct";
            try
            {
                var query = from o in obj.Products where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.id = int.Parse(model.id);
                    item.ProductCode = model.ProductCode;
                    item.Name = model.Name;
                    item.tag1 = model.tag1;
                    item.tag2 = model.tag1;
                    item.tag3 = model.tag3;
                    item.salePrice = model.SalePrice;
                    item.costPrice = model.CostPrice;
                    item.Manufacturer = model.Manufacturer;
                    item.Description = model.description;
                    item.VendorId = int.Parse(model.Vendorld);
                    item.FiscalYearId = Convert.ToInt32(model.FiscalYearld);
                    item.eDate = Convert.ToDateTime(model.eDate);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ProductCode[" + model.ProductCode + "] Name[" + model.Name + "] tag1[" + model.tag1 + "] tag2[ " + model.tag2 + "] tag3 [" + model.tag3 + " ] Manufacture[ " + model.Manufacturer + " ] Description [ " + model.description + "]  VendorId [ " + model.Vendorld + "] FiscalYearId [ " + model.FiscalYearld + "] eDate[ " + model.eDate + "]");
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
        public int Delete(Models.MProducts model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CProduct";
            try
            {
                var query = from o in obj.Products where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Products.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ProductCode[" + model.ProductCode + "] Name[" + model.Name + "] tag1[" + model.tag1 + "] tag2[ " + model.tag2 + "] tag3 [" + model.tag3 + " ] Manufacture[ " + model.Manufacturer + " ] Description [ " + model.description + "]  VendorId [ " + model.Vendorld + "] FiscalYearId [ " + model.FiscalYearld + "] eDate[ " + model.eDate + "]");
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
        public List<Models.MProducts> GetAll()
        {
            List<Models.MProducts> model = new List<Models.MProducts>();
            var query = from o in obj.Products select o;
            foreach (var item in query)
            {
                Models.MProducts m = new Models.MProducts();
                m.id = Convert.ToString(item.id);
                m.ProductCode = item.ProductCode;
                m.Name = item.Name;
                m.tag1 = item.tag2;
                m.tag2 = item.tag2;
                m.tag3 = item.tag3;
                m.CostPrice = item.costPrice;
                m.SalePrice = item.salePrice;
                m.Manufacturer = item.Manufacturer;
                m.description = item.Description;
                Classes.CVendor cv = new CVendor();
                m.Vendorld = Convert.ToString(item.VendorId);
                m.VendorName = cv.GetVendorNameById(m.Vendorld);
                m.FiscalYearld = Convert.ToString(item.FiscalYearId);
                m.eDate = Convert.ToString(item.eDate);
                m.WareHouseId = Convert.ToString(item.WareHouseId);

                model.Add(m);
            }

            return model;
        }

        public List<Models.MProducts> GetAllbyid(int id)
        {
            List<Models.MProducts> model = new List<Models.MProducts>();
            var query = from o in obj.Products where (o.id) == id select o;
            foreach (var item in query)
            {
                Models.MProducts m = new Models.MProducts();
                m.id = Convert.ToString(item.id);
                m.ProductCode = item.ProductCode;
                m.Name = item.Name;
                m.tag1 = item.tag2;
                m.tag2 = item.tag2;
                m.tag3 = item.tag3;
                m.SalePrice = item.salePrice;
                m.CostPrice = item.costPrice;
                m.Manufacturer = item.Manufacturer;
                m.description = item.Description;
                m.Vendorld = Convert.ToString(item.VendorId);
                m.FiscalYearld = Convert.ToString(item.FiscalYearId);
                m.eDate = Convert.ToString(item.eDate);

                model.Add(m);
            }

            return model;
        }

    }
}