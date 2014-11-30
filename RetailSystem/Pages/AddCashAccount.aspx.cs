using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class AddCashAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && Page.IsPostBack)
            {
                Classes.CCashAccount ca = new Classes.CCashAccount();
                Models.MCashAccount ma = new Models.MCashAccount();
                ma.AccountType = "Personal";
                ma.BeginDate = txtBeginDate.Text;
                ma.CashAccountName = txtCashAccountName.Text;
                ma.ClientId = -1;
                ma.VendorId = -1;
                ma.OpeningBalance = txtOpeningBalance.Text;
                ma.WareHouseId = Convert.ToInt32(Session["WareHouse"].ToString());
                ma.AccountType = ma.AccountType = Common.Constants.CashAccountTypes.Personal.ToString();
                if (ca.Save(ma) > 0)
                {
                    Classes.CCashTransaction cct = new Classes.CCashTransaction();
                    Models.MCashTransactions mct = new Models.MCashTransactions();
                    mct.CashAccountId = ca.GetLastAccountId();
                    mct.Credit = txtOpeningBalance.Text;
                    mct.Debit = "0";
                    mct.Description = "Opened Account";
                    mct.eDate = txtBeginDate.Text;
                    mct.FiscalYearId = Convert.ToInt32(Session["FiscalYear"].ToString());
                    mct.OrderId = -1;
                    mct.Total = txtOpeningBalance.Text;
                    mct.TransactionId = -1;
                    mct.TransactionType = "Credit";
                    mct.WareHouseId = Convert.ToInt32(Session["WareHouse"].ToString()); 

                    mct.UserId = Session["UserId"].ToString();
                    if (cct.Save(mct) > 0)
                    {
                        ShowSuccessMessage();
                    }
                    else
                    {
                        ShowFailMessage();
                    }
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

    }
}