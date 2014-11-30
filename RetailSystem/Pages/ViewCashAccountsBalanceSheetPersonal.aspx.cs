using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewCashAccountsBalanceSheetPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
                BindDropDowns();
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {

        }

        private void BindDropDowns()
        {
            Classes.CCashAccount cv = new Classes.CCashAccount();
            Dictionary<int, string> VendorData = new Dictionary<int, string>();
            List<Models.MCashAccount> Get = new List<Models.MCashAccount>();
            Get = cv.GetAll();
            Get = Get.Where(o => o.ClientId == -1
                && o.AccountType == Common.Constants.CashAccountTypes.Vendor.ToString()).ToList();
            VendorData.Add(-1, "Please Select");
            for (int i = 0; i < Get.Count; i++)
            {
                VendorData.Add(Convert.ToInt32(Get[i].id), Get[i].CashAccountName);

            }
            ddlAccountType.DataValueField = "Key";
            ddlAccountType.DataTextField = "Value";
            ddlAccountType.DataSource = VendorData;
            ddlAccountType.DataBind();

        }

        private void BindGrid()
        {
            List<Models.MViewModels.MViewCashAccountBalanceSheet> CashAccounts = new List<Models.MViewModels.MViewCashAccountBalanceSheet>();
            Classes.CViewClasses.CViewCashAccountBalanceSheet ccv = new Classes.CViewClasses.CViewCashAccountBalanceSheet();
            CashAccounts = ccv.GetAll(Common.Constants.CashAccountTypes.Personal.ToString());
            grdAccounts.DataSource = CashAccounts;
            grdAccounts.DataBind();

        }

    }
}