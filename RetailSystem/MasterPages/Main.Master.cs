using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.MasterPages
{
    public partial class Main : Classes.MasterBaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.CUsers cu = new Classes.CUsers();
            string LoggedInUserId = string.Empty;
            string FiscalYear = string.Empty;
            string WareHouseName = string.Empty;
            
            LoggedInUserId = Session["User"].ToString();
            FiscalYear = ReturnFiscalYear();
            int UserId = cu.GetUserIdByName(LoggedInUserId);
            WareHouseName = ReturnWareHouseName(UserId.ToString());
            lblLoggedIn.Text = LoggedInUserId;
            lblFiscalYear.Text = FiscalYear;

            lblWareHouse.Text = WareHouseName;
            menu.InnerHtml = BuildMenu();

        }




        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Classes.CUsers cu = new Classes.CUsers();
            int UserId = cu.GetUserIdByName(txtLoginUserId.Text);
            Models.MUsers mu = new Models.MUsers();
            string WareHouseId = string.Empty;
            mu.name = txtLoginUserId.Text;
            mu.password = txtLoginPassword.Text;           
            int retVal = cu.ValidateUser(mu);
            if (retVal == -1)
            {
                lblShow.Text = "Invalid User ID or Password";
            }
            else if (retVal == -2)
            {
                Response.Redirect("~/Pages/SetFiscalYear.aspx");
            }
            else if (retVal == 1)
            {
                Session["User"] = txtLoginUserId.Text;
                Session["FiscalYear"] = retVal;
                Session["WareHouse"] = ReturnWareHouseId(UserId.ToString());

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Models.MUsers mu = new Models.MUsers();
            mu.name = txtuserID.Text;
            mu.password = txtPassword.Text;
            Classes.CUsers cu = new Classes.CUsers();

            if (cu.Save(mu) < 0)
            {
                ShowFailMessage();
            }
            else if (cu.Save(mu) == 2)
            {
                lbluser.Text = "UserName [" + txtuserID.Text + "] Already exists";
            }
            else
            {
                ShowSuccessMessage();
            }
        }

        private string ReturnFiscalYear()
        {
            string FiscalYear = string.Empty;
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            if (Cache["FiscalYear"] != null)
            {
                FiscalYear = Cache["FiscalYear"].ToString();
                return FiscalYear;
            }
            else
            {
                int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
                List<Models.MFiscalYear> Get = new List<Models.MFiscalYear>();
                Get = cf.GetAllById(FiscalYearId);
                if (Get.Count() != 0)
                {
                    string From = Get[0].fiscalFrom.ToShortDateString();
                    string To = Get[0].fiscalTo.ToShortDateString();
                    FiscalYear = From + "--" + To;
                    Cache["FiscalYear"] = FiscalYear;
                    return FiscalYear;
                }
            }
            return FiscalYear;
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


        private string ReturnWareHouseName(string UserId)
        {
            string WareHouse = string.Empty;
            Classes.CUserWareHouseContainer cw = new Classes.CUserWareHouseContainer();
            WareHouse = cw.GetWareHouseNameByUserId(UserId);
            return WareHouse;
        }

        private string ReturnWareHouseId(string UserId)
        {
            string WareHouse = string.Empty;
            Classes.CUserWareHouseContainer cw = new Classes.CUserWareHouseContainer();
            WareHouse = cw.GetWareHouseIdByUserId(UserId);
            return WareHouse;
        }
        private string BuildMenu()
        {
            string Menu = string.Empty;
            string UserName = Session["User"].ToString();
            Classes.CUsers cu = new Classes.CUsers();
            Menu = "<ul class=\"nav navbar-nav\" > <li class=\"home-link\">  <a href=\"Main.aspx\"><i class=\"fa fa-home\"></i><span class=\"hidden\">Home</span></a></li>";
            int UserId = cu.GetUserIdByName(UserName);
            List<string> Permissions = cu.ParsePermissions(UserId);


            #region setup

            Menu += " <li class=\"dropdown \">";
            Menu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\">Setup Forms +</a>";
            Menu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pages-drop\" >";
            Menu += this.RetrunSetupMenu(Permissions);
            Menu += "</ul></li>";

            #endregion

            #region management
            Menu += " <li class=\"dropdown \">";
            Menu += "<a href=\"#\" class=\"dropdown-toggle\" id=\"pages-drop\" data-toggle=\"dropdown\" data-hover=\"dropdown\">Managemnt +</a>";
            Menu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pages-drop\" >";
            Menu += this.RetrunManagementMenu(Permissions);
            Menu += "</ul></li>";
            #endregion

            #region transactions
            Menu += " <li class=\"dropdown \">";
            Menu += "<a href=\"#\" class=\"dropdown-toggle\" id=\"pages-drop\" data-toggle=\"dropdown\" data-hover=\"dropdown\">Transactions +</a>";
            Menu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pages-drop\" >";
            Menu += RetrunTransactionsMenu(Permissions);
            Menu += "</ul></li>";
            #endregion

            #region reports
            Menu += " <li class=\"dropdown \">";
            Menu += "<a href=\"#\" class=\"dropdown-toggle\" id=\"pages-drop\" data-toggle=\"dropdown\" data-hover=\"dropdown\">Inventory Control +</a>";
            Menu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pages-drop\" >";
            Menu += this.RetrunInventoryControlMenu(Permissions);
            Menu += "</ul></li>";
            #endregion

            #region accounts
            Menu += " <li class=\"dropdown \">";
            Menu += "<a href=\"#\" class=\"dropdown-toggle\" id=\"pages-drop\" data-toggle=\"dropdown\" data-hover=\"dropdown\">Accounts +</a>";
            Menu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pages-drop\" >";
            Menu += this.RetrunAccountsMenu(Permissions);
            Menu += "</ul></li>";
            #endregion

            Menu += "</ul>";
            return Menu;
        }

        private string RetrunSetupMenu(List<string> Permissions)
        {
            string SetupMenu = string.Empty;

            //Products
            #region Products
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.ProductsWrite).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Products</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddProdudcts.aspx\" tabindex=\"-1\" class=\"menu-item\">Add Products</a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditProducts.aspx\" tabindex=\"-1\" class=\"menu-item\">View Products </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";
            }
            else if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.ProductsRead).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Products</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditProducts.aspx\" tabindex=\"-1\" class=\"menu-item\">View Products </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";
            }
            #endregion

            //Vendor
            #region Vendor
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.VendorWrite).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Vendor</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddVendor.aspx\" tabindex=\"-1\" class=\"menu-item\">Add Vendors</a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditVendor.aspx\" tabindex=\"-1\" class=\"menu-item\">View Vendors </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";
            }
            else if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.VendorRead).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Vendor</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddVendor.aspx\" tabindex=\"-1\" class=\"menu-item\">Add Vendors</a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";
            }
            #endregion

            //Client
            #region Client
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.ClientsWrite).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Clients</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddClient.aspx\" tabindex=\"-1\" class=\"menu-item\">Add Client</a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditClients.aspx\" tabindex=\"-1\" class=\"menu-item\">View / Edit Clients </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";
            }
            else if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.ClientsRead).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Clients</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditClients.aspx\" tabindex=\"-1\" class=\"menu-item\">View / Edit Clients </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";
            }
            #endregion

            //WareHouse
            #region WareHouse
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.WareHouseWrite).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Warehouse</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddWareHouse.aspx\" tabindex=\"-1\" class=\"menu-item\">Add Warehouse</a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditWarehouse.aspx\" tabindex=\"-1\" class=\"menu-item\">View / Edit Warehouse </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";
            }
            else if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.WareHouseRead).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Warehouse</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditWareHouse.aspx\" tabindex=\"-1\" class=\"menu-item\">View / Edit Warehouse </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";
            }
            #endregion

            //BankAccounts
            #region BankAccounts
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.BankAndAccountsWrite).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Bank</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddBank.aspx\" tabindex=\"-1\" class=\"menu-item\">Add Bank</a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditBank.aspx\" tabindex=\"-1\" class=\"menu-item\">View / Edit Bank </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";

                //Bank Account
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Bank Accounts</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddAccount.aspx\" tabindex=\"-1\" class=\"menu-item\">Add Bank Account</a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditAccount.aspx\" tabindex=\"-1\" class=\"menu-item\">View / Edit Bank Account </a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"SetDefaultAccount.aspx\" tabindex=\"-1\" class=\"menu-item\">Set Default Account </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";

                //Cash Account                
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Cash Accounts</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddCashAccount.aspx\" tabindex=\"-1\" class=\"menu-item\">Add Cash Account</a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditCashAccount.aspx\" tabindex=\"-1\" class=\"menu-item\">View / Edit Personal Cash Account </a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewCashAccountsVendors.aspx\" tabindex=\"-1\" class=\"menu-item\">View Vendors Cash Account </a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewCashAccountsClients.aspx\" tabindex=\"-1\" class=\"menu-item\">View Clients Cash Account </a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"SetDefaultCashAccount.aspx\" tabindex=\"-1\" class=\"menu-item\">Set Default Accounts </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";

            }
            else if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.BankAndAccountsRead).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Bank</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditWareHouse.aspx\" tabindex=\"-1\" class=\"menu-item\">View / Edit Warehouse </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";


                //Bank Account
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Bank Accounts</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditAccount.aspx\" tabindex=\"-1\" class=\"menu-item\">View / Edit Bank Account </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";
            }
            #endregion

            //FiscalYear
            #region FiscalYear
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.AccountsRead).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.AccountsWrite).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Fiscal Year</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddFiscalYear.aspx\" tabindex=\"-1\" class=\"menu-item\">Add NewFiscal Year</a></li>";
                SetupMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"SetDefaultFiscalYear.aspx\" tabindex=\"-1\" class=\"menu-item\">Set Default Fiscal Year </a></li>";
                SetupMenu += "</ul>";
                SetupMenu += "</li>";



            }

            #endregion

            //Opening Balance
            #region OpeningBalance
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.OpeningBalance).ToString()))))
            {
                SetupMenu += "<li class=\"dropdown dropdown-submenu\">";
                SetupMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Opening Balances</a>";
                SetupMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                SetupMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddOpeningInventory.aspx\" tabindex=\"-1\" class=\"menu-item\">Open Inventory Balance</a></li>";
               
                SetupMenu += "</ul>";
                SetupMenu += "</li>";



            }

            #endregion
            return SetupMenu;
        }

        private string RetrunManagementMenu(List<string> Permissions)
        {
            string ManagementMenu = string.Empty;
            //Employee
            #region Employee
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.EmployeeWrite).ToString()))))
            {
                ManagementMenu += "<li class=\"dropdown dropdown-submenu\">";
                ManagementMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Employees</a>";
                ManagementMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                ManagementMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddEmployee.aspx\" tabindex=\"-1\" class=\"menu-item\">Add Employees</a></li>";
                ManagementMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditEmployees.aspx\" tabindex=\"-1\" class=\"menu-item\">View / Edit Employees </a></li>";
                ManagementMenu += "</ul>";
                ManagementMenu += "</li>";
            }
            else if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.EmployeeRead).ToString()))))
            {
                ManagementMenu += "<li class=\"dropdown dropdown-submenu\">";
                ManagementMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Employees</a>";
                ManagementMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                ManagementMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewEditEmployees.aspx\" tabindex=\"-1\" class=\"menu-item\">View / Edit Employees </a></li>";
                ManagementMenu += "</ul>";
                ManagementMenu += "</li>";
            }
            #endregion

            //Payroll
            #region Payroll
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.PayrollWrite).ToString()))))
            {
                ManagementMenu += "<li class=\"dropdown dropdown-submenu\">";
                ManagementMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Payroll</a>";
                ManagementMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                ManagementMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"PaySalary.aspx\" tabindex=\"-1\" class=\"menu-item\">Pay Salary</a></li>";
                ManagementMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewPaidSalary.aspx\" tabindex=\"-1\" class=\"menu-item\">Show Paid Salaries </a></li>";
                ManagementMenu += "</ul>";
                ManagementMenu += "</li>";
            }
            else if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.PayrollRead).ToString()))))
            {
                ManagementMenu += "<li class=\"dropdown dropdown-submenu\">";
                ManagementMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Payroll</a>";
                ManagementMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                ManagementMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewPaidSalary.aspx\" tabindex=\"-1\" class=\"menu-item\">Show Paid Salaries </a></li>";
                ManagementMenu += "</ul>";
                ManagementMenu += "</li>";
            }
            #endregion

            //User Management
            #region UserManagement
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.UserManagementWrite).ToString()))))
            {
                ManagementMenu += "<li class=\"dropdown dropdown-submenu\">";
                ManagementMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Users and Roles</a>";
                ManagementMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                ManagementMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddRoles.aspx\" tabindex=\"-1\" class=\"menu-item\">Add Roles</a></li>";
                ManagementMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AssignPermissions.aspx\" tabindex=\"-1\" class=\"menu-item\">Set Permissions to Roles</a></li>";
                ManagementMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"ApproveUserIds.aspx\" tabindex=\"-1\" class=\"menu-item\">Approve Users</a></li>";
                ManagementMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AssignRoles.aspx\" tabindex=\"-1\" class=\"menu-item\">Assign Roles</a></li>";
                ManagementMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddUsersToWareHouse.aspx\" tabindex=\"-1\" class=\"menu-item\">Assign Warehouses</a></li>";
                ManagementMenu += "</ul>";
                ManagementMenu += "</li>";
            }
            else if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.UserManagementRead).ToString()))))
            {
                ManagementMenu += "<li class=\"dropdown dropdown-submenu\">";
                ManagementMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Users and Roles</a>";
                ManagementMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                ManagementMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"#\" tabindex=\"-1\" class=\"menu-item\">No Link </a></li>";
                ManagementMenu += "</ul>";
                ManagementMenu += "</li>";
            }
            #endregion
            return ManagementMenu;
        }

        private string RetrunTransactionsMenu(List<string> Permissions)
        {
            string TransactionsMenu = string.Empty;
            //Orders
            #region Orders
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.OrdersWrite).ToString()))))
            {
                TransactionsMenu += "<li class=\"dropdown dropdown-submenu\">";
                TransactionsMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Orders</a>";
                TransactionsMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                TransactionsMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"AddOrder.aspx\" tabindex=\"-1\" class=\"menu-item\">Add Order</a></li>";
                TransactionsMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"ViewEditOrderLine.aspx\" tabindex=\"-1\" class=\"menu-item\">View Orders</a></li>";
                TransactionsMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"RevertOrderOrTransaction.aspx\" tabindex=\"-1\" class=\"menu-item\">Revert Transactions</a></li>";
                TransactionsMenu += "</ul>";
                TransactionsMenu += "</li>";
                TransactionsMenu += "<li class=\"dropdown dropdown-submenu\">";
                TransactionsMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Purchase</a>";
                TransactionsMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                TransactionsMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"Purchases.aspx\" tabindex=\"-1\" class=\"menu-item\">Purchase Inventory</a></li>";
                TransactionsMenu += "</ul>";
                TransactionsMenu += "</li>";
                TransactionsMenu += "<li class=\"dropdown dropdown-submenu\">";
                TransactionsMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Sales</a>";
                TransactionsMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                TransactionsMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"SalesJournal.aspx\" tabindex=\"-1\" class=\"menu-item\">Sale Goods</a></li>";
                TransactionsMenu += "</ul>";
                TransactionsMenu += "</li>";
                TransactionsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"TransferFunds.aspx\" tabindex=\"-1\" class=\"menu-item\">Transfer Funds</a></li>";

            }
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                || Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.SalesJournal).ToString()))))
            {
                
            }
            #endregion

            //Payments
            #region Payments
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.PaymentsWrite).ToString()))))
            {
                TransactionsMenu += "<li class=\"dropdown dropdown-submenu\">";
                TransactionsMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Payments</a>";
                TransactionsMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                TransactionsMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"Payment.aspx\" tabindex=\"-1\" class=\"menu-item\">Payments Of Orders</a></li>";
                TransactionsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"Viewpaymentstatus.aspx\" tabindex=\"-1\" class=\"menu-item\">View Payment Status</a></li>";
                TransactionsMenu += "</ul>";
                TransactionsMenu += "</li>";
            }
            else if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.PaymentsRead).ToString()))))
            {
                TransactionsMenu += "<li class=\"dropdown dropdown-submenu\">";
                TransactionsMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Payments</a>";
                TransactionsMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                TransactionsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"Viewpaymentstatus.aspx\" tabindex=\"-1\" class=\"menu-item\">View Payment Status</a></li>";
                TransactionsMenu += "</ul>";
                TransactionsMenu += "</li>";
            }
            #endregion



            return TransactionsMenu;
        }

        private string RetrunInventoryControlMenu(List<string> Permissions)
        {
            string InventoryControlMenu = string.Empty;
            //Inventory Reports
            #region Inventory Reports
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.InventoryRead).ToString()))))
            {
                InventoryControlMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"ViewInventory.aspx\" tabindex=\"-1\" class=\"menu-item\">View Total Inventory</a></li>";
                InventoryControlMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"ViewInventoryTransactions.aspx\" tabindex=\"-1\" class=\"menu-item\">View Inventory Balance</a></li>";
                InventoryControlMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"ViewCashInHand.aspx\" tabindex=\"-1\" class=\"menu-item\">View Cash In Hand</a></li>";
                InventoryControlMenu += " <li role=\"presentation\"><a role=\"menuitem\" href=\"ViewEndingAccountsBalance.aspx\" tabindex=\"-1\" class=\"menu-item\">View Ending Accounts Balance</a></li>";
                InventoryControlMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ItemProfatibilityReport.aspx\" tabindex=\"-1\" class=\"menu-item\">View Item Profatiblity</a></li>";
                InventoryControlMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewTransactions.aspx\" tabindex=\"-1\" class=\"menu-item\">View All Transactions</a></li>";
            }

            #endregion
            return InventoryControlMenu;
        }

        private string RetrunAccountsMenu(List<string> Permissions)
        {
            string AccountsMenu = string.Empty;
            //Accounts Balance Sheet
            #region Accounts Balance Sheet
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.AccountsRead).ToString()))))
            {
              
                AccountsMenu += "<li class=\"dropdown dropdown-submenu\">";
                AccountsMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Accounts Balance Sheets</a>";
                AccountsMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                AccountsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewAccountsBalanceSheet.aspx\" tabindex=\"-1\" class=\"menu-item\">View Accounts Balance Sheet</a></li>";
                AccountsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewCashAccountsBalanceSheetPersonal.aspx\" tabindex=\"-1\" class=\"menu-item\">View Cash BS Personal</a></li>";
                AccountsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewCashAccountsBalanceSheetVendors.aspx\" tabindex=\"-1\" class=\"menu-item\">View Cash BS Vendors</a></li>";
                AccountsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewCashAccountsBalanceSheetClients.aspx\" tabindex=\"-1\" class=\"menu-item\">View Cash BS Clients</a></li>";
                AccountsMenu += "</ul>";
                AccountsMenu += "</li>";
            }

            #endregion

            //Remaining Payments
            #region Remaining Payments
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.PaymentsRead).ToString()))))
            {
                AccountsMenu += "<li class=\"dropdown dropdown-submenu\">";
                AccountsMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Remaining Payments</a>";
                AccountsMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                AccountsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewReceivable.aspx\" tabindex=\"-1\" class=\"menu-item\">View Recievables</a></li>";
                AccountsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewPayables.aspx\" tabindex=\"-1\" class=\"menu-item\">View Payables</a></li>";
                AccountsMenu += "</ul>";
                AccountsMenu += "</li>";
            }

            #endregion

            //Expense
            #region Expense
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Expenses).ToString()))))
            {
                AccountsMenu += "<li class=\"dropdown dropdown-submenu\">";
                AccountsMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Record Expenses</a>";
                AccountsMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                AccountsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ShopExpense.aspx\" tabindex=\"-1\" class=\"menu-item\">Shop Expense</a></li>";
                AccountsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"MscExpense.aspx\" tabindex=\"-1\" class=\"menu-item\">Msc Expense</a></li>";
                AccountsMenu += "</ul>";
                AccountsMenu += "</li>";
            }

            #endregion

            //Financial Reports
            #region GJ
            if (Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.Admin).ToString())))
                ||
                Permissions.Exists(o => o.Equals((((int)Common.Constants.Permissions.GeneralJournalWrite).ToString()))))
            {
                AccountsMenu += "<li class=\"dropdown dropdown-submenu\">";
                AccountsMenu += "<a href=\"#\" class=\"dropdown-toggle\"  data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"false\">Financial Reports</a>";
                AccountsMenu += "<ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"pricing-drop\">";
                AccountsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewGeneralJournal.aspx\" tabindex=\"-1\" class=\"menu-item\">View Journal</a></li>";
                AccountsMenu += "<li role=\"presentation\"> <a role=\"menuitem\" href=\"ViewTrialBalance.aspx\" tabindex=\"-1\" class=\"menu-item\">View Trial Balance</a></li>";
                AccountsMenu += "</ul>";
                AccountsMenu += "</li>";
            }

            #endregion
            return AccountsMenu;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Session["UserId"] = null;
                Session["FiscalYear"] = null;
                Response.Redirect("~/Default.aspx");

            }
        }



    }
}