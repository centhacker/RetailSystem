using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewAccountsBalanceSheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropDowns();
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                FilterAccountsAndBindData();
            }
        }


        #region Private Functions
         
        private void BindDropDowns()
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
            ddlAccountType.DataValueField = "Key";
            ddlAccountType.DataTextField = "Value";
            ddlAccountType.DataSource = VendorData;
            ddlAccountType.DataBind();

        }

        private void FilterAccountsAndBindData()
        {
            List<Models.MAccountTransactionsView> Accounts = new List<Models.MAccountTransactionsView>();
            Classes.CAccountTransaction cat = new Classes.CAccountTransaction();
            Accounts = cat.GetAllViewAccounts();
            string AccountId = (ddlAccountType.SelectedValue);
            Accounts = (from o in Accounts
                        where o.AccountId == AccountId
                        select o).ToList();
            int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
            Accounts = (from o in Accounts
                        where o.FiscalYearId == FiscalYearId.ToString()
                   select o).ToList();
            Accounts = (from o in Accounts
                        orderby o.eDate ascending
                        select o).ToList();
            grdAccounts.DataSource = Accounts;
            grdAccounts.DataBind();
        }

        #endregion

        protected void grdAccounts_PageIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void grdAccounts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAccounts.PageIndex = e.NewPageIndex;
            FilterAccountsAndBindData();
        }
    }
}