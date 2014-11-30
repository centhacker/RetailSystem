using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class COrders
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public string GetOrderNameById(string orderId)
        {
            string OrderName = string.Empty;
            var query = (from o in obj.Orders
                         where o.id == Convert.ToInt32(orderId)
                         select o.OrderName).FirstOrDefault();
            if (query != null)
            {
                OrderName = query.ToString();
            }
            return OrderName;
        }


        public string ReturnOrderTypeById(int OrderId)
        {
            string OrderName = string.Empty;
            var query = (from o in obj.Orders
                         where o.id == Convert.ToInt32(OrderId)
                         select o).FirstOrDefault();
            if (query != null)
            {
                if (query.ClientId == -1)
                {
                    OrderName = "Vendor";
                }
                if (query.VendorId == -1)
                {
                    OrderName = "Client";
                }
            }
            return OrderName;
        }

        public int GetLastOrderID()
        {

            try
            {
                int OrderId = 0;
                var query = obj.Orders.OrderByDescending(u => u.id).FirstOrDefault();
                OrderId = Convert.ToInt32(query.id);
                return OrderId;
            }
            catch
            {

                return -1;
            }
        }

        public int Save(Models.MOrders model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "COrders";
            try
            {
                DB.Order bs = new DB.Order();
                //bs.id = Convert.ToInt32(model.id);
                bs.OrderNo = model.OrdersNo;
                bs.OrderName = model.OrderName;
                bs.OrderDescription = model.OrderDescription;
                bs.OrderDate = Convert.ToDateTime(model.Orderdate);
                bs.deliveryDate = Convert.ToDateTime(model.deliverydate);
                bs.TotalCost = model.TotalCost;
                bs.OrderType = model.OrderType;
                bs.ClientId = Convert.ToInt32(model.ClientId);
                bs.VendorId = Convert.ToInt32(model.venorld);
                bs.FiscalYearId = Convert.ToInt32(model.FiscalYearld);
                bs.eDate = Convert.ToDateTime(model.eDate);
                bs.WareHouseId = Convert.ToInt32(model.WareHouseId);
                bs.Installments = model.Installments;
                bs.InstallmentDueDate = model.InstallmentDueDate;
                bs.ModeOfPayment = model.ModeOfPayment;
                bs.GrantorName = model.GrantorName;
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] OrderNo[" + model.OrdersNo + "] OrderName[" + model.OrderName + "] Orderdescription[" + model.OrderDescription + "] OrderDate[ " + model.Orderdate + " ] DeliveryDate[ " + model.deliverydate + " ] TotalCost [ " + model.TotalCost + " ] OrdersType [ " + model.ClientId + "] VendoeId [ " + model.venorld + " ] FiscalId [ " + model.FiscalYearld + "] eDate [ " + model.eDate + " ]");
                obj.Orders.InsertOnSubmit(bs);
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

        public int Update(Models.MOrders model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "COrder";
            try
            {
                var query = from o in obj.Orders where Convert.ToString(o.id) == Convert.ToString(model.id) select o;

                foreach (var item in query)
                {
                    item.OrderNo = model.OrdersNo;
                    item.OrderName = model.OrderName;
                    item.OrderDescription = model.OrderDescription;
                    item.OrderDate = Convert.ToDateTime(model.Orderdate);
                    item.deliveryDate = Convert.ToDateTime(model.deliverydate);
                    item.TotalCost = model.TotalCost;
                    item.OrderType = model.OrderType;
                    item.ClientId = Convert.ToInt32(model.ClientId);
                    item.VendorId = Convert.ToInt32(model.venorld);
                    item.FiscalYearId = Convert.ToInt32(model.FiscalYearld);
                    item.eDate = Convert.ToDateTime(model.eDate);

                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] OrderNo[" + model.OrdersNo + "] OrderName[" + model.OrderName + "] Orderdescription[" + model.OrderDescription + "] OrderDate[ " + model.Orderdate + " ] DeliveryDate[ " + model.deliverydate + " ] TotalCost [ " + model.TotalCost + " ] OrdersType [ " + model.ClientId + "] VendoeId [ " + model.venorld + " ] FiscalId [ " + model.FiscalYearld + "] eDate [ " + model.eDate + " ]");
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
        public int Delete(Models.MOrders model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "COrder";
            try
            {
                var query = from o in obj.Orders where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Orders.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] OrderNo[" + model.OrdersNo + "] OrderName[" + model.OrderName + "] Orderdescription[" + model.OrderDescription + "] OrderDate[ " + model.Orderdate + " ] DeliveryDate[ " + model.deliverydate + " ] TotalCost [ " + model.TotalCost + " ] OrdersType [ " + model.ClientId + "] VendoeId [ " + model.venorld + " ] FiscalId [ " + model.FiscalYearld + "] eDate [ " + model.eDate + " ]");
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
        public List<Models.MOrders> GetAll()
        {
            List<Models.MOrders> model = new List<Models.MOrders>();
            var query = from o in obj.Orders select o;
            foreach (var item in query)
            {
                Models.MOrders m = new Models.MOrders();
                m.id = Convert.ToString(item.id);
                m.OrdersNo = item.OrderNo;
                m.OrderName = item.OrderName;
                m.OrderDescription = item.OrderDescription;
                m.Orderdate = Convert.ToString(item.OrderDate);
                m.deliverydate = Convert.ToString(item.deliveryDate);
                m.TotalCost = item.TotalCost;
                m.OrderType = item.OrderType;
                m.ClientId = Convert.ToString(item.ClientId);
                m.venorld = Convert.ToString(item.VendorId);
                m.FiscalYearld = Convert.ToString(item.FiscalYearId);
                m.eDate = Convert.ToString(item.eDate);
                m.InstallmentDueDate = item.InstallmentDueDate;
                m.Installments = item.Installments;
                m.ModeOfPayment = item.ModeOfPayment;
                m.WareHouseId = item.WareHouseId.ToString();
                m.GrantorName = item.GrantorName;
                model.Add(m);
            }

            return model;
        }
        public List<Models.MOrders> GetAllbyid(int id)
        {
            List<Models.MOrders> model = new List<Models.MOrders>();
            var query = from o in obj.Orders where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MOrders m = new Models.MOrders();
                m.id = Convert.ToString(item.id);
                m.OrdersNo = item.OrderNo;
                m.OrderName = item.OrderName;
                m.OrderDescription = item.OrderDescription;
                m.Orderdate = Convert.ToString(item.OrderDate);
                m.deliverydate = Convert.ToString(item.deliveryDate);
                m.TotalCost = item.TotalCost;
                m.OrderType = item.OrderType;
                m.ClientId = Convert.ToString(item.ClientId);
                m.venorld = Convert.ToString(item.VendorId);
                m.FiscalYearld = Convert.ToString(item.FiscalYearId);
                m.eDate = Convert.ToString(item.eDate);
                model.Add(m);
            }

            return model;
        }


    }
}