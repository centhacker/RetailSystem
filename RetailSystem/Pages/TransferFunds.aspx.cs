using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class TransferFunds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDdl();
            }
        }

        private void BindDdl()
        {
            Dictionary<int, string> BankAccounts = new Dictionary<int, string>();
            Classes.CBankOfAccount cca = new Classes.CBankOfAccount();
            List<Models.MBankAccount> ListOfBankAccounts = new List<Models.MBankAccount>();
            ListOfBankAccounts = cca.GetAll();
            ListOfBankAccounts = ListOfBankAccounts.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            BankAccounts.Add(-1, "Please Select");
            for (int i = 0; i < ListOfBankAccounts.Count; i++)
            {
                BankAccounts.Add(Convert.ToInt32(ListOfBankAccounts[i].id),
                    ListOfBankAccounts[i].AccountHolderId + "-" + ListOfBankAccounts[i].Accounttitle);
            }
            ddlBankAccount.DataSource = BankAccounts;
            ddlBankAccount.DataTextField = "Value";
            ddlBankAccount.DataValueField = "Key";
            ddlBankAccount.DataBind();
            Classes.CCashAccount ca = new Classes.CCashAccount();
            List<Models.MCashAccount> CashAccounts = new List<Models.MCashAccount>();
            CashAccounts = ca.GetAll();
            CashAccounts = CashAccounts.Where(o => o.WareHouseId == Convert.ToInt32(Session["WareHouse"].ToString())
                                            && o.VendorId == -1 && o.ClientId == -1).ToList();
            Dictionary<int, string> CashAccountsDc = new Dictionary<int, string>();
            CashAccountsDc.Add(-1, "Please Select");
            for (int i = 0; i < CashAccounts.Count; i++)
            {
                CashAccountsDc.Add(CashAccounts[i].id, CashAccounts[i].CashAccountName);
            }

            ddlCashAccount.DataSource = CashAccountsDc;
            ddlCashAccount.DataTextField = "Value";
            ddlCashAccount.DataValueField = "Key";
            ddlCashAccount.DataBind();
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

        private int TransferAmount()
        {
            string CashAccountId = string.Empty;
            string BankAccountId = string.Empty;
            string Amount = string.Empty;
            string ActualBalance = string.Empty;
            CashAccountId = ddlCashAccount.SelectedValue.ToString();
            BankAccountId = ddlBankAccount.SelectedValue.ToString();
            Amount = txtAmount.Text;
            ActualBalance = lblCashAccount.Text;
            if (CashAccountId != "-1")
            {
                if (BankAccountId != "-1")
                {
                    float differece = Convert.ToSingle(Amount) - Convert.ToSingle(ActualBalance);
                    float oldBankBalance = Convert.ToSingle(lblBankAccount.Text);
                    if (differece >= 0)
                    {
                        Classes.CBankOfAccount cb = new Classes.CBankOfAccount();
                        Classes.CCashAccount cca = new Classes.CCashAccount();
                        if (cb.SetNewAccountTotal(Convert.ToInt32(BankAccountId), oldBankBalance + Convert.ToSingle(Amount)) > 0)
                        {
                            float oldCashAccount = Convert.ToSingle(lblCashAccount.Text);
                            float newCashTotal = Convert.ToSingle(oldCashAccount - Convert.ToSingle(Amount));
                            if (cca.SetNewAccountTotal(Convert.ToInt32(CashAccountId), newCashTotal) > 0)
                            {
                                return 1;
                            }
                            else
                            {
                                return -5;
                            }
                            
                        }
                        else
                        {
                            return -4;
                        }
                    }
                    else
                    {
                        return -3;
                    }

                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int retVal = TransferAmount();
            switch (retVal)
            {
                case 1:
                    {
                        ShowSuccessMessage();
                        break;
                    }
                case -1:
                    {
                        ShowErrorModal("Please select cash account");
                        break;
                    }
                case -2:
                    {
                        ShowErrorModal("Please select bank account ");
                        break;
                    }
                case -3:
                    {
                        ShowErrorModal("Not enough funds to transfer");
                        break;
                    }
                case -4:
                    {
                        ShowErrorModal("Transfer was not made");
                        break;
                    }
                case -5: 
                    {
                        ShowErrorModal("Cash Account not effected");
                        break;
                    }
                default:
                    ShowFailMessage();
                    break;
            }
        }



        protected void ddlCashAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddlCashAccount.SelectedValue.ToString();
            if (id != "-1")
            {
                Classes.CCashAccount ca = new Classes.CCashAccount();
                string total = ca.ReturnTotalOfCashAccount(Convert.ToInt32(id)).ToString();
                lblCashAccount.Text = total;

            }
            else
            {
                lblCashAccount.Text = string.Empty;
            }
        }

        protected void ddlBankAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddlBankAccount.SelectedValue.ToString();
            if (id != "-1")
            {
                Classes.CBankOfAccount cb = new Classes.CBankOfAccount();
                string total = cb.ReturnTotalOfAccountById(Convert.ToInt32(id)).ToString();
                lblBankAccount.Text = total;
            }
            else
            {
                lblBankAccount.Text = string.Empty;
            }
        }
    }
}