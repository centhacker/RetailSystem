using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewPaidSalary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid() 
        { 
            List<Models.MViewModels.MviewPaidSalary> Get = new List<Models.MViewModels.MviewPaidSalary>();
            Classes.CViewClasses.CViewPaidSalary cp = new Classes.CViewClasses.CViewPaidSalary();
            Get = cp.GetAll();
            Get = Get.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            List<DateTime> Dates = cf.GetDefaultDatesById(FiscalYearId);
            Get = (from o in Get
                   where Convert.ToDateTime(o.Month) >= Dates[0] && Convert.ToDateTime(o.Month) <= Dates[1]
                   
                   select o).ToList();
            grdRec.DataSource = Get;
            grdRec.DataBind();
        }
    }
}