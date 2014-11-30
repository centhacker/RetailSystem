using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CVendor
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        public string GetVendorNameById(string VendorId)
        {
            string VendorName = string.Empty;
            var query = (from o in obj.Vendors where o.id == Convert.ToInt32(VendorId) select o.name).FirstOrDefault();
            if (!string.IsNullOrEmpty(query.ToString()))
            {
                return VendorId + "-" + query.ToString();
            }
            else
            {
                return VendorName;
            }
        }


        public int GetLastVendorId()
        {
            var query = obj.Vendors.OrderByDescending(o => o.id).FirstOrDefault();
            return Convert.ToInt32(query.id);

        }
        public int Save(Models.MVendor model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CVendor";
            try
            {

                DB.Vendor bs = new DB.Vendor();
                bs.id = Convert.ToInt32(model.id);
                bs.name = model.name;
                bs.Address = model.Addreess;
                bs.phone = model.phone;
                bs.WareHouseId = Convert.ToInt32(model.WareHouseId);
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] name[" + model.name + "] Address[" + model.Addreess + "] phone[" + model.phone + "]");
                obj.Vendors.InsertOnSubmit(bs);
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
        public int Update(Models.MVendor model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CVendor";
            try
            {
                var query = from o in obj.Vendors where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.name = model.name;
                    item.Address = model.Addreess;
                    item.phone = model.phone;
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] name[" + model.name + "] Adress[" + model.Addreess + "] phone[" + model.phone + "]");
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
        public int Delete(Models.MVendor model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CVendor";
            try
            {
                var query = from o in obj.Vendors where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Vendors.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] name[" + model.name + "] Adress[" + model.Addreess + "] phone[" + model.phone + "]");
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
        public List<Models.MVendor> GetAll()
        {
            List<Models.MVendor> model = new List<Models.MVendor>();
            var query = from o in obj.Vendors select o;
            foreach (var item in query)
            {
                Models.MVendor m = new Models.MVendor();
                m.id = Convert.ToString(item.id);
                m.name = item.name;
                m.Addreess = item.Address;
                m.phone = item.phone;
                m.WareHouseId = item.WareHouseId.ToString();
                model.Add(m);
            }

            return model;
        }
        public List<Models.MVendor> GetAllbyid(int id)
        {
            List<Models.MVendor> model = new List<Models.MVendor>();
            var query = from o in obj.Vendors where o.id == id select o;
            foreach (var item in query)
            {
                Models.MVendor m = new Models.MVendor();
                m.id = Convert.ToString(item.id);
                m.name = item.name;
                m.Addreess = item.Address;
                m.phone = item.phone;

                model.Add(m);
            }

            return model;
        }
    }
}