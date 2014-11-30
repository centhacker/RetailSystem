using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEditEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void BindDataControls()
        {
            Classes.CEmployees ce = new Classes.CEmployees();

        }

        protected void grdEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = grdEmployees.Rows[index];

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);



            }
        }


        private void BindData()
        {
            Classes.CEmployees ce = new Classes.CEmployees();
            List<Models.MEmployees> Employees = new List<Models.MEmployees>();
            Employees = ce.GetAll();
            if (Session["WareHouse"] != null)
            {
                string WareHouseId = Session["WareHouse"].ToString();
                Employees = (from o in Employees
                             where o.WareHouseId == WareHouseId
                             select o).ToList();
                grdEmployees.DataSource = Employees;
                grdEmployees.DataBind();
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