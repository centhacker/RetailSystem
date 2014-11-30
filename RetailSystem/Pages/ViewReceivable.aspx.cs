using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewReceivable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid(); BindDdl();
            }
        }

        private void BindGrid()
        {
            Classes.CPayment cp = new Classes.CPayment();
            List<Models.MOrderViewOfPayment> Payments = new List<Models.MOrderViewOfPayment>();
            Payments = cp.ShowClientOrderViewForPayment();
            int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            List<DateTime> Dates = cf.GetDefaultDatesById(FiscalYearId);
            Payments = (from o in Payments
                        where Convert.ToDateTime(o.OrderDate) >= Dates[0] && Convert.ToDateTime(o.OrderDate) <= Dates[1]
                        select o).ToList();
            grdRec.DataSource = Payments;
            grdRec.DataBind();

        }

        private void BindGrid(int clientId)
        {
            Classes.CPayment cp = new Classes.CPayment();
            List<Models.MOrderViewOfPayment> Payments = new List<Models.MOrderViewOfPayment>();
            Payments = cp.ShowClientOrderViewForPayment(clientId);
            grdRec.DataSource = Payments;
            grdRec.DataBind();

        }

        private void BindDdl()
        {
            Dictionary<int, string> Items = new Dictionary<int, string>();
            List<Models.MClients> get = new List<Models.MClients>();
            Classes.CClients cw = new Classes.CClients();
            get = cw.GetAll();
            Items.Add(-1, "Please select Clients");
            for (int i = 0; i < get.Count; i++)
            {
                int id = get[i].id;
                string name = get[i].Name;
                Items.Add(Convert.ToInt32(id), name);

            }
            ddlClient.DataTextField = "Value";
            ddlClient.DataValueField = "Key";
            ddlClient.DataSource = Items;
            ddlClient.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlClient.SelectedValue != "-1")
            {
                BindGrid(Convert.ToInt32(ddlClient.SelectedValue));
            }
            else
            {
                ShowErrorModal("Please select a client");
            }
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