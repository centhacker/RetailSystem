using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CPayrollDetails
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MPayrollDetails model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPayrollDetails";
            try
            {

                DB.PayrollDetail bs = new DB.PayrollDetail();
                bs.id = Convert.ToInt32(model.PayrollId);
                bs.LastMonthPaid = model.LastMonthPaid;
                

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PayrollId[" + model.PayrollId + "] LastMonthPaid[" + model.LastMonthPaid + "] ");
                obj.PayrollDetails.InsertOnSubmit(bs);
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
        public int Update(Models.MPayrollDetails model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPayrollDetails";
            try
            {
                var query = from o in obj.PayrollDetails where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.PayrollId = Convert.ToInt32(model.PayrollId);
                    item.LastMonthPaid = model.LastMonthPaid;
                    
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PayrollId[" + model.PayrollId + "] LastMonthPaid[" + model.LastMonthPaid + "] ");
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
        public int Delete(Models.MPayrollDetails model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPayrollDetails";
            try
            {
                var query = from o in obj.PayrollDetails where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.PayrollDetails.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PayrollId[" + model.PayrollId + "] LastMonthPaid[" + model.LastMonthPaid + "] ");
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
        public List<Models.MPayrollDetails> GetAll()
        {
            List<Models.MPayrollDetails> model = new List<Models.MPayrollDetails>();
            var query = from o in obj.PayrollDetails select o;
            foreach (var item in query)
            {
                Models.MPayrollDetails m = new Models.MPayrollDetails();
                m.id = Convert.ToString(item.id);
                m.PayrollId = Convert.ToString(item.PayrollId);
                m.LastMonthPaid = item.LastMonthPaid;
                
                model.Add(m);
            }

            return model;
        }
        public List<Models.MPayrollDetails> GetAllbyid(int id)
        {
            List<Models.MPayrollDetails> model = new List<Models.MPayrollDetails>();
            var query = from o in obj.PayrollDetails where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MPayrollDetails m = new Models.MPayrollDetails();
                m.id = Convert.ToString(item.id);
                m.PayrollId = Convert.ToString(item.PayrollId);
                m.LastMonthPaid = item.LastMonthPaid;
                
                model.Add(m);
            }

            return model;
        }

    }
}