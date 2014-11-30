using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewCashInHand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void grdAccountTransaction_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        private void BindGrid()
        {
            Classes.CViewClasses.CViewCashInHand cvh = new Classes.CViewClasses.CViewCashInHand();
            List<Models.MViewModels.MViewCashInHand> Get = new List<Models.MViewModels.MViewCashInHand>();
            int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            List<DateTime> Dates = cf.GetDefaultDatesById(FiscalYearId);
            Get = cvh.GetAll(Convert.ToInt32(FiscalYearId));
            float totalCashInhand = 0;
            for (int i = 0; i < Get.Count; i++)
            {
                totalCashInhand += Convert.ToSingle(Get[i].Total);
            }
            lblTotal.Text = totalCashInhand.ToString();
            grdAccountTransaction.DataSource = Get;
            grdAccountTransaction.DataBind();

        }
    }
}