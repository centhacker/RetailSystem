using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CUserDetails
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MUserDetails model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUserDetail";
            try
            {

                DB.UserDetail bs = new DB.UserDetail();
                bs.id = Convert.ToInt32(model.id);
                bs.userId = Convert.ToInt32(model.userId);
                bs.FirstName = model.FirstName;
                bs.LastName = model.LastName;
                bs.cellNo = model.cellNo;
                bs.phoneNo = model.phoneNo;
                bs.Address = model.Address;
                bs.emailId = model.emailId;
                bs.CNIC = model.CNIC;
                bs.eDate = Convert.ToDateTime(model.eDate);

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Value id[" + model.id + "] userId[" + model.userId + "] FirstName[" + model.FirstName + "] LastName[" + model.LastName + "] cellNo[" + model.cellNo + " ] phoneNo [ " + model.phoneNo + "] Address [" + model.Address + " ] emailId [ " + model.emailId + " ] CNIC [ " + model.CNIC + " ] eDate[ " + model.eDate + " ]");
                obj.UserDetails.InsertOnSubmit(bs);
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
        public int Update(Models.MUserDetails model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUserDetail";
            try
            {
                var query = from o in obj.UserDetails where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.userId = int.Parse(model.userId);
                    item.FirstName = model.FirstName;
                    item.LastName = model.LastName;
                    item.cellNo = model.cellNo;
                    item.phoneNo = model.phoneNo;
                    item.Address = model.Address;
                    item.emailId = model.emailId;
                    item.CNIC = model.CNIC;
                    item.eDate = Convert.ToDateTime(model.eDate);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Value id[" + model.id + "] userId[" + model.userId + "] FirstName[" + model.FirstName + "] LastName[" + model.LastName + "] cellNo[" + model.cellNo + " ] phoneNo [ " + model.phoneNo + "] Address [" + model.Address + " ] emailId [ " + model.emailId + " ] CNIC [ " + model.CNIC + " ] eDate[ " + model.eDate + " ]");
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
        public int Delete(Models.MUserDetails model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CUserDetail";
            try
            {
                var query = from o in obj.UserDetails where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.UserDetails.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Value id[" + model.id + "] userId[" + model.userId + "] FirstName[" + model.FirstName + "] LastName[" + model.LastName + "] cellNo[" + model.cellNo + " ] phoneNo [ " + model.phoneNo + "] Address [" + model.Address + " ] emailId [ " + model.emailId + " ] CNIC [ " + model.CNIC + " ] eDate[ " + model.eDate + " ]");
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
        public List<Models.MUserDetails> GetAll()
        {
            List<Models.MUserDetails> model = new List<Models.MUserDetails>();
            var query = from o in obj.UserDetails select o;
            foreach (var item in query)
            {
                Models.MUserDetails m = new Models.MUserDetails();
                m.userId = Convert.ToString(item.userId);
                m.FirstName = item.FirstName;
                m.LastName = item.LastName;
                m.cellNo = item.cellNo;
                m.phoneNo = item.phoneNo;
                m.Address = item.Address;
                m.emailId = item.emailId;
                m.CNIC = item.CNIC;
                m.eDate = Convert.ToString(item.eDate);
                model.Add(m);
            }

            return model;
        }
        public List<Models.MUserDetails> GetAllbyid(int id)
        {
            List<Models.MUserDetails> model = new List<Models.MUserDetails>();
            var query = from o in obj.UserDetails where (o.id) == id select o;
            foreach (var item in query)
            {
                Models.MUserDetails m = new Models.MUserDetails();
                m.userId = Convert.ToString(item.userId);
                m.FirstName = item.FirstName;
                m.LastName = item.LastName;
                m.cellNo = item.cellNo;
                m.phoneNo = item.phoneNo;
                m.Address = item.Address;
                m.emailId = item.emailId;
                m.CNIC = item.CNIC;
                m.eDate = Convert.ToString(item.eDate);
                model.Add(m);
            }

            return model;
        }


    }
}