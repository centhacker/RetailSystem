using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class SetDefaultFiscalYear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDdl();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int FiscalYearId = 0;
            if (Page.IsPostBack && Convert.ToInt32(ddlFiscalYear.SelectedValue) != -1)
            {
                Classes.CFiscalYear cf = new Classes.CFiscalYear();
                FiscalYearId = Convert.ToInt32(ddlFiscalYear.SelectedValue);
                if (cf.UpdateDefaultFiscalYear(FiscalYearId) < 0)
                {
                    ShowFailMessage();
                }
                else
                {
                    ShowSuccessMessage();
                    UpdateCacheAndSession(FiscalYearId, ddlFiscalYear.SelectedItem.Text);
                }
            }
            else
            {
                ShowErrorModal("Please select a fiscal Year");
            }
        }

        private void UpdateCacheAndSession(int FiscalYearId, string FiscalYear)
        {
            Session["FiscalYear"] = FiscalYearId;
            Cache["FiscalYear"] = FiscalYear;
        }
        private void BindDdl()
        {
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            List<Models.MFiscalYear> FY = new List<Models.MFiscalYear>();
            FY = cf.GetAll();

            Dictionary<int, string> Get = new Dictionary<int, string>();
            Get.Add(-1, "Please select");
            for (int i = 0; i < FY.Count; i++)
            {
                Get.Add(FY[i].id, FY[i].fiscalFrom.ToShortDateString() + "--" + FY[i].fiscalTo.ToShortDateString());
            }
            ddlFiscalYear.DataValueField = "Key";
            ddlFiscalYear.DataTextField = "Value";
            ddlFiscalYear.DataSource = Get;
            ddlFiscalYear.DataBind();
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

        private void ShowSuccessMessage()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalSuccess').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);

        }
        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }
        private void ShowFailMessage()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalDanger').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);
        }
    }
}