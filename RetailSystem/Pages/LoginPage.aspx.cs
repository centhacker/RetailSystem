using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Classes.CUsers cu = new Classes.CUsers();
            int UserId = cu.GetUserIdByName(txtLoginUserId.Text);
            Models.MUsers mu = new Models.MUsers();
            string WareHouseId = string.Empty;
            mu.name = txtLoginUserId.Text;
            mu.password = txtLoginPassword.Text;
            int retVal = cu.ValidateUser(mu);
            if (retVal == -1)
            {
                lblShow.Text = "Invalid User ID or Password";
            }
            else if (retVal == -2)
            {
                Response.Redirect("~/Pages/SetFiscalYear.aspx");
            }
            else
            {
                Session["UserId"] = cu.GetUserIdByName(txtLoginUserId.Text);
                Session["User"] = txtLoginUserId.Text;
                Session["FiscalYear"] = retVal;
                Session["WareHouse"] = ReturnWareHouseId(UserId.ToString());
                Response.Redirect("~/Pages/Main.aspx");
            }
        }

        private string ReturnWareHouseId(string UserId)
        {
            string WareHouse = string.Empty;
            Classes.CUserWareHouseContainer cw = new Classes.CUserWareHouseContainer();
            WareHouse = cw.GetWareHouseIdByUserId(UserId);
            return WareHouse;
        }
    }
}