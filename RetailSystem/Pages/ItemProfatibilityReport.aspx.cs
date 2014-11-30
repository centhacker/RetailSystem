using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ItemProfatibilityReport : System.Web.UI.Page
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
            Classes.CViewClasses.CViewItemProfatibilityReport cvp = new Classes.CViewClasses.CViewItemProfatibilityReport();
            List<Models.MViewModels.MItemProfatibilityReport> Get = new List<Models.MViewModels.MItemProfatibilityReport>();
            int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            List<DateTime> Dates = cf.GetDefaultDatesById(FiscalYearId);
            Get = cvp.GetAll(Dates[0],Dates[1]);
            grdAccountTransaction.DataSource = Get;
            grdAccountTransaction.DataBind();
        }
    }
}