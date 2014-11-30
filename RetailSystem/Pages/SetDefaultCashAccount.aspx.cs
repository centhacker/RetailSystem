using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class SetDefaultCashAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDdl(); BindAccountNames();
            }
        }

        protected void btnSetSales_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string AccountId = ddlSalesAccount.SelectedValue;
                Classes.CDefaultCashAccount cd = new Classes.CDefaultCashAccount();
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

        protected void btnSetPurchase_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string AccountId = ddlPurchaseAccount.SelectedValue;
                Classes.CDefaultCashAccount cd = new Classes.CDefaultCashAccount();
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


        private void BindAccountNames()
        {
            Classes.CDefaultCashAccount cdf = new Classes.CDefaultCashAccount();
            Classes.CCashAccount cba = new Classes.CCashAccount();
            List<Models.MCashAccount> ListSalesAccounts = new List<Models.MCashAccount>();
            List<Models.MCashAccount> ListPurchaseAccounts = new List<Models.MCashAccount>();
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
                    lblSalesAccount.Text = ListSalesAccounts[0].CashAccountName ;
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
                    lblPurchaseAccount.Text = ListPurchaseAccounts[0].CashAccountName;
                }

            }
        }

        private void BindDdl()
        {
            Classes.CCashAccount ca = new Classes.CCashAccount();
            List<Models.MCashAccount> CashAccounts = new List<Models.MCashAccount>();
            CashAccounts = ca.GetAll();
            CashAccounts = CashAccounts.Where(o => o.WareHouseId == Convert.ToInt32(Session["WareHouse"].ToString())
                                            && o.VendorId == -1 && o.ClientId == -1).ToList();
            Dictionary<int, string> Accounts = new Dictionary<int, string>();
            Accounts.Add(-1, "Please Select");
            for (int i = 0; i < CashAccounts.Count; i++)
            {
                Accounts.Add(CashAccounts[i].id, CashAccounts[i].CashAccountName);
            }
            ddlPurchaseAccount.DataValueField = "Key";
            ddlPurchaseAccount.DataTextField = "Value";
            ddlSalesAccount.DataValueField = "Key";
            ddlSalesAccount.DataTextField = "Value";
            ddlSalesAccount.DataSource = Accounts;
            ddlPurchaseAccount.DataSource = Accounts;
            ddlSalesAccount.DataBind();
            ddlPurchaseAccount.DataBind();

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

        protected void ddlPurchaseAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}