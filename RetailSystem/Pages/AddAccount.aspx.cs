using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class AddAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropDown();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                if (Convert.ToInt32(ddlBankId.SelectedValue) > 0)
                {


                    string AccountBankId = ddlBankId.SelectedValue;
                    string AccountNumber = txtAccountNumber.Text;
                    string AccountTitle = txtAccountTitle.Text;
                    string AccountHolderId = txtAccountHolderId.Text;
                    string OpeningDate = txtBeginDate.Text;
                    string OpeningBalance = txtOpeningBalance.Text;
                    Models.MBankAccount mv = new Models.MBankAccount();
                    mv.BankId = AccountBankId;
                    mv.accountNumber = AccountNumber;
                    mv.Accounttitle = AccountTitle;
                    mv.AccountHolderId = AccountHolderId;
                    mv.BeginDate = OpeningDate;
                    mv.OpeningBalance = OpeningBalance;
                    mv.Balance = OpeningBalance;
                    mv.WareHouseId = Session["WareHouse"].ToString();
                    Classes.CBankOfAccount ccv = new Classes.CBankOfAccount();
                    if (ccv.Save(mv) < 0)
                    {
                        ShowFailMessage();
                    }
                    else
                    {
                        Classes.CAccountTransaction cat = new Classes.CAccountTransaction();
                        Models.MAccountTransaction mat = new Models.MAccountTransaction();
                        mat.AccountId = ccv.ReturnLastAccountId().ToString();
                        mat.CurrentTransaction = "0";
                        mat.Credit = mv.OpeningBalance;
                        mat.Debit = "0";
                        mat.eDate = DateTime.Now;
                        mat.Total = OpeningBalance;
                        mat.Description = "Opened Account [" + AccountTitle + "] Opening Balance [" + OpeningBalance + "]";
                        mat.Transactiontype = "Credit";
                        mat.FiscalYearId = Session["FiscalYear"].ToString(); 

                        if (cat.Save(mat) < 0)
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
                else
                {
                    ShowErrorModal("Please Select Bank");
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

        private void BindDropDown()
        {
            Classes.CBank cv = new Classes.CBank();
            Dictionary<int, string> VendorData = new Dictionary<int, string>();
            List<Models.MBank> get = new List<Models.MBank>();
            get = cv.GetAll();
            VendorData.Add(-1, "Please Select");
            for (int i = 0; i < get.Count; i++)
            {
                VendorData.Add(Convert.ToInt32(get[i].id), get[i].Name + " Branch: " + get[i].BranchCode);

            }
            ddlBankId.DataTextField = "Value";
            ddlBankId.DataValueField = "Key";
            ddlBankId.DataSource = VendorData;
            ddlBankId.DataBind();
        }

    }
}
