using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CJournal
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        public int Save(Models.MJournal model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CJournal";
            try
            {
                DB.Journal bs = new DB.Journal();
                bs.id = Convert.ToInt32(model.id);
                bs.acc_id = Convert.ToInt32(model.acc_id);
                bs.amount = Convert.ToInt32(model.amount);
                bs.des = model.des;
                bs.type = model.type;
                bs.e_date = Convert.ToDateTime(model.e_date);

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] acc_id[" + model.acc_id + "] amount[" + model.amount + "] des[" + model.des + "] type[" + model.type + "] e_date[" + model.e_date + "]");
                obj.Journals.InsertOnSubmit(bs);
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
        public int Update(Models.MJournal model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CJournal";
            try
            {
                var query = from o in obj.Journals where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.acc_id = int.Parse(model.acc_id);
                    item.amount = Convert.ToSingle(model.amount);
                    item.des = model.des;
                    item.type = model.type;
                    item.e_date = Convert.ToDateTime(model.e_date);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] acc_id[" + model.acc_id + "] amount[" + model.amount + "] des[" + model.des + "] type[" + model.type + "] e_date[" + model.e_date + "]");
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
        public int Delete(Models.MJournal model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CJournal";
            try
            {
                var query = from o in obj.Journals where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Journals.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] acc_id[" + model.acc_id + "] amount[" + model.amount + "] des[" + model.des + "] type[" + model.type + "] e_date[" + model.e_date + "]");
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
        public List<Models.MJournal> GetAll()
        {
            List<Models.MJournal> model = new List<Models.MJournal>();
            var query = from o in obj.Journals select o;
            foreach (var item in query)
            {
                Models.MJournal m = new Models.MJournal(); 

                m.acc_id = Convert.ToString(item.acc_id);
                m.des = item.des;
                m.amount = Convert.ToString(item.amount);
                m.type = Convert.ToString(item.type);
                m.e_date = Convert.ToString(item.e_date);
                model.Add(m);
            }

            return model;
        }
        public List<Models.MJournal> GetAllbyid(int id)
        {
            List<Models.MJournal> model = new List<Models.MJournal>();
            var query = from o in obj.Journals where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MJournal m = new Models.MJournal();
                m.id = Convert.ToString(item.id);
                m.acc_id = Convert.ToString(item.acc_id);
                m.des = item.des;
                m.type = item.type;
                m.e_date = Convert.ToString(item.e_date);
                model.Add(m);
            }

            return model;
        }


    }
}