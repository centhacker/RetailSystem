using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CPaymentContainer
    {

        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.PaymentContainer model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPaymentContainer";
            try
            {

                DB.PaymentBankContainer bs = new DB.PaymentBankContainer();
                bs.id = Convert.ToInt32(model.id);
                bs.PaymentId = model.PaymentId;
                bs.BankId = model.BankId;
                bs.AmountRemaining = model.AmountRemaning;
               


                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PaymentId[" + model.PaymentId + "] BankId[" + model.BankId + "] AmountRemaining[" + model.AmountRemaning + "]  ");
                obj.PaymentBankContainers.InsertOnSubmit(bs);
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
        public int Update(Models.PaymentContainer model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPaymentContainer";
            try
            {
                var query = from o in obj.PaymentBankContainers where o.id == model.id select o;

                foreach (var item in query)
                {
                    item.PaymentId = model.PaymentId;
                    item.BankId = model.BankId;
                    item.AmountRemaining = model.AmountRemaning;
                    
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PaymentId[" + model.PaymentId + "] BankId[" + model.BankId + "] AmountRemaining[" + model.AmountRemaning + "]  ");
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
        public int Delete(Models.PaymentContainer model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPaymentContainer";
            try
            {
                var query = from o in obj.PaymentBankContainers where o.id == model.id select o;
                foreach (var item in query)
                {
                    obj.PaymentBankContainers.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PaymentId[" + model.PaymentId + "] BankId[" + model.BankId + "] AmountRemaining[" + model.AmountRemaning + "]  ");
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
        public List<Models.PaymentContainer> GetAll()
        {
            List<Models.PaymentContainer> model = new List<Models.PaymentContainer>();
            var query = from o in obj.PaymentBankContainers select o;
            foreach (var item in query)
            {
                Models.PaymentContainer m = new Models.PaymentContainer();
                m.id = item.id;
                m.PaymentId = Convert.ToInt32(item.PaymentId);
                m.BankId = Convert.ToInt32(item.BankId);
                m.AmountRemaning = item.AmountRemaining;
               

                model.Add(m);
            }

            return model;
        }
        public List<Models.PaymentContainer> GetAllbyid(int id)
        {
            List<Models.PaymentContainer> model = new List<Models.PaymentContainer>();
            var query = from o in obj.PaymentBankContainers where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.PaymentContainer m = new Models.PaymentContainer();
                m.id = item.id;
                m.PaymentId = Convert.ToInt32(item.PaymentId);
                m.BankId = Convert.ToInt32(item.BankId);
                m.AmountRemaning = item.AmountRemaining;
                model.Add(m);
            }

            return model;
        }
    }
}