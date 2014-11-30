using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CClients
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public string ReturnClientNameById(string ClientId)
        {
            string ClientName = string.Empty;
            var query = (from o in obj.Clients
                         where o.id == Convert.ToInt32(ClientId)
                         select o.Name).FirstOrDefault();
            if (query != null)
            {
                ClientName = query.ToString();
            }
            return ClientName;
        }

        public int GetLastClientId()
        {
            var query = obj.Clients.OrderByDescending(o => o.id).FirstOrDefault();
            return Convert.ToInt32(query.id);

        }

        public int Save(Models.MClients model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CClients";
            try
            {

                DB.Client bs = new DB.Client();
                bs.id = Convert.ToInt32(model.id);
                bs.ClientTypeId = Convert.ToInt32(model.ClientTypeld);
                bs.Name = model.Name;
                bs.phone = model.phone;
                bs.EmailAddress = model.EmailAddress;
                bs.Address1 = model.Address1;
                bs.Address2 = model.Address2;
                bs.City = model.City;
                bs.isVendor = model.isVendor;
                bs.eDate = Convert.ToDateTime(model.edate);
                bs.WareHouseId = Convert.ToInt32(model.WareHouseId);
                bs.NIC = model.NIC;
                bs.GrantorName = model.GrantorName;
                bs.GrantorNIC = model.GrantorNIC;
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model id[" + model.id + "] ClientTypeId[" + model.ClientTypeld + "] Name[" + model.Name + "] phone[" + model.phone + "] EmailAddress[ " + model.EmailAddress + "] Address1 [" + model.Address1 + "] Address2 [" + model.Address2 + "] City [" + model.City + "] isVendor[ " + model.isVendor + "] eDate[ " + model.edate + "]");
                obj.Clients.InsertOnSubmit(bs);
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

        public int Update(Models.MClients model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CClients";
            try
            {
                var query = from o in obj.Clients where o.id == model.id select o;

                foreach (var item in query)
                {
                    item.ClientTypeId = int.Parse(model.ClientTypeld);
                    item.Name = model.Name;
                    item.EmailAddress = model.EmailAddress;
                    item.Address1 = model.EmailAddress;
                    item.Address2 = model.Address2;
                    item.City = model.City;
                    item.isVendor = model.isVendor;
                    item.eDate = Convert.ToDateTime(model.edate);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model id[" + model.id + "] ClientTypeId[" + model.ClientTypeld + "] Name[" + model.Name + "] phone[" + model.phone + "] EmailAddress[ " + model.EmailAddress + "] Address1 [" + model.Address1 + "] Address2 [" + model.Address2 + "] City [" + model.City + "] isVendor[ " + model.isVendor + "] eDate[ " + model.edate + "]");
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


        public int Delete(Models.MClients model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CClients";
            try
            {
                var query = from o in obj.Clients where o.id == model.id select o;
                foreach (var item in query)
                {
                    obj.Clients.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model id[" + model.id + "] ClientTypeId[" + model.ClientTypeld + "] Name[" + model.Name + "] phone[" + model.phone + "] EmailAddress[ " + model.EmailAddress + "] Address1 [" + model.Address1 + "] Address2 [" + model.Address2 + "] City [" + model.City + "] isVendor[ " + model.isVendor + "] eDate[ " + model.edate + "]");
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

        public string ReturnGrantorName(string CliendId)
        {
            string GrantorName = string.Empty;
            var q = (from o in obj.Clients
                     where o.id == Convert.ToInt32(CliendId)
                     select o.GrantorName).FirstOrDefault();
            GrantorName = q.ToString();
            return GrantorName;
        }
        public List<Models.MClients> GetAll()
        {
            List<Models.MClients> model = new List<Models.MClients>();
            var query = from o in obj.Clients select o;
            foreach (var item in query)
            {
                Models.MClients m = new Models.MClients();

                m.Name = item.Name;
                m.isVendor = Convert.ToBoolean(item.isVendor);
                m.Address1 = item.Address1;
                m.Address2 = item.Address2;
                m.EmailAddress = item.EmailAddress;
                m.id = item.id;
                m.phone = item.phone;
                m.City = item.City;
                m.ClientTypeld = (from a in obj.ClientTypes where a.id == item.ClientTypeId select a.Name).FirstOrDefault().ToString();
                m.WareHouseId = item.WareHouseId.ToString();
                m.NIC = item.NIC;
                m.GrantorName = item.GrantorName;
                m.GrantorNIC = item.GrantorNIC;
                model.Add(m);
            }

            return model;
        }





    }
}