using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class SetDefaultAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDdlOfAccounts(); BindAccountNames();

            }
        }

        private void BindAccountNames()
        {
            Classes.CDefaultAccount cdf = new Classes.CDefaultAccount();
            Classes.CBankOfAccount cba = new Classes.CBankOfAccount();
            List<Models.MBankAccount> ListSalesAccounts = new List<Models.MBankAccount>();
            List<Models.MBankAccount> ListPurchaseAccounts = new List<Models.MBankAccount>();
            int SalesAccount = cdf.ReturnSaleDefaultAccount(Convert.ToInt32(Session["WareHouse"]));
            if (SalesAccount < 0)
            {

                lblSalesAccount.Text = "No Default Account Set";
            }
            else
            {
                ListSalesAccounts = cba.GetAllbyid(SalesAccount);
                if (ListSalesAccounts.Count == 0)
                {
                     lblSalesAccount.Text = "No Default Account Set";
                }
                else
                {
                    lblSalesAccount.Text = ListSalesAccounts[0].Accounttitle + "-" + ListSalesAccounts[0].accountNumber;
                }

            }
            int PurchaseAccount = cdf.ReturnPurchaseDefaultAccount(Convert.ToInt32(Session["WareHouse"]));
            if (PurchaseAccount < 0)
            {

                lblPurchaseAccount.Text = "No Default Account Set";
            }
            else
            {
                ListPurchaseAccounts = cba.GetAllbyid(PurchaseAccount);
                if (ListPurchaseAccounts.Count == 0)
                {
                    lblPurchaseAccount.Text = "No Default Account Set";
                }
                else
                {
                    lblPurchaseAccount.Text = ListPurchaseAccounts[0].Accounttitle + "-" + ListPurchaseAccounts[0].accountNumber;
                }

            }
        }

        private void BindDdlOfAccounts()
        {
            Dictionary<int, string> Accounts = new Dictionary<int, string>();
            Classes.CBankOfAccount ca = new Classes.CBankOfAccount();
            List<Models.MBankAccount> ListOfAccounts = new List<Models.MBankAccount>();
            ListOfAccounts = ca.GetAll();
            ListOfAccounts = ListOfAccounts.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            Accounts.Add(-1, "Please select Account");
            for (int i = 0; i < ListOfAccounts.Count; i++)
            {
                int AccountId = Convert.ToInt32(ListOfAccounts[i].id);
                string AccountTitle = ListOfAccounts[i].Accounttitle + "-" + ListOfAccounts[i].accountNumber;
                Accounts.Add(AccountId, AccountTitle);
            }
            ddlPurchaseAccount.DataTextField = "Value";
            ddlPurchaseAccount.DataValueField = "Key";
            ddlSalesAccount.DataTextField = "Value";
            ddlSalesAccount.DataValueField = "Key";
            ddlSalesAccount.DataSource = Accounts;
            ddlPurchaseAccount.DataSource = Accounts;
            ddlPurchaseAccount.DataBind();
            ddlSalesAccount.DataBind();

        }

        protected void btnSetPurchase_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string AccountId = ddlPurchaseAccount.SelectedValue;
                Classes.CDefaultAccount cd = new Classes.CDefaultAccount();
                Models.MDefaultAccounts md = new Models.MDefaultAccounts();
                md.DefaultPurchaseAccountId = AccountId;
                string WareHouseId = Session["WareHouse"].ToString();
                md.WareHouseId = Convert.ToInt32(WareHouseId);
                if (cd.SaveDefaultAccounts(md, "Purchase") < 0)
                {
                    ShowFailMessage();
                }
                else
                {
                    ShowSuccessMessage();
                    BindAccountNames();

                }

            }
        }

        protected void btnSetSales_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string AccountId = ddlSalesAccount.SelectedValue;
                Classes.CDefaultAccount cd = new Classes.CDefaultAccount();
                Models.MDefaultAccounts md = new Models.MDefaultAccounts();
                md.DefaultSaleAccountId = AccountId;
                string WareHouseId = Session["WareHouse"].ToString();
                md.WareHouseId = Convert.ToInt32(WareHouseId);
                if (cd.SaveDefaultAccounts(md, "Sale") < 0)
                {
                    ShowFailMessage();
                }
                else
                {
                    ShowSuccessMessage();

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
    }
}