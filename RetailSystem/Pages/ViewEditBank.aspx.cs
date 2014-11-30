using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEditBank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void grdBank_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = grdBank.Rows[index];

                lblBank.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                txtBankName.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
                txtBankBranch.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
                txtBankBranchCode.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
                txtBankTelephoneNumber.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text).ToString();
                txtBankEmailAddress.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text).ToString();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);


            }
        }

        private void BindData()
        {
            Classes.CBank cb = new Classes.CBank();
            grdBank.DataSource = cb.GetAll(); 
            grdBank.DataBind();
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
            string BankId = lblBank.Text;
            string BankName = txtBankName.Text;
            string BankBranch = txtBankBranch.Text;
            string BankBranchCode = txtBankBranchCode.Text;
            string BankTelePhoneNnumber = txtBankTelephoneNumber.Text;
            string BankEmailAddress = txtBankEmailAddress.Text;
            Models.MBank mv = new Models.MBank();
            mv.id = BankId;
            mv.Name = BankName;
            mv.Branch = BankBranch;
            mv.BranchCode = BankBranchCode;
            mv.TelephoneNumber = BankTelePhoneNnumber;
            mv.EmailAddress = BankEmailAddress;

            Classes.CBank ccv = new Classes.CBank();
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

        protected void grdWareHouse_RowCommand(object sender, GridViewCommandEventArgs e)
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