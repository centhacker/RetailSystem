using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class AddBank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }


        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
           
            if (Page.IsValid)
            {
                string BankName = txtBankName.Text;
                string BankBranch = txtBankBranch.Text;
                string BankBranchCode = txtBankBranchCode.Text;
                string BankTelePhoneNnumber = txtBankTelephoneNumber.Text;
                string BankEmailAddress = txtBankEmailAddress.Text;
                Models.MBank mv = new Models.MBank();
                mv.Name = BankName;
                mv.Branch = BankBranch;
                mv.BranchCode = BankBranchCode;
                mv.TelephoneNumber = BankTelePhoneNnumber;
                mv.EmailAddress = BankEmailAddress;
                
                Classes.CBank ccv = new Classes.CBank();
                if (ccv.Save(mv) < 0)
                {
                    ShowFailMessage();
                }
                else
                {
                    ShowSuccessMessage();
                    ClearTextBoxes(Page);
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
