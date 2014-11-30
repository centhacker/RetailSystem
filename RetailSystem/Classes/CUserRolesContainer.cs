using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CUserRolesContainer
    {

        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MUserRolesContainer model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUserRolesContainer";
            try
            {

                DB.UserRolesContainer bs = new DB.UserRolesContainer();
                bs.id = int.Parse(model.id);
                bs.userId = int.Parse(model.userId);
                

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] userId[" + model.userId + "] RolesId[" + model.Rolesid + "] ");
                obj.UserRolesContainers.InsertOnSubmit(bs);
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
        public int Update(Models.MUserRolesContainer model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUserRolesContainer";
            try
            {
                var query = from o in obj.UserRolesContainers where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.userId = int.Parse(model.userId);
                    item.RolesId = int.Parse(model.Rolesid);
                    
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] userId[" + model.userId + "] RolesId[" + model.Rolesid + "] ");
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
        public int Delete(Models.MUserRolesContainer model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUserRolesContainer";
            try
            {
                var query = from o in obj.UserRolesContainers where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.UserRolesContainers.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] userId[" + model.userId + "] RolesId[" + model.Rolesid + "] ");
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
        public List<Models.MUserRolesContainer> GetAll()
        {
            List<Models.MUserRolesContainer> model = new List<Models.MUserRolesContainer>();
            var query = from o in obj.UserRolesContainers select o;
            foreach (var item in query)
            {
                Models.MUserRolesContainer m = new Models.MUserRolesContainer();
                m.id = Convert.ToString(item.id);
                m.userId = Convert.ToString(item.userId);
                m.Rolesid = Convert.ToString(item.RolesId);
               
                model.Add(m);
            }

            return model;
        }
        public List<Models.MUserRolesContainer> GetAllbyid(int id)
        {
            List<Models.MUserRolesContainer> model = new List<Models.MUserRolesContainer>();
            var query = from o in obj.UserRolesContainers where (o.id) ==id select o;
            foreach (var item in query)
            {
                Models.MUserRolesContainer m = new Models.MUserRolesContainer();
                m.id = Convert.ToString( item.id);
                m.userId = Convert.ToString(item.userId);
                m.Rolesid = Convert.ToString(item.RolesId);
                model.Add(m);
            }

            return model;
        }

    }
}