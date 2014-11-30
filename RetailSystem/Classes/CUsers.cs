using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CUsers
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public string GetUserNameById(int UserId)
        {
            string UserName = string.Empty;
            var query = (from o in obj.Users where o.id == UserId select o.name).FirstOrDefault();

            UserName = Convert.ToString(query);

            return UserName;
        }

        public int Save(Models.MUsers model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUsers";
            try
            {
                var query = from a in obj.Users where a.name == model.name select a.name;
                if (query.Count() == 0)
                {
                    DB.User bs = new DB.User();

                    bs.name = model.name;
                    bs.password = model.password;
                    bs.Approved = "0";
                    bs.eDate = Convert.ToDateTime(model.eDate);

                    l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] name[" + model.name + "] password[" + model.password + "] eDate[" + model.eDate + "]");
                    obj.Users.InsertOnSubmit(bs);
                    obj.SubmitChanges();
                    l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Inserted Successfully");
                    return 1;
                }
                else
                {
                    return 2;
                }

            }
            catch (Exception ex)
            {
                l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
                return -1;
            }
        }
        public int Update(Models.MUsers model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUsers";
            try
            {
                var query = from o in obj.Users where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.name = model.name;
                    item.password = model.password;
                    item.Approved = item.Approved;
                    item.eDate = Convert.ToDateTime(model.eDate);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] name[" + model.name + "] password[" + model.password + "] eDate[" + model.eDate + "]");
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

        public int Delete(Models.MUsers model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUsers";
            try
            {
                var query = from o in obj.Users where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Users.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] name[" + model.name + "] password[" + model.password + "] eDate[" + model.eDate + "]");
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
        public List<Models.MUsers> GetAll()
        {
            List<Models.MUsers> model = new List<Models.MUsers>();
            var query = from o in obj.Users select o;
            foreach (var item in query)
            {
                Models.MUsers m = new Models.MUsers();
                m.id = Convert.ToString(item.id);
                m.name = item.name;
                m.password = item.password;
                m.Approved = item.Approved;
                m.eDate = Convert.ToString(item.eDate);
                model.Add(m);
            }

            return model;
        }


        public int GetUserIdByName(string UserName)
        {
            int UserId = -1;
            var query = (from o in obj.Users where o.name == UserName select o.id).FirstOrDefault();
            
                UserId = Convert.ToInt32(query);
            
            return UserId;
        }

        public List<Models.MUsers> GetAllbyid(int id)
        {
            List<Models.MUsers> model = new List<Models.MUsers>();
            var query = from o in obj.Users where (o.id) == id select o;
            foreach (var item in query)
            {
                Models.MUsers m = new Models.MUsers();
                m.id = Convert.ToString(item.id);
                m.name = item.name;
                m.password = item.password;
                m.eDate = Convert.ToString(item.eDate);
                model.Add(m);
            }

            return model;
        }


        public List<Models.MUsers> GetUnApprovedUsers()
        {
            List<Models.MUsers> model = new List<Models.MUsers>();
            var query = from o in obj.Users where o.Approved == "0" select o;
            foreach (var item in query)
            {
                Models.MUsers m = new Models.MUsers();
                m.id = Convert.ToString(item.id);
                m.name = item.name;
                m.password = item.password;
                m.Approved = item.Approved;
                m.eDate = Convert.ToString(item.eDate);
                model.Add(m);
            }

            return model;
        }
        public List<Models.MUsers> GetApprovedUsers()
        {
            List<Models.MUsers> model = new List<Models.MUsers>();
            var query = from o in obj.Users where o.Approved == "1" select o;
            foreach (var item in query)
            {
                Models.MUsers m = new Models.MUsers();
                m.id = Convert.ToString(item.id);
                m.name = item.name;
                m.password = item.password;
                m.Approved = item.Approved;
                m.eDate = Convert.ToString(item.eDate);
                model.Add(m);
            }

            return model;
        }

        public int ValidateUser(Models.MUsers mu)
        {
            CFiscalYear cf = new CFiscalYear();
            int fiscalYearId = cf.CheckFiscalYear();
            if (fiscalYearId < 0)
            {
                return -2;
            }
            else
            {
                var query = (from a in obj.Users where a.name == mu.name select a.password).FirstOrDefault();
                var query1 = (from a in obj.Users where a.name == mu.name select a.Approved).FirstOrDefault();
                if (query == mu.password && query1.ToString() == "1")
                {
                    return fiscalYearId;
                }
                else
                {
                    return -1;
                }
            }


        }

        public int ReturnUserIdByName(string UserName)
        {
            CFiscalYear cf = new CFiscalYear();
            int fiscalYearId = cf.CheckFiscalYear();
            if (fiscalYearId < 0)
            {
                return -2;
            }
            else
            {
                var query = (from a in obj.Users where a.name == UserName select a.id).FirstOrDefault();

                return Convert.ToInt32(query);
            }
        }

        public int ApproveUsers(int UserId)
        {
            try
            {
                var query = from u in obj.Users where u.id == UserId select u;
                if (query != null)
                {
                    foreach (var item in query)
                    {
                        item.Approved = "1";
                        item.name = item.name;
                        item.password = item.password;

                    }



                    obj.SubmitChanges();
                    return 1;
                }
                else
                {
                    return 2;
                }


            }
            catch
            {

                return -1;
            }

        }



        public int AssignRolesToUser(int RoleId, int UserId)
        {
            try
            {
                var query = from o in obj.UserRolesContainers where o.userId == UserId select o;
                DB.UserRolesContainer urc = new DB.UserRolesContainer();
                if (query.Count() == 0)
                {
                    urc.RolesId = RoleId;
                    urc.userId = UserId;
                    obj.UserRolesContainers.InsertOnSubmit(urc);
                    obj.SubmitChanges();
                }
                else
                {
                    foreach (var item in query)
                    {
                        item.RolesId = RoleId;
                        item.userId = UserId;
                    }
                    obj.SubmitChanges();
                }
                return 1;
            }
            catch
            {

                return -1;
            }
        }


        public List<string> ParsePermissions(int UserId)
        {
            List<string> Permissions = new List<string>();
            var RolesId = (from o in obj.UserRolesContainers where o.userId == UserId select o.RolesId).FirstOrDefault();

            if (RolesId != null)
            {
                var query = (from o in obj.Permissions where o.RoleID == Convert.ToInt32(RolesId) select o.Permission1).FirstOrDefault();
                if (query != null)
                {
                    Permissions.Clear();
                    Permissions = query.ToString().Split('-').ToList();
                }

            }

            return Permissions;
        }

        public int RejectUsers(int UserId)
        {
            try
            {
                var query = from u in obj.Users where u.id == UserId select u;
                if (query != null)
                {
                    foreach (var item in query)
                    {
                        obj.Users.DeleteOnSubmit(item);

                    }
                    obj.SubmitChanges();
                    return 1;
                }
                else
                {
                    return 2;
                }


            }
            catch
            {

                return -1;
            }
        }

    }
}