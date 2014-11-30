using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem
{
    public partial class Default : System.Web.UI.Page
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Models.MUsers mu = new Models.MUsers();
                mu.name = txtuserID.Text;
                mu.password = txtPassword.Text;
                Classes.CUsers cu = new Classes.CUsers();
                int RetVal = cu.Save(mu);
                if (RetVal < 0)
                {
                    ShowFailMessage();
                }
                else if (RetVal == 2)
                {
                    lbluser.Text = "UserName [" + txtuserID.Text + "] Already exists";
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
    }
}