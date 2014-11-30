using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class AddProdudcts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropDown();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Convert.ToInt32(ddlVendorId.SelectedValue) != -1)
                {
                    string ProductCode = txtProductCode.Text;
                    string ProductName = txtProductName.Text;
                    string ProductTag1 = txtProductTag1.Text;
                    string ProductTag2 = txtProductTag2.Text;
                    string ProductManufacturer = txtProductManufacturer.Text;
                    string ProductDescription = txtProductDescription.Text;
                    string ProductVendorId = ddlVendorId.SelectedValue;
                    string CostPrice = txtCostPrice.Text;
                    string SalePrice = txtSalePrice.Text;
                    Models.MProducts mv = new Models.MProducts();
                    mv.ProductCode = ProductCode;
                    mv.Name = ProductName;
                    mv.tag1 = ProductTag1;
                    mv.tag2 = ProductTag2;
                    mv.CostPrice = CostPrice;
                    mv.SalePrice = SalePrice;
                    mv.Manufacturer = ProductManufacturer;
                    mv.description = ProductDescription;
                    mv.Vendorld = ProductVendorId;
                    mv.WareHouseId = Session["WareHouse"].ToString();
                    Classes.CProducts ccv = new Classes.CProducts();
                    if (ccv.Save(mv) < 0)
                    {
                        ShowFailMessage();
                    }
                    else
                    {
                        ShowSuccessMessage();
                        ClearTextBoxes(Page);


                    }
                }
                else
                {
                    ShowErrorMessage("Please select a Vendor");
                }

            }
            else
            {

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

        private void BindDropDown()
        {
            Classes.CVendor cv = new Classes.CVendor();
            Dictionary<int, string> VendorData = new Dictionary<int, string>();
            List<Models.MVendor> get = new List<Models.MVendor>();
            get = cv.GetAll();
            get = get.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
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
        private void ShowErrorMessage(string Error)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = Error;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal('show');");
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
