using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class AddUsersToWareHouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDdls();
            }
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string UserId = ddlUsers.SelectedValue.ToString();
                string WareHouseName = string.Empty;
                Classes.CUserWareHouseContainer cu = new Classes.CUserWareHouseContainer();
                WareHouseName = cu.GetWareHouseNameByUserId(UserId);
                lblWareHouse.Text = WareHouseName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (Convert.ToInt32(ddlUsers.SelectedValue) > 0)
                {
                    if (Convert.ToInt32(ddlWareHouse.SelectedValue) > 0)
                    {
                        string UserId = ddlUsers.SelectedValue;
                        string WareHouseId = ddlWareHouse.SelectedValue;
                        Classes.CUserWareHouseContainer cw = new Classes.CUserWareHouseContainer();
                        Models.MUserWareHouseContainer mw = new Models.MUserWareHouseContainer();
                        mw.UserId = UserId;
                        mw.WareHouseId = WareHouseId;
                        if (cw.Save(mw) > 0)
                        {
                            ShowSuccessMessage();
                        }
                        else
                        {
                            ShowFailMessage();
                        }
                    }
                    else
                    {
                        ShowErrorModal("Please select a Ware House");
                    }
                }
                else
                {
                    ShowErrorModal("Please select a User Id");
                }
            }
        }

        #region private events
        private void BindDdls()
        {
            Dictionary<int, string> WareHouse = new Dictionary<int, string>();
            List<Models.MwareHouse> LWareHouse = new List<Models.MwareHouse>();
            Classes.CWareHouse cw = new Classes.CWareHouse();
            LWareHouse = cw.GetAll();
            WareHouse.Add(-1, "Please select WareHouse");
            for (int i = 0; i < LWareHouse.Count; i++)
            {
                WareHouse.Add(Convert.ToInt32(LWareHouse[i].id), LWareHouse[i].Name);
            }
            ddlWareHouse.DataSource = WareHouse;
            ddlWareHouse.DataValueField = "Key";
            ddlWareHouse.DataTextField = "Value";
            ddlWareHouse.DataBind();

            Dictionary<int, string> Users = new Dictionary<int, string>();
            List<Models.MUsers> LUsers = new List<Models.MUsers>();
            Classes.CUsers cu = new Classes.CUsers();
            LUsers = cu.GetAll();
            Users.Add(-1, "Please Select User Id");
            for (int i = 0; i < LUsers.Count; i++)
            {
                Users.Add(Convert.ToInt32(LUsers[i].id), LUsers[i].name);
            }
            ddlUsers.DataSource = Users;
            ddlUsers.DataValueField = "Key";
            ddlUsers.DataTextField = "Value";
            ddlUsers.DataBind();



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

        private void CreatePreviewModal()
        {

        }
        #endregion




    }
}