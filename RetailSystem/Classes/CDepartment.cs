using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CDepartment
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MDepartment model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CDepartment";
            try
            {

                DB.Department bs = new DB.Department();
                bs.id = Convert.ToInt32(model.id);
                bs.Name = model.Name;
                bs.Address = model.Address;
               

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] Name[" + model.Name + "] Address[" + model.Address + "] ");
                obj.Departments.InsertOnSubmit(bs);
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
        public int Update(Models.MDepartment model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CDepartment";
            try
            {
                var query = from o in obj.Departments where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.Name = model.Name;
                    item.Address = model.Address;
                    
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] Name[" + model.Name + "] Address[" + model.Address + "] ");
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
        public int Delete(Models.MDepartment model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CDepartment";
            try
            {
                var query = from o in obj.Departments where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Departments.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] Name[" + model.Name + "] Address[" + model.Address + "] ");
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
        public List<Models.MDepartment> GetAll()
        {
            List<Models.MDepartment> model = new List<Models.MDepartment>();
            var query = from o in obj.Departments select o;
            foreach (var item in query)
            {
                Models.MDepartment m = new Models.MDepartment();
                m.id = Convert.ToString(item.id);
                m.Name = item.Name;
                m.Address = item.Address;
                
                model.Add(m);
            }

            return model;
        }
        public List<Models.MDepartment> GetAllbyid(int id)
        {
            List<Models.MDepartment> model = new List<Models.MDepartment>();
            var query = from o in obj.Departments where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MDepartment m = new Models.MDepartment();
                m.id = Convert.ToString(item.id);
                m.Name = item.Name;
                m.Address = item.Address;
               
                model.Add(m);
            }

            return model;
        }

    }
}