using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class CDesignation
    {
        DB.DBContextDataContext obj = new DB.DBContextDataContext();

        //public int Save(Models.MDesignation model)
        //{
        //    //Common.Logger l = new Common.Logger();
        //    //string ClassName = "CDesignation";
        //    //try
        //    //{

        //    //    DB.Designation bs = new DB.Designation();
        //    //    bs.id = Convert.ToInt32(model.id);
        //    //    bs.DesignationName = model.DesignationName;
        //    //    bs.RoleId = Convert.ToInt32(model.RoleId);
                

        //    //    l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] DesignationName[" + model.DesignationName + "] RoleId[" + model.RoleId + "] ");
        //    //    obj.Designations.InsertOnSubmit(bs);
        //    //    obj.SubmitChanges();
        //    //    l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Inserted Successfully");
        //    //    return 1;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
        //    //    return -1;
        //    //}
        //}
        //public int Update(Models.MDesignation model)
        //{
        //    Common.Logger l = new Common.Logger();
        //    string ClassName = "CDesignation";
        //    try
        //    {
        //        var query = from o in obj.Designations where Convert.ToString(o.id) == model.id select o;

        //        foreach (var item in query)
        //        {
        //            item.DesignationName = Convert.ToString(model.DesignationName);
        //            item.RoleId = Convert.ToInt32(model.RoleId);
                   
        //        }
        //        l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] DesignationName[" + model.DesignationName + "] RoleId[" + model.RoleId + "] ");
        //        obj.SubmitChanges();
        //        l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Updated Successfully");
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
        //        return -1;
        //    }
        //}
        //public int Delete(Models.MDesignation model)
        //{
        //    Common.Logger l = new Common.Logger();
        //    string ClassName = "CDesignation";
        //    try
        //    {
        //        var query = from o in obj.Designations where Convert.ToString(o.id) == model.id select o;
        //        foreach (var item in query)
        //        {
        //            obj.Designations.DeleteOnSubmit(item);
        //        }
        //        l.Print(ClassName, Common.LogPointer.Info.ToString(), "Model Values id[" + model.id + "] DesignationName[" + model.DesignationName + "] RoleId[" + model.RoleId + "] ");
        //        obj.SubmitChanges();
        //        l.Print(ClassName, Common.LogPointer.Info.ToString(), "Record Deleted Successfully");
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        l.Print(ClassName, Common.LogPointer.Error.ToString(), ex.ToString());
        //        return -1;
        //    }
        //}
        //public List<Models.MDesignation> GetAll()
        //{
        //    List<Models.MDesignation> model = new List<Models.MDesignation>();
        //    var query = from o in obj.Designations select o;
        //    foreach (var item in query)
        //    {
        //        Models.MDesignation m = new Models.MDesignation();
        //        m.id = Convert.ToString(item.id);
        //        m.DesignationName = item.DesignationName;
        //        m.RoleId = Convert.ToString(item.RoleId);
                
        //        model.Add(m);
        //    }

        //    return model;
        //}
        //public List<Models.MDesignation> GetAllbyid(int id)
        //{
        //    List<Models.MDesignation> model = new List<Models.MDesignation>();
        //    var query = from o in obj.Designations where Convert.ToString(o.id) == id.ToString() select o;
        //    foreach (var item in query)
        //    {
        //        Models.MDesignation m = new Models.MDesignation();
        //        m.id = Convert.ToString(item.id);
        //        m.DesignationName = item.DesignationName;
        //        m.RoleId = Convert.ToString(item.RoleId);
        //    }

        //    return model;
        //}



    }
}