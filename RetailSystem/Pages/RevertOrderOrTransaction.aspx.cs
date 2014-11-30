using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class RevertOrderOrTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrids();
            }
        }

        protected void grdOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("revert"))
            {
                int OrderId = Convert.ToInt32(grdOrders.Rows[index].Cells[0].Text);
                lblOrderConfirm.Text = OrderId.ToString();
                string QueryString = "?OrderId=" + OrderId.ToString();
                Response.Redirect("~/Pages/RevertConfirmPage.aspx" + QueryString);
            }
        }

        protected void grdTransactions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("revert"))
            {

                int TransactionId = Convert.ToInt32(grdTransactions.Rows[index].Cells[0].Text);
                lblTransactionConfirm.Text = TransactionId.ToString();
                ShowTransactionConfirmDialogue();
            }
        }
        protected void btnOrderConfirmYes_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Classes.CRevertInventory cr = new Classes.CRevertInventory();
                int OrderId = Convert.ToInt32(lblOrderConfirm.Text);
                if (cr.RevertOrderTransaction(OrderId) > 0)
                {
                    ShowSuccessMessage();
                    BindGrids();
                }
                else
                {
                    ShowFailMessage();
                }
            }
        }

        protected void btnTransactionConfirm_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Classes.CRevertInventory cr = new Classes.CRevertInventory();
                int TransactionId = Convert.ToInt32(lblTransactionConfirm.Text);
                if (cr.RevertSingleTransaction(TransactionId) > 0)
                {
                    ShowSuccessMessage();
                    BindGrids();
                }
                else
                {
                    ShowFailMessage();
                }
            }
        }


        #region Private Events
        private void BindGrids()
        {
            Classes.CViewClasses.CViewTransactions cst = new Classes.CViewClasses.CViewTransactions();
            Classes.COrders co = new Classes.COrders();
            List<Models.MOrders> OrderTransactions = new List<Models.MOrders>();
            List<Models.MViewModels.MViewTransactions> JournalTransactions = new List<Models.MViewModels.MViewTransactions>();
            JournalTransactions = cst.GetAll();
            OrderTransactions = co.GetAll();
            JournalTransactions = (from o in JournalTransactions
                                   where o.OrderId == "-1"
                                   select o).ToList();
            grdOrders.DataSource = OrderTransactions;
            grdOrders.DataBind();
            grdTransactions.DataSource = JournalTransactions;
            grdTransactions.DataBind();

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
        private void ShowOrderConfirmDialogue()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#OrderConfirm').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);
        }
        private void ShowTransactionConfirmDialogue()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#TransactionConfirm').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);
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
        #endregion

        protected void grdOrderConfirm_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }




    }
}