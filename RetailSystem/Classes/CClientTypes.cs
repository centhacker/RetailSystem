using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CClientTypes
    {

        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        public int Save(Models.MClientTypes model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CClientTypes";
            try
            {

                DB.ClientType bs = new DB.ClientType();
                
                bs.Name = model.name;

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model id[" + model.id + "] Name[" + model.name + "] ");
                obj.ClientTypes.InsertOnSubmit(bs);
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
        public int Update(Models.MClientTypes model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CClientTypes";
            try
            {
                var query = from o in obj.ClientTypes where o.id == int.Parse(model.id) select o;
                foreach (var item in query)
                {
                    item.Name = model.name;

                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model id[" + model.id + "] Name[" + model.name + "] ");
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
        public int Delete(Models.MClientTypes model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CClientTypes";
            try
            {
                var query = from o in obj.ClientTypes where o.id == int.Parse(model.id) select o;
                foreach (var item in query)
                {
                    obj.ClientTypes.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model id[" + model.id + "] Name[" + model.name + "] ");
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
        public List<Models.MClientTypes> GetAll()
        {
            List<Models.MClientTypes> model = new List<Models.MClientTypes>();
            var query = from o in obj.ClientTypes select o;
            foreach (var item in query)
            {
                Models.MClientTypes m = new Models.MClientTypes();
                m.id = Convert.ToString(item.id);
                m.name = Convert.ToString(item.Name);
                model.Add(m);
            }
            return model;
        }
        public List<Models.MClientTypes> GetAllbyid(int id)
        {
            List<Models.MClientTypes> model = new List<Models.MClientTypes>();
            var query = from o in obj.ClientTypes where (o.id) == id select o;
            foreach (var item in query)
            {
                Models.MClientTypes m = new Models.MClientTypes();
                m.id = Convert.ToString(item.id);
                m.name = item.Name;

                model.Add(m);
            }

            return model;
        }




    }
}