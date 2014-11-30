using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CBank
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MBank model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CBank";
            try
            {

                DB.Bank bs = new DB.Bank();
                bs.id = Convert.ToInt32(model.id);
                bs.Name = model.Name;
                bs.Branch = model.Branch;
                bs.BranchCode = model.BranchCode;
                bs.TelephoneNumber = model.TelephoneNumber;
                bs.EmailAddress = model.EmailAddress;


                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] Name[" + model.Name + "] Branch[" + model.Branch + "] BranchCode[" + model.BranchCode + "] TelephoneNumber [ " + model.TelephoneNumber + "] EmailAddress [ " + model.EmailAddress + " ] ");
                obj.Banks.InsertOnSubmit(bs);
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
        public int Update(Models.MBank model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CBank";
            try
            {
                var query = from o in obj.Banks where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.Name = model.Name;
                    item.Branch = model.Branch;
                    item.BranchCode = model.BranchCode;
                    item.TelephoneNumber = model.TelephoneNumber;
                    item.EmailAddress = model.EmailAddress;
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] Name[" + model.Name + "] Branch[" + model.Branch + "] BranchCode[" + model.BranchCode + "] TelephoneNumber [ " + model.TelephoneNumber + "] EmailAddress [ " + model.EmailAddress + " ] ");
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
        public int Delete(Models.MBank model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CBank";
            try
            {
                var query = from o in obj.Banks where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.Banks.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] Name[" + model.Name + "] Branch[" + model.Branch + "] BranchCode[" + model.BranchCode + "] TelephoneNumber [ " + model.TelephoneNumber + "] EmailAddress [ " + model.EmailAddress + " ] ");
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
        public List<Models.MBank> GetAll()
        {
            List<Models.MBank> model = new List<Models.MBank>();
            var query = from o in obj.Banks select o;
            foreach (var item in query)
            {
                Models.MBank m = new Models.MBank();
                m.id = Convert.ToString(item.id);
                m.Name = item.Name;
                m.Branch = item.Branch;
                m.BranchCode = item.BranchCode;
                m.TelephoneNumber = item.TelephoneNumber;
                m.EmailAddress = item.EmailAddress;
                
                model.Add(m);
            }

            return model;
        }
        public List<Models.MBank> GetAllbyid(int id)
        {
            List<Models.MBank> model = new List<Models.MBank>();
            var query = from o in obj.Banks where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.MBank m = new Models.MBank();
                m.id = Convert.ToString(item.id);
                m.Name = item.Name;
                m.Branch = item.Branch;
                m.BranchCode = item.BranchCode;
                m.TelephoneNumber = item.TelephoneNumber;
                m.EmailAddress = item.EmailAddress;
                model.Add(m);
            }

            return model;
        }

    }
}