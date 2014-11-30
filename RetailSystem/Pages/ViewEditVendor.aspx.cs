using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEditVendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void grdVendor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = grdVendor.Rows[index];

                lblVendor.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                txtVendorname.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
                txtVendorAddress.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
                txtVendorphone.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);


            }
        }
        private void BindData()
        {
            Classes.CVendor cb = new Classes.CVendor();
            List<Models.MVendor> Vendors = new List<Models.MVendor>();
            if (Session["WareHouse"] != null)
            {
                string WareHouseId = Session["WareHouse"].ToString();
                Vendors = cb.GetAll();
                Vendors = (from o in Vendors
                           where o.WareHouseId == WareHouseId
                           select o).ToList();
                grdVendor.DataSource = Vendors;
                grdVendor.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            string vendorID = lblVendor.Text;
            string VendorName = txtVendorname.Text;
            string VendorAddress = txtVendorAddress.Text;
            string VendorPhone = txtVendorphone.Text;
            Models.MVendor mv = new Models.MVendor();
            mv.id = Convert.ToString(vendorID);
            mv.name = VendorName;
            mv.Addreess = VendorAddress;
            mv.phone = VendorPhone;
            Classes.CVendor ccv = new Classes.CVendor();
            if (ccv.Update(mv) < 0)
            {
                ShowFailMessage();
            }
            else
            {
                ShowSuccessMessage();
                ClearTextBoxes(Page);
                BindData();
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


        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }

        protected void grdWareHouse_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdWareHouse_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}