using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CTransactionType
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();
        public int Save(Models.MTransactionType model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CTransactionType";
            try
            {

                DB.TransactionType bs = new DB.TransactionType();
                bs.TransactionType1 = model.TransactionType;
                bs.id = Convert.ToInt32( model.id);
                bs.TransactionType1 = model.TransactionType;
                bs.ActionType = model.ActionType;

                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] TransactionType[" + model.TransactionType + "] ActionType[" + model.ActionType + "] ");
                obj.TransactionTypes.InsertOnSubmit(bs);
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
        public int Update(Models.MTransactionType model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CTransactionType";
            try
            {
                var query = from o in obj.TransactionTypes where Convert.ToString(o.id) == model.id select o;

                foreach (var item in query)
                {
                    item.TransactionType1 = model.TransactionType;
                    item.ActionType = model.ActionType;
                    
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] TransactionType[" + model.TransactionType + "] ActionType[" + model.ActionType + "] ");
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
        public int Delete(Models.MTransactionType model)
        {
            Common.Logger l = new Common.Logger();
            string ClassName = "CTransaction";
            try
            {
                var query = from o in obj.TransactionTypes where Convert.ToString(o.id) == model.id select o;
                foreach (var item in query)
                {
                    obj.TransactionTypes.DeleteOnSubmit(item);
                }
                l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] TransactionType[" + model.TransactionType + "] ActionType[" + model.ActionType + "] ");
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
        public List<Models.MTransactionType> GetAll()
        {
            List<Models.MTransactionType> model = new List<Models.MTransactionType>();
            var query = from o in obj.TransactionTypes select o;
            foreach (var item in query)
            {
                Models.MTransactionType m = new Models.MTransactionType();
                m.id = Convert.ToString(item.id);
                m.TransactionType = item.TransactionType1;
                m.ActionType = item.ActionType;
                
                model.Add(m);
            }

            return model;
        }
        public List<Models.MTransactionType> GetAllbyid(int id)
        {
            List<Models.MTransactionType> model = new List<Models.MTransactionType>();
            var query = from o in obj.TransactionTypes where (o.id) == id select o;
            foreach (var item in query)
            {
                Models.MTransactionType m = new Models.MTransactionType();
                m.id = Convert.ToString(item.id);
                m.TransactionType = item.TransactionType1;
                m.ActionType = item.ActionType;

                model.Add(m);
            }

            return model;
        }
    }
}