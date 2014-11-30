using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class PaymentsLinePurchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetDataFromQueryString(); BindDropDowns();
                divBankAccount.Visible = false;
                divCashAccount.Visible = false;
            }
        }

        protected void btnPaymentPurchase_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && Page.IsPostBack)
            {
                if (ddlOption.SelectedValue != "-1")
                {
                    int retVal = SavePayment("Vendor");
                    if (retVal > 0)
                    {

                        ClearTextBoxes(Page);
                        ShowSuccessMessage();


                    }
                    else if (retVal == -1)
                    {
                        ShowErrorModal("Payment was unsuccessfull");
                    }
                    else if (retVal == -2)
                    {
                        ShowErrorModal("Payment Amount has been updated without any account transaction");
                    }
                    else if (retVal == -3)
                    {
                        ShowErrorModal("No type of order was defined, Please revert Payment");
                    }
                    else if (retVal == -4)
                    {
                        ShowErrorModal("Payments has been updated, But no accounts has been effected");
                    }
                    else if (retVal == -5)
                    {
                        ShowErrorModal("Account not updated.");
                    }
                }
                else
                {
                    ShowErrorModal("Please select an Mode Of Payment");
                }
            }
        }

        protected void ddlOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                int OptionValue = Convert.ToInt32(ddlOption.SelectedValue);
                switch (OptionValue)
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
                        divBankAccount.Visible = false;
                        divCashAccount.Visible = false;
                        break;
                }
            }
        }


        private void BindDropDowns()
        {
            List<Models.MBankAccount> BankAccount = new List<Models.MBankAccount>();
            List<Models.MCashAccount> CashAccount = new List<Models.MCashAccount>();
            Classes.CBankOfAccount ca = new Classes.CBankOfAccount();
            Classes.CCashAccount cc = new Classes.CCashAccount();
            BankAccount = ca.GetAll();
            CashAccount = cc.GetAll();
            BankAccount = BankAccount.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            CashAccount = CashAccount.Where(o => o.WareHouseId == Convert.ToInt32(Session["WareHouse"].ToString())).ToList();
            Dictionary<int, string> Bank = new Dictionary<int, string>();
            Dictionary<int, string> Cash = new Dictionary<int, string>();
            Cash.Add(-1, "Please Select");
            Bank.Add(-1, "Please Select");
            for (int i = 0; i < CashAccount.Count; i++)
            {
                Cash.Add(CashAccount[i].id, CashAccount[i].CashAccountName);
            }
            for (int i = 0; i < BankAccount.Count; i++)
            {
                Bank.Add(Convert.ToInt32(BankAccount[i].id), BankAccount[i].Accounttitle + "-" + BankAccount[i].accountNumber);
            }
            ddlCashAccount.DataTextField = "Value";
            ddlCashAccount.DataValueField = "Key";
            ddlPurchaseAccount.DataTextField = "Value";
            ddlPurchaseAccount.DataValueField = "Key";
            ddlCashAccount.DataSource = Cash;
            ddlPurchaseAccount.DataSource = Bank;
            ddlCashAccount.DataBind();
            ddlPurchaseAccount.DataBind();
        }

        private void SetDataFromQueryString()
        {
            string OrderId = string.Empty;
            string OrderName = string.Empty;
            string OrderCode = string.Empty;
            string OrderPaymentId = string.Empty;
            string OrderVendorId = string.Empty;
            string OrderVendorName = string.Empty;
            string OrderSalesTotal = string.Empty;
            string OrderAmountTotal = string.Empty;
            string OrderAmountPaid = string.Empty;
            string OrderAmountRemaining = string.Empty;

            OrderId = Request.QueryString["OrderID"].ToString();

            OrderName = Request.QueryString["OrderName"].ToString();
            OrderCode = Request.QueryString["OrderCode"].ToString();
            OrderPaymentId = Request.QueryString["OrderPaymentId"].ToString();
            OrderVendorId = Request.QueryString["OrderVendorId"].ToString();
            OrderVendorName = Request.QueryString["OrderVendorName"].ToString();
            OrderAmountTotal = Request.QueryString["OrderTotal"].ToString();
            OrderAmountPaid = Request.QueryString["OrderAmountPaid"].ToString();
            OrderAmountRemaining = Request.QueryString["OrderAmountRemaining"].ToString();

            lblPurchaseOrderId.Text = OrderId;
            lblPurchaseOrderName.Text = OrderName;
            lblPurchaseOrderCode.Text = OrderCode;
            lblPurchasePaymentId.Text = OrderPaymentId;
            lblPurchaseVendorId.Text = OrderVendorId;
            lblPurchaseVendorName.Text = OrderVendorName;
            lblPurchaseTotalCost.Text = OrderAmountTotal;
            lblPurchaseAmountPaid.Text = OrderAmountPaid;
            lblPurchaseAmountRemaining.Text = OrderAmountRemaining;

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
        private int SavePayment(string Type)
        {
            string PaymentId = lblPurchasePaymentId.Text;
            string OrderId = lblPurchaseOrderId.Text;
            string totalCost = lblPurchaseTotalCost.Text;
            string CurrentAmountPaid = txtPurchaseAmount.Text;
            string AccountId = string.Empty;
            string ChequeNumber = string.Empty;
            int OptionValue = Convert.ToInt32(ddlOption.SelectedValue);
            switch (OptionValue)
            {
                case -1:
                    {
                        return -1;

                    }
                case 1:
                    {
                        if (cbBankPurchases.Checked)
                        {
                            Classes.CDefaultAccount df = new Classes.CDefaultAccount();
                            AccountId = df.ReturnPurchaseDefaultAccount(Convert.ToInt32(Session["WareHouse"])).ToString();
                        }
                        else
                        {
                            AccountId = ddlPurchaseAccount.SelectedValue;
                        }
                        ChequeNumber = txtCheque.Text;
                        break;
                    }
                case 2:
                    {
                        if (cbSalePurchases.Checked)
                        {
                            Classes.CDefaultCashAccount df = new Classes.CDefaultCashAccount();
                            AccountId = df.ReturnPurchaseDefaultAccount(Convert.ToInt32(Session["WareHouse"])).ToString();
                        }
                        else
                        {
                            AccountId = ddlCashAccount.SelectedValue;
                        }
                        break;
                    }
                default:
                    return -1;

            }

            float AmountRemaining = Convert.ToSingle(totalCost) - (Convert.ToSingle(CurrentAmountPaid) + Convert.ToSingle(lblPurchaseAmountPaid.Text));
            string RemainingAmount = AmountRemaining.ToString();
            string DatePaid = txtPurchaseDate.Text;
            return ProcessPayments(PaymentId, OrderId, totalCost, CurrentAmountPaid, AccountId
                , AmountRemaining, RemainingAmount, DatePaid, Type, ChequeNumber);

        }

        private int ProcessPayments(string PaymentId, string OrderId, string totalCost, string CurrentAmountPaid,
            string AccountId, float AmountRemaining, string RemainingAmount, string DatePaid, string Type, string Cheque)
        {
            if (Page.IsValid)
            {
                Classes.CBankOfAccount cba = new Classes.CBankOfAccount();
                Classes.CAccountTransaction cat = new Classes.CAccountTransaction();
                Classes.CCashAccount cha = new Classes.CCashAccount();
                Classes.CCashTransaction cht = new Classes.CCashTransaction();
                Classes.CPayment cp = new Classes.CPayment();
                Classes.CPaymentLine cpl = new Classes.CPaymentLine();
                Classes.CSaleTransations cs = new Classes.CSaleTransations();
                Models.MAccountTransaction mat = new Models.MAccountTransaction();
                Models.MPayments mp = new Models.MPayments();
                Models.PaymentLine mpl = new Models.PaymentLine();
                Models.MCashTransactions mht = new Models.MCashTransactions();
                Models.MCashAccount mha = new Models.MCashAccount();

                #region Payments
                mp.Paid = (Convert.ToSingle(totalCost) - AmountRemaining).ToString();
                if (cp.UpdateAmountPaid(Convert.ToInt32(PaymentId), mp.Paid) < 0)
                {
                    return -1;
                }
                #endregion

                #region PaymentLine
                mpl.PaymentId = Convert.ToInt32(PaymentId);
                mpl.BankId = Convert.ToInt32(AccountId);
                mpl.Date = DatePaid;
                mpl.PaidAmount = CurrentAmountPaid;
                mpl.RemainingAmount = RemainingAmount;
                mpl.CumulativeAmount = (Convert.ToSingle(cpl.LastPaidAmount(mpl.PaymentId))
                                        + Convert.ToSingle(CurrentAmountPaid)).ToString();
                int OptionValue = Convert.ToInt32(ddlOption.SelectedValue);
                mpl.Cheque = Cheque;
                switch (OptionValue)
                {
                    case -1:
                        {

                            return -1;

                        }
                    case 1:
                        {

                            #region Account Transactions
                            mpl.ModeOfPayment = Common.Constants.ModeOfPayment.Cheque.ToString();
                            float AccountTotal = cba.ReturnTotalOfAccountById(Convert.ToInt32(AccountId));
                            mat.AccountId = AccountId;
                            if (Type.Contains("Vendor"))
                            {
                                mat.Description = "Payment Of Order Id[" + OrderId + "] Paid, Amount ["
                                    + CurrentAmountPaid + "]";
                                mat.Debit = CurrentAmountPaid;
                                mat.Credit = "0";
                                mat.Total = (AccountTotal - Convert.ToSingle(CurrentAmountPaid)).ToString();
                                mat.CurrentTransaction = cs.GetIdByOrderId(Convert.ToInt32(OrderId)).ToString();
                                mat.Transactiontype = "Debit";

                                mat.FiscalYearId = Session["FiscalYear"].ToString();
                                mat.eDate = Convert.ToDateTime(DatePaid);

                            }
                            else if (Type.Contains("Client"))
                            {
                                mat.Description = "Payment Of Order Id[" + OrderId + "] Recieved, Amount ["
                                 + CurrentAmountPaid + "]";
                                mat.Debit = "0";
                                mat.Credit = CurrentAmountPaid;
                                mat.CurrentTransaction = cs.GetIdByOrderId(Convert.ToInt32(OrderId)).ToString();
                                mat.Total = (AccountTotal + Convert.ToSingle(CurrentAmountPaid)).ToString();
                                mat.Transactiontype = "Credit";
                                mat.FiscalYearId = Session["FiscalYear"].ToString();
                                mat.eDate = Convert.ToDateTime(DatePaid);

                            }
                            else
                            {
                                return -3;
                            }

                            if (cat.Save(mat) < 0)
                            {
                                return -4;
                            }
                            if (cba.SetNewAccountTotal(Convert.ToInt32(AccountId), Convert.ToSingle(mat.Total)) < 0)
                            {
                                return -5;
                            }
                            #endregion
                            break;
                        }
                    case 2:
                        {

                            #region Cash Transaction
                            mpl.ModeOfPayment = Common.Constants.ModeOfPayment.Cash.ToString();
                            mpl.Cheque = "-";
                            float AccountTotal = cha.ReturnTotalOfCashAccount(Convert.ToInt32(AccountId));
                            mht.CashAccountId = Convert.ToInt32(AccountId);
                            if (Type.Contains("Vendor"))
                            {
                                mht.Credit = "0";
                                mht.Debit = CurrentAmountPaid;
                                mht.Description = "Payment Of Order Id[" + OrderId + "] Paid, Amount ["
                                 + CurrentAmountPaid + "]";
                                mht.eDate = (DatePaid);
                                mht.FiscalYearId = Convert.ToInt32(Session["FiscalYear"].ToString());
                                mht.OrderId = Convert.ToInt32(OrderId);
                                mht.Total = totalCost;
                                mht.TransactionId = -1;
                                mht.TransactionType = "Debit";
                                string UserName = Session["User"].ToString();
                                Classes.CUsers cu = new Classes.CUsers();
                                string UserId = cu.GetUserIdByName(UserName).ToString();
                                mht.UserId = Session["User"].ToString();
                                mht.WareHouseId = Convert.ToInt32(Session["WareHouse"].ToString());

                            }
                            else if (Type.Contains("Client"))
                            {
                                mht.Credit = CurrentAmountPaid;
                                mht.Debit = "0";
                                mht.Description = "Payment Of Order Id[" + OrderId + "] Recieved, Amount ["
                                 + CurrentAmountPaid + "]";
                                mht.eDate = (DatePaid);
                                mht.FiscalYearId = Convert.ToInt32(Session["FiscalYear"].ToString());
                                mht.OrderId = Convert.ToInt32(OrderId);
                                mht.Total = totalCost;
                                mht.TransactionId = -1;
                                mht.TransactionType = "Debit";
                                string UserName = Session["User"].ToString();
                                Classes.CUsers cu = new Classes.CUsers();
                                string UserId = cu.GetUserIdByName(UserName).ToString();
                                mht.UserId = Session["User"].ToString();
                                mht.WareHouseId = Convert.ToInt32(Session["WareHouse"].ToString());

                            }
                            else
                            {
                                return -3;
                            }

                            if (cht.Save(mht) < 0)
                            {
                                return -4;
                            }
                            if (cha.SetNewAccountTotal(Convert.ToInt32(AccountId), Convert.ToSingle(mat.Total)) < 0)
                            {
                                return -5;
                            }
                            #endregion
                            break;
                        }
                    default:
                        return -1;

                }
                if (cpl.Save(mpl) < 0)
                {
                    return -2;
                }
                #endregion



                #region Accounts
                if (Convert.ToSingle(mp.Paid) > 0)
                {
                    if (Type == "Vendor")
                    {
                        Classes.CJournal cj = new Classes.CJournal();
                        Models.MJournal mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.MerchandiseInventory).ToString();
                        mj.amount = mp.Paid;
                        mj.des = "Payment Recieved of Order id [" + OrderId + "]";
                        mj.e_date = (DatePaid);
                        mj.type = Common.Constants.Accounts.Type.Debit.ToString();
                        cj.Save(mj);

                        mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.AccountsPayable).ToString();
                        mj.amount = mp.Paid;
                        mj.des = "Payment Recieved of Order id [" + OrderId + "]";
                        mj.e_date = (DatePaid);
                        mj.type = Common.Constants.Accounts.Type.Credit.ToString();
                        cj.Save(mj);
                    }
                    else if (Type == "Client")
                    {
                        Classes.CJournal cj = new Classes.CJournal();
                        Models.MJournal mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.CostOfGoodsSold).ToString();
                        mj.amount = mp.Paid;
                        mj.des = "Payment Recieved of Order id [" + OrderId + "]";
                        mj.e_date = (DatePaid);
                        mj.type = Common.Constants.Accounts.Type.Debit.ToString();
                        cj.Save(mj);

                        mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.MerchandiseInventory).ToString();
                        mj.amount = mp.Paid;
                        mj.des = "Payment Recieved of Order id [" + OrderId + "]";
                        mj.e_date = (DatePaid);
                        mj.type = Common.Constants.Accounts.Type.Credit.ToString();
                        cj.Save(mj);

                        cj = new Classes.CJournal();
                        mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.AccountsRecievalbes).ToString();
                        mj.amount = mp.Paid;
                        mj.des = "Payment Recieved of Order id [" + OrderId + "]";
                        mj.e_date = (DatePaid);
                        mj.type = Common.Constants.Accounts.Type.Debit.ToString();
                        cj.Save(mj);

                        mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.Sales).ToString();
                        mj.amount = mp.Paid;
                        mj.des = "Payment Recieved of Order id [" + OrderId + "]";
                        mj.e_date = (DatePaid);
                        mj.type = Common.Constants.Accounts.Type.Credit.ToString();
                        cj.Save(mj);
                    }
                }
                #endregion


            }
            lblPurchaseAmountRemaining.Text = AmountRemaining.ToString();
            lblPurchaseAmountPaid.Text = (Convert.ToSingle(totalCost) - AmountRemaining).ToString();
            return 1;
        }


    }
}