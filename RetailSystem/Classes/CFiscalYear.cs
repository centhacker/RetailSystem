using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CFiscalYear
    {
        private DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.MFiscalYear model)
        {
            try
            {
                DB.FiscalYear fy = new DB.FiscalYear();
                fy.fiscalFrom = model.fiscalFrom;
                fy.fiscalTo = model.fiscalTo;
                obj.FiscalYears.InsertOnSubmit(fy);
                obj.SubmitChanges();


                //Setting the newly added fiscal year as default
                UpdateDefaultFiscalYear(GetLastFiscalYearId());
                return 1;
            }
            catch
            {

                return -1;
            }
        }
       
        public List<DateTime> GetDefaultDatesById(int fiscalYearId)
        {
            List<DateTime> Get = new List<DateTime>();
            var from = (from o in obj.FiscalYears
                        where o.id == fiscalYearId
                        select o.fiscalFrom).FirstOrDefault();
            Get.Add(Convert.ToDateTime(from));
            var to = (from o in obj.FiscalYears
                        where o.id == fiscalYearId
                        select o.fiscalTo).FirstOrDefault();
            Get.Add(Convert.ToDateTime(to));
            return Get;
        }

        public List<Models.MFiscalYear> GetAll()
        {
            List<Models.MFiscalYear> Get = new List<Models.MFiscalYear>();
            var query = from o in obj.FiscalYears
                        select
                            o;
            foreach (var item in query)
            {
                Models.MFiscalYear mf = new Models.MFiscalYear();
                mf.id = item.id;
                mf.fiscalFrom = Convert.ToDateTime(item.fiscalFrom);
                mf.fiscalTo = Convert.ToDateTime(item.fiscalTo);
                Get.Add(mf);
            }

            return Get;
        }

        public List<Models.MFiscalYear> GetAllById(int FiscalYear)
        {
            List<Models.MFiscalYear> Get = new List<Models.MFiscalYear>();
            var query = from o in obj.FiscalYears
                        where o.id == FiscalYear
                        select
                            o;
            foreach (var item in query)
            {
                Models.MFiscalYear mf = new Models.MFiscalYear();
                mf.fiscalFrom = Convert.ToDateTime(item.fiscalFrom);
                mf.fiscalTo = Convert.ToDateTime(item.fiscalTo);
                Get.Add(mf);
            }

            return Get;
        }

        public int Update(Models.MFiscalYear model)
        {
            try
            {
                var query = from o in obj.FiscalYears where model.id == o.id select o;
                foreach (var item in query)
                {
                    item.fiscalFrom = model.fiscalFrom;
                    item.fiscalTo = model.fiscalTo;

                }
                obj.SubmitChanges();
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }
        }
        public int GetLastFiscalYearId()
        {
            try
            {
                var query = obj.FiscalYears.OrderByDescending(o => o.id).FirstOrDefault();
                if (query != null)
                {
                    return query.id;
                }
                else
                {
                    return -1;
                }

            }
            catch
            {

                return -1;
            }
        }

        public int CheckFiscalYear()
        {
            try
            {
                var query = from o in obj.FiscalYears select o;
                var fiscal = from o in obj.DefaultFiscalYears select o;
                if (fiscal.Count() <= 0 || query.Count() <= 0)
                {
                    return -1;
                }
                else
                {
                    int fiscalYearId = 0;
                    fiscalYearId = Convert.ToInt32((from o in obj.DefaultFiscalYears select o.DefaultfiscalYear1).FirstOrDefault());

                    return fiscalYearId;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int UpdateDefaultFiscalYear(int FiscalYearId)
        {
            try
            {
                var query = from o in obj.DefaultFiscalYears select o;
                if (query.Count() <= 0)
                {
                    DB.DefaultFiscalYear df = new DB.DefaultFiscalYear();
                    df.DefaultfiscalYear1 = FiscalYearId;
                    obj.DefaultFiscalYears.InsertOnSubmit(df);
                    obj.SubmitChanges();
                }
                else
                {
                    var GetFiscal = from o in obj.DefaultFiscalYears
                                    where o.DefaultfiscalYear1 == FiscalYearId
                                    select o;
                    foreach (var item in GetFiscal)
                    {
                        item.DefaultfiscalYear1 = FiscalYearId;
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
    }
}