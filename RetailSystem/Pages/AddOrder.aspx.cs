using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace RetailSystem.Pages
{
    public partial class AddOrder : System.Web.UI.Page
    {
        #region Form Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindControls();
                FirstGridViewRow();

            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "DatePickerInit();", true);
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
                    TextBox SalePrice = (TextBox)gr.FindControl("txtSp");
                    int salePrice = Convert.ToInt32(SalePrice.Text);
                    TextBox totalCost = (TextBox)gr.FindControl("txtTotal");
                    totalCost.Text = Convert.ToString(salePrice * TotalUnits);

                }
                catch
                {
                }
            }
        }




        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string retVal = CheckInventory();
                string defaultAccount = string.Empty;


                if (retVal == "Successfull")
                {
                    int Result = SaveOrders();
                    if (Result == -2)
                    {
                        ShowErrorModal("Please select Order Type");
                    }
                    else if (Result == -1)
                    {
                        ShowErrorModal("Order was Not Saved");
                    }
                    else if (Result == -3)
                    {
                        ShowErrorModal("Order was Saved Without any Products");
                    }
                    else if (Result == -4)
                    {
                        ShowErrorModal("Order was Saved without any payment");
                    }
                    else if (Result == -5)
                    {
                        ShowErrorModal("Please select Vendor");
                    }
                    else if (Result == -6)
                    {
                        ShowErrorModal("Please select Client");
                    }
                    else if (Result == -7)
                    {
                        ShowErrorModal("Please select WareHouse");
                    }
                    else if (Result == -8)
                    {
                        ShowErrorModal("Please select Mode Of Payment");
                    }
                    else if (Result < 0)
                    {
                        ShowErrorModal("Order was Not Saved");
                    }
                    else
                    {
                        ShowSuccessMessage();
                        ClearTextBoxes(Page);
                        DeleteAllRowsFromGrid();


                    }
                }
                else
                {
                    ShowErrorModal(retVal);
                }

            }
        }
        protected void ddlOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string ddlValue = ddlOrderType.SelectedValue;
                switch (ddlValue)
                {
                    case "0":
                        {
                            divClient.Visible = false;
                            divVendor.Visible = false;
                            break;
                        }
                    case "1":
                        {
                            divVendor.Visible = false;
                            divClient.Visible = true;
                            break;
                        }
                    case "2":
                        {
                            divClient.Visible = false;
                            divVendor.Visible = true;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }
        protected void grdProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
                    grdProducts.DataSource = dt;
                    grdProducts.DataBind();

                    for (int i = 0; i < grdProducts.Rows.Count - 1; i++)
                    {
                        grdProducts.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.NamingContainer;
                TextBox txtCostPrice = (TextBox)row.FindControl("txtCp");
                TextBox txtSalePrice = (TextBox)row.FindControl("txtSp");
                string ProductsId = Convert.ToString(ddl.SelectedValue);
                if (Convert.ToInt32(ProductsId) > 0)
                {
                    txtCostPrice.Text = ReturnCostPrice(ProductsId);
                    txtSalePrice.Text = ReturnSalePrice(ProductsId);
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

                    TextBox SalePrice = (TextBox)row.FindControl("txtSp");
                    if (string.IsNullOrEmpty(SalePrice.Text))
                    {
                        SalePrice.Text = "0";
                    }
                    int salePrice = Convert.ToInt32(SalePrice.Text);
                    TextBox totalCost = (TextBox)row.FindControl("txtTotal");
                    totalCost.Text = Convert.ToString(salePrice * TotalUnits);

                }
                catch
                {
                }
            }
        }
        #endregion

        #region StatiLists
        private static List<Models.MProducts> Products = new List<Models.MProducts>();
        #endregion

        #region Private Functions
        private void DeleteAllRowsFromGrid()
        {
            grdProducts.DataSource = null;
            grdProducts.DataBind();
            FirstGridViewRow();
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
            dt.Columns.Add(new DataColumn("SalePrice", typeof(string)));
            dt.Columns.Add(new DataColumn("TotalUnits", typeof(string)));
            dt.Columns.Add(new DataColumn("TotalCost", typeof(string)));
            dr = dt.NewRow();

            dr["RowNumber"] = 1;

            dr["Products"] = string.Empty;

            dr["CostPrice"] = string.Empty;
            dr["SalePrice"] = string.Empty;
            dr["TotalUnits"] = string.Empty;
            dr["TotalCost"] = string.Empty;


            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            grdProducts.DataSource = dt;
            grdProducts.DataBind();
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
                    grdProducts.DataSource = dtOld;
                    grdProducts.DataBind();

                    for (int i = 0; i < grdProducts.Rows.Count - 1; i++)
                    {
                        grdProducts.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }

        }
        private string CheckInventory()
        {
            Classes.CInventory ci = new Classes.CInventory();
            int wareHouseId = Convert.ToInt32(Session["WareHouse"].ToString());
            string OrderType = ddlOrderType.SelectedItem.Text;
            switch (OrderType)
            {
                case "Please Select":
                    {
                        return "Please select Order Type";
                        //    break;
                    }
                case "Order To Client":
                    {
                        if (Convert.ToInt32(ddlCustomer.SelectedValue) < 0)
                        {
                            return "Please select a Client";
                        }
                        break;
                    }
                case "Order From Vendor":
                    {
                        if (Convert.ToInt32(ddlVendor.SelectedValue) < 0)
                        {
                            return "Please select a Vendor";
                        }
                        break;
                    }
                default:
                    break;
            }
            if (wareHouseId < 0)
            {
                return "Please select warehouse";
            }
            else
            {
                if (OrderType.Contains("Client"))
                {
                    for (int i = 0; i < grdProducts.Rows.Count; i++)
                    {
                        DropDownList ddlProduct = (DropDownList)grdProducts.Rows[i].FindControl("ddlProducts");
                        TextBox txtUnits = (TextBox)grdProducts.Rows[i].FindControl("txtUnits");
                        int ProductId = Convert.ToInt32(ddlProduct.SelectedValue);
                        int Units = Convert.ToInt32(txtUnits.Text);
                        string retVal = ci.CheckInventory(ProductId, Units, wareHouseId).ToString();
                        switch (retVal)
                        {
                            case "Successfull":
                                {
                                    break;
                                }
                            default:
                                return retVal + " Product[" + ddlProduct.SelectedItem.Text + "] in warehouse [" + Session["WareHouse"].ToString() + "]";

                        }

                    }
                }
                return "Successfull";
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
                          (DropDownList)grdProducts.Rows[rowIndex].Cells[1].FindControl("ddlProducts");

                        TextBox txtCostPrice =
                          (TextBox)grdProducts.Rows[rowIndex].Cells[2].FindControl("txtCp");
                        TextBox txtSalePrice =
                         (TextBox)grdProducts.Rows[rowIndex].Cells[3].FindControl("txtSp");
                        TextBox txtUnits =
                         (TextBox)grdProducts.Rows[rowIndex].Cells[4].FindControl("txtUnits");
                        TextBox txtTotal =
                         (TextBox)grdProducts.Rows[rowIndex].Cells[5].FindControl("txtTotal");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;


                        dtCurrentTable.Rows[i - 1]["Products"] = ddlProducts.SelectedValue;

                        dtCurrentTable.Rows[i - 1]["CostPrice"] = txtCostPrice.Text;
                        dtCurrentTable.Rows[i - 1]["SalePrice"] = txtSalePrice.Text;
                        dtCurrentTable.Rows[i - 1]["TotalUnits"] = txtUnits.Text;
                        dtCurrentTable.Rows[i - 1]["TotalCost"] = txtTotal.Text;


                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    grdProducts.DataSource = dtCurrentTable;
                    grdProducts.DataBind();
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
                          (DropDownList)grdProducts.Rows[rowIndex].Cells[1].FindControl("ddlProducts");

                        TextBox txtCostPrice = (TextBox)grdProducts.Rows[rowIndex].Cells[2].FindControl("txtCp");
                        TextBox txtSalePrice = (TextBox)grdProducts.Rows[rowIndex].Cells[3].FindControl("txtSp");
                        TextBox txtUnits = (TextBox)grdProducts.Rows[rowIndex].Cells[4].FindControl("txtUnits");
                        TextBox txtTotal = (TextBox)grdProducts.Rows[rowIndex].Cells[5].FindControl("txtTotal");


                        //Added these lines
                        string OrderType = ddlOrderType.SelectedValue;
                        int VendorId = -1;
                        if (OrderType == "2")
                        {
                            VendorId = Convert.ToInt32(ddlVendor.SelectedValue);
                        }
                        else
                        {
                            VendorId = -1;
                        }
                        ddlProducts.DataValueField = "Key";
                        ddlProducts.DataTextField = "Value";
                        ddlProducts.DataSource = BindProductsDdl(VendorId);
                        ddlProducts.DataBind();

                        //****************

                        ddlProducts.SelectedValue = dt.Rows[i]["Products"].ToString();

                        txtCostPrice.Text = dt.Rows[i]["CostPrice"].ToString();
                        txtSalePrice.Text = dt.Rows[i]["SalePrice"].ToString();
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
                           (DropDownList)grdProducts.Rows[rowIndex].Cells[1].FindControl("ddlProducts");

                        TextBox txtCostPrice = (TextBox)grdProducts.Rows[rowIndex].Cells[2].FindControl("txtCp");
                        TextBox txtSalePrice = (TextBox)grdProducts.Rows[rowIndex].Cells[3].FindControl("txtSp");
                        TextBox txtUnits = (TextBox)grdProducts.Rows[rowIndex].Cells[4].FindControl("txtUnits");
                        TextBox txtTotal = (TextBox)grdProducts.Rows[rowIndex].Cells[5].FindControl("txtTotal");

                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Products"] = ddlProducts.Text;

                        dtCurrentTable.Rows[i - 1]["CostPrice"] = txtCostPrice.Text;
                        dtCurrentTable.Rows[i - 1]["SalePrice"] = txtSalePrice.Text;
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
            BindProductsLists(); BindWarehouseDdl();
            BindClientsDdl(); BindVendorsDdl();
        }
        private float ReturnTotalOrderCost()
        {
            float OrderTotal = 0;
            for (int i = 0; i < grdProducts.Rows.Count; i++)
            {
                TextBox txtTotal = (TextBox)grdProducts.Rows[i].FindControl("txtTotal");
                OrderTotal += Convert.ToSingle(txtTotal.Text);
            }
            return OrderTotal;
        }
        private void ShowSuccessMessage()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalSuccess').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);

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
        private void ShowFailMessage()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalDanger').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);
        }
        private void BindVendorsDdl()
        {
            Dictionary<int, string> Items = new Dictionary<int, string>();
            List<Models.MVendor> get = new List<Models.MVendor>();
            Classes.CVendor cw = new Classes.CVendor();
            get = cw.GetAll();
            get = get.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            Items.Add(-1, "Please select Vendor");
            for (int i = 0; i < get.Count; i++)
            {
                string id = get[i].id;
                string name = get[i].name;
                Items.Add(Convert.ToInt32(id), name);

            }
            ddlVendor.DataTextField = "Value";
            ddlVendor.DataValueField = "Key";
            ddlVendor.DataSource = Items;
            ddlVendor.DataBind();
        }
        private void BindClientsDdl()
        {
            Dictionary<int, string> Items = new Dictionary<int, string>();
            List<Models.MClients> get = new List<Models.MClients>();
            Classes.CClients cw = new Classes.CClients();
            get = cw.GetAll();
            get = get.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            Items.Add(-1, "Please select Clients");
            for (int i = 0; i < get.Count; i++)
            {
                int id = get[i].id;
                string name = get[i].Name;
                Items.Add(Convert.ToInt32(id), name);

            }
            ddlCustomer.DataTextField = "Value";
            ddlCustomer.DataValueField = "Key";
            ddlCustomer.DataSource = Items;
            ddlCustomer.DataBind();
        }
        private void BindWarehouseDdl()
        {
            //Dictionary<int, string> Items = new Dictionary<int, string>();
            //List<Models.MwareHouse> get = new List<Models.MwareHouse>();
            //Classes.CWareHouse cw = new Classes.CWareHouse();
            //get = cw.GetAll();
            //Items.Add(-1, "Please select Warehouse");
            //for (int i = 0; i < get.Count; i++)
            //{
            //    string id = get[i].id;
            //    string name = get[i].Name;
            //    Items.Add(Convert.ToInt32(id), name);

            //}
            //ddlWareHouse.DataTextField = "Value";
            //ddlWareHouse.DataValueField = "Key";
            //ddlWareHouse.DataSource = Items;
            //ddlWareHouse.DataBind();
        }
        private Dictionary<int, string> BindProductsDdl(int VendorId)
        {
            Dictionary<int, string> Get = new Dictionary<int, string>();
            Get.Add(-1, "Select Products");
            if (VendorId != -1)
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    int id = Convert.ToInt32(Products[i].id);
                    string name = Products[i].Name;
                    int ProductVendorId = Convert.ToInt32(Products[i].Vendorld);
                    if (VendorId == ProductVendorId)
                    {
                        Get.Add(id, name);
                    }

                }
            }
            else
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    int id = Convert.ToInt32(Products[i].id);
                    string name = Products[i].Name;
                    Get.Add(id, name);
                }
            }
            return Get;
        }
        private void BindProductsLists()
        {
            Classes.CProducts cp = new Classes.CProducts();
            Products = cp.GetAll();
            Products = Products.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
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
        private int SaveOrders()
        {
            try
            {
                Classes.CDefaultCashAccount cda = new Classes.CDefaultCashAccount();
                Classes.CDefaultAccount cba = new Classes.CDefaultAccount();

                int OrderId = 0;
                string OrderNo = txtOrderNo.Text;
                string OrderName = txtOrderName.Text;
                string OrderDescription = txtOrderDescription.Text;
                string OrderDate = txtOrderDate.Text;
                string OrderDeliveryDate = txtDeliveryOfOrderDate.Text;
                string TotalCost = ReturnTotalOrderCost().ToString();
                string OrderType = ddlOrderType.SelectedValue;
                string VendorId = ddlVendor.SelectedValue;
                string ClientId = ddlCustomer.SelectedValue;
                string WareHouseId = Session["WareHouse"].ToString();
                string ModeOfPayment = ddlModeOfPayment.SelectedItem.Text;
                string Installments = txtInstallments.Text;
                string InstallmentDueDate = txtIntallmentDueDate.Text;
                if (OrderType == "1")
                {
                    OrderType = "Order To Client";
                }
                else if (OrderType == "2")
                {
                    OrderType = "Order To Vendor";
                }
                else
                {
                    return -2;
                }
                if (ModeOfPayment == "Please Select")
                {
                    return -8;
                }
                Models.MOrders mr = new Models.MOrders();
                mr.OrdersNo = OrderNo;
                mr.OrderName = OrderName;
                mr.OrderDescription = OrderDescription;
                mr.Orderdate = OrderDate;
                mr.deliverydate = OrderDeliveryDate;
                mr.TotalCost = TotalCost;
                mr.OrderType = OrderType;
                mr.eDate = DateTime.Now.ToShortDateString();
                mr.FiscalYearld = Session["FiscalYear"].ToString();
                mr.WareHouseId = WareHouseId;
                mr.ModeOfPayment = ModeOfPayment;
                mr.Installments = Installments;
                mr.InstallmentDueDate = InstallmentDueDate;
                
                if (OrderType.EndsWith("Vendor"))
                {
                    mr.venorld = VendorId;
                    mr.ClientId = "-1";
                    if (Convert.ToInt32(VendorId) < 0)
                    {
                        return -5;
                    }
                }
                else
                {
                    if (cbGrantor.Checked)
                    {
                        string GrantorName = txtGrantorInfo.Text;
                        mr.GrantorName = GrantorName;
                    }
                    
                    mr.ClientId = ClientId;
                    mr.venorld = "-1";
                    if (Convert.ToInt32(ClientId) < 0)
                    {
                        return -6;
                    }
                }
                Classes.COrders co = new Classes.COrders();
                if (Convert.ToInt32(WareHouseId) < 0)
                {
                    return -7;
                }

                //Saving Order
                if (co.Save(mr) < 0)
                {
                    return -1;
                }

                OrderId = co.GetLastOrderID();
                if (OrderId < 0)
                {
                    return -3;
                }
                //Saving Order Products

                #region objects
                Models.MOrdersLine mor = new Models.MOrdersLine();
                Models.MSaleTransactions ms = new Models.MSaleTransactions();
                Classes.CSaleTransations ct = new Classes.CSaleTransations();
                Classes.COrderOnline cor = new Classes.COrderOnline();
                Models.MInventory mi = new Models.MInventory();
                Classes.CInventory ci = new Classes.CInventory();
                float OrderTotalCost = 0;

                #endregion
                for (int i = 0; i < grdProducts.Rows.Count; i++)
                {
                    #region objects initializing
                    mor = new Models.MOrdersLine();
                    ms = new Models.MSaleTransactions();
                    ct = new Classes.CSaleTransations();
                    cor = new Classes.COrderOnline();
                    mi = new Models.MInventory();
                    ci = new Classes.CInventory();
                    DropDownList ddlProduct = (DropDownList)grdProducts.Rows[i].FindControl("ddlProducts");
                    TextBox txtCp = (TextBox)grdProducts.Rows[i].FindControl("txtCp");
                    TextBox txtSp = (TextBox)grdProducts.Rows[i].FindControl("txtSp");
                    TextBox txtUnits = (TextBox)grdProducts.Rows[i].FindControl("txtUnits");
                    TextBox txtTotal = (TextBox)grdProducts.Rows[i].FindControl("txtTotal");
                    string ProductId = ddlProduct.SelectedValue;
                    string CostPrice = txtCp.Text;
                    string SalePrice = txtSp.Text;
                    string TotalUnits = txtUnits.Text;
                    string totalCost = (Convert.ToInt32(TotalUnits) * Convert.ToInt32(SalePrice)).ToString();
                    OrderTotalCost += Convert.ToSingle(totalCost);
                    #endregion

                    //OrderLine
                    #region OrderLine
                    mor.OrderId = OrderId.ToString();
                    mor.ProductId = ProductId;
                    if (OrderType.EndsWith("Vendor"))
                    {
                        mor.SalePrice = CostPrice;
                    }
                    else
                    {
                        mor.SalePrice = SalePrice;
                    }
                    mor.unit = TotalUnits;
                    mor.totalProductCost = totalCost;
                    mor.eDate = DateTime.Now.ToShortDateString();
                    if (cor.Save(mor) < 0)
                    {
                        return -3;
                    }
                    #endregion

                    //Sale transaction
                    #region Sale Transaction

                    ms.ProductID = ProductId;
                    ms.clientID = ClientId;
                    ms.CostPrice = CostPrice;
                    ms.SalePrice = SalePrice;
                    ms.units = TotalUnits;
                    ms.clientID = ClientId;
                    ms.VendorID = VendorId;
                    ms.date = Convert.ToDateTime(txtOrderDate.Text);
                    ms.WareHouseId = WareHouseId;
                    ms.OrderId = OrderId.ToString();
                    if (OrderType.EndsWith("Vendor"))
                    {
                        ms.transactionType = Common.Constants.SaleTransactions.Addition.ToString();
                    }
                    else
                    {
                        ms.transactionType = Common.Constants.SaleTransactions.Deduction.ToString();
                    }


                    //sale transaction
                    if (ct.Save(ms) < 0)
                    { return -1; }
                    #endregion


                    //Inventory
                    #region Inventory
                    mi.ProductId = ProductId;
                    mi.WareHouseld = WareHouseId;
                    mi.Quantity = TotalUnits;
                    mi.FiscalYearld = Session["FiscalYear"].ToString();
                    mi.Date = Convert.ToDateTime(OrderDate);
                    mi.Cost = CostPrice;
                    if (OrderType.EndsWith("Vendor"))
                    {
                        //  mi.Cost = CostPrice;
                        if (ci.Save(mi, Common.Constants.SaleTransactions.Addition) < 0)
                        {
                            return -4;
                        }
                    }
                    else
                    {
                        //   mi.Cost = SalePrice;
                        if (ci.Save(mi, Common.Constants.SaleTransactions.Deduction) < 0)
                        {
                            return -4;
                        }
                    }
                    #endregion

                    //Accounts 
                    #region Accounts
                    if (OrderType.Contains("Vendor"))
                    {
                        Classes.CJournal cj = new Classes.CJournal();
                        Models.MJournal mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.MerchandiseInventory).ToString();
                        mj.amount = totalCost;
                        mj.des = "Order Of Inventory for Vendor of Product Id [" + ProductId + "] units [" + TotalUnits + "] ";
                        mj.e_date = (OrderDate);
                        mj.type = Common.Constants.Accounts.Type.Debit.ToString();
                        cj.Save(mj);

                        mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.AccountsPayable).ToString();
                        mj.amount = totalCost;
                        mj.des = "Order Of Inventory for Vendor of Product Id [" + ProductId + "] units [" + TotalUnits + "] ";
                        mj.e_date = (OrderDate);
                        mj.type = Common.Constants.Accounts.Type.Credit.ToString();
                        cj.Save(mj);
                    }
                    else if (OrderType.Contains("Client"))
                    {
                        Classes.CJournal cj = new Classes.CJournal();
                        Models.MJournal mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.AccountsRecievalbes).ToString();
                        mj.amount = totalCost;
                        mj.des = "Order Of Inventory for Client of Product Id [" + ProductId + "] units [" + TotalUnits + "] ";
                        mj.e_date = (OrderDate);
                        mj.type = Common.Constants.Accounts.Type.Debit.ToString();
                        cj.Save(mj);

                        cj = new Classes.CJournal();
                        mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.Sales).ToString();
                        mj.amount = totalCost;
                        mj.des = "Order Of Inventory for Client of Product Id [" + ProductId + "] units [" + TotalUnits + "] ";
                        mj.e_date = (OrderDate);
                        mj.type = Common.Constants.Accounts.Type.Credit.ToString();
                        cj.Save(mj);


                        cj = new Classes.CJournal();
                        mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.CostOfGoodsSold).ToString();
                        mj.amount = totalCost;
                        mj.des = "Order Of Inventory for Client of Product Id [" + ProductId + "] units [" + TotalUnits + "] ";
                        mj.e_date = (OrderDate);
                        mj.type = Common.Constants.Accounts.Type.Debit.ToString();
                        cj.Save(mj);

                        cj = new Classes.CJournal();
                        mj = new Models.MJournal();
                        mj.acc_id = Convert.ToInt32(Common.Constants.Accounts.ChartOfAccounts.MerchandiseInventory).ToString();
                        mj.amount = totalCost;
                        mj.des = "Order Of Inventory for Client of Product Id [" + ProductId + "] units [" + TotalUnits + "] ";
                        mj.e_date = (OrderDate);
                        mj.type = Common.Constants.Accounts.Type.Credit.ToString();
                        cj.Save(mj);
                    }
                    #endregion

                }

                //Payments
                #region Payments
                Classes.CPayment cap = new Classes.CPayment();
                Models.MPayments map = new Models.MPayments();
                string TransactionId = ct.GetLastTransactionId().ToString();
                if (ddlOrderType.SelectedItem.Text.Contains("Vendor"))
                {
                    map.ClientId = -1;
                    map.VendorId = Convert.ToInt32(VendorId);
                }
                else if (ddlOrderType.SelectedItem.Text.Contains("Client"))
                {
                    map.ClientId = Convert.ToInt32(ClientId);
                    map.VendorId = -1;
                }
                map.TransactionId = Convert.ToInt32(TransactionId);
                map.Paid = "0";
                map.TotalCost = OrderTotalCost.ToString();
                map.OrderId = OrderId;
                map.PaymentType = Common.Constants.PaymentTypes.Partial.ToString();
                map.Paymentstate = Common.Constants.PaymentState.NotPaid.ToString();
                if (cap.Save(map) < 0)
                {
                    return -4;
                }
                #endregion

                return 1;

            }
            catch
            {
                return -1;

            }
        }

        #endregion

        protected void TextBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void cbGrantor_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string ClientId = ddlCustomer.SelectedValue.ToString();
                if (ClientId!= "-1")
                {
                    Classes.CClients cc = new Classes.CClients();
                    txtGrantorInfo.Text = cc.ReturnGrantorName(ClientId);
                }
            }
        }






    }
}