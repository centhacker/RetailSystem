using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CHOD
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MHOD model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CHOD";
            try
            {

                DB.HOD bs = new DB.HOD();
                bs.id = Convert.ToInt32(model.id);
                bs.EmployeeId = Convert.ToInt32(model.EmployeeId);
                bs.DepartmentId = Convert.ToInt32(model.DePartmentId);
                

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmployeeId[" + model.EmployeeId + "] DepartmentId[" + model.DePartmentId + "] ");
                obj.HODs.InsertOnSubmit(bs);
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
        public int Update(Models.MHOD model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CHOD";
            try
            {
                var query = from o in obj.HODs where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.EmployeeId = Convert.ToInt32(model.EmployeeId);
                    item.DepartmentId = Convert.ToInt32(model.DePartmentId);
                    
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmployeeId[" + model.EmployeeId + "] DepartmentId[" + model.DePartmentId + "] ");
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
        public int Delete(Models.MHOD model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CHOD";
            try
            {
                var query = from o in obj.HODs where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.HODs.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmployeeId[" + model.EmployeeId + "] DepartmentId[" + model.DePartmentId + "] ");
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

        public List<Models.MHOD> GetAll()
        {
            List<Models.MHOD> model = new List<Models.MHOD>();
            var query = from o in obj.HODs select o;
            foreach (var item in query)
            {
                Models.MHOD m = new Models.MHOD();
                m.id = Convert.ToString(item.id);
                m.EmployeeId = Convert.ToString(item.EmployeeId);
                m.DePartmentId = Convert.ToString(item.DepartmentId);
                
                model.Add(m);
            }

            return model;
        }
        public List<Models.MHOD> GetAllbyid(int id)
        {
            List<Models.MHOD> model = new List<Models.MHOD>();
            var query = from o in obj.HODs where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {

                Models.MHOD m = new Models.MHOD();
                m.id = Convert.ToString(item.id);
                m.EmployeeId = Convert.ToString(item.EmployeeId);
                m.DePartmentId = Convert.ToString(item.DepartmentId);
                
                model.Add(m);
            }

            return model;
        }
    }
}