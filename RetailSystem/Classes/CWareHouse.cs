using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CWareHouse
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public string GetWareHouseNameById(int WarehouseId)
        {
            string Warehouse = string.Empty;
            var query = (from o in obj.WareHouses where o.id == WarehouseId select o.Name + "-" + o.Address).FirstOrDefault();
            if (query!=null)
            {
                Warehouse = query.ToString();
            }
            return Warehouse;
        }

        public int Save(Models.MwareHouse model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CWareHouse";
            try
            {

                DB.WareHouse bs = new DB.WareHouse();
                bs.id = Convert.ToInt32(model.id);
                bs.Name = model.Name;
                bs.Address = model.Address;
                bs.Phone = model.phone;
                bs.Description = model.Description;
                bs.openedDate = Convert.ToDateTime(model.openedDate);

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] Name[" + model.Name + "] Adress[" + model.Address + "] Description[" + model.Description + "] openedDate [ " + model.openedDate + "]");
                obj.WareHouses.InsertOnSubmit(bs);
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
        public int Update(Models.MwareHouse model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CWareHouse";
            try
            {
                var query = from o in obj.WareHouses where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.Name = model.Name;
                    item.Address = model.Address;
                    item.Phone = model.phone;
                    item.Description = model.Description;
                    item.openedDate = Convert.ToDateTime(model.openedDate);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] Name[" + model.Name + "] Adress[" + model.Address + "] Description[" + model.Description + "] openedDate [ " + model.openedDate + "]");
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
        public int Delete(Models.MwareHouse model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CWareHouse";
            try
            {
                var query = from o in obj.WareHouses where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.WareHouses.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] Name[" + model.Name + "] Adress[" + model.Address + "] Description[" + model.Description + "] openedDate [ " + model.openedDate + "]");
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

        public List<Models.MwareHouse> GetAll()
        {
            List<Models.MwareHouse> model = new List<Models.MwareHouse>();
            var query = from o in obj.WareHouses select o;
            foreach (var item in query)
            {
                Models.MwareHouse m = new Models.MwareHouse();
                m.id = Convert.ToString(item.id);
                m.Name = item.Name;
                m.Address = item.Address;
                m.phone = item.Phone;
                m.Description = item.Description;
                m.openedDate = Convert.ToString(item.openedDate);
                model.Add(m);
            }

            return model;
        }
        public List<Models.MwareHouse> GetAllbyid(int id)
        {
            List<Models.MwareHouse> model = new List<Models.MwareHouse>();
            var query = from o in obj.WareHouses where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MwareHouse m = new Models.MwareHouse();
                m.id = Convert.ToString(item.id);
                m.Name = item.Name;
                m.Address = item.Address;
                m.phone = item.Phone;
                m.Description = item.Description;
                m.openedDate = Convert.ToString(item.openedDate);
                model.Add(m);
            }

            return model;
        }

    }
}