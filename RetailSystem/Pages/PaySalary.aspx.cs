using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class PaySalary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindEmployeeDdl(); BindAccountsDdl(); BindCashAccountDdl();
                divBankAccount.Visible = false;
                divCashAccount.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                int retVal = SavePaymentOfEmployee();
                if (retVal > 0)
                {
                    ShowSuccessMessage();
                    ClearTextBoxes(Page);
                }
                else if (retVal == -4)
                {
                    ShowErrorModal("Please Select mode of Payment Bank/Cash");
                }
                else if (retVal == -5)
                {
                    ShowErrorModal("Please Select mode of Payment Bank/Cash");
                }
                else if (retVal == -1)
                {
                    ShowErrorModal("Payments were not saved");
                }
                else if (retVal == -2)
                {
                    ShowErrorModal("Payments are saved but account was not effected!");
                }
                else if (retVal == -3)
                {
                    ShowErrorModal("Payments are saved but not transaction was recorded");
                }

            }
        }

        protected void ddlOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                int value = Convert.ToInt32(ddlOption.SelectedValue);
                switch (value)
                {
                    case -1:
                        {
                            divBankAccount.Visible = false;
                            divCashAccount.Visible = false;
                            break;
                        }
                    case 1:
                        {
                            divBankAccount.Visible = true;
                            divCashAccount.Visible = false;
                            break;
                        }
                    case 2:
                        {
                            divBankAccount.Visible = false;
                            divCashAccount.Visible = true;
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        #region Private functions
        private int SavePaymentOfEmployee()
        {
            int AccountId = Convert.ToInt32(ddlAccount.SelectedValue);
            int CashAccountId = Convert.ToInt32(ddlCashAccount.SelectedValue);
            string EmployeeId = ddlEmployee.SelectedValue;
            string MonthPaid = txtMonth.Text;
            string SalaryId = Session["WareHouse"].ToString();
            string Paid = txtPaidAmount.Text;
            string DatePaid = txtDateOfPayment.Text;
            Classes.CPaidSalary cp = new Classes.CPaidSalary();
            Models.MPaidSalary mp = new Models.MPaidSalary();
            mp.EmployeeId = EmployeeId;
            mp.MonthPaid = MonthPaid;
            mp.Paid = Paid;
            mp.SalaryId = SalaryId;
            mp.DatePaid = DatePaid;

            int option = Convert.ToInt32(ddlOption.SelectedValue);
            if (option < 1)
            {
                return -4;
            }
            if (cp.Save(mp) > 0)
            {
                switch (option)
                {
                    case 1:
                        {

                            Classes.CBankOfAccount cab = new Classes.CBankOfAccount();
                            Classes.CAccountTransaction cat = new Classes.CAccountTransaction();
                            Models.MAccountTransaction mat = new Models.MAccountTransaction();
                            float AccountTotal = cab.ReturnTotalOfAccountById(AccountId);
                            AccountTotal = AccountTotal - Convert.ToSingle(Paid);
                            if (cab.SetNewAccountTotal(AccountId, AccountTotal) > 0)
                            {
                                // float PreviousAccountTotal = cab.ReturnTotalOfAccountById(AccountId);
                                mat.AccountId = AccountId.ToString();
                                mat.Credit = "0";
                                mat.CurrentTransaction = "-1";
                                mat.Debit = Paid;
                                mat.Description = "Paid Salary for the month of [" + MonthPaid + "] to " +
                                     "Employee[" + ddlEmployee.SelectedItem.Text + "] Amount [" + Paid + "]";
                                mat.eDate = Convert.ToDateTime(DatePaid);
                                mat.FiscalYearId = Convert.ToInt32(Session["FiscalYear"]).ToString();
                                //  PreviousAccountTotal = PreviousAccountTotal - Convert.ToSingle(Paid);
                                mat.Total = AccountTotal.ToString();
                                if (cat.Save(mat) > 0)
                                {
                                    Classes.CJournal cj = new Classes.CJournal();
                                    Models.MJournal mj = new Models.MJournal();
                                    mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.SalaryExpense).ToString();
                                    mj.amount = mp.Paid;
                                    mj.des = "Payment of Employee  [" + ddlEmployee.SelectedItem.Text + "] ";
                                    mj.e_date = (DatePaid);
                                    mj.type = Common.Constants.Accounts.Type.Debit.ToString();
                                    cj.Save(mj);

                                    mj = new Models.MJournal();
                                    mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.Cash).ToString();
                                    mj.amount = mp.Paid;
                                    mj.des = "Payment of Employee  [" + ddlEmployee.SelectedItem.Text + "] ";
                                    mj.e_date = (DatePaid);
                                    mj.type = Common.Constants.Accounts.Type.Credit.ToString();
                                    cj.Save(mj);

                                    return 1;
                                }
                                else
                                {
                                    return -3;
                                }
                            }
                            else
                            {
                                return -2;
                            }
                           
                        }
                    case 2:
                        {
                            Classes.CCashAccount cab = new Classes.CCashAccount();
                            Classes.CCashTransaction cat = new Classes.CCashTransaction();
                            Models.MCashTransactions mat = new Models.MCashTransactions();
                            float AccountTotal = cab.ReturnTotalOfCashAccount(CashAccountId);
                            AccountTotal = AccountTotal - Convert.ToSingle(Paid);
                            if (cab.SetNewAccountTotal(CashAccountId, AccountTotal) > 0)
                            {
                                // float PreviousAccountTotal = cab.ReturnTotalOfAccountById(AccountId);
                                mat.CashAccountId = CashAccountId;
                                mat.Credit = "0";
                                mat.Debit = Paid;
                                mat.Description = "Paid Salary for the month of [" + MonthPaid + "] to " +
                                     "Employee[" + ddlEmployee.SelectedItem.Text + "] Amount [" + Paid + "]";
                                if (cat.Save(mat) > 0)
                                {
                                    Classes.CJournal cj = new Classes.CJournal();
                                    Models.MJournal mj = new Models.MJournal();
                                    mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.SalaryExpense).ToString();
                                    mj.amount = mp.Paid;
                                    mj.des = "Payment of Employee  [" + ddlEmployee.SelectedItem.Text + "] ";
                                    mj.e_date = (DatePaid);
                                    mj.type = Common.Constants.Accounts.Type.Debit.ToString();
                                    cj.Save(mj);

                                    mj = new Models.MJournal();
                                    mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.Cash).ToString();
                                    mj.amount = mp.Paid;
                                    mj.des = "Payment of Employee  [" + ddlEmployee.SelectedItem.Text + "] ";
                                    mj.e_date = (DatePaid);
                                    mj.type = Common.Constants.Accounts.Type.Credit.ToString();
                                    cj.Save(mj);

                                    return 1;
                                }
                                else
                                {
                                    return -3;
                                }
                            }
                            else
                            {
                                return -2;
                            }
                           
                        }
                    default:
                        return -5;
                      
                }
            }
            else
            {
                return -1;
            }

        }

        private void BindEmployeeDdl()
        {
            Classes.CEmployees ce = new Classes.CEmployees();
            Dictionary<int, string> Employees = new Dictionary<int, string>();
            List<Models.MEmployees> Get = new List<Models.MEmployees>();
            Get = ce.GetAll();
            Get = Get.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            Employees.Add(-1, "Please Select Employees");
            for (int i = 0; i < Get.Count; i++)
            {
                int Id = Convert.ToInt32(Get[i].id);
                string EmployeeName = Get[i].FirstName + "-" + Get[i].LastName;
                Employees.Add(Id, EmployeeName);
            }
            ddlEmployee.DataTextField = "Value";
            ddlEmployee.DataValueField = "Key";
            ddlEmployee.DataSource = Employees;
            ddlEmployee.DataBind();
        }


        private void BindAccountsDdl()
        {
            Classes.CBankOfAccount cv = new Classes.CBankOfAccount();
            Dictionary<int, string> VendorData = new Dictionary<int, string>();
            List<Models.MBankAccount> Get = new List<Models.MBankAccount>();
            Get = cv.GetAll();
            Get = Get.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            VendorData.Add(-1, "Please Select");
            for (int i = 0; i < Get.Count; i++)
            {
                VendorData.Add(Convert.ToInt32(Get[i].id), Get[i].Accounttitle + " Number: " + Get[i].accountNumber);

            }
            ddlAccount.DataValueField = "Key";
            ddlAccount.DataTextField = "Value";
            ddlAccount.DataSource = VendorData;
            ddlAccount.DataBind();


        }

        private void BindCashAccountDdl()
        {
            Classes.CCashAccount cv = new Classes.CCashAccount();
            Dictionary<int, string> VendorData = new Dictionary<int, string>();
            List<Models.MCashAccount> Get = new List<Models.MCashAccount>();
            Get = cv.GetAll();
            Get = Get.Where(o => o.WareHouseId == Convert.ToInt32(Session["WareHouse"].ToString())).ToList();
            VendorData.Add(-1, "Please Select");
            for (int i = 0; i < Get.Count; i++)
            {
                VendorData.Add(Convert.ToInt32(Get[i].id), Get[i].CashAccountName);

            }
            ddlCashAccount.DataValueField = "Key";
            ddlCashAccount.DataTextField = "Value";
            ddlCashAccount.DataSource = VendorData;
            ddlCashAccount.DataBind();
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
        #endregion


    }
}