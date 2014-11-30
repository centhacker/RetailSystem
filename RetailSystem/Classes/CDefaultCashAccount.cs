using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CDefaultCashAccount
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        public int SaveDefaultAccounts(Models.MDefaultAccounts model, string AccountType)
        {
            try
            {
                var query = from o in obj.DefaultCashAccounts
                            where o.WareHouseId == Convert.ToInt32(model.WareHouseId)
                            select o;

                switch (AccountType)
                {

                    case "Purchase":
                        {

                            if (query.Count() == 0)
                            {
                                DB.DefaultCashAccount df = new DB.DefaultCashAccount();
                                df.DefaultPurchaseAccountId = Convert.ToInt32(model.DefaultPurchaseAccountId);
                                df.DefaultSalesAccountId = Convert.ToInt32(model.DefaultSaleAccountId);
                                df.WareHouseId = Convert.ToInt32(model.WareHouseId);
                                obj.DefaultCashAccounts.InsertOnSubmit(df);

                            }
                            else
                            {
                                foreach (var item in query)
                                {
                                    item.DefaultPurchaseAccountId = Convert.ToInt32(model.DefaultPurchaseAccountId);
                                }
                            }

                            obj.SubmitChanges();

                            return 1;

                        }
                    case "Sale":
                        {

                            if (query.Count() == 0)
                            {
                                DB.DefaultCashAccount df = new DB.DefaultCashAccount();
                                df.DefaultPurchaseAccountId = Convert.ToInt32(model.DefaultPurchaseAccountId);
                                df.DefaultSalesAccountId = Convert.ToInt32(model.DefaultSaleAccountId);
                                df.WareHouseId = Convert.ToInt32(model.WareHouseId);
                                obj.DefaultCashAccounts.InsertOnSubmit(df);

                            }
                            else
                            {
                                foreach (var item in query)
                                {
                                    item.DefaultSalesAccountId = Convert.ToInt32(model.DefaultSaleAccountId);
                                }
                            }

                            obj.SubmitChanges();
                            return 1;
                        }
                    default:
                        {
                            return -1;
                        }
                }
            }
            catch
            {

                return -1;
            }
        }

        public int ReturnPurchaseDefaultAccount(int WareHouseId)
        {
            try
            {
                int DefaultPurchaseAccountId = -1;
                var query = (from o in obj.DefaultCashAccounts
                             where o.WareHouseId == WareHouseId
                             select o.DefaultPurchaseAccountId).FirstOrDefault();
                DefaultPurchaseAccountId = Convert.ToInt32(query);
                return DefaultPurchaseAccountId;
            }
            catch
            {

                return -1;
            }
        }


        public int ReturnSaleDefaultAccount(int WareHouseId)
        {
            try
            {
                int DefaultSaleAccountId = -1;
                var query = (from o in obj.DefaultCashAccounts
                             where o.WareHouseId == WareHouseId
                             select o.DefaultSalesAccountId).FirstOrDefault();
                DefaultSaleAccountId = Convert.ToInt32(query);
                return DefaultSaleAccountId;
            }
            catch
            {

                return -1;
            }
        }
    }
}