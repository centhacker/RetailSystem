using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CPayroll
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();


        public int Save(Models.MPayroll model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPayRoll";
            try
            {

                DB.Payroll bs = new DB.Payroll();
                bs.id = Convert.ToInt32(model.id);
                bs.EmpId = Convert.ToInt32(model.EmpId);
                bs.SalaryId = Convert.ToInt32(model.SalaryId);
                bs.DateOfPay = Convert.ToString(model.DateOfPay);

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmpId[" + model.EmpId + "] salaryId[" + model.SalaryId + "] DateOfPay[" + model.DateOfPay + "]");
                obj.Payrolls.InsertOnSubmit(bs);
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
        public int Update(Models.MPayroll model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPayroll";
            try
            {
                var query = from o in obj.Payrolls where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.EmpId = Convert.ToInt32(model.EmpId);
                    item.SalaryId = Convert.ToInt32(model.SalaryId);
                    item.DateOfPay = Convert.ToString(model.DateOfPay);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmpId[" + model.EmpId + "] salaryId[" + model.SalaryId + "] DateOfPay[" + model.DateOfPay + "]");
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
        public int Delete(Models.MPayroll model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPayroll";
            try
            {
                var query = from o in obj.Payrolls where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Payrolls.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] EmpId[" + model.EmpId + "] salaryId[" + model.SalaryId + "] DateOfPay[" + model.DateOfPay + "]");
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
        public List<Models.MPayroll> GetAll()
        {
            List<Models.MPayroll> model = new List<Models.MPayroll>();
            var query = from o in obj.Payrolls select o;
            foreach (var item in query)
            {
                Models.MPayroll m = new Models.MPayroll();
                m.id = Convert.ToString(item.id);
                m.EmpId = Convert.ToString(item.EmpId);
                m.SalaryId = Convert.ToString(item.SalaryId);
                m.DateOfPay = Convert.ToDateTime(item.DateOfPay);
                model.Add(m);
            }

            return model;
        }
    }
}