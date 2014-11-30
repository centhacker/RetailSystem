using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ShopExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindAccountsDdl();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ddlSaleAccount.SelectedValue != "-1" && Page.IsValid)
            {
                if (Save() > 0)
                {
                    ClearTextBoxes(Page);
                    ShowSuccessMessage();

                }
                else
                {
                    ClearTextBoxes(Page);
                    ShowFailMessage();
                }
            }
        }

        #region Private Events
        private int Save()
        {
            Classes.CBankOfAccount cb = new Classes.CBankOfAccount();
            Classes.CAccountTransaction cat = new Classes.CAccountTransaction();
            Classes.CDefaultAccount cd = new Classes.CDefaultAccount();
            Models.MAccountTransaction mat = new Models.MAccountTransaction();
            int AccountId = 0;
            string Amount = string.Empty;
            string Description = string.Empty;
            string Debit = string.Empty;
            string Credit = string.Empty;
            string Total = string.Empty;
            string CurrentTransaction = string.Empty;
            string FiscalYearId = string.Empty;
            DateTime eDate;
            if (cbDefault.Checked)
            {
                AccountId = cd.ReturnPurchaseDefaultAccount(Convert.ToInt32(Session["WareHouse"])); 
            }
            else
            {
                AccountId = Convert.ToInt32(ddlSaleAccount.SelectedValue);

            }
            Amount = txtamount.Text;
            Description = "Shop Expense: " + txtDescription.Text;
            Debit = txtamount.Text;
            Credit = "0";
            Total = txtamount.Text;
            CurrentTransaction = "-21";
            FiscalYearId = Convert.ToInt32(Session["FiscalYear"]).ToString();
            eDate = Convert.ToDateTime(txtdate.Text);
            mat.AccountId = Convert.ToInt32(AccountId).ToString();
            mat.Credit = Credit;
            mat.Debit = Debit;
            mat.Description = Description;
            mat.FiscalYearId = FiscalYearId;
            mat.Total = Total;
            mat.Transactiontype = "Expense";

            if (cb.SetNewAccountTotal(Convert.ToInt32(AccountId), Convert.ToSingle(Total)) > 0)
            {
                if (cat.Save(mat) > 0)
                {
                    Classes.CJournal cj = new Classes.CJournal();
                    Models.MJournal mj = new Models.MJournal();
                    mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.GeneralExpense).ToString();
                    mj.amount = Total;
                    mj.des = "Shop Expense ";
                    mj.e_date = (eDate).ToShortDateString();
                    mj.type = Common.Constants.Accounts.Type.Debit.ToString();
                    cj.Save(mj);

                    mj = new Models.MJournal();
                    mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.Cash).ToString();
                    mj.amount = Total;
                    mj.des = "Shop Expense ";
                    mj.e_date = (eDate).ToShortDateString();
                    mj.type = Common.Constants.Accounts.Type.Credit.ToString();
                    cj.Save(mj);
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        private void BindAccountsDdl()
        {
            Classes.CBankOfAccount cv = new Classes.CBankOfAccount();
            Dictionary<int, string> VendorData = new Dictionary<int, string>();
            List<Models.MBankAccount> Get = new List<Models.MBankAccount>();
            Get = cv.GetAll();
            VendorData.Add(-1, "Please Select");
            for (int i = 0; i < Get.Count; i++)
            {
                VendorData.Add(Convert.ToInt32(Get[i].id), Get[i].Accounttitle + " Number: " + Get[i].accountNumber);

            }

            ddlSaleAccount.DataSource = VendorData;
            ddlSaleAccount.DataValueField = "Key";
            ddlSaleAccount.DataTextField = "Value";
            ddlSaleAccount.DataBind();

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
        #endregion
    }
}