using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CPostings
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MPostings model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPostings";
            try
            {
                DB.Posting bs = new DB.Posting();
                bs.id = Convert.ToInt32(model.id);
                bs.acc_id = Convert.ToInt32(model.acc_id);
                bs.acc_num = model.acc_num;
                bs.type = model.type;
                bs.amount = Convert.ToSingle(model.amount);
                bs.e_date = Convert.ToDateTime(model.e_date);

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] acc_id[" + model.acc_id + "] acc_num[" + model.acc_num + "] type[" + model.type + "] amount [ " + model.amount + " ] e_date [" + model.e_date + " ]");
                obj.Postings.InsertOnSubmit(bs);
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

        public int Update(Models.MPostings model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPostings";
            try
            {
                var query = from o in obj.Postings where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.acc_id =Convert.ToInt32 (model.acc_id);
                    item.acc_num = model.acc_num;
                    item.type = model.type;
                    item.amount = Convert.ToSingle(model.amount);
                    item.e_date = Convert.ToDateTime(model.e_date);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] acc_id[" + model.acc_id + "] acc_num[" + model.acc_num + "] type[" + model.type + "] amount [ " + model.amount + " ] e_date [" + model.e_date + " ]");
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

        public int Delete(Models.MPostings model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPostings";
            try
            {
                var query = from o in obj.Postings where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Postings.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] acc_id[" + model.acc_id + "] acc_num[" + model.acc_num + "] type[" + model.type + "] amount [ " + model.amount + " ] e_date [" + model.e_date + " ]");
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

        public List<Models.MPostings> GetAll()
        {
            List<Models.MPostings> model = new List<Models.MPostings>();
            var query = from o in obj.Postings select o;
            foreach (var item in query)
            {
                Models.MPostings m = new Models.MPostings();
                m.id = Convert.ToString(item.id);
                m.acc_id = Convert.ToString(item.acc_id);
                m.acc_num = item.acc_num;
                m.type = item.type;
                m.amount = Convert.ToString(item.amount);
                m.e_date = Convert.ToString(item.e_date);
                model.Add(m);
            }

            return model;
        }

        public List<Models.MPostings> GetAllbyid(int id)
        {
            List<Models.MPostings> model = new List<Models.MPostings>();
            var query = from o in obj.Postings where o.id == id select o;
            foreach (var item in query)
            {
                Models.MPostings m = new Models.MPostings();
                m.id = Convert.ToString(item.id);
                m.acc_id = Convert.ToString(item.acc_id);
                m.acc_num = item.acc_num;
                m.type = item.type;
                m.amount = Convert.ToString(item.amount);
                m.e_date = Convert.ToString(item.e_date);
                model.Add(m);
            }

            return model;
        }

    }
}