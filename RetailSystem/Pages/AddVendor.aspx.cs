using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class AddVendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["WareHouse"] != null)
            {
                string WareHouseId = Session["WareHouse"].ToString();

                if (Page.IsValid)
                {
                    string VendorName = txtVendorName.Text;
                    string VendorAddress = txtVendorAddress.Text;
                    string VendorPhone = txtVendorPhoneNo.Text;
                    Models.MVendor mv = new Models.MVendor();
                    mv.name = VendorName;
                    mv.Addreess = VendorAddress;
                    mv.phone = VendorPhone;
                    mv.WareHouseId = WareHouseId;
                    Classes.CVendor ccv = new Classes.CVendor();
                    if (ccv.Save(mv) > 0)
                    {
                        //ShowFailMessage();
                        Classes.CCashAccount ca = new Classes.CCashAccount();
                        Models.MCashAccount ma = new Models.MCashAccount();
                        ma.CashAccountName = VendorName;
                        ma.BeginDate = DateTime.Now.ToShortDateString();
                        ma.ClientId = -1;
                        ma.OpeningBalance = "0";
                        ma.AccountType = ma.AccountType = Common.Constants.CashAccountTypes.Vendor.ToString();
                        ma.VendorId =  ccv.GetLastVendorId();;
                        ma.WareHouseId = Convert.ToInt32(Session["WareHouse"].ToString());
                        if (ca.Save(ma) > 0)
                        {
                            Classes.CCashTransaction cct = new Classes.CCashTransaction();
                            Models.MCashTransactions mct = new Models.MCashTransactions();
                            mct.CashAccountId = ca.GetLastAccountId();
                            mct.Credit = "0";
                            mct.Debit = "0";
                            mct.Description = "Opened Client Account[" + txtVendorName.Text + "]";
                            mct.eDate = DateTime.Now.ToShortDateString();
                            mct.FiscalYearId = Convert.ToInt32(Session["FiscalYear"].ToString());
                            mct.OrderId = -1;
                            mct.Total = "0";
                            mct.TransactionId = -1;
                            mct.TransactionType = "Credit";
                            mct.WareHouseId = Convert.ToInt32(Session["WareHouse"].ToString());
                            mct.UserId = Session["UserId"].ToString();
                            if (cct.Save(mct) > 0)
                            {
                                ShowSuccessMessage();
                                ClearTextBoxes(Page);
                            }
                            else
                            {
                                ShowFailMessage();
                            }
                        }
                        else
                        {
                            ShowErrorModal("Vendor Saved but Account was not opened");
                        }

                    }
                    else
                    {
                        ShowFailMessage();
                    }
                }
            }
            else
            {
                ShowErrorModal("Cannot Save, No Warehouse associated with current user");
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