using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEditAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void grdAccountTransaction_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = grdAccountTransaction.Rows[index];

                lblAccountTransaction.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                txtBankId.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
                txtAccountNumber.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
                txtAccountTitle.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
                txtAccountHolderId.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text).ToString();
                
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);


            }
        }
        private void BindData()
        {
            Classes.CBankOfAccount cb = new Classes.CBankOfAccount();
            List<Models.MBankAccount> Get = new List<Models.MBankAccount>();
            Get = cb.GetAll();
            Get = Get.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            grdAccountTransaction.DataSource = Get;
            grdAccountTransaction.DataBind();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string AccountId = lblAccountTransaction.Text;
            string AccountNumber = txtAccountNumber.Text;
            string AccountTitle = txtAccountTitle.Text;
            string AccountHolderId = txtAccountHolderId.Text;
            string BankId = txtBankId.Text;
            Models.MBankAccount mv = new Models.MBankAccount();
            mv.id = AccountId;
            mv.BankId = BankId;
            mv.accountNumber = AccountNumber;
            mv.Accounttitle = AccountTitle;
            mv.AccountHolderId = AccountHolderId;
            mv.OpeningBalance = txtOpeningBalance.Text;
            mv.Balance = txtBalance.Text;

            Classes.CBankOfAccount ccv = new Classes.CBankOfAccount();
            if (ccv.Update(mv) < 0)
            {
                ShowFailMessage();
            }
            else
            {
                ShowSuccessMessage();
                BindData();
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