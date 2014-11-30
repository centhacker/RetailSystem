using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEditClients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindPageControls();

            }
        }


        private void BindPageControls()
        {
            Classes.CClients ccl = new Classes.CClients();
            if (Session["WareHouse"] != null)
            {
                string WareHouseId = Session["WareHouse"].ToString();
                List<Models.MClients> Clients = new List<Models.MClients>();
                Clients = ccl.GetAll();
                Clients = (from o in Clients
                           where o.WareHouseId == WareHouseId
                           select
                           o).ToList();
                grdClients.DataSource = Clients;
                grdClients.DataBind();
                BindDropDown();

            }
            
        }
        private Dictionary<int, string> ShowAllClientTypes()
        {
            Dictionary<int, string> ReturnClientTypes = new Dictionary<int, string>();
            Classes.CClientTypes ccl = new Classes.CClientTypes();
            List<Models.MClientTypes> Get = ccl.GetAll();
            ReturnClientTypes.Add(0, "Please Select");
            for (int i = 0; i < Get.Count; i++)
            {
                int ClientTypeId = Convert.ToInt32(Get[i].id);
                string ClientTypeName = Get[i].name;
                ReturnClientTypes.Add(ClientTypeId, ClientTypeName);
            }

            return ReturnClientTypes;
        }
        private void BindDropDown()
        {
            ddlClientType.DataValueField = "Key";
            ddlClientType.DataTextField = "Value";
            ddlClientType.DataSource = ShowAllClientTypes();
            ddlClientType.DataBind();
        }
        protected void grdClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = grdClients.Rows[index];
                lblClientId.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();


                txtClientName.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
                txtPhone.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
                txtEmail.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text).ToString();
                txtAddress1.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text).ToString();
                txtAddress2.Text = HttpUtility.HtmlDecode(gvrow.Cells[6].Text).ToString();
                txtCity.Text = HttpUtility.HtmlDecode(gvrow.Cells[7].Text).ToString();
                if (HttpUtility.HtmlDecode(gvrow.Cells[8].Text).ToString() == "True")
                {
                    cbIsVendor.Checked = true;
                }

                string ddlValue = ddlClientType.Items.FindByText(HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString()).Value;
                ddlClientType.SelectedValue = ddlValue;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);



            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlClientType.SelectedValue) > 0)
            {
                string ClientTypeId = ddlClientType.SelectedValue.ToString();
                string ClientName = txtClientName.Text;
                string ClientPhone = txtPhone.Text;
                string ClientEmail = txtEmail.Text;
                string ClientAddress1 = txtAddress1.Text;
                string ClientAddress2 = txtAddress2.Text;
                string City = txtCity.Text;
                string eDate = DateTime.Now.ToString();
                bool IsVendor = false;
                if (cbIsVendor.Checked)
                {
                    IsVendor = true;
                }
                Models.MClients mc = new Models.MClients();
                mc.id = Convert.ToInt32(lblClientId.Text);
                mc.ClientTypeld = ClientTypeId;
                mc.Name = ClientName;
                mc.phone = ClientPhone;
                mc.Address1 = ClientAddress1;
                mc.Address2 = ClientAddress2;
                mc.EmailAddress = ClientEmail;
                mc.City = City;
                mc.isVendor = IsVendor;
                mc.edate = eDate;
                Classes.CClients cc = new Classes.CClients();
                if (cc.Update(mc) < 0)
                {
                    ShowFailMessage();
                }
                else
                {
                    ShowSuccessMessage();
                    BindPageControls();

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