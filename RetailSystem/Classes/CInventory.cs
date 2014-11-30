using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CInventory
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();



        public int Save(Models.MInventory model, Common.Constants.SaleTransactions transaction)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInventory";
            try
            {
                string totalUnitsofProducts = string.Empty;
                DB.Inventory bs = new DB.Inventory();
                DB.InventoryBalance iv = new DB.InventoryBalance();
                switch (transaction)
                {
                    #region Addition Indentory
                    case Common.Constants.SaleTransactions.Addition:
                        {
                            #region Updating Inventory
                            var query = (from o in obj.Inventories
                                         where Convert.ToInt32(model.WareHouseld) == o.WareHouseId
                                             && o.ProductId == Convert.ToInt32(model.ProductId)
                                             && o.Cost == model.Cost
                                         select o.Quantity).FirstOrDefault();

                            if (query == null)
                            {
                                totalUnitsofProducts = model.Quantity;
                                //Inventory
                                bs.ProductId = int.Parse(model.ProductId);
                                bs.WareHouseId = int.Parse(model.WareHouseld);
                                bs.Cost = model.Cost;
                                bs.date = model.Date;
                                bs.Quantity = totalUnitsofProducts;
                                bs.FiscalYearId = int.Parse(model.FiscalYearld);
                                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ProductId[" + model.ProductId + "] WareHouseId[" + model.WareHouseld + "] Cost[" + model.Cost + "] Quantity[ " + model.Cost + "] FiscalYearId[ " + model.FiscalYearld + " ] ");
                                obj.Inventories.InsertOnSubmit(bs);
                                obj.SubmitChanges();
                                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Inserted Successfully");



                            }
                            else
                            {
                                totalUnitsofProducts = query;
                                float Quantity = 0;
                                Quantity = Convert.ToSingle(totalUnitsofProducts)
                                    + Convert.ToSingle(model.Quantity);
                                var Data = (from o in obj.Inventories
                                            where Convert.ToInt32(model.WareHouseld) == o.WareHouseId
                                                && o.ProductId == Convert.ToInt32(model.ProductId)
                                                && o.Cost == model.Cost
                                            select o);
                                foreach (var item in Data)
                                {
                                    item.ProductId = Convert.ToInt32(model.ProductId);
                                    item.Quantity = Convert.ToString(Quantity);
                                    item.Cost = model.Cost;
                                    item.WareHouseId = Convert.ToInt32(model.WareHouseld);
                                    item.date = model.Date;

                                }


                                obj.SubmitChanges();
                            }
                            #endregion

                            #region updating Inventory Balance
                            var invenotryBalance = (from o in obj.InventoryBalances
                                                    where o.ProductsId == Convert.ToInt32(model.ProductId) &&
                                                    o.WarehouseId == Convert.ToInt32(model.WareHouseld)
                                                    orderby o.id ascending
                                                    select o);
                            if (!invenotryBalance.Any())
                            {
                                iv.Date = Convert.ToDateTime(model.Date);
                                iv.ProductsId = Convert.ToInt32(model.ProductId);
                                iv.WarehouseId = Convert.ToInt32(model.WareHouseld);
                                iv.PurchaseUnitsCost = model.Cost;
                                iv.PurchaseUnits = model.Quantity;
                                float PurchaseTotal = Convert.ToSingle(Convert.ToSingle(model.Cost) * Convert.ToSingle(model.Quantity));
                                iv.PurchaseTotal = PurchaseTotal.ToString();
                                iv.BalanceUnitsCost = model.Cost;
                                iv.BalanceUnits = model.Quantity;
                                iv.BalanceTotal = PurchaseTotal.ToString();
                                obj.InventoryBalances.InsertOnSubmit(iv);
                                obj.SubmitChanges();

                            }
                            else
                            {
                                float oldUnits = 0, oldCost = 0, oldTotal = 0,
                                    newTotal = 0, newUnits = 0, newCost = 0;
                                foreach (var item in invenotryBalance)
                                {
                                    oldUnits = Convert.ToSingle(item.BalanceUnits);
                                    oldCost = Convert.ToSingle(item.BalanceUnitsCost);
                                    oldTotal = Convert.ToSingle(item.BalanceTotal);
                                    newUnits = oldUnits + Convert.ToSingle(model.Quantity);
                                    newCost = Convert.ToSingle(model.Cost);
                                    newTotal = Convert.ToSingle(newUnits * newCost);

                                }
                                iv.Date = Convert.ToDateTime(model.Date);
                                iv.ProductsId = Convert.ToInt32(model.ProductId);
                                iv.WarehouseId = Convert.ToInt32(model.WareHouseld);
                                iv.PurchaseUnitsCost = model.Cost;
                                iv.PurchaseUnits = model.Quantity;
                                float PurchaseTotal = Convert.ToSingle(Convert.ToSingle(model.Cost) * Convert.ToSingle(model.Quantity));
                                iv.PurchaseTotal = PurchaseTotal.ToString();
                                iv.BalanceUnitsCost = newCost.ToString();
                                iv.BalanceUnits = newUnits.ToString();
                                iv.BalanceTotal = newTotal.ToString();
                                obj.InventoryBalances.InsertOnSubmit(iv);
                                obj.SubmitChanges();

                            }


                            #endregion

                            break;
                        }
                    #endregion

                    #region Deduction Indentory

                    case Common.Constants.SaleTransactions.Deduction:
                        {
                            #region Updating Inventory
                            var query = (from o in obj.Inventories
                                         where Convert.ToInt32(model.WareHouseld) == o.WareHouseId
                                             && o.ProductId == Convert.ToInt32(model.ProductId)
                                             && o.Cost == model.Cost
                                         orderby o.date
                                         select o.Quantity).FirstOrDefault();
                            if (query == null)
                            {
                                return 0;
                            }
                            else
                            {
                                totalUnitsofProducts = query;
                                float Quantity = 0;
                                Quantity = Convert.ToSingle(totalUnitsofProducts)
                                    - Convert.ToSingle(model.Quantity);
                                if (Quantity < 0)
                                {
                                    //Quantity not found in warehouse/Invenotry
                                    return 0;
                                }

                                var Data = (from o in obj.Inventories
                                            where Convert.ToInt32(model.WareHouseld) == o.WareHouseId
                                                 && o.ProductId == Convert.ToInt32(model.ProductId)
                                                && model.Cost == model.Cost
                                            select o);
                                foreach (var item in Data)
                                {
                                    item.ProductId = Convert.ToInt32(model.ProductId);
                                    item.Quantity = Convert.ToString(Quantity);
                                    item.Cost = model.Cost;
                                    item.WareHouseId = Convert.ToInt32(model.WareHouseld);
                                    bs.date = model.Date;

                                }

                                obj.SubmitChanges();



                            }
                            #endregion

                            #region Updating Inventory Balance
                            var invenotryBalance = (from o in obj.InventoryBalances
                                                    where o.ProductsId == Convert.ToInt32(model.ProductId) &&
                                                    o.WarehouseId == Convert.ToInt32(model.WareHouseld)
                                                    orderby o.id ascending
                                                    select o);
                            if (!invenotryBalance.Any())
                            {
                                iv.Date = Convert.ToDateTime(model.Date);
                                iv.ProductsId = Convert.ToInt32(model.ProductId);
                                iv.WarehouseId = Convert.ToInt32(model.WareHouseld);
                                iv.SaleUnitsCost = model.Cost;
                                iv.SaleUnits = model.Quantity;
                                float PurchaseTotal = Convert.ToSingle(Convert.ToSingle(model.Cost) * Convert.ToSingle(model.Quantity));
                                iv.SaleTotal = PurchaseTotal.ToString();
                                iv.BalanceUnitsCost = model.Cost;
                                iv.BalanceUnits = model.Quantity;
                                iv.BalanceTotal = PurchaseTotal.ToString();
                                obj.InventoryBalances.InsertOnSubmit(iv);
                                obj.SubmitChanges();

                            }
                            else
                            {
                                float oldUnits = 0, oldCost = 0, oldTotal = 0,
                                    newTotal = 0, newUnits = 0, newCost = 0;
                                foreach (var item in invenotryBalance)
                                {
                                    oldUnits = Convert.ToSingle(item.BalanceUnits);
                                    oldCost = Convert.ToSingle(item.BalanceUnitsCost);
                                    oldTotal = Convert.ToSingle(item.BalanceTotal);
                                    newUnits = oldUnits - Convert.ToSingle(model.Quantity);
                                    newCost = Convert.ToSingle(model.Cost);
                                    newTotal = Convert.ToSingle(newUnits * newCost);

                                }
                                iv.Date = Convert.ToDateTime(model.Date);
                                iv.ProductsId = Convert.ToInt32(model.ProductId);
                                iv.WarehouseId = Convert.ToInt32(model.WareHouseld);
                                iv.SaleUnitsCost = model.Cost;
                                iv.SaleUnits = model.Quantity;
                                float PurchaseTotal = Convert.ToSingle(Convert.ToSingle(model.Cost) * Convert.ToSingle(model.Quantity));
                                iv.SaleTotal = PurchaseTotal.ToString();
                                iv.BalanceUnitsCost = newCost.ToString();
                                iv.BalanceUnits = newUnits.ToString();
                                iv.BalanceTotal = newTotal.ToString();
                                obj.InventoryBalances.InsertOnSubmit(iv);
                                obj.SubmitChanges();

                            }


                            #endregion

                            break;
                        }

                    #endregion

                    #region Transfer Inventory
                    case Common.Constants.SaleTransactions.Transfer:
                        {

                            break;
                        }

                    #endregion

                    default:
                        {
                            totalUnitsofProducts = "0";
                            break;
                        }
                }




                return 1;


            }
            catch (Exception ex)
            {
                l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
                return -1;
            }
        }

        public List<Models.MInventory> GetInventoryData()
        {
            List<Models.MInventory> Data = new List<Models.MInventory>();
            var query = from o in obj.Inventories orderby o.WareHouseId ascending select o;
            if (query != null)
            {
                foreach (var item in query)
                {
                    Models.MInventory mi = new Models.MInventory();
                    string Get = string.Empty;
                    string WareHouseName = string.Empty;
                    Classes.CProducts cp = new CProducts();
                    Classes.CWareHouse cw = new CWareHouse();
                    Get = cp.GetProductNameWithTagsById(Convert.ToInt32(item.ProductId));
                    WareHouseName = cw.GetWareHouseNameById(Convert.ToInt32(item.WareHouseId));
                    string[] ProductDetails = Get.Split('-');
                    mi.ProductCode = ProductDetails[0];
                    mi.ProductName = ProductDetails[1];
                    mi.ProducyTag1 = ProductDetails[2];
                    mi.ProductTag2 = ProductDetails[3];
                    mi.ProductId = item.ProductId.ToString();
                    mi.WareHouseld = item.WareHouseId.ToString();
                    mi.WareHouseName = WareHouseName;
                    mi.Cost = item.Cost;
                    mi.Quantity = item.Quantity;
                    mi.TotalCost = Convert.ToSingle(Convert.ToSingle(item.Cost) * Convert.ToSingle(item.Quantity));
                    Data.Add(mi);
                }
            }


            return Data;

        }
        public List<Models.MInventoryBalance> GetInventoryBalance(DateTime fromDate, DateTime toDate)
        {
            List<Models.MInventoryBalance> Data = new List<Models.MInventoryBalance>();
            var query = from o in obj.InventoryBalances
                        where o.Date >= fromDate && o.Date <= toDate
                        select o;
            Classes.CProducts cp = new CProducts();
            Classes.CWareHouse cw = new CWareHouse();
            foreach (var item in query)
            {
                Models.MInventoryBalance mib = new Models.MInventoryBalance();
                string ProductName = string.Empty;
                string WarehouseName = string.Empty;
                ProductName = cp.GetProductNameWithTagsById(Convert.ToInt32(item.ProductsId));
                mib.WareHouseId = Convert.ToInt32(item.WarehouseId.ToString());
                WarehouseName = cw.GetWareHouseNameById(Convert.ToInt32(item.WarehouseId));
                mib.BalanceTotal = item.BalanceTotal;
                mib.BalanceUnits = item.BalanceUnits;
                mib.BalanceUnitsCost = item.BalanceUnitsCost;
                mib.date = Convert.ToDateTime(item.Date);
                mib.ProductName = ProductName;
                mib.PurchaseTotal = item.PurchaseTotal;
                mib.PurchaseUnits = item.PurchaseUnits;
                mib.PurchaseUnitsCost = item.PurchaseUnitsCost;
                mib.SaleTotal = item.SaleTotal;
                mib.SaleUnits = item.SaleUnits;
                mib.SaleUnitsCost = item.SaleUnitsCost;
                mib.WareHouseName = WarehouseName;
                Data.Add(mib);


            }

            return Data;
        }
        public int Update(Models.MInventory model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInventory";
            try
            {
                var query = from o in obj.Inventories where Convert.ToString(o.id) == Convert.ToString(model.id) select o;

                foreach (var item in query)
                {
                    item.ProductId = int.Parse(model.ProductId);
                    item.WareHouseId = int.Parse(model.WareHouseld);
                    item.Cost = model.Cost;
                    item.Quantity = model.Quantity;
                    item.FiscalYearId = int.Parse(model.FiscalYearld);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ProductId[" + model.ProductId + "] WareHouseId[" + model.WareHouseld + "] Cost[" + model.Cost + "] Quantity[ " + model.Cost + "] FiscalYearId[ " + model.FiscalYearld + " ] ");
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
        public int Delete(Models.MInventory model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CInventory";
            try
            {
                var query = from o in obj.Inventories where Convert.ToString(o.id) == Convert.ToString(model.id) select o;
                foreach (var item in query)
                {
                    obj.Inventories.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] ProductId[" + model.ProductId + "] WareHouseId[" + model.WareHouseld + "] Cost[" + model.Cost + "] Quantity[ " + model.Cost + "] FiscalYearId[ " + model.FiscalYearld + " ] ");
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
        public List<Models.MInventory> GetAll()
        {
            List<Models.MInventory> model = new List<Models.MInventory>();
            var query = from o in obj.Inventories select o;
            foreach (var item in query)
            {
                Models.MInventory m = new Models.MInventory();
                m.id = Convert.ToString(item.id);
                m.ProductId = Convert.ToString(item.ProductId);
                m.WareHouseld = Convert.ToString(item.WareHouseId);
                m.Cost = item.Cost;
                m.Quantity = item.Quantity;
                m.FiscalYearld = Convert.ToString(item.FiscalYearId);
                model.Add(m);
            }

            return model;
        }
        public List<Models.MInventory> GetAllbyid(int id)
        {
            List<Models.MInventory> model = new List<Models.MInventory>();
            var query = from o in obj.Inventories where Convert.ToString(o.id) == Convert.ToString(id) select o;
            foreach (var item in query)
            {

                Models.MInventory m = new Models.MInventory();
                m.id = Convert.ToString(item.id);
                m.ProductId = Convert.ToString(item.ProductId);
                m.WareHouseld = Convert.ToString(item.WareHouseId);
                m.Cost = item.Cost;
                m.Quantity = item.Quantity;
                m.FiscalYearld = Convert.ToString(item.FiscalYearId);
                model.Add(m);
            }

            return model;
        }
        public string CheckInventory(int ProductId, int Units, int WarehouseId)
        {
            var query = (from o in obj.Inventories
                         where
                             o.ProductId == ProductId && o.WareHouseId == WarehouseId
                         select o.Quantity).FirstOrDefault();
            if (query != null)
            {
                if (Convert.ToInt32(query) < Units)
                {
                    return "Not Equal Inventory Has [" + query + "] units ";
                }
                else
                {
                    return "Successfull";
                }
            }
            else
            {
                return "Inventory Not found for the ";
            }

        }





    }
}