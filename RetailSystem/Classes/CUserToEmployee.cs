using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CUserToEmployee
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MUserToEmployee model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUserToEmployee";
            try
            {

                DB.UserToEmployee bs = new DB.UserToEmployee();
                bs.id = model.id;
                bs.EmployeeId = model.EmployeeId;
                bs.UserId = model.UserId;
                

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmployeeId[" + model.EmployeeId + "] UserId[" + model.UserId + "] ");
                obj.UserToEmployees.InsertOnSubmit(bs);
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
        public int Update(Models.MUserToEmployee model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUserToEmployee";
            try
            {
                var query = from o in obj.UserToEmployees where o.id == model.id select o;

                foreach (var item in query)
                {
                    item.EmployeeId = model.EmployeeId;
                    item.UserId = model.UserId;
                }

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmployeeId[" + model.EmployeeId + "] UserId[" + model.UserId + "] ");
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
        
 
            public int Delete(Models.MUserToEmployee model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUserToEmployee";
            try
            {
                var query = from o in obj.UserToEmployees where o.id == model.id select o;
                foreach (var item in query)
                {
                    obj.UserToEmployees.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmployeeId[" + model.EmployeeId + "] UserId[" + model.UserId + "] ");
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
        public List<Models.MUserToEmployee> GetAll()
        {
            List<Models.MUserToEmployee> model = new List<Models.MUserToEmployee>();
            var query = from o in obj.UserToEmployees select o;
            foreach (var item in query)
            {
                Models.MUserToEmployee m = new Models.MUserToEmployee();
                m.id = item.id;
                m.EmployeeId = Convert.ToInt32(item.EmployeeId);
                m.UserId = Convert.ToInt32(item.UserId);
                
                
                model.Add(m);
            }

            return model;
        }
        public List<Models.MUserToEmployee> GetAllbyid(int id)
        {
            List<Models.MUserToEmployee> model = new List<Models.MUserToEmployee>();
            var query = from o in obj.UserToEmployees where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MUserToEmployee m = new Models.MUserToEmployee();
                m.id = item.id;
                m.EmployeeId = Convert.ToInt32(item.EmployeeId);
                m.UserId = Convert.ToInt32(item.UserId);
                
            }

            return model;
        }


    }
}
