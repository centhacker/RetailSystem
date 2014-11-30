using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class Assign_User_Ids_to_Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropDowns();
            }
        }

        private void BindDropDowns()
        {
            ddlEmployees.DataValueField = "Key";
            ddlEmployees.DataTextField = "Value";
            ddlUsers.DataValueField = "Key";
            ddlUsers.DataTextField = "Value";
            ddlUsers.DataSource = ShowAllUsers();
            ddlUsers.DataBind();
            ddlEmployees.DataSource = ShowAllEmployees();
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
        private Dictionary<int, string> ShowAllEmployees()
        {
            Classes.CEmployees cu = new Classes.CEmployees();
            Dictionary<int, string> Get = new Dictionary<int, string>();
            List<Models.MEmployees> GetUsers = new List<Models.MEmployees>();
            GetUsers = cu.GetAll();
            Get.Add(-1, "Please Select");
            for (int i = 0; i < GetUsers.Count; i++)
            {
                int Key = Convert.ToInt32(GetUsers[i].id);
                string Value = GetUsers[i].FirstName;
                Get.Add(Key, Value);
            }
            return Get;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string EmployeeId = ddlEmployees.SelectedValue;
            string UserId = ddlEmployees.SelectedValue;
            if (EmployeeId != "-1" && UserId != "-1")
            {

            }
            else
            {
                lblError.Text = "Please select a proper value of employees/users";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);
            }
             

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