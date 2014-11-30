using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CRoles
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MRoles model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CRoles";
            try
            {

                DB.Role bs = new DB.Role();
                //bs.id = int.Parse(model.id);
                bs.RoleName = model.RoleName;


                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] RoleName[" + model.RoleName + "] ");
                obj.Roles.InsertOnSubmit(bs);
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
        public int Update(Models.MRoles model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CRoles";
            try
            {
                var query = from o in obj.Roles where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.id = int.Parse(model.id);
                    item.RoleName = model.RoleName;

                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] RoleName[" + model.RoleName + "] ");
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
        public int Delete(Models.MRoles model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CRoles";
            try
            {
                var query = from o in obj.Roles where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Roles.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] RoleName[" + model.RoleName + "] ");
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
        public List<Models.MRoles> GetAll()
        {
            List<Models.MRoles> model = new List<Models.MRoles>();
            var query = from o in obj.Roles select o;
            foreach (var item in query)
            {
                Models.MRoles m = new Models.MRoles();
                m.id = Convert.ToString(item.id);
                m.RoleName = item.RoleName;

                model.Add(m);
            }

            return model;
        }
        public List<Models.MRoles> GetAllbyid(int id)
        {
            List<Models.MRoles> model = new List<Models.MRoles>();
            var query = from o in obj.Roles where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MRoles m = new Models.MRoles();
                m.id = Convert.ToString(item.id);
                m.RoleName = item.RoleName;

                model.Add(m);
            }

            return model;
        }

        public int isAdmin(string UserName)
        {
            Classes.CUsers cu = new Classes.CUsers();
            int UserId = cu.GetUserIdByName(UserName);
            List<string> Permissions = cu.ParsePermissions(UserId);
            if (Permissions.Contains("33") || Permissions.Contains("-33") || Permissions.Contains("33-"))
            {
                return 1;    
            }
            return -1;
            
        }

        public int AssignPermissionsToRoles(int RoleID, string PermissionsString) 
        {
            try
            {
                var query = from o in obj.Permissions where o.RoleID == RoleID select o;
                if (query.Count()==0)
                {
                    DB.Permission per = new DB.Permission();
                    per.Permission1 = PermissionsString;
                    per.RoleID = RoleID;
                    obj.Permissions.InsertOnSubmit(per);
                }
                else
                {
                    foreach (var item in query)
                    {
                        item.Permission1 = PermissionsString;
                    }
                }

                obj.SubmitChanges();
               
                return 1;
            }
            catch 
            {

                return -1;
            }
        }


    }

}