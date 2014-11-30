using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewCashAccountsClients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            Classes.CCashAccount ca = new Classes.CCashAccount();
            List<Models.MCashAccount> CashAccount = new List<Models.MCashAccount>();
            CashAccount = ca.GetAll();
            CashAccount = CashAccount.Where(o =>
                o.WareHouseId == Convert.ToInt32(Session["WareHouse"].ToString())
                && o.VendorId == -1 && o.AccountType == Common.Constants.CashAccountTypes.Client.ToString()).ToList();
            grdAccountTransaction.DataSource = CashAccount;
            grdAccountTransaction.DataBind();
        }
    }
}