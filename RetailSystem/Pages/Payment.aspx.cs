using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindAccountsDdl(); BindClientsGird(); BindVendorsGrid();
            }
        }

        protected void grdSales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("showOrder"))
            {
                ShowModal("modalSalesOrders");

            }
            else if (e.CommandName.Equals("payment"))
            {

                GridViewRow gvrow = grdSales.Rows[index];
                float totalCost = Convert.ToSingle(HttpUtility.HtmlDecode(gvrow.Cells[7].Text).ToString());
                float AmountPaid = Convert.ToSingle(HttpUtility.HtmlDecode(gvrow.Cells[8].Text).ToString());
                string QueryString = "?OrderID=" + HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString() +
                    "&OrderName=" + HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString() + "" +
                "&OrderCode=" + HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString() + "" +
                "&OrderPaymentId=" + HttpUtility.HtmlDecode(gvrow.Cells[4].Text).ToString() + "" +
                "&OrderClientId=" + HttpUtility.HtmlDecode(gvrow.Cells[5].Text).ToString() + "" +
                "&OrderClientName=" + HttpUtility.HtmlDecode(gvrow.Cells[6].Text).ToString() + "" +
                "&OrderSalesTotal=" + HttpUtility.HtmlDecode(gvrow.Cells[7].Text).ToString() + "" +
                "&OrderAmountPaid=" + HttpUtility.HtmlDecode(gvrow.Cells[8].Text).ToString() + "" +
                "&OrderAmountRemaining=" + (totalCost - AmountPaid).ToString() + "";

                Response.Redirect("~/Pages/PaymentLineSales.aspx" + QueryString);
            }
        }

        protected void grdPurchases_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("showOrder"))
            {
                ShowModal("modalPurchaseOrders");

            }
            else if (e.CommandName.Equals("payment"))
            {
                GridViewRow gvrow = grdPurchases.Rows[index];

                float totalCost = Convert.ToSingle(HttpUtility.HtmlDecode(gvrow.Cells[7].Text).ToString());
                float AmountPaid = Convert.ToSingle(HttpUtility.HtmlDecode(gvrow.Cells[8].Text).ToString());
             

                string QueryString = "?OrderID=" + HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString() +
                    "&OrderName=" + HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString() + "" +
                "&OrderCode=" + HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString() + "" +
                "&OrderPaymentId=" + HttpUtility.HtmlDecode(gvrow.Cells[4].Text).ToString() + "" +
                "&OrderVendorId=" + HttpUtility.HtmlDecode(gvrow.Cells[5].Text).ToString() + "" +
                "&OrderVendorName=" + HttpUtility.HtmlDecode(gvrow.Cells[6].Text).ToString() + "" +
                "&OrderTotal=" + HttpUtility.HtmlDecode(gvrow.Cells[7].Text).ToString() + "" +
                "&OrderAmountPaid=" + HttpUtility.HtmlDecode(gvrow.Cells[8].Text).ToString() + "" +
                "&OrderAmountRemaining=" + (totalCost - AmountPaid).ToString() + "";
                Response.Redirect("~/Pages/PaymentsLinePurchase.aspx"  + QueryString);
            }
        }

        protected void btnPaymentPurchase_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && Page.IsPostBack)
            {
                if (ddlPurchaseAccount.SelectedValue != "-1" || cbPurchases.Checked)
                {
                    int retVal = SavePayment("Vendor");
                    if (retVal > 0)
                    {
                        BindVendorsGrid();
                        HideModal();
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
                    ShowErrorModal("Please select an account or check default account");
                }
            }
        }

        protected void btnPaymentSales_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && Page.IsPostBack)
            {
                if (ddlSaleAccount.SelectedValue != "-1" || cbSalesDefault.Checked)
                {
                    int retVal = SavePayment("Client");
                    if (retVal > 0)
                    {
                        BindClientsGird();
                        HideModal();
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
                    ShowErrorModal("Please select an account or check default account");
                }
            }
        }


        #region Private Events
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
        private void HideModal()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('.modal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);

        }

        private void ShowModal(string modalId)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#" + modalId + "').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);

        }

        private void BindAccountsDdl()
        {
            Classes.CBankOfAccount cv = new Classes.CBankOfAccount();
            Dictionary<int, string> VendorData = new Dictionary<int, string>();
            List<Models.MBankAccount> Get = new List<Models.MBankAccount>();
            Get = cv.GetAll();
            VendorData.Add(-1, "Please Select");
            for (int i = 0; i < Get.Count; i++)
            {
                VendorData.Add(Convert.ToInt32(Get[i].id), Get[i].Accounttitle + " Number: " + Get[i].accountNumber);

            }

            ddlSaleAccount.DataSource = VendorData;
            ddlPurchaseAccount.DataSource = VendorData;
            ddlSaleAccount.DataValueField = "Key";
            ddlSaleAccount.DataTextField = "Value";
            ddlPurchaseAccount.DataValueField = "Key";
            ddlPurchaseAccount.DataTextField = "Value";
            ddlPurchaseAccount.DataBind();
            ddlSaleAccount.DataBind();

        }

        private void BindVendorsGrid()
        {
            List<Models.MOrderViewOfPayment> VendorPayments = new List<Models.MOrderViewOfPayment>();
            Classes.CPayment cp = new Classes.CPayment();
            VendorPayments = cp.ShowVendorOrderViewForPayment();
            grdPurchases.DataSource = VendorPayments;
            grdPurchases.DataBind();
        }

        private void BindClientsGird()
        {
            List<Models.MOrderViewOfPayment> ClientPayments = new List<Models.MOrderViewOfPayment>();
            Classes.CPayment cp = new Classes.CPayment();
            ClientPayments = cp.ShowClientOrderViewForPayment();
            grdSales.DataSource = ClientPayments;
            grdSales.DataBind();
        }

        private int SavePayment(string Type)
        {
            switch (Type)
            {
                case "Client":
                    {
                        string PaymentId = lblSalesPaymentId.Text;
                        string OrderId = lblSalesOrderID.Text;
                        string totalCost = lblSalesTotalCost.Text;
                        string CurrentAmountPaid = txtSalesAmount.Text;
                        string AccountId = ddlSaleAccount.SelectedValue;
                        if (cbSalesDefault.Checked)
                        {
                            Classes.CDefaultAccount df = new Classes.CDefaultAccount();
                            AccountId = df.ReturnSaleDefaultAccount(Convert.ToInt32(Session["WareHouse"])).ToString();
                        }
                        float AmountRemaining = Convert.ToSingle(totalCost) - (Convert.ToSingle(CurrentAmountPaid) + Convert.ToSingle(lblSalesAmountPaid.Text));
                        string RemainingAmount = AmountRemaining.ToString();
                        string DatePaid = txtSalesDate.Text;
                        return ProcessPayments(PaymentId, OrderId, totalCost, CurrentAmountPaid, AccountId
                            , AmountRemaining, RemainingAmount, DatePaid, Type);

                    }
                case "Vendor":
                    {
                        string PaymentId = lblPurchasePaymentId.Text;
                        string OrderId = lblPurchaseOrderId.Text;
                        string totalCost = lblPurchaseTotalCost.Text;
                        string CurrentAmountPaid = txtPurchaseAmount.Text;
                        string AccountId = ddlPurchaseAccount.SelectedValue;
                        if (cbPurchases.Checked)
                        {
                            Classes.CDefaultAccount df = new Classes.CDefaultAccount();
                            AccountId = df.ReturnPurchaseDefaultAccount(Convert.ToInt32(Session["WareHouse"])).ToString();
                        }
                        float AmountRemaining = Convert.ToSingle(totalCost) - (Convert.ToSingle(CurrentAmountPaid) + Convert.ToSingle(lblPurchaseAmountPaid.Text));
                        string RemainingAmount = AmountRemaining.ToString();
                        string DatePaid = txtPurchaseDate.Text;
                        return ProcessPayments(PaymentId, OrderId, totalCost, CurrentAmountPaid, AccountId
                            , AmountRemaining, RemainingAmount, DatePaid, Type);

                    }
                default:
                    return -1;

            }




        }

        private int ProcessPayments(string PaymentId, string OrderId, string totalCost, string CurrentAmountPaid,
            string AccountId, float AmountRemaining, string RemainingAmount, string DatePaid, string Type)
        {
            if (Page.IsValid)
            {
                Classes.CBankOfAccount cba = new Classes.CBankOfAccount();
                Classes.CAccountTransaction cat = new Classes.CAccountTransaction();
                Classes.CPayment cp = new Classes.CPayment();
                Classes.CPaymentLine cpl = new Classes.CPaymentLine();
                Classes.CSaleTransations cs = new Classes.CSaleTransations();
                Models.MAccountTransaction mat = new Models.MAccountTransaction();
                Models.MPayments mp = new Models.MPayments();
                Models.PaymentLine mpl = new Models.PaymentLine();

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
                if (cpl.Save(mpl) < 0)
                {
                    return -2;
                }
                #endregion

                #region Account Transactions
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

            return 1;
        }


        #endregion




    }
}