using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CPaymentLine
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        public int Save(Models.PaymentLine model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPaymentLine";
            try
            {

                DB.PaymentLine bs = new DB.PaymentLine();
                bs.id = Convert.ToInt32(model.id);
                bs.PaymentId = model.PaymentId;
                bs.PaidAmount = model.PaidAmount;
                bs.BankId = model.BankId;
                bs.PaidAmount = model.PaidAmount;
                bs.RemainingAmount = model.RemainingAmount;
                bs.CumulativeAmount = model.CumulativeAmount;
                bs.Date = Convert.ToDateTime(model.Date);
                bs.ModeOfPayment = model.ModeOfPayment;
                bs.Cheque = model.Cheque;
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PaymentId[" + model.PaymentId + "] PaidAmount[" + model.PaidAmount + "]  ");
                obj.PaymentLines.InsertOnSubmit(bs);
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

        public float LastPaidAmount(int PaymentId)
        {
            float PaidAmount = 0;
            try
            {
                var query = (from o in obj.PaymentLines
                             where o.PaymentId == PaymentId
                             orderby o.PaymentId descending
                             select o.PaidAmount).FirstOrDefault();
                if (query != null)
                {
                    PaidAmount = Convert.ToSingle(query);
                }

                return PaidAmount;
            }
            catch
            {
                return 0;
            }

        }

        public int Update(Models.PaymentLine model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPaymentLine";
            try
            {
                var query = from o in obj.PaymentLines where o.id == model.id select o;

                foreach (var item in query)
                {
                    item.PaymentId = model.PaymentId;
                    item.PaidAmount = model.PaidAmount;

                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PaymentId[" + model.PaymentId + "] PaidAmount[" + model.PaidAmount + "]  ");
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
        public int Delete(Models.PaymentLine model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CPaymentLine";
            try
            {
                var query = from o in obj.PaymentLines where o.id == model.id select o;
                foreach (var item in query)
                {
                    obj.PaymentLines.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] PaymentId[" + model.PaymentId + "] PaidAmount[" + model.PaidAmount + "]  ");
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
        public List<Models.PaymentLine> GetAll()
        {
            List<Models.PaymentLine> model = new List<Models.PaymentLine>();
            var query = from o in obj.PaymentLines select o;
            foreach (var item in query)
            {
                Models.PaymentLine m = new Models.PaymentLine();
                m.id = item.id;
                m.PaymentId = Convert.ToInt32(item.PaymentId);
                m.PaidAmount = item.PaidAmount;
                m.ModeOfPayment = item.ModeOfPayment;
                m.RemainingAmount = item.RemainingAmount;
                m.BankId = Convert.ToInt32(item.BankId);
                m.Cheque = item.Cheque;
                m.CumulativeAmount = item.CumulativeAmount;
                m.Date = Convert.ToDateTime(item.Date).ToShortDateString();
                model.Add(m);
            }

            return model;
        }
        public List<Models.PaymentLine> GetAllbyid(int id)
        {
            List<Models.PaymentLine> model = new List<Models.PaymentLine>();
            var query = from o in obj.PaymentLines where Convert.ToString(o.id) == id.ToString() select o;
            foreach (var item in query)
            {
                Models.PaymentLine m = new Models.PaymentLine();
                m.id = item.id;
                m.PaymentId = Convert.ToInt32(item.PaymentId);
                m.PaidAmount = item.PaidAmount;

                model.Add(m);
            }

            return model;
        }
    }
}