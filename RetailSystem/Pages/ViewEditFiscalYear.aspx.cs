using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEditFiscalYear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
            }
        }

        protected void btnSetPurchase_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack && ddlFiscalYear.SelectedValue != "-1")
            {
                string[] GetDates = ddlFiscalYear.SelectedItem.Text.Split('-');
                DateTime from = Convert.ToDateTime(GetDates[0]);
                DateTime to = Convert.ToDateTime(GetDates[1]);
                Models.MFiscalYear mf = new Models.MFiscalYear();
                mf.fiscalFrom = from;
                mf.fiscalTo = to;
                int fiscalYearId = Convert.ToInt32(ddlFiscalYear.SelectedValue);
                Classes.CFiscalYear cf = new Classes.CFiscalYear();
                if (cf.UpdateDefaultFiscalYear(fiscalYearId) < 0)
                {
                    ShowFailMessage();
                }
                else
                {
                    ShowSuccessMessage();
                }
            }
            else
            {
                ShowErrorModal("Please select a fiscal year");
            }
        }

        private void ShowSuccessMessage()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalSuccess').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);

        }
        private void ShowFailMessage()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalDanger').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);
        }

        private Dictionary<int, string> BindDropDown()
        {
            List<Models.MFiscalYear> Get = new List<Models.MFiscalYear>();
            Dictionary<int, string> Data = new Dictionary<int, string>();
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            Get = cf.GetAll();
            Data.Add(-1, "Please select");
            for (int i = 0; i < Get.Count; i++)
            {
                Data.Add(Get[i].id, Get[i].fiscalFrom + "-" + Get[i].fiscalTo);
            }
            ddlFiscalYear.DataSource = Data;
            ddlFiscalYear.DataValueField = "Key";
            ddlFiscalYear.DataTextField = "Value";
            ddlFiscalYear.DataBind();

            return Data;
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