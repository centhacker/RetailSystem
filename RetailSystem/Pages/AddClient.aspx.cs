using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class AddClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropDown();
            }
        }

        protected void btnNewClientType_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ClientTypesModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Session["WareHouse"] != null)
            {
                string WareHouseId = Session["WareHouse"].ToString();
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
                    mc.ClientTypeld = ClientTypeId;
                    mc.Name = ClientName;
                    mc.phone = ClientPhone;
                    mc.Address1 = ClientAddress1;
                    mc.Address2 = ClientAddress2;
                    mc.EmailAddress = ClientEmail;
                    mc.City = City;
                    mc.isVendor = IsVendor;
                    mc.edate = eDate;
                    mc.WareHouseId = (WareHouseId);
                    mc.GrantorName = txtGrantorName.Text;
                    mc.NIC = txtNIC.Text;
                    mc.GrantorNIC = txtGrantorNIC.Text;
                    Classes.CClients cc = new Classes.CClients();
                    if (cc.Save(mc) > 0)
                    {
                        Classes.CCashAccount ca = new Classes.CCashAccount();
                        Models.MCashAccount ma = new Models.MCashAccount();
                        ma.CashAccountName = ClientName;
                        ma.BeginDate = eDate;
                        ma.ClientId = cc.GetLastClientId();
                        ma.OpeningBalance = "0";
                        ma.AccountType = Common.Constants.CashAccountTypes.Client.ToString();
                        ma.VendorId = -1;
                        ma.WareHouseId = Convert.ToInt32(Session["WareHouse"].ToString());
                        if (ca.Save(ma) > 0)
                        {

                            Classes.CCashTransaction cct = new Classes.CCashTransaction();
                            Models.MCashTransactions mct = new Models.MCashTransactions();
                            mct.CashAccountId = ca.GetLastAccountId();
                            mct.Credit = "0";
                            mct.Debit = "0";
                            mct.Description = "Opened Client Account[" + txtClientName.Text + "]";
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
                            ShowErrorModal("Client Saved but Account was not opened");
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

        protected void btnSubmitClientType_Click(object sender, EventArgs e)
        {


            if (Page.IsValid)
            {
                string ClientTypeName = txtClientType.Text;
                Models.MClientTypes mct = new Models.MClientTypes();
                Classes.CClientTypes cct = new Classes.CClientTypes();
                mct.name = ClientTypeName;
                if (cct.Save(mct) < 0)
                {
                    ShowFailMessage();
                }
                else
                {
                    ClearTextBoxes(Page);
                    ShowSuccessMessage();
                    BindDropDown();

                }
            }
        }

        private void BindDropDown()
        {
            ddlClientType.DataValueField = "Key";
            ddlClientType.DataTextField = "Value";
            ddlClientType.DataSource = ShowAllClientTypes();
            ddlClientType.DataBind();
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