using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEditCashAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void grdAccountTransaction_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = grdAccountTransaction.Rows[index];

                lblCashAccountId.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                txtCashAccountName.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString();
                txtOpeningBalance.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
                txtBeginDate.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);


            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Classes.CCashAccount ca = new Classes.CCashAccount();
                Models.MCashAccount ma = new Models.MCashAccount();
                ma.AccountType = "Personal";
                ma.BeginDate = txtBeginDate.Text;
                ma.CashAccountName = txtCashAccountName.Text;
                ma.ClientId = -1;
                ma.VendorId = -1;
                ma.OpeningBalance = txtOpeningBalance.Text;
                ma.WareHouseId = Convert.ToInt32(Session["WareHouse"].ToString());
                if (ca.Save(ma) > 0)
                {
                    ShowSuccessMessage();
                    BindData();
                }
                else
                {
                    ShowFailMessage();
                }
            }
        }


        private void BindData()
        {
            Classes.CCashAccount ca = new Classes.CCashAccount();
            List<Models.MCashAccount> CashAccount = new List<Models.MCashAccount>();
            CashAccount = ca.GetAll();
            CashAccount = CashAccount.Where(o =>
                o.WareHouseId == Convert.ToInt32(Session["WareHouse"].ToString())
                && o.ClientId == -1 && o.VendorId == -1).ToList();
            grdAccountTransaction.DataSource = CashAccount;
            grdAccountTransaction.DataBind();
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