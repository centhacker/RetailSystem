using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class AddFiscalYear : System.Web.UI.Page
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
                    ShowSuccessMessage();
                }
                else
                {
                    ShowFailMessage();
                }
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
    }
}