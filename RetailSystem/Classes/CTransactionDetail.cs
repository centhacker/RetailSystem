using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CTransactionDetail
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MTransactionDetail model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CTransactionDetail";
            try
            {

                DB.TransactionDetail bs = new DB.TransactionDetail();
                bs.id = int.Parse(model.id);
                bs.TransactionId = int.Parse(model.TransactionId);
                bs.FromWareHouseId = int.Parse(model.FormWareHouseId);
                bs.ToWareHouseId =Convert.ToInt32( model.ToWareHouseId);
                bs.TransactionQuantity = model.transactionCost;
                bs.TotalCost = model.TotalCost;
                bs.eDate = Convert.ToDateTime(model.eDate);

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] TrancactionId[" + model.TransactionId + "] ProductId[" + model.ProductId + "] FromWareHouseId[" + model.FormWareHouseId + "] ToWareHouseId[ " + model.ToWareHouseId + " ] TransactionQuantity [" + model.TransactionQuantity + " ] TransactionCost[ " + model.transactionCost + " ] TotalCost [ " + model.TotalCost + " ] eDate[ " + model.eDate + " ]");
                obj.TransactionDetails.InsertOnSubmit(bs);
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

        public int Update(Models.MTransactionDetail model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CTransaction";
            try
            {
                var query = from o in obj.TransactionDetails where Convert.ToString(o.id) == model.id select o;
                
                foreach (var item in query)
                {
                    item.id =Convert.ToInt32( model.id);
                    item.TransactionId =Convert.ToInt32( model.ProductId);
                    item.FromWareHouseId = Convert.ToInt32(model.FormWareHouseId);
                    item.ToWareHouseId = Convert.ToInt32(model.ToWareHouseId);
                    item.TransactionQuantity = model.TransactionQuantity;
                    item.TransactionCost = model.transactionCost;
                    item.TotalCost = model.TotalCost;
                    item.eDate = Convert.ToDateTime(model.eDate);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] TrancactionId[" + model.TransactionId + "] ProductId[" + model.ProductId + "] FromWareHouseId[" + model.FormWareHouseId + "] ToWareHouseId[ " + model.ToWareHouseId + " ] TransactionQuantity [" + model.TransactionQuantity + " ] TransactionCost[ " + model.transactionCost + " ] TotalCost [ " + model.TotalCost + " ] eDate[ " + model.eDate + " ]");
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
        public int Delete(Models.MTransactionDetail model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CTransaction";
            try
            {
                var query = from o in obj.TransactionDetails where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.TransactionDetails.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] TrancactionId[" + model.TransactionId + "] ProductId[" + model.ProductId + "] FromWareHouseId[" + model.FormWareHouseId + "] ToWareHouseId[ " + model.ToWareHouseId + " ] TransactionQuantity [" + model.TransactionQuantity + " ] TransactionCost[ " + model.transactionCost + " ] TotalCost [ " + model.TotalCost + " ] eDate[ " + model.eDate + " ]");
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
        public List<Models.MTransactionDetail> GetAll()
        {
            List<Models.MTransactionDetail> model = new List<Models.MTransactionDetail>();
            var query = from o in obj.TransactionDetails select o;
            foreach (var item in query)
            {
                Models.MTransactionDetail m = new Models.MTransactionDetail();
                m.id = Convert.ToString(item.id);
                m.TransactionId = Convert.ToString(item.TransactionId);
                m.FormWareHouseId = Convert.ToString(item.FromWareHouseId);
                m.ToWareHouseId =Convert.ToString( item.ToWareHouseId);
                m.TransactionQuantity = item.TransactionQuantity;
                m.TotalCost = item.TotalCost;
                m.eDate = Convert.ToString(item.eDate);
                model.Add(m);
            }

            return model;
        }
        public List<Models.MTransactionDetail> GetAllbyid(int id)
        {
            List<Models.MTransactionDetail> model = new List<Models.MTransactionDetail>();
            var query = from o in obj.TransactionDetails where o.id == id select o;
            foreach (var item in query)
            {
                Models.MTransactionDetail m = new Models.MTransactionDetail();
                m.id =Convert.ToString( item.id);
                m.TransactionId =Convert.ToString( item.TransactionId);
                m.FormWareHouseId = Convert.ToString(item.FromWareHouseId);
                m.ToWareHouseId = Convert.ToString(item.ToWareHouseId);
                m.TransactionQuantity = item.TransactionQuantity;
                m.TotalCost = item.TotalCost;
                m.eDate =Convert.ToString( item.eDate);
                model.Add(m);
            }

            return model;
        }

    }
}