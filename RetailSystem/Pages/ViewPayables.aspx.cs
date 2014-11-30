using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewPayables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid(); BindDdl();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlVendor.SelectedValue != "-1")
            {
                BindGrid(Convert.ToInt32(ddlVendor.SelectedValue));
            }
            else
            {
                ShowErrorModal("Please select vendor");
            }
        }

        private void BindGrid()
        {
            Classes.CPayment cp = new Classes.CPayment();
            List<Models.MOrderViewOfPayment> Payments = new List<Models.MOrderViewOfPayment>();
            Payments = cp.ShowVendorOrderViewForPayment();
            int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            List<DateTime> Dates = cf.GetDefaultDatesById(FiscalYearId);
            Payments = (from o in Payments
                        where Convert.ToDateTime(o.OrderDate) >= Dates[0] && Convert.ToDateTime(o.OrderDate) <= Dates[1]
                        select o).ToList();
            grdRec.DataSource = Payments;
            grdRec.DataBind();

        }
        private void BindGrid(int VendorId)
        {
            Classes.CPayment cp = new Classes.CPayment();
            List<Models.MOrderViewOfPayment> Payments = new List<Models.MOrderViewOfPayment>();
            Payments = cp.ShowVendorOrderViewForPayment(VendorId);
            grdRec.DataSource = Payments;
            grdRec.DataBind();

        }

        private void BindDdl()
        {
            Classes.CVendor cv = new Classes.CVendor();
            Dictionary<int, string> VendorData = new Dictionary<int, string>();
            List<Models.MVendor> get = new List<Models.MVendor>();
            get = cv.GetAll();
            VendorData.Add(-1, "Please Select");
            for (int i = 0; i < get.Count; i++)
            {
                VendorData.Add(Convert.ToInt32(get[i].id), get[i].name);

            }
            ddlVendor.DataTextField = "Value";
            ddlVendor.DataValueField = "Key";
            ddlVendor.DataSource = VendorData;
            ddlVendor.DataBind();

        }

        private void ShowErrorModal(string Error)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Font.Bold = true;
            lblError.Text = Error;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalError').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }



    }
}