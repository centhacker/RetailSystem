using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RetailSystem.DB;

namespace RetailSystem.Classes
{
    public class CEmployees
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public string GetEmployeeNameById(int EmployeeId)
        {
            var query = (from o in obj.Employees
                         where o.id == EmployeeId
                         select
                         o.FirstName + "-" + o.LastName).FirstOrDefault();
            if (query != null)
            {
                return query.ToString();
            }
            return string.Empty;

        }


        public int GetLastEmployeeId()
        {
            var query = obj.Employees.OrderByDescending(o => o.id).FirstOrDefault();
            return Convert.ToInt32(query.id);

        }

        public int Save(Models.MEmployees model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CEmployees";
            try
            {



                DB.Employee bs = new DB.Employee();
                bs.id = Convert.ToInt32(model.id);
                bs.DesignationId = Convert.ToInt32(model.DesignationId);
                bs.FirstName = model.FirstName;
                bs.LastName = model.LastName;
                bs.DateOfBirth = model.DateOfBirth;
                bs.Gender = model.Gender;
                bs.Address = model.Address;
                bs.City = model.City;
                bs.HomePhone = model.HomePhone;
                bs.CellNo = model.CellNo;
                bs.Email = model.Email;
                bs.EmergencyContactNo = model.EmergencyContactNo;
                bs.WarehouseId = Convert.ToInt32(model.WareHouseId);
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] DesignationId[" + model.DesignationId + "] FirstName[" + model.FirstName + "] LastName[" + model.LastName + "] DateOfBirth [" + model.DateOfBirth + " ] gender [ " + model.Gender + " ] Address[ " + model.Address + " ] City [ " + model.City + " ] HomePhone [ " + model.HomePhone + " ] CellPhone [ " + model.CellNo + " ] Email[ " + model.Email + " ] EmergencyContactNo [ " + model.EmergencyContactNo + " ]");
                obj.Employees.InsertOnSubmit(bs);
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

        public int Update(Models.MEmployees model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "Employees";
            try
            {
                var query = from o in obj.Employees where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.DesignationId = Convert.ToInt32(model.DesignationId);
                    item.FirstName = model.FirstName;
                    item.FirstName = model.FirstName;
                    item.LastName = model.LastName;
                    item.DateOfBirth = model.DateOfBirth;
                    item.Gender = model.Gender;
                    item.Address = model.Address;
                    item.City = model.City;
                    item.HomePhone = model.HomePhone;
                    item.CellNo = model.CellNo;
                    item.Email = model.Email;
                    item.EmergencyContactNo = model.EmergencyContactNo;
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] DesignationId[" + model.DesignationId + "] FirstName[" + model.FirstName + "] LastName[" + model.LastName + "] DateOfBirth [" + model.DateOfBirth + " ] gender [ " + model.Gender + " ] Address[ " + model.Address + " ] City [ " + model.City + " ] HomePhone [ " + model.HomePhone + " ] CellPhone [ " + model.CellNo + " ] Email[ " + model.Email + " ] EmergencyContactNo [ " + model.EmergencyContactNo + " ]");
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
        public int Delete(Models.MEmployees model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CEmployees";
            try
            {
                var query = from o in obj.Employees where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Employees.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] DesignationId[" + model.DesignationId + "] FirstName[" + model.FirstName + "] LastName[" + model.LastName + "] DateOfBirth [" + model.DateOfBirth + " ] gender [ " + model.Gender + " ] Address[ " + model.Address + " ] City [ " + model.City + " ] HomePhone [ " + model.HomePhone + " ] CellPhone [ " + model.CellNo + " ] Email[ " + model.Email + " ] EmergencyContactNo [ " + model.EmergencyContactNo + " ]");
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
        public List<Models.MEmployees> GetAll()
        {
            List<Models.MEmployees> model = new List<Models.MEmployees>();
            var query = from o in obj.Employees select o;
            foreach (var item in query)
            {
                Models.MEmployees m = new Models.MEmployees();
                m.id = Convert.ToString(item.id);
                m.DesignationId = Convert.ToString(item.DesignationId);
                m.FirstName = item.FirstName;
                m.LastName = item.LastName;
                m.DateOfBirth = item.DateOfBirth;
                m.Gender = item.Gender;
                m.Address = item.Address;
                m.City = item.City;
                m.HomePhone = item.HomePhone;
                m.CellNo = item.CellNo;
                m.Email = item.Email;
                m.EmergencyContactNo = item.EmergencyContactNo;
                m.WareHouseId = item.WarehouseId.ToString();
                model.Add(m);
            }

            return model;
        }
        public List<Models.MEmployees> GetAllbyid(int id)
        {
            List<Models.MEmployees> model = new List<Models.MEmployees>();
            var query = from o in obj.Employees where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MEmployees m = new Models.MEmployees();
                m.id = Convert.ToString(item.id);
                m.DesignationId = Convert.ToString(item.DesignationId);
                m.FirstName = item.FirstName;
                m.LastName = item.LastName;
                m.DateOfBirth = item.DateOfBirth;
                m.Gender = item.Gender;
                m.Address = item.Address;
                m.City = item.City;
                m.HomePhone = item.HomePhone;
                m.CellNo = item.CellNo;
                m.Email = item.Email;
                m.EmergencyContactNo = item.EmergencyContactNo;
                model.Add(m);
            }

            return model;
        }



    }
}