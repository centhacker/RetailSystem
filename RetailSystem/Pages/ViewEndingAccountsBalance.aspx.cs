using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEndingAccountsBalance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            List<Models.MViewModels.MViewEndingAccountsBalance> AccountsBalance = new List<Models.MViewModels.MViewEndingAccountsBalance>();
            Classes.CViewClasses.CViewAccountsEndingBalance cv = new Classes.CViewClasses.CViewAccountsEndingBalance();
            AccountsBalance = cv.GetAll();
            grdAccountTransaction.DataSource = AccountsBalance;
            grdAccountTransaction.DataBind();
            
        }
    }
}