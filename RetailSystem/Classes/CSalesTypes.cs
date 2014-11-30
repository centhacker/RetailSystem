using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CSalesTypes
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MsaleTypes model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CSaleTypes";
            try
            {

                DB.SaleType bs = new DB.SaleType();
                bs.id = int.Parse(model.id);
                bs.name = model.name;
               

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] name[" + model.name + "]");
                obj.SaleTypes.InsertOnSubmit(bs);
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
        public int Update(Models.MsaleTypes model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CSalesType";
            try
            {
                var query = from o in obj.SaleTypes where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.id = int.Parse(model.id);
                    item.name = model.name;
                    
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] name[" + model.name + "]");
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
        public int Delete(Models.MsaleTypes model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CSaleTypes";
            try
            {
                var query = from o in obj.SaleTypes where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.SaleTypes.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] name[" + model.name + "]");
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

        public List<Models.MsaleTypes> GetAll()
        {
            List<Models.MsaleTypes> model = new List<Models.MsaleTypes>();
            var query = from o in obj.SaleTypes select o;
            foreach (var item in query)
            {
                Models.MsaleTypes m = new Models.MsaleTypes();
                m.id = Convert.ToString(item.id);
                m.name = item.name;
               
                model.Add(m);
            }

            return model;
        }
        public List<Models.MsaleTypes> GetAllbyid(int id)
        {
            List<Models.MsaleTypes> model = new List<Models.MsaleTypes>();
            var query = from o in obj.SaleTypes where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MsaleTypes m = new Models.MsaleTypes();
                m.id = Convert.ToString(item.id);
                m.name = item.name;
               
                model.Add(m);
            }

            return model;
        }

    }
}