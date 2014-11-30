using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEditWarehouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void grdWareHouse_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = grdWareHouse.Rows[index];
                lblWareHouse.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();


                txtWareHousename.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
                txtWareHouseAddress.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
                txtWareHousephone.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
                txtWarehouseDescription.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text).ToString();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);



            }

        }
        private void BindData()
        {
            Classes.CWareHouse cw = new Classes.CWareHouse();
            grdWareHouse.DataSource = cw.GetAll();
            grdWareHouse.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string WareHouseName = txtWareHousename.Text;
                string wareHouseAddress = txtWareHouseAddress.Text;
                string WareHousePhone = txtWareHousephone.Text;
                string WareHouseDescription = txtWarehouseDescription.Text;

                Models.MwareHouse mv = new Models.MwareHouse();
                mv.id = lblWareHouse.Text;
                mv.Name = WareHouseName;
                mv.Address = wareHouseAddress;
                mv.phone = WareHousePhone;
                mv.Description = WareHouseDescription;


                Classes.CWareHouse ccv = new Classes.CWareHouse();
                if (ccv.Update(mv) < 0)
                {
                    ShowFailMessage();
                }
                else
                {
                    ShowSuccessMessage();
                    ClearTextBoxes(Page);
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


    }
}