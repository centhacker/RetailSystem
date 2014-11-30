using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CAllowancesPaid
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MAllowancePaid model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CAllowancePaid";
            try
            {

                DB.AllowancesPaid bs = new DB.AllowancesPaid();
                bs.id = int.Parse(model.id);
                bs.PaidSalaryId = int.Parse(model.PaidSalaryId);
                bs.AllowancePaid = model.AllowancePaid;
                bs.AllowanceTitle = model.AllowanceTitle;

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PaidsalaryId[" + model.PaidSalaryId + "] AllowancePaid[" + model.AllowancePaid + "] AllowanceTitle[" + model.AllowanceTitle + "]");
                obj.AllowancesPaids.InsertOnSubmit(bs);
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
        public int Update(Models.MAllowancePaid model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CAllowancePaid";
            try
            {
                var query = from o in obj.AllowancesPaids where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.PaidSalaryId = int.Parse(model.PaidSalaryId);
                    item.AllowancePaid = model.AllowancePaid;
                    item.AllowanceTitle = model.AllowanceTitle;
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PaidsalaryId[" + model.PaidSalaryId + "] AllowancePaid[" + model.AllowancePaid + "] AllowanceTitle[" + model.AllowanceTitle + "]");
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
        public int Delete(Models.MAllowancePaid model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CAllowancePaid";
            try
            {
                var query = from o in obj.AllowancesPaids where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.AllowancesPaids.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PaidsalaryId[" + model.PaidSalaryId + "] AllowancePaid[" + model.AllowancePaid + "] AllowanceTitle[" + model.AllowanceTitle + "]");
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
        public List<Models.MAllowancePaid> GetAll()
        {
            List<Models.MAllowancePaid> model = new List<Models.MAllowancePaid>();
            var query = from o in obj.AllowancesPaids select o;
            foreach (var item in query)
            {
                Models.MAllowancePaid m = new Models.MAllowancePaid();
                m.id = Convert.ToString(item.id);
                m.PaidSalaryId = Convert.ToString(item.PaidSalaryId);
                m.AllowancePaid = item.AllowancePaid;
                m.AllowanceTitle = item.AllowanceTitle;
                model.Add(m);
            }

            return model;
        }
        public List<Models.MAllowancePaid> GetAllbyid(int id)
        {
            List<Models.MAllowancePaid> model = new List<Models.MAllowancePaid>();
            var query = from o in obj.AllowancesPaids where (o.id) == id select o;
            foreach (var item in query)
            {
                Models.MAllowancePaid m = new Models.MAllowancePaid();
                m.id = Convert.ToString(item.id);
                m.PaidSalaryId = Convert.ToString(item.PaidSalaryId);
                m.AllowancePaid = item.AllowancePaid;
                m.AllowanceTitle = item.AllowanceTitle;
                model.Add(m);
            }

            return model;
        }


    }
}