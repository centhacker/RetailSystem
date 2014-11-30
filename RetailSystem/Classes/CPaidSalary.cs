using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CPaidSalary
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MPaidSalary model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPaidSalary";
            try
            {

                DB.PaidSalary bs = new DB.PaidSalary();
                bs.id = Convert.ToInt32(model.id);
                bs.EmployeeId = Convert.ToInt32(model.EmployeeId);
                bs.SalaryId = Convert.ToInt32(model.SalaryId);
                bs.MonthPaid = model.MonthPaid;
                bs.Paid = model.Paid;
                bs.DatePaid = Convert.ToDateTime(model.DatePaid);
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmployeeId[" + model.EmployeeId + "] SalaryId[" + model.SalaryId + "] MonthPaid[" + model.MonthPaid + "] Paid [ " + model.Paid + " ]");
                obj.PaidSalaries.InsertOnSubmit(bs);
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
        public int Update(Models.MPaidSalary model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPaidSalary";
            try
            {
                var query = from o in obj.PaidSalaries where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.EmployeeId = Convert.ToInt32(model.EmployeeId);
                    item.SalaryId = Convert.ToInt32(model.SalaryId);
                    item.MonthPaid = model.MonthPaid;
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmployeeId[" + model.EmployeeId + "] SalaryId[" + model.SalaryId + "] MonthPaid[" + model.MonthPaid + "] Paid [ " + model.Paid + " ]");
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
        public int Delete(Models.MPaidSalary model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPaidSalary";
            try
            {
                var query = from o in obj.PaidSalaries where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.PaidSalaries.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmployeeId[" + model.EmployeeId + "] SalaryId[" + model.SalaryId + "] MonthPaid[" + model.MonthPaid + "] Paid [ " + model.Paid + " ]");
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
        public List<Models.MPaidSalary> GetAll()
        {
            List<Models.MPaidSalary> model = new List<Models.MPaidSalary>();
            var query = from o in obj.PaidSalaries select o;
            foreach (var item in query)
            {
                Classes.CEmployees cp = new CEmployees();
                string EmployeeName = string.Empty;
                EmployeeName = cp.GetEmployeeNameById(Convert.ToInt32(item.EmployeeId));
                Models.MPaidSalary m = new Models.MPaidSalary();
                m.id = Convert.ToString(item.id);
                m.EmployeeName = EmployeeName;
                m.EmployeeId = Convert.ToString(item.EmployeeId);
                m.SalaryId = Convert.ToString(item.SalaryId);
                m.MonthPaid = item.MonthPaid;
                m.Paid = item.Paid;
                m.DatePaid = item.DatePaid.ToString();
                model.Add(m);
            }

            return model;
        }
        public List<Models.MPaidSalary> GetAllbyid(int id)
        {
            List<Models.MPaidSalary> model = new List<Models.MPaidSalary>();
            var query = from o in obj.PaidSalaries where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MPaidSalary m = new Models.MPaidSalary();
                m.id = Convert.ToString(item.id);
                m.EmployeeId = Convert.ToString(item.EmployeeId);
                m.SalaryId = Convert.ToString(item.SalaryId);
                m.MonthPaid = item.MonthPaid;
                m.Paid = item.Paid;
                model.Add(m);
            }

            return model;
        }


    }
}