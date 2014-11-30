using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class AssignRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropDowns();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlEmployees.SelectedValue != "-1" && ddlUsers.SelectedValue != "-1")
            {
                Classes.CUsers cu = new Classes.CUsers();

                int UserId = Convert.ToInt32( ddlUsers.SelectedValue);
                int RolesId = Convert.ToInt32(ddlEmployees.SelectedValue);
                if (cu.AssignRolesToUser(RolesId,UserId) < 0)
                {
                    ShowMessage("Role Was not assigned please refresh the page!");
                }
                else
                {
                    ShowMessage("Role assigned successfully!");
                }
            }
            else
            {
                ShowMessage("Please select a proper value of roles/users");
            }
        }


        private void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);
        }
        private void BindDropDowns()
        {
            ddlEmployees.DataValueField = "Key";
            ddlEmployees.DataTextField = "Value";
            ddlUsers.DataValueField = "Key";
            ddlUsers.DataTextField = "Value";
            ddlUsers.DataSource = ShowAllUsers();
            ddlUsers.DataBind();
            ddlEmployees.DataSource = ShowAllRoles();
            ddlEmployees.DataBind();

        }

        private Dictionary<int, string> ShowAllUsers()
        {
            Classes.CUsers cu = new Classes.CUsers();
            Dictionary<int, string> Get = new Dictionary<int, string>();
            List<Models.MUsers> GetUsers = new List<Models.MUsers>();
            GetUsers = cu.GetApprovedUsers();
            Get.Add(-1, "Please Select");
            for (int i = 0; i < GetUsers.Count; i++)
            {
                int Key = Convert.ToInt32(GetUsers[i].id);
                string Value = GetUsers[i].name;
                Get.Add(Key, Value);
            }
            return Get;
        }
        private Dictionary<int, string> ShowAllRoles()
        {
            Classes.CRoles cu = new Classes.CRoles();
            Dictionary<int, string> Get = new Dictionary<int, string>();
            List<Models.MRoles> GetUsers = new List<Models.MRoles>();
            GetUsers = cu.GetAll();
            Get.Add(-1,"Please Select");
            for (int i = 0; i < GetUsers.Count; i++)
            {
                int Key = Convert.ToInt32(GetUsers[i].id);
                string Value = GetUsers[i].RoleName;
                Get.Add(Key, Value);
            }
            return Get;
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