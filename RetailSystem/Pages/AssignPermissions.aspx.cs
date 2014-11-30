using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class AssignPermissions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropDown();
            }
        }

        protected void cbAllRead_CheckedChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (cbAllRead.Checked)
                {
                    CheckAllReadControls();
                }
                else
                {
                    UnCheckAllReadControls();
                }

            }
        }




        protected void cbAllWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (cbAllWrite.Checked)
                {
                    CheckAllControls();
                }
                else
                {
                    UnCheckAllControls();
                }

            }
        }

        private void ShowFailMessage()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalDanger').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);
        }
        private void ShowSuccessMessage()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalSuccess').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string RoleId = ddlRoles.SelectedValue;
            string RolesString = ComposeRolesString();
            if (Convert.ToInt32(RoleId) < 0)
            {
                ShowFailMessage();
            }
            else
            {
                Classes.CRoles cr = new Classes.CRoles();
                if (cr.AssignPermissionsToRoles(Convert.ToInt32(RoleId), RolesString) < 0)
                {
                    ShowFailMessage();
                }
                else
                {
                    ShowSuccessMessage();

                }
            }

        }


        private void BindDropDown()
        {
            Dictionary<int, string> Get = new Dictionary<int, string>();
            List<Models.MRoles> GetRoles = new List<Models.MRoles>();
            Classes.CRoles cr = new Classes.CRoles();
            GetRoles = cr.GetAll();
            Get.Add(-1, "Please Select");
            for (int i = 0; i < GetRoles.Count; i++)
            {
                Get.Add(Convert.ToInt32(GetRoles[i].id), GetRoles[i].RoleName);
            }
            ddlRoles.DataValueField = "Key";
            ddlRoles.DataTextField = "Value";
            ddlRoles.DataSource = Get;
            ddlRoles.DataBind();

        }

        #region Private Roles and cbs functions
        private void CheckAllReadControls()
        {
            cbAccountsRead.Checked = true;
            cbAllRead.Checked = true;
            cbBankRead.Checked = true;
            cbClientsRead.Checked = true;
            cbEmployeeRead.Checked = true;
            cbGeneralJournalRead.Checked = true;
            cbInventoryRead.Checked = true;
            cbOrdersRead.Checked = true;
            cbPayrollRead.Checked = true;
            cbProductsRead.Checked = true;
         //   cbRolesRead.Checked = true;
            cbSalesJournal.Checked = true;
            cbUserManegementRead.Checked = true;
            cbVendorRead.Checked = true;
            cbWareHouseRead.Checked = true;
            cbPaymentsRead.Checked = true;
            cbReportsRead.Checked = true;


        }

        private void UnCheckAllReadControls()
        {
            cbAccountsRead.Checked = false;
            cbAllRead.Checked = false;
            cbBankRead.Checked = false;
            cbClientsRead.Checked = false;
            cbEmployeeRead.Checked = false;
            cbGeneralJournalRead.Checked = false;
            cbInventoryRead.Checked = false;
            cbOrdersRead.Checked = false;
            cbPayrollRead.Checked = false;
            cbProductsRead.Checked = false;
          //  cbRolesRead.Checked = false;
            cbSalesJournal.Checked = false;
            cbUserManegementRead.Checked = false;
            cbVendorRead.Checked = false;
            cbWareHouseRead.Checked = false;
            cbPaymentsRead.Checked = false;
        }

        private void CheckAllControls()
        {
            cbOpeningBalance.Checked = true;
            cbAccountsRead.Checked = true;
            cbAccountsWrite.Checked = true;
            cbAllRead.Checked = true;
            cbAllWrite.Checked = true;
            cbBankRead.Checked = true;
            cbBankUser.Checked = true;
            cbBankWrite.Checked = true;
            cbClientsRead.Checked = true;
            cbClientsWrite.Checked = true;
            cbEmployeeRead.Checked = true;
            cbEmployeeWrite.Checked = true;
            cbGeneralJournalRead.Checked = true;
            cbInventoryRead.Checked = true;
            cbOrdersRead.Checked = true;
            cbOrdersWrite.Checked = true;
            cbPayrollRead.Checked = true;
            cbPayrollWrite.Checked = true;
            cbProductsRead.Checked = true;
            cbProductsWrite.Checked = true;
        //    cbRolesRead.Checked = true;
        //    cbRolesWrite.Checked = true;
            cbSalesJournal.Checked = true;
            cbUserManegementRead.Checked = true;
            cbUserManegementWrite.Checked = true;
            cbVendorRead.Checked = true;
            cbVendorWrite.Checked = true;
            cbWareHouseRead.Checked = true;
            cbWareHouseWrite.Checked = true;
            cbGeneralJournalWrite.Checked = true;
            cbPaymentsRead.Checked = true;
            cbPaymentsWrite.Checked = true;
            cbReportsRead.Checked = true;
            cbExpense.Checked = true;
        }

        private void UnCheckAllControls()
        {
            cbOpeningBalance.Checked = false;
            cbAccountsRead.Checked = false;
            cbAccountsWrite.Checked = false;
            cbAllRead.Checked = false;
            cbAllWrite.Checked = false;
            cbBankRead.Checked = false;
            cbBankUser.Checked = false;
            cbBankWrite.Checked = false;
            cbClientsRead.Checked = false;
            cbClientsWrite.Checked = false;
            cbEmployeeRead.Checked = false;
            cbEmployeeWrite.Checked = false;
            cbGeneralJournalRead.Checked = false;
            cbInventoryRead.Checked = false;
            cbOrdersRead.Checked = false;
            cbOrdersWrite.Checked = false;
            cbPayrollRead.Checked = false;
            cbPayrollWrite.Checked = false;
            cbProductsRead.Checked = false;
            cbProductsWrite.Checked = false;
         //   cbRolesRead.Checked = false;
          //  cbRolesWrite.Checked = false;
            cbSalesJournal.Checked = false;
            cbUserManegementRead.Checked = false;
            cbUserManegementWrite.Checked = false;
            cbVendorRead.Checked = false;
            cbVendorWrite.Checked = false;
            cbWareHouseRead.Checked = false;
            cbWareHouseWrite.Checked = false;
            cbGeneralJournalWrite.Checked = false;
            cbPaymentsWrite.Checked = false;
            cbPaymentsRead.Checked = false;
            cbReportsRead.Checked = false;
            cbExpense.Checked = false;
        }


        private string ComposeRolesString()
        {
            string resultRoles = string.Empty;
            if (cbAllWrite.Checked)
            {
                return (int)Common.Constants.Permissions.AllReadWrite + "-";
            }
            else if (cbAllWrite.Checked)
            {
                return (int)Common.Constants.Permissions.AllRead + "-";
            }
            else
            {
                string RolesString = string.Empty;
                RolesString += CheckEmployee();
              //  RolesString += CheckRoles();
                RolesString += CheckOrders();
                RolesString += CheckWareHouse();
                RolesString += CheckAccounts();
                RolesString += CheckClients();
                RolesString += CheckPayroll();
                RolesString += CheckProducts();
                RolesString += CheckUserManagement();
                RolesString += CheckVendor();
                RolesString += CheckInventoryAndSales();
                RolesString += CheckBankAndAccounts();
                RolesString += CheckPayments();
                RolesString += CheckReports();
                RolesString += CheckOpeningBalance();
                resultRoles = RolesString;
            }
            return resultRoles;
        }


        private string CheckPayments()
        {
            string resultRoles = string.Empty;
            if (cbPaymentsWrite.Checked)
            {
                return (int)Common.Constants.Permissions.PaymentsWrite + "-";
            }
            else if (cbPaymentsRead.Checked)
            {
                return (int)Common.Constants.Permissions.PaymentsRead + "-";
            }
            return resultRoles;

        }


        private string CheckReports()
        {
            string resultRoles = string.Empty;
            if (cbReportsRead.Checked)
            {
                return (int)Common.Constants.Permissions.ReporsRead+ "-";
            }
            if (cbExpense.Checked)
            {
                return (int)Common.Constants.Permissions.Expenses + "-";
            }

            return resultRoles;

        }

        private string CheckEmployee()
        {
            string resultRoles = string.Empty;
            if (cbEmployeeWrite.Checked)
            {
                return (int)Common.Constants.Permissions.EmployeeWrite + "-";
            }
            else if (cbEmployeeRead.Checked)
            {
                return (int)Common.Constants.Permissions.EmployeeRead + "-";
            }
            return resultRoles;
        }
        //private string CheckRoles()
        //{
        //    string resultRoles = string.Empty;
        //    if (cbRolesWrite.Checked)
        //    {
        //        return (int)Common.Constants.Permissions.RolesWrite + "-";
        //    }
        //    else if (cbRolesRead.Checked)
        //    {
        //        return (int)Common.Constants.Permissions.RolesRead + "-";
        //    }
        //    return resultRoles;
        //}
        private string CheckOrders()
        {
            string resultRoles = string.Empty;
            if (cbOrdersWrite.Checked)
            {
                return (int)Common.Constants.Permissions.OrdersWrite + "-";
            }
            else if (cbOrdersRead.Checked)
            {
                return (int)Common.Constants.Permissions.OrdersRead + "-";
            }
            return resultRoles;
        }
        private string CheckWareHouse()
        {
            string resultRoles = string.Empty;
            if (cbWareHouseWrite.Checked)
            {
                return (int)Common.Constants.Permissions.WareHouseWrite + "-";
            }
            else if (cbWareHouseRead.Checked)
            {
                return (int)Common.Constants.Permissions.WareHouseRead + "-";
            }
            return resultRoles;
        }
        private string CheckOpeningBalance()
        {
            string resultRoles = string.Empty;
            if (cbOpeningBalance.Checked)
            {
                return (int)Common.Constants.Permissions.OpeningBalance + "-";
            }
            
            return resultRoles;
        }
        private string CheckAccounts()
        {
            string resultRoles = string.Empty;
            if (cbAccountsWrite.Checked)
            {
                return (int)Common.Constants.Permissions.AccountsWrite + "-";
            }
            else if (cbAccountsRead.Checked)
            {
                return (int)Common.Constants.Permissions.AccountsRead + "-";
            }
            return resultRoles;
        }
        private string CheckClients()
        {
            string resultRoles = string.Empty;
            if (cbClientsWrite.Checked)
            {
                return (int)Common.Constants.Permissions.ClientsWrite + "-";
            }
            else if (cbClientsRead.Checked)
            {
                return (int)Common.Constants.Permissions.ClientsRead + "-";
            }
            return resultRoles;
        }
        private string CheckPayroll()
        {
            string resultRoles = string.Empty;
            if (cbPayrollWrite.Checked)
            {
                return (int)Common.Constants.Permissions.PayrollWrite + "-";
            }
            else if (cbPayrollRead.Checked)
            {
                return (int)Common.Constants.Permissions.PayrollRead + "-";
            }
            return resultRoles;
        }
        private string CheckProducts()
        {
            string resultRoles = string.Empty;
            if (cbProductsWrite.Checked)
            {
                return (int)Common.Constants.Permissions.ProductsWrite + "-";
            }
            else if (cbProductsRead.Checked)
            {
                return (int)Common.Constants.Permissions.ProductsRead + "-";
            }
            return resultRoles;
        }
        private string CheckUserManagement()
        {
            string resultRoles = string.Empty;
            if (cbUserManegementWrite.Checked)
            {
                return (int)Common.Constants.Permissions.UserManagementWrite + "-";
            }
            else if (cbUserManegementRead.Checked)
            {
                return (int)Common.Constants.Permissions.UserManagementRead + "-";
            }
            return resultRoles;
        }
        private string CheckVendor()
        {
            string resultRoles = string.Empty;
            if (cbVendorWrite.Checked)
            {
                return (int)Common.Constants.Permissions.VendorWrite + "-";
            }
            else if (cbVendorRead.Checked)
            {
                return (int)Common.Constants.Permissions.VendorRead + "-";
            }
            return resultRoles;
        }
        private string CheckInventoryAndSales()
        {
            string resultRoles = string.Empty;
            if (cbInventoryRead.Checked)
            {
                return (int)Common.Constants.Permissions.InventoryRead + "-";
            }
            if (cbSalesJournal.Checked)
            {
                return (int)Common.Constants.Permissions.SalesJournal + "-";
            }
            if (cbGeneralJournalWrite.Checked)
            {
                return (int)Common.Constants.Permissions.GeneralJournalWrite + "-";
            }
            else if (cbGeneralJournalRead.Checked)
            {
                return (int)Common.Constants.Permissions.GeneralJournalRead + "-";
            }

            return resultRoles;
        }
        private string CheckBankAndAccounts()
        {
            string resultRoles = string.Empty;
            if (cbBankWrite.Checked)
            {
                return (int)Common.Constants.Permissions.BankAndAccountsWrite + "-";
            }
            else if (cbBankRead.Checked)
            {
                return (int)Common.Constants.Permissions.BankAndAccountsRead + "-";
            }
            if (cbBankUser.Checked)
            {
                return (int)Common.Constants.Permissions.BankAndAccountsUse + "-";
            }
            return resultRoles;
        }

        #endregion
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