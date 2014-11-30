using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class COrderOnline
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        public int Save(Models.MOrdersLine model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "COrderLine"; 
            try
            {
                DB.OrderLine bs = new DB.OrderLine();
                bs.OrderId = Convert.ToInt32(model.OrderId);
                bs.ProductId = Convert.ToInt32( model.ProductId);
                bs.SalePrice = model.SalePrice;
                bs.units = model.unit;
                bs.totalProductCost = model.totalProductCost;
                bs.eDate = Convert.ToDateTime(model.eDate);

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] OrderId[" + model.OrderId + "] ProductId[" + model.ProductId + "] SalePrice[" + model.SalePrice + "] units [" + model.unit + " ] totalProductCost [ " + model.totalProductCost + " ] eDate[ " + model.eDate + "]");
                obj.OrderLines.InsertOnSubmit(bs);
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

        public List<Models.MOrdersLine> GetAll() 
        {
            List<Models.MOrdersLine> Get = new List<Models.MOrdersLine>();
            var query = from o in obj.OrderLines select o;
            foreach (var item in query)
            {
                Models.MOrdersLine mol = new Models.MOrdersLine();
                mol.id = item.id.ToString();
                mol.eDate = item.eDate.ToString();
                mol.OrderId = item.OrderId.ToString();
                mol.ProductId = item.ProductId.ToString();
                mol.SalePrice = item.SalePrice;
                mol.totalProductCost = item.totalProductCost;
                mol.unit = item.units;                
                Get.Add(mol);

            }

            return Get;
        }
        

    }
}