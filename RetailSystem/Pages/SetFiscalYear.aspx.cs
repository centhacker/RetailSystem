using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class SetFiscalYear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && IsPostBack)
            {
                DateTime from = Convert.ToDateTime(txtFrom.Text);
                DateTime to = Convert.ToDateTime(txtTo.Text);
                Models.MFiscalYear mf = new Models.MFiscalYear();
                mf.fiscalFrom = from;
                mf.fiscalTo = to;
                Classes.CFiscalYear cf = new Classes.CFiscalYear();
                if (cf.Save(mf) > 0)
                {
                    Response.Redirect("~/Pages/Main.aspx");
                }
                else
                {
                    
                    ShowErrorModal("there was an error saving the new fiscal year");
                }
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