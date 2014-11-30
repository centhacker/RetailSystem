using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class Purchases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FirstGridViewRow();
                BindControls();

            }
        }

        protected void grdSales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    grdSales.DataSource = dt;
                    grdSales.DataBind();

                    for (int i = 0; i < grdSales.Rows.Count - 1; i++)
                    {
                        grdSales.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }


        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack && Page.IsValid)
            {
                //   int ClientId = Convert.ToInt32(ddlClient.SelectedValue);
                int WareHouseID = Convert.ToInt32(ddlWareHouse.SelectedValue);

                if (WareHouseID > 0)
                {
                    if (grdSales.Rows.Count > 0)
                    {
                        Classes.CDefaultAccount cd = new Classes.CDefaultAccount();
                        if (cd.ReturnPurchaseDefaultAccount(Convert.ToInt32(Session["WareHouse"])) > 0)
                        {
                            ShowPreviewModal();
                        }
                        else
                        {
                            ShowErrorModal("Default Purchase Account not set, kindly set it in Accounts");
                        }

                    }
                    else
                    {
                        ShowErrorModal("Please Add some rows to journal");
                    }

                }
                else
                {
                    ShowErrorModal("Please select WareHouse");
                }



            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Saving Journal
            try
            {
                #region Objects
                Classes.CBankOfAccount cab = new Classes.CBankOfAccount();
                Classes.CAccountTransaction cat = new Classes.CAccountTransaction();
                Classes.CSaleTransations ct = new Classes.CSaleTransations();
                Classes.CDefaultAccount df = new Classes.CDefaultAccount();
                Classes.CInventory ci = new Classes.CInventory();
                Classes.CPayment cpay = new Classes.CPayment();
                Classes.CPaymentLine cpl = new Classes.CPaymentLine();
                Classes.CPaymentContainer cpc = new Classes.CPaymentContainer();
                Models.MInventory mi = new Models.MInventory();
                Models.MAccountTransaction mat = new Models.MAccountTransaction();
                Models.MSaleTransactions ms = new Models.MSaleTransactions();
                Models.MPayments mpay = new Models.MPayments();
                Models.PaymentContainer mpc = new Models.PaymentContainer();
                Models.PaymentLine mpl = new Models.PaymentLine();
                #endregion


                string WareHouseId = ddlWareHouse.SelectedValue;
                float Discount = Convert.ToSingle(txtDiscount.Text);
                Discount = Discount / grdSales.Rows.Count;
                if (Convert.ToInt32(WareHouseId) > 0)
                {
                    #region Start Saving

                    for (int i = 0; i < grdSales.Rows.Count; i++)
                    {
                        DropDownList ddlProduct = (DropDownList)grdSales.Rows[i].FindControl("ddlProducts");
                        TextBox txtCp = (TextBox)grdSales.Rows[i].FindControl("txtCp");
                        Label txtVendor = (Label)grdSales.Rows[i].FindControl("txtVendor");
                        TextBox txtUnits = (TextBox)grdSales.Rows[i].FindControl("txtUnits");
                        TextBox txtTotal = (TextBox)grdSales.Rows[i].FindControl("txtTotal");

                        string ProductId = ddlProduct.SelectedValue;
                        string CostPrice = txtCp.Text;
                        string[] VendorDetails = txtVendor.Text.Split('-');
                        string VendorId = VendorDetails[0];
                        string TotalUnits = txtUnits.Text;
                        string totalCost = (Convert.ToInt32(TotalUnits) * Convert.ToInt32(CostPrice)).ToString();
                        totalCost = Convert.ToSingle(Convert.ToSingle(totalCost) - Discount).ToString();
                        ms.ProductID = ProductId;
                        ms.CostPrice = CostPrice;
                        ms.units = TotalUnits;
                        ms.date = Convert.ToDateTime(txtDate.Text);
                        ms.transactionType = Common.Constants.SaleTransactions.Addition.ToString();
                        ms.date = Convert.ToDateTime(txtDate.Text);
                        ms.VendorID = VendorId;
                        ms.OrderId = "-1";
                        ms.WareHouseId = WareHouseId;
                        ms.clientID = "-1";
                        ms.Discount = Discount.ToString();
                        //sale transaction
                        if (ct.Save(ms) > 0)
                        {

                            mi.WareHouseld = WareHouseId;
                            mi.Cost = CostPrice;
                            mi.Quantity = TotalUnits;
                            mi.ProductId = ProductId;
                            mi.FiscalYearld = "1";
                            mi.Date = Convert.ToDateTime(txtDate.Text);

                            //inventory
                            int retVal = ci.Save(mi, Common.Constants.SaleTransactions.Addition);
                            if (retVal > 0)
                            {
                                #region Accounts Transactions
                                //Payments

                                int TransactionId = 0;
                                TransactionId = ct.GetLastTransactionId();
                                if (TransactionId != 0)
                                {

                                    string AccountId = string.Empty;
                                    AccountId = df.ReturnPurchaseDefaultAccount(Convert.ToInt32(Session["WareHouse"])).ToString();
                                    mat.AccountId = AccountId;
                                    mat.Debit = totalCost;
                                    mat.Credit = "0";
                                    mat.Description = "Purchased Product[" + ddlProduct.SelectedItem.Text + "] Units ["
                                        + TotalUnits + " At Cost/Unit[" + CostPrice + "]] ";
                                    float AccountTotal = cab.ReturnTotalOfAccountById(Convert.ToInt32(AccountId));
                                    AccountTotal = AccountTotal - Convert.ToSingle(totalCost);
                                    mat.Total = AccountTotal.ToString();
                                    mat.CurrentTransaction = TransactionId.ToString();
                                    mat.Transactiontype = "Debit";
                                    mat.FiscalYearId = Session["FiscalYear"].ToString();
                                    mat.eDate = Convert.ToDateTime(txtDate.Text);
                                    //Account Transation
                                    if (cat.Save(mat) > 0)
                                    {

                                        //Updating Account total
                                        if (cab.SetNewAccountTotal(Convert.ToInt32(AccountId), AccountTotal) > 0)
                                        {

                                            //Updating Payments
                                            mpay.ClientId = 0;
                                            mpay.VendorId = Convert.ToInt32(VendorId);
                                            mpay.OrderId = 0;
                                            mpay.TransactionId = TransactionId;
                                            mpay.Paid = totalCost;
                                            mpay.TotalCost = totalCost;
                                            mpay.PaymentType = Common.Constants.PaymentTypes.Full.ToString();
                                            mpay.Paymentstate = Common.Constants.PaymentState.Paid.ToString();
                                            if (cpay.Save(mpay) > 0)
                                            {
                                                int PaymentId = cpay.ReturnLastPaymentId();
                                                mpc.BankId = Convert.ToInt32(AccountId);
                                                mpc.PaymentId = PaymentId;
                                                mpc.AmountRemaning = "0";
                                                if (cpc.Save(mpc) > 0)
                                                {
                                                    mpl.PaymentId = PaymentId;
                                                    mpl.PaidAmount = totalCost;
                                                    mpl.RemainingAmount = "0";
                                                    mpl.BankId = Convert.ToInt32(AccountId);
                                                    mpl.Date = txtDate.Text;
                                                    mpl.CumulativeAmount = totalCost;
                                                    if (cpl.Save(mpl) > 0)
                                                    {
                                                        ShowErrorModal("Successfully Saved Journal");
                                                    }
                                                }
                                            }

                                        }
                                    }

                                }
                                #endregion

                            }
                            else if (retVal == 0)
                            {
                                ShowErrorModal("Not enough units");
                            }
                            else
                            {
                                ShowErrorModal("There was Error Saving the Journal");
                                break;
                            }
                        }
                        else
                        {
                            ShowErrorModal("There was Error Saving the Journal");
                            break;

                        }


                    }

                    ShowErrorModal("Successfully Saved Journal");
                    DeleteAllRowsFromGrid();
                    ClearTextBoxes(Page);
                    HidePreviewModal();
                    #endregion
                }
                else
                {
                    ShowErrorModal("Please Select Warehouse");
                }

            }
            catch
            {


            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.NamingContainer;
                TextBox txtCostPrice = (TextBox)row.FindControl("txtCp");

                Label txtVendor = (Label)row.FindControl("txtVendor");
                string ProductsId = Convert.ToString(ddl.SelectedValue);
                txtVendor.Text = ReturnVendorName(ProductsId);
                if (Convert.ToInt32(ProductsId) > 0)
                {
                    txtCostPrice.Text = ReturnCostPrice(ProductsId);

                }

                //Calculating
                try
                {
                    TextBox units = (TextBox)row.FindControl("txtUnits");
                    int TotalUnits = 0;
                    if (string.IsNullOrEmpty(units.Text))
                    {
                        units.Text = "0";
                    }

                    TotalUnits = Convert.ToInt32(units.Text);

                    TextBox CostPrice = (TextBox)row.FindControl("txtCp");
                    if (string.IsNullOrEmpty(CostPrice.Text))
                    {
                        CostPrice.Text = "0";
                    }
                    int salePrice = Convert.ToInt32(CostPrice.Text);
                    TextBox totalCost = (TextBox)row.FindControl("txtTotal");
                    totalCost.Text = Convert.ToString(salePrice * TotalUnits);

                }
                catch
                {
                }

            }

        }

        protected void txtUnits_TextChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    TextBox units = (TextBox)sender;
                    GridViewRow gr = (GridViewRow)units.NamingContainer;
                    int TotalUnits = Convert.ToInt32(units.Text);
                    TextBox CostPrice = (TextBox)gr.FindControl("txtCp");
                    int costPrice = Convert.ToInt32(CostPrice.Text);
                    TextBox totalCost = (TextBox)gr.FindControl("txtTotal");
                    totalCost.Text = Convert.ToString(costPrice * TotalUnits);

                }
                catch
                {
                }
            }
        }


        #region StatiLists
        private static List<Models.MProducts> Products = new List<Models.MProducts>();

        #endregion


        #region Private Functions

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
        private void HidePreviewModal()
        {

            string innerHtml = string.Empty;
            previewDiv.InnerHtml = innerHtml;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalPreview').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }
        private void DeleteAllRowsFromGrid()
        {
            grdSales.DataSource = null;
            grdSales.DataBind();
            FirstGridViewRow();
        }


        private void ShowPreviewModal()
        {

            string innerHtml = BuildPreviewModalGrid();
            previewDiv.InnerHtml = innerHtml;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalPreview').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }
        private string BuildPreviewModalGrid()
        {
            float totalJounalCost = 0, totalJournalUnits = 0;
            string innerHTML = string.Empty;
            string Productshtml = string.Empty, CPhtml = string.Empty, SPHtml = string.Empty
                , UnitsHTML = string.Empty, TotalHtml = string.Empty;
            string JournalCost = string.Empty;
            innerHTML += "<div class=\"row pricing-stack pricing-table margin-top-lg\">";
            try
            {

                Productshtml += "<div class=\"col-md-3 pricing-table-plan \"><div class=\"well title-hidden\">";
                Productshtml += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>Products</b></li>";
                CPhtml += "<div class=\"col-md-2 pricing-table-plan \"><div class=\"well title-hidden\">";
                CPhtml += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>Cost Price</b></li>";

                UnitsHTML += "<div class=\"col-md-2 pricing-table-plan \"><div class=\"well title-hidden\">";
                UnitsHTML += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>Total Units</b></li>";
                TotalHtml += "<div class=\"col-md-2 pricing-table-plan \"><div class=\"well title-hidden\">";
                TotalHtml += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>Total Cost</b></li>";
                txtDiscount.Text = "0";
                for (int i = 0; i < grdSales.Rows.Count; i++)
                {
                    DropDownList ddlProduct = (DropDownList)grdSales.Rows[i].FindControl("ddlProducts");
                    TextBox txtCp = (TextBox)grdSales.Rows[i].FindControl("txtCp");

                    TextBox txtUnits = (TextBox)grdSales.Rows[i].FindControl("txtUnits");
                    TextBox txtTotal = (TextBox)grdSales.Rows[i].FindControl("txtTotal");
                    string Product = ddlProduct.SelectedItem.Text;
                    string CostPrice = txtCp.Text;

                    string TotalUnits = txtUnits.Text;
                    string totalCost = (Convert.ToInt32(TotalUnits) * Convert.ToInt32(CostPrice)).ToString();
                    totalJounalCost += Convert.ToSingle(totalCost);
                    totalJournalUnits += Convert.ToSingle(TotalUnits);
                    Productshtml += "<li> " + Product + "</li>";
                    CPhtml += "<li> " + CostPrice + "</li>";

                    UnitsHTML += "<li> " + TotalUnits + "</li>";
                    TotalHtml += "<li> " + totalCost + "</li>";

                }

                Productshtml += "</ul></div></div>";
                CPhtml += "</ul></div></div>";

                UnitsHTML += "</ul></div></div>";
                TotalHtml += "</ul></div></div>";



                //Adding all html
                innerHTML += Productshtml + CPhtml + SPHtml + UnitsHTML + TotalHtml;

                //ending div
                innerHTML += "</div>";

                //Adding Message Div
                innerHTML += "<div class=\"alert-info\"><b>Total Journal Cost: " + totalJounalCost + "</b>";
                innerHTML += "<br/>Total Units in Journal: " + totalJournalUnits + "</div>";

            }
            catch
            {
                //Adding Message Div
                innerHTML += "<div class=\"alert-danger\"><b>There are some errors in jounrnal</b>";
                innerHTML += "<li>Kindly check sale and cost price</li>";
                innerHTML += "<li>Kindly check number of rows</li>";
                innerHTML += "<li>Kindly check units of products added</li>";
                innerHTML += "</div>";



            }
            return innerHTML;

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

        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new DataColumn("Products", typeof(string)));

            dt.Columns.Add(new DataColumn("CostPrice", typeof(string)));

            dt.Columns.Add(new DataColumn("Vendors", typeof(string)));
            dt.Columns.Add(new DataColumn("TotalUnits", typeof(string)));
            dt.Columns.Add(new DataColumn("TotalCost", typeof(string)));
            dr = dt.NewRow();

            dr["RowNumber"] = 1;

            dr["Products"] = string.Empty;

            dr["CostPrice"] = string.Empty;

            dr["Vendors"] = string.Empty;
            dr["TotalUnits"] = string.Empty;
            dr["TotalCost"] = string.Empty;


            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            grdSales.DataSource = dt;
            grdSales.DataBind();
            AddNewRow();
            SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtOld = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(0);
                if (dtOld.Rows.Count > 1)
                {
                    dtOld.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dtOld.NewRow();
                    ViewState["CurrentTable"] = dtOld;
                    grdSales.DataSource = dtOld;
                    grdSales.DataBind();

                    for (int i = 0; i < grdSales.Rows.Count - 1; i++)
                    {
                        grdSales.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }

        }
        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        DropDownList ddlProducts =
                          (DropDownList)grdSales.Rows[rowIndex].Cells[1].FindControl("ddlProducts");

                        TextBox txtCostPrice =
                          (TextBox)grdSales.Rows[rowIndex].Cells[2].FindControl("txtCp");

                        Label txtVendor =
                         (Label)grdSales.Rows[rowIndex].Cells[4].FindControl("txtVendor");
                        TextBox txtUnits =
                         (TextBox)grdSales.Rows[rowIndex].Cells[5].FindControl("txtUnits");
                        TextBox txtTotal =
                         (TextBox)grdSales.Rows[rowIndex].Cells[6].FindControl("txtTotal");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        try
                        {
                            //Added these lines

                            ddlProducts.DataValueField = "Key";
                            ddlProducts.DataTextField = "Value";
                            ddlProducts.DataSource = BindProductsDdl();
                            ddlProducts.DataBind();

                            //****************
                        }
                        catch
                        {

                        }
                        dtCurrentTable.Rows[i - 1]["Products"] = ddlProducts.SelectedValue;

                        dtCurrentTable.Rows[i - 1]["CostPrice"] = txtCostPrice.Text;

                        dtCurrentTable.Rows[i - 1]["Vendors"] = txtVendor.Text;
                        dtCurrentTable.Rows[i - 1]["TotalUnits"] = txtUnits.Text;
                        dtCurrentTable.Rows[i - 1]["TotalCost"] = txtTotal.Text;


                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    grdSales.DataSource = dtCurrentTable;
                    grdSales.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        DropDownList ddlProducts =
                          (DropDownList)grdSales.Rows[rowIndex].Cells[1].FindControl("ddlProducts");

                        TextBox txtCostPrice = (TextBox)grdSales.Rows[rowIndex].Cells[2].FindControl("txtCp");

                        Label txtVendor = (Label)grdSales.Rows[rowIndex].Cells[4].FindControl("txtVendor");
                        TextBox txtUnits = (TextBox)grdSales.Rows[rowIndex].Cells[5].FindControl("txtUnits");
                        TextBox txtTotal = (TextBox)grdSales.Rows[rowIndex].Cells[6].FindControl("txtTotal");


                        //Added these lines

                        ddlProducts.DataValueField = "Key";
                        ddlProducts.DataTextField = "Value";
                        ddlProducts.DataSource = BindProductsDdl();
                        ddlProducts.DataBind();

                        //****************

                        ddlProducts.SelectedValue = dt.Rows[i]["Products"].ToString();

                        txtCostPrice.Text = dt.Rows[i]["CostPrice"].ToString();

                        txtVendor.Text = dt.Rows[i]["Vendors"].ToString();
                        txtUnits.Text = dt.Rows[i]["TotalUnits"].ToString();
                        txtTotal.Text = dt.Rows[i]["TotalCost"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        DropDownList ddlProducts =
                           (DropDownList)grdSales.Rows[rowIndex].Cells[1].FindControl("ddlProducts");

                        TextBox txtCostPrice = (TextBox)grdSales.Rows[rowIndex].Cells[2].FindControl("txtCp");

                        Label txtVendor = (Label)grdSales.Rows[rowIndex].Cells[4].FindControl("txtVendor");
                        TextBox txtUnits = (TextBox)grdSales.Rows[rowIndex].Cells[5].FindControl("txtUnits");
                        TextBox txtTotal = (TextBox)grdSales.Rows[rowIndex].Cells[6].FindControl("txtTotal");

                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Products"] = ddlProducts.Text;

                        dtCurrentTable.Rows[i - 1]["CostPrice"] = txtCostPrice.Text;

                        dtCurrentTable.Rows[i - 1]["Vendors"] = txtVendor.Text;
                        dtCurrentTable.Rows[i - 1]["TotalUnits"] = txtUnits.Text;
                        dtCurrentTable.Rows[i - 1]["TotalCost"] = txtTotal.Text;

                        rowIndex++;
                    }

                    ViewState["CurrentTable"] = dtCurrentTable;
                    //grvStudentDetails.DataSource = dtCurrentTable;
                    //grvStudentDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }
        private void BindControls()
        {
            BindWarehouseDdl(); BindStaticLists(); BindVendorsDdl();

        }

        private Dictionary<int, string> BindProductsDdl()
        {
            Dictionary<int, string> Get = new Dictionary<int, string>();
            Get.Add(-1, "Select Products");
            for (int i = 0; i < Products.Count; i++)
            {
                int id = Convert.ToInt32(Products[i].id);
                string name = Products[i].Name;
                Get.Add(id, name);
            }
            return Get;
        }
        private void BindStaticLists()
        {
            Classes.CProducts cp = new Classes.CProducts();
            Products = cp.GetAll();
            Products = Products.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
        }
        private void BindWarehouseDdl()
        {
            Dictionary<int, string> Items = new Dictionary<int, string>();
            List<Models.MwareHouse> get = new List<Models.MwareHouse>();
            Classes.CWareHouse cw = new Classes.CWareHouse();
            get = cw.GetAll();
            Items.Add(-1, "Please select Warehouse");
            for (int i = 0; i < get.Count; i++)
            {
                string id = get[i].id;
                string name = get[i].Name;
                Items.Add(Convert.ToInt32(id), name);

            }
            ddlWareHouse.DataTextField = "Value";
            ddlWareHouse.DataValueField = "Key";
            ddlWareHouse.DataSource = Items;
            ddlWareHouse.DataBind();
        }
        private void BindVendorsDdl()
        {
            //dance bitch 
        }
        private string ReturnVendorName(string ProductsId)
        {
            string VendorName = string.Empty;
            Classes.CProducts cp = new Classes.CProducts();
            VendorName = cp.ReturnVendorName(ProductsId);
            return VendorName;
        }
        private string ReturnCostPrice(string ProdcutsId)
        {
            string CostPrice = string.Empty;
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].id == ProdcutsId)
                {
                    CostPrice = Products[i].CostPrice;
                    break;
                }
            }
            return CostPrice;
        }
        private string ReturnSalePrice(string ProdcutsId)
        {

            string SalePrice = string.Empty;
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].id == ProdcutsId)
                {
                    SalePrice = Products[i].SalePrice;
                    break;
                }
            }
            return SalePrice;
        }

        #endregion
    }
}