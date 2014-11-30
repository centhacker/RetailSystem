using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewGeneralJourna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            Classes.CViewClasses.CViewGeneralJournal cj = new Classes.CViewClasses.CViewGeneralJournal();
            List<Models.MViewModels.MGeneralJournal> gj = new List<Models.MViewModels.MGeneralJournal>();
            int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            List<DateTime> Dates = cf.GetDefaultDatesById(FiscalYearId);
            gj = cj.GetAll();
            gj = (from o in gj
                  where Convert.ToDateTime(o.Date) >= Dates[0] && Convert.ToDateTime(o.Date) <= Dates[1]
                  select o).ToList();
            grdRec.DataSource = gj;
            grdRec.DataBind();
        }
    }
}