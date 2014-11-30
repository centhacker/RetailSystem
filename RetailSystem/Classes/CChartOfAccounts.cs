using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CChartOfAccounts
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MChartOfAccounts Models)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CChartOfAccounts";
            try
            {
                DB.ChartOfAccount bs = new DB.ChartOfAccount();
                bs.num = Models.num;
                bs.name = Models.name;
                bs.type = Models.type;
                bs.e_date = Convert.ToDateTime(Models.e_date);

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values num[" + Models.num + "] name[" + Models.name + "] type[" + Models.type + "] e_date[" + Models.e_date + "] id[ " + Models.id + "]");

                obj.ChartOfAccounts.InsertOnSubmit(bs);
                obj.SubmitChanges();
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Inserted Sucessfully");

                return 1;
            }

            catch (Exception ex)
            {

                l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
                return -1;
            }


        }
        public int Update(Models.MChartOfAccounts models)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CChartOfAccounts";
            try
            {
                var query = from o in obj.ChartOfAccounts where Convert.ToString(o.id) == models.id select o;
                foreach (var item in query)
                {
                    item.num = models.num;
                    item.name = models.name;
                    item.type = models.type;
                    item.e_date = Convert.ToDateTime(models.e_date);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + models.id + "] num[" + models.num + "] name[" + models.name + "] type[" + models.type + "] e_date[" + models.e_date + "]");
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
        public int Delete(Models.MChartOfAccounts model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CChartOFAccount";
            try
            {
                var query = from o in obj.ChartOfAccounts where o.id == Convert.ToInt32(model.id) select o;
                foreach (var item in query)
                {
                    obj.ChartOfAccounts.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "id[" + model.id + "] num[" + model.num + "] name[" + model.name + "] type[" + model.type + "] e_date[" + model.e_date + "]");
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
        public List<Models.MChartOfAccounts> GetAll()
        {
            List<Models.MChartOfAccounts> model = new List<Models.MChartOfAccounts>();
            var query = from o in obj.ChartOfAccounts select o;
            foreach (var item in query)
            {
                Models.MChartOfAccounts m = new Models.MChartOfAccounts();
                m.id = Convert.ToString(item.id);
                m.num = item.num;
                m.name = item.name;
                m.type = item.type;
                m.e_date = Convert.ToString(item.e_date);
                model.Add(m);
            }

            return model;
        }

        public List<Models.MChartOfAccounts> GetAllbyid(int id)
        {
            List<Models.MChartOfAccounts> model = new List<Models.MChartOfAccounts>();
            var query = from o in obj.ChartOfAccounts where o.id == id select o;
            foreach (var item in query)
            {
                Models.MChartOfAccounts m = new Models.MChartOfAccounts();
                m.id = Convert.ToString(item.id);
                m.num = item.num;
                m.name = item.name;
                m.type = item.type;
                m.e_date = Convert.ToString(item.e_date);
                model.Add(m);
            }

            return model;
        }




    }
}