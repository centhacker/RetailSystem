using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem
{
    public partial class RevertConfirmPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderId"].ToString()))
                {
                    string OrderId = Request.QueryString["OrderId"].ToString();
                    BindGrid(Convert.ToInt32(OrderId));
                }


            }
        }

        protected void grdOrderConfirm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("revert"))
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderId"].ToString()))
                {
                    int OrderId = Convert.ToInt32(Request.QueryString["OrderId"].ToString());
                    int ProductId = Convert.ToInt32(grdOrderConfirm.Rows[index].Cells[0].Text);
                    int Units = Convert.ToInt32(grdOrderConfirm.Rows[index].Cells[0].Text);
                    Classes.CRevertInventory cv = new Classes.CRevertInventory();
                    if (cv.RevertOrderTransaction(OrderId, Units, ProductId) > 0)
                    {
                        ShowSuccessMessage();
                        BindGrid(OrderId);
                    }
                    else
                    {

                    }
                }


            }
        }


        private void BindGrid(int OrderId)
        {
            Classes.CRevertInventory cri = new Classes.CRevertInventory();
            List<Models.MRevertInventory.RevertConfirm> GetAll = new List<Models.MRevertInventory.RevertConfirm>();
            GetAll = cri.GetAllConfirm(OrderId);
            grdOrderConfirm.DataSource = GetAll;
            grdOrderConfirm.DataBind();
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
        protected void txtCp_DataBinding(object sender, EventArgs e)
        {

        }
    }
}