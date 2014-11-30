using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ShowPaidSalary : System.Web.UI.Page
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
            List<Models.MPaidSalary> Get = new List<Models.MPaidSalary>();
            Get = (List<Models.MPaidSalary>)HttpContext.Current.Cache["PaidSalary"];
            if (Get == null)
            {
                Classes.CPaidSalary cp = new Classes.CPaidSalary();
                Get = cp.GetAll();
                HttpContext.Current.Cache["PaidSalary"] = Get;
            }
            int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            List<DateTime> Dates = cf.GetDefaultDatesById(FiscalYearId);
            Get = (from o in Get
                  where Convert.ToDateTime(o.MonthPaid) >= Dates[0] && Convert.ToDateTime(o.MonthPaid) <= Dates[1]
                  select o).ToList();

            grdVendor.DataSource = Get;
            grdVendor.DataBind();
        }
    }
}