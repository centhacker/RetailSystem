using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ApproveUserIds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Classes.CUsers cu = new Classes.CUsers();
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvrow = grdUsers.Rows[index];
            int userId = Convert.ToInt32(HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString());
            string userName = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
            int rc = 0;
            if (e.CommandName.Equals("approve"))
            {
                rc = cu.ApproveUsers(userId);
                if ( rc > 0)
                {
                    lblError.ForeColor = System.Drawing.Color.Green;
                    ShowMessage("The User[" + userName + "] has been Approved");
                    BindGrid();
                }
                else 
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    ShowMessage("The User[" + userName + "] has not been Approved Kindly refresh the page and try again");
                }
                
               
            }
            else if (e.CommandName.Equals("notapprove"))
            {
                if (cu.RejectUsers(userId) > 0)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;

                    ShowMessage("The User[" + userName + "] has been Rejected");
                    BindGrid();
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;

                    ShowMessage("The User[" + userName + "] has not been Rejected Kindly Refresh the page and try again");
                    BindGrid();
                }
                
            }
        }

        protected void grdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        private void ShowMessage(string Message)
        {
            lblError.Text = Message;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);
        }
        private void BindGrid()
        {
            Classes.CUsers cu = new Classes.CUsers();
            grdUsers.DataSource = cu.GetUnApprovedUsers();
            grdUsers.DataBind();

        }

        protected void grdUsers_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {

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