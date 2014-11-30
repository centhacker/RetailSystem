using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CSaleTransations
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int GetLastTransactionId()
        {
            var query = obj.Transaction1s.OrderByDescending(u => u.id).FirstOrDefault();
            return Convert.ToInt32(query.id);

        }

        public int GetIdByOrderId(int orderID)
        {
            try
            {
                int TransactionId = 0;
                var query = (from o in obj.Transaction1s
                             orderby o.id descending
                             where o.OrderId == Convert.ToInt32(orderID)
                             select o.id).FirstOrDefault();
                TransactionId = Convert.ToInt32(query);
                return TransactionId;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public int Save(Models.MSaleTransactions model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CSaleTransaction";
            try
            {

                DB.Transaction1 bs = new DB.Transaction1();
                bs.id = Convert.ToInt32(model.id);
                bs.ProductID = Convert.ToInt32(model.ProductID);
                bs.CostPrice = model.CostPrice;
                bs.SalePrice = model.SalePrice;
                bs.units = model.units;
                bs.TransactionType = model.transactionType;
                bs.VendorID = model.VendorID;
                bs.ClientID = model.clientID;
                bs.OrderId = Convert.ToInt32(model.OrderId);
                bs.WareHouseId = Convert.ToInt32(model.WareHouseId);
                bs.date = model.date;

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ProductID[" + model.ProductID + "] CostPrice[" + model.CostPrice + "] SalePrice[" + model.SalePrice + "] units [ " + model.units + "] TransactionType [ " + model.transactionType + " ]  ClientID [ " + model.clientID + " ] VendorID [ " + model.VendorID + " ] date [ " + model.date + " ]");
                obj.Transaction1s.InsertOnSubmit(bs);
                obj.SubmitChanges();


                if (model.transactionType == Common.Constants.SaleTransactions.Addition.ToString())
                {
                    Classes.CJournal cj = new CJournal();
                    DB.Journal j = new DB.Journal();
                    j.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.MerchandiseInventory);
                    j.amount = Convert.ToSingle(Convert.ToSingle(bs.CostPrice) * Convert.ToSingle(bs.units)) - Convert.ToSingle(model.Discount);
                    j.des = "Purchased Inventory [" + bs.units + "] ";
                    j.e_date = Convert.ToDateTime(model.date);
                    j.type = Common.Constants.Accounts.Type.Debit.ToString();
                    obj.Journals.InsertOnSubmit(j);
                    obj.SubmitChanges();

                    if (Convert.ToSingle(model.Discount) > 0)
                    {
                        j = new DB.Journal();
                        j.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.PurchaseDiscount);
                        j.amount = Convert.ToSingle(model.Discount);
                        j.des = "Purchased Inventory Discount [" + bs.units + "] ";
                        j.e_date = Convert.ToDateTime(model.date);
                        j.type = Common.Constants.Accounts.Type.Debit.ToString();
                        obj.Journals.InsertOnSubmit(j);
                        obj.SubmitChanges();
                    }


                    j = new DB.Journal();
                    j.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.Cash);
                    j.amount = Convert.ToSingle(Convert.ToSingle(bs.CostPrice) * Convert.ToSingle(bs.units));
                    j.des = "Purchased Inventory [" + bs.units + "] ";
                    j.e_date = Convert.ToDateTime(model.date);
                    j.type = Common.Constants.Accounts.Type.Credit.ToString();
                    obj.Journals.InsertOnSubmit(j);
                    obj.SubmitChanges();

                   


                }
                else if (model.transactionType == Common.Constants.SaleTransactions.Deduction.ToString())
                {
                    Classes.CJournal cj = new CJournal();
                    DB.Journal j = new DB.Journal();
                    j.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.Cash);
                    j.amount = Convert.ToSingle(Convert.ToSingle(bs.CostPrice) * Convert.ToSingle(bs.units)) - Convert.ToSingle(model.Discount);
                    j.des = "Sold Inventory [" + bs.units + "] ";
                    j.e_date = Convert.ToDateTime(model.date);
                    j.type = Common.Constants.Accounts.Type.Debit.ToString();
                    obj.Journals.InsertOnSubmit(j);
                    obj.SubmitChanges();

                    if (Convert.ToSingle(model.Discount) > 0)
                    {
                        j = new DB.Journal();
                        j.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.SalesDiscount);
                        j.amount = Convert.ToSingle(model.Discount);
                        j.des = "Sold Inventory Discount [" + bs.units + "] ";
                        j.e_date = Convert.ToDateTime(model.date);
                        j.type = Common.Constants.Accounts.Type.Debit.ToString();
                        obj.Journals.InsertOnSubmit(j);
                        obj.SubmitChanges();
                    }


                    j = new DB.Journal();
                    j.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.Sales);
                    j.amount = Convert.ToSingle(Convert.ToSingle(bs.CostPrice) * Convert.ToSingle(bs.units));
                    j.des = "Sold Inventory [" + bs.units + "] ";
                    j.e_date = Convert.ToDateTime(model.date);
                    j.type = Common.Constants.Accounts.Type.Credit.ToString();
                    obj.Journals.InsertOnSubmit(j);
                    obj.SubmitChanges();

                    

                    cj = new CJournal();
                    j = new DB.Journal();
                    j.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.CostOfGoodsSold);
                    j.amount = Convert.ToSingle(Convert.ToSingle(bs.CostPrice) * Convert.ToSingle(bs.units));
                    j.des = "Sold Inventory [" + bs.units + "] ";
                    j.e_date = Convert.ToDateTime(model.date);
                    j.type = Common.Constants.Accounts.Type.Debit.ToString();
                    obj.Journals.InsertOnSubmit(j);
                    obj.SubmitChanges();

                    j = new DB.Journal();
                    j.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.MerchandiseInventory);
                    j.amount = Convert.ToSingle(Convert.ToSingle(bs.CostPrice) * Convert.ToSingle(bs.units));
                    j.des = "Sold Inventory [" + bs.units + "] ";
                    j.e_date = Convert.ToDateTime(model.date);
                    j.type = Common.Constants.Accounts.Type.Credit.ToString();
                    obj.Journals.InsertOnSubmit(j);
                    obj.SubmitChanges();




                }


                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Inserted Successfully");
                return 1;
            }
            catch (Exception ex)
            {
                l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
                return -1;
            }
        }
        public int Update(Models.MSaleTransactions model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CSaleTransaction";
            try
            {
                var query = from o in obj.Transaction1s where o.id == model.id select o;

                foreach (var item in query)
                {
                    item.ProductID = Convert.ToInt32(model.ProductID);
                    item.CostPrice = model.CostPrice;
                    item.SalePrice = model.SalePrice;
                    item.units = model.units;
                    item.TransactionType = model.transactionType;
                    item.ClientID = model.clientID;
                    item.VendorID = model.VendorID;
                    item.date = model.date;
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ProductID[" + model.ProductID + "] CostPrice[" + model.CostPrice + "] SalePrice[" + model.SalePrice + "] units [ " + model.units + "] TransactionType [ " + model.transactionType + " ]  ClientID [ " + model.clientID + " ] VendorID [ " + model.VendorID + " ] date [ " + model.date + " ]");
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
        public int Delete(Models.MSaleTransactions model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CSaleTransaction";
            try
            {
                var query = from o in obj.Transaction1s where o.id == model.id select o;
                foreach (var item in query)
                {
                    obj.Transaction1s.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ProductID[" + model.ProductID + "] CostPrice[" + model.CostPrice + "] SalePrice[" + model.SalePrice + "] units [ " + model.units + "] TransactionType [ " + model.transactionType + " ]  ClientID [ " + model.clientID + " ] VendorID [ " + model.VendorID + " ] date [ " + model.date + " ]");
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
        public List<Models.MSaleTransactions> GetAll()
        {
            List<Models.MSaleTransactions> model = new List<Models.MSaleTransactions>();
            var query = from o in obj.Transaction1s select o;
            foreach (var item in query)
            {
                Models.MSaleTransactions m = new Models.MSaleTransactions();
                m.id = item.id;
                m.ProductID = Convert.ToString(item.ProductID);
                m.CostPrice = item.CostPrice;
                m.SalePrice = item.SalePrice;
                m.units = item.units;
                m.transactionType = item.TransactionType;
                m.clientID = item.VendorID;
                m.date = Convert.ToDateTime(item.date);
                m.OrderId = item.OrderId.ToString();
                m.WareHouseId = item.WareHouseId.ToString();
                model.Add(m);
            }

            return model;
        }
        public List<Models.MSaleTransactions> GetAllbyid(int id)
        {
            List<Models.MSaleTransactions> model = new List<Models.MSaleTransactions>();
            var query = from o in obj.Transaction1s where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MSaleTransactions m = new Models.MSaleTransactions();
                m.id = item.id;
                m.ProductID = Convert.ToString(item.ProductID);
                m.CostPrice = item.CostPrice;
                m.SalePrice = item.SalePrice;
                m.units = item.units;
                m.transactionType = item.TransactionType;
                m.clientID = item.VendorID;
                m.date = Convert.ToDateTime(item.date);
                model.Add(m);
            }

            return model;
        }
    }
}