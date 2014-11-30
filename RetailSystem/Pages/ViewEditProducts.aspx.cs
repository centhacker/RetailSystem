using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEditProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }

        }

        protected void grdProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = grdProduct.Rows[index];

                lblProductid.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                txtProductcode.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
                txtProductName.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
                txtProducttag1.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
                txtProducttag2.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text).ToString();
                txtCp.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text).ToString();
                txtSp.Text = HttpUtility.HtmlDecode(gvrow.Cells[6].Text).ToString();
                
                BindDropDown();
                ddlVendorId.SelectedValue = HttpUtility.HtmlDecode(gvrow.Cells[7].Text).ToString();
                txtProductManufacturer.Text = HttpUtility.HtmlDecode(gvrow.Cells[9].Text).ToString();
                txtProductDescription.Text = HttpUtility.HtmlDecode(gvrow.Cells[10].Text).ToString();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);


            }
        }
        private void BindData()
        {

            Classes.CProducts cb = new Classes.CProducts();
            grdProduct.DataSource = cb.GetAll();
            grdProduct.DataBind();

        }

        private void BindDropDown() 
        {
            Classes.CVendor cv = new Classes.CVendor();
            Dictionary<int, string> VendorData = new Dictionary<int, string>();
            List<Models.MVendor> get = new List<Models.MVendor>();
            get = cv.GetAll();
            VendorData.Add(-1, "Please Select");
            for (int i = 0; i < get.Count; i++)
            {
                VendorData.Add(Convert.ToInt32(get[i].id), get[i].name);

            }
            ddlVendorId.DataTextField = "Value";
            ddlVendorId.DataValueField = "Key";
            ddlVendorId.DataSource = VendorData;
            ddlVendorId.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string ProductId = lblProductid.Text;
            string ProductCode = txtProductcode.Text;
            string ProductName = txtProductName.Text;
            string ProductTag1 = txtProducttag1.Text;
            string ProductTag2 = txtProducttag2.Text;
            string ProductManufacturer = txtProductManufacturer.Text;
            string ProductDescription = txtProductDescription.Text;

            string CostPrice = txtCp.Text;
            string SalePrice = txtSp.Text;
            Models.MProducts mv = new Models.MProducts();
            mv.id = ProductId;
            mv.ProductCode = ProductCode;
            mv.Name = ProductName;
            mv.tag1 = ProductTag1;
            mv.tag2 = ProductTag2;
            mv.CostPrice = CostPrice;
            mv.SalePrice = SalePrice;
            mv.Manufacturer = ProductManufacturer;
            mv.description = ProductDescription;
            mv.Vendorld = ddlVendorId.SelectedValue;

            Classes.CProducts ccv = new Classes.CProducts();
            if (ccv.Update(mv) < 0)
            {
                ShowFailMessage();
            }
            else
            {
                ShowSuccessMessage();
                BindData();
                ClearTextBoxes(Page);


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