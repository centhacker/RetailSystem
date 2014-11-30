using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CUserWareHouseContainer
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

     

        public int Save(Models.MUserWareHouseContainer model)
        {
            try
            {
                DB.UserWareHouseContainer uw = new DB.UserWareHouseContainer();
                var query = from o in obj.UserWareHouseContainers
                            where o.UserId == Convert.ToInt32(model.UserId)
                            select o;
                if (query.Count() == 0)
                {
                    uw.UserId = Convert.ToInt32(model.UserId);
                    uw.WareHouseId = Convert.ToInt32(model.WareHouseId);
                    obj.UserWareHouseContainers.InsertOnSubmit(uw);
                    obj.SubmitChanges();
                }
                else
                {
                    foreach (var item in query)
                    {
                        item.WareHouseId = Convert.ToInt32(model.WareHouseId);
                    }
                    obj.SubmitChanges();
                }


                return 1;
            }
            catch
            {

                return -1;
            }
        }

        

        public string GetWareHouseNameByUserId(string UserId)
        {
            string WareHouseName = string.Empty;
            var query = (from o in obj.UserWareHouseContainers
                         where
                             o.UserId == Convert.ToInt32(UserId)
                         select o.WareHouseId).FirstOrDefault();
            if (query == null)
            {
                WareHouseName = "No WareHouse Associated";
            }
            else
            {
                CWareHouse cw = new CWareHouse();
                WareHouseName = cw.GetWareHouseNameById(Convert.ToInt32(query));

            }
            return WareHouseName;

        }
        public string GetWareHouseIdByUserId(string UserId)
        {
            string WareHouseName = string.Empty;
            var query = (from o in obj.UserWareHouseContainers
                         where
                             o.UserId == Convert.ToInt32(UserId)
                         select o.WareHouseId).FirstOrDefault();
            if (query == null)
            {
                WareHouseName = "No WareHouse Associated";
            }
            else
            {
                CWareHouse cw = new CWareHouse();
                WareHouseName = query.ToString();

            }
            return WareHouseName;

        }
    }
}