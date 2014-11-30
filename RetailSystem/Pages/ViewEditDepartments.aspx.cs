using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEditDepartments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdDepartments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = grdDepartments.Rows[index];

                lblDepartmentId.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                txtDepartmentName.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
                txtDepartmentAddress.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void BindData()
        {
            Classes.CDepartment cb = new Classes.CDepartment();
            grdDepartments.DataSource = cb.GetAll();
            grdDepartments.DataBind();

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