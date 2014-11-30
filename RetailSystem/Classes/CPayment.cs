using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CPayment
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        public int Save(Models.MPayments model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPayment";
            try
            {

                DB.Payment bs = new DB.Payment();
                bs.ClientId = Convert.ToInt32(model.ClientId);
                bs.VendorId = model.VendorId;
                bs.OrderId = model.OrderId;
                bs.TransactionId = model.TransactionId;
                bs.Paid = model.Paid;
                bs.TotalCost = model.TotalCost;
                bs.PaymentType = model.PaymentType;
                bs.PaymentState = model.Paymentstate;
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ClientId[" + model.ClientId + "] VendorId[" + model.VendorId + "] OrderId[" + model.OrderId + "] TransactionId [ " + model.TransactionId + "] Paid [ " + model.Paid + " ]  PaymentType[ " + model.PaymentType + " ] PaymentState [ " + model.Paymentstate + " ]");
                obj.Payments.InsertOnSubmit(bs);
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


        public int UpdateAmountPaid(int PaymentId, string AmountPaid)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPayment";
            try
            {
                var query = from o in obj.Payments where o.id == PaymentId select o;

                foreach (var item in query)
                {
                    item.Paid = AmountPaid;
                    if (item.Paid == item.TotalCost)
                    {
                        item.PaymentState = Common.Constants.PaymentState.Paid.ToString();
                    }
                }
                //l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ClientId[" + model.ClientId + "] VendorId[" + model.VendorId + "] OrderId[" + model.OrderId + "] TransactionId [ " + model.TransactionId + "] Paid [ " + model.Paid + " ]  PaymentType[ " + model.PaymentType + " ] PaymentState [ " + model.Paymentstate + " ]");
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

        public List<Models.MOrderViewOfPayment> ShowClientOrderViewForPayment()
        {
            COrders co = new COrders();
            COrderOnline col = new COrderOnline();
            CClients cc = new CClients();
            List<Models.MOrderViewOfPayment> ClientPayments = new List<Models.MOrderViewOfPayment>();
            List<Models.MPayments> Payments = this.GetAll();
            List<Models.MOrders> Orders = co.GetAll();

            List<Models.MOrdersLine> OrderLine = col.GetAll();

            var query = from o in Payments
                        where o.OrderId != 0
                        && o.VendorId == -1
                        && o.ClientId != -1
                        && o.Paymentstate != Common.Constants.PaymentState.Paid.ToString()
                        select o;

            foreach (var item in query)
            {
                Models.MOrderViewOfPayment mop = new Models.MOrderViewOfPayment();
                mop.PaymentId = item.id.ToString();
                mop.ClientId = item.ClientId.ToString();
                string clientName = cc.ReturnClientNameById(mop.ClientId);
                string OrderId = item.OrderId.ToString();
                mop.OrderId = item.OrderId.ToString();
                string OrderDate = (from o in Orders
                                    where o.id == OrderId
                                    select o.Orderdate).FirstOrDefault();
                mop.OrderDate = OrderDate;
                mop.OrderName = (from o in Orders
                                 where o.id == OrderId
                                 select o.OrderName).FirstOrDefault();
                mop.OrderCode = (from o in Orders
                                 where o.id == OrderId
                                 select o.OrdersNo).FirstOrDefault();
                mop.PaidAmount = item.Paid;
                mop.TotalCost = item.TotalCost;
                mop.ClientName = clientName;
                ClientPayments.Add(mop);
            }

            return ClientPayments;
        }

        public List<Models.MOrderViewOfPayment> ShowClientOrderViewForPayment(int ClientId)
        {
            COrders co = new COrders();
            COrderOnline col = new COrderOnline();
            CClients cc = new CClients();
            List<Models.MOrderViewOfPayment> ClientPayments = new List<Models.MOrderViewOfPayment>();
            List<Models.MPayments> Payments = this.GetAll();
            List<Models.MOrders> Orders = co.GetAll();

            List<Models.MOrdersLine> OrderLine = col.GetAll();

            var query = from o in Payments
                        where o.OrderId != 0
                        && o.VendorId == -1
                        && o.ClientId == ClientId
                        && o.Paymentstate != Common.Constants.PaymentState.Paid.ToString()
                        select o;

            foreach (var item in query)
            {
                Models.MOrderViewOfPayment mop = new Models.MOrderViewOfPayment();
                mop.PaymentId = item.id.ToString();
                mop.ClientId = item.ClientId.ToString();
                string clientName = cc.ReturnClientNameById(mop.ClientId);
                string OrderId = item.OrderId.ToString();
                mop.OrderId = item.OrderId.ToString();
                string OrderDate = (from o in Orders
                                    where o.id == OrderId
                                    select o.Orderdate).FirstOrDefault();
                mop.OrderDate = OrderDate;
                mop.OrderName = (from o in Orders
                                 where o.id == OrderId
                                 select o.OrderName).FirstOrDefault();
                mop.OrderCode = (from o in Orders
                                 where o.id == OrderId
                                 select o.OrdersNo).FirstOrDefault();
                mop.PaidAmount = item.Paid;
                mop.TotalCost = item.TotalCost;
                mop.ClientName = clientName;
                ClientPayments.Add(mop);
            }

            return ClientPayments;
        }

        public List<Models.MOrderViewOfPayment> ShowVendorOrderViewForPayment()
        {
            COrders co = new COrders();
            COrderOnline col = new COrderOnline();
            CVendor cv = new CVendor();
            List<Models.MOrderViewOfPayment> VendorPayments = new List<Models.MOrderViewOfPayment>();
            List<Models.MPayments> Payments = this.GetAll();
            List<Models.MOrders> Orders = co.GetAll();

            List<Models.MOrdersLine> OrderLine = col.GetAll();

            var query = from o in Payments
                        where o.OrderId != 0
                        && o.ClientId == -1
                        && o.VendorId != -1
                        && o.Paymentstate != Common.Constants.PaymentState.Paid.ToString()
                        select o;

            foreach (var item in query)
            {
                Models.MOrderViewOfPayment mop = new Models.MOrderViewOfPayment();
                mop.PaymentId = item.id.ToString();
                mop.VendorId = item.VendorId.ToString();
                string vendorName = cv.GetVendorNameById(mop.VendorId);
                string OrderId = item.OrderId.ToString();
                mop.OrderId = item.OrderId.ToString();
                string OrderDate = (from o in Orders
                                    where o.id == OrderId
                                    select o.Orderdate).FirstOrDefault();
                mop.OrderDate = OrderDate;
                mop.OrderName = (from o in Orders
                                 where o.id == OrderId
                                 select o.OrderName).FirstOrDefault();
                mop.OrderCode = (from o in Orders
                                 where o.id == OrderId
                                 select o.OrdersNo).FirstOrDefault();
                mop.PaidAmount = item.Paid;
                mop.TotalCost = item.TotalCost;
                mop.VendorName = vendorName;
                VendorPayments.Add(mop);
            }

            return VendorPayments;
        }

        public List<Models.MOrderViewOfPayment> ShowVendorOrderViewForPayment(int VendorId)
        {
            COrders co = new COrders();
            COrderOnline col = new COrderOnline();
            CVendor cv = new CVendor();
            List<Models.MOrderViewOfPayment> VendorPayments = new List<Models.MOrderViewOfPayment>();
            List<Models.MPayments> Payments = this.GetAll();
            List<Models.MOrders> Orders = co.GetAll();

            List<Models.MOrdersLine> OrderLine = col.GetAll();

            var query = from o in Payments
                        where o.OrderId != 0
                        && o.ClientId == -1
                        && o.VendorId == VendorId
                        && o.Paymentstate != Common.Constants.PaymentState.Paid.ToString()
                        select o;

            foreach (var item in query)
            {
                Models.MOrderViewOfPayment mop = new Models.MOrderViewOfPayment();
                mop.PaymentId = item.id.ToString();
                mop.VendorId = item.VendorId.ToString();
                string vendorName = cv.GetVendorNameById(mop.VendorId);
                string OrderId = item.OrderId.ToString();
                mop.OrderId = item.OrderId.ToString();
                string OrderDate = (from o in Orders
                                    where o.id == OrderId
                                    select o.Orderdate).FirstOrDefault();
                mop.OrderDate = OrderDate;
                mop.OrderName = (from o in Orders
                                 where o.id == OrderId
                                 select o.OrderName).FirstOrDefault();
                mop.OrderCode = (from o in Orders
                                 where o.id == OrderId
                                 select o.OrdersNo).FirstOrDefault();
                mop.PaidAmount = item.Paid;
                mop.TotalCost = item.TotalCost;
                mop.VendorName = vendorName;
                VendorPayments.Add(mop);
            }

            return VendorPayments;
        }

        public int ReturnLastPaymentId()
        {
            int PaymentId = -1;
            var query = obj.Payments.OrderByDescending(u => u.id).FirstOrDefault();
            if (query != null)
            {
                PaymentId = Convert.ToInt32(query.id);
                return PaymentId;
            }
            else
            {
                return PaymentId;
            }
        }
        public int Update(Models.MPayments model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPayment";
            try
            {
                var query = from o in obj.Payments where o.id == model.id select o;

                foreach (var item in query)
                {
                    item.ClientId = model.ClientId;
                    item.VendorId = model.VendorId;
                    item.OrderId = model.OrderId;
                    item.TransactionId = model.TransactionId;
                    item.Paid = model.Paid;
                    item.PaymentType = model.PaymentType;
                    item.PaymentState = model.Paymentstate;
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ClientId[" + model.ClientId + "] VendorId[" + model.VendorId + "] OrderId[" + model.OrderId + "] TransactionId [ " + model.TransactionId + "] Paid [ " + model.Paid + " ]  PaymentType[ " + model.PaymentType + " ] PaymentState [ " + model.Paymentstate + " ]");
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
        public int Delete(Models.MPayments model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPayments";
            try
            {
                var query = from o in obj.Payments where o.id == model.id select o;
                foreach (var item in query)
                {
                    obj.Payments.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ClientId[" + model.ClientId + "] VendorId[" + model.VendorId + "] OrderId[" + model.OrderId + "] TransactionId [ " + model.TransactionId + "] Paid [ " + model.Paid + " ]  PaymentType[ " + model.PaymentType + " ] PaymentState [ " + model.Paymentstate + " ]");
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
        public List<Models.MPayments> GetAll()
        {
            List<Models.MPayments> model = new List<Models.MPayments>();
            var query = from o in obj.Payments select o;
            foreach (var item in query)
            {
                Models.MPayments m = new Models.MPayments();
                m.id = Convert.ToInt32(item.id);
                m.ClientId = Convert.ToInt32(item.ClientId);
                m.VendorId = Convert.ToInt32(item.VendorId);
                m.OrderId = Convert.ToInt32(item.OrderId);
                m.TransactionId = Convert.ToInt32(item.TransactionId);
                m.Paid = item.Paid;
                m.TotalCost = item.TotalCost;
                m.PaymentType = item.PaymentType;
                m.Paymentstate = item.PaymentState;


                model.Add(m);
            }

            return model;
        }
        public List<Models.MPayments> GetAllbyid(int id)
        {
            List<Models.MPayments> model = new List<Models.MPayments>();
            var query = from o in obj.Payments where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MPayments m = new Models.MPayments();
                m.id = Convert.ToInt32(item.id);
                m.ClientId = Convert.ToInt32(item.ClientId);
                m.VendorId = Convert.ToInt32(item.VendorId);
                m.OrderId = Convert.ToInt32(item.OrderId);
                m.TransactionId = Convert.ToInt32(item.TransactionId);
                m.Paid = item.Paid;
                m.Paymentstate = item.PaymentState;
                m.PaymentType = item.PaymentType;
                model.Add(m);
            }

            return model;
        }




    }



}