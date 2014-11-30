using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewEditOrderLine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrids();
            }
        }

        protected void grdOrdersClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Page.IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("viewDetails"))
                {
                    GridViewRow gvrow = grdOrdersClients.Rows[index];
                    string OrderId = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                    PreviewOrderDetails(Convert.ToInt32(OrderId));
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#viewOrderDetailModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);



                }
                if (e.CommandName.Equals("ViewPayment"))
                {
                    GridViewRow gvrow = grdOrdersClients.Rows[index];
                    string OrderId = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                    PreviewPaymentHistory(Convert.ToInt32(OrderId));
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#viewOrderPaymentHistory').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);



                }
            }
        }

        protected void grdOrderVendors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Page.IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("viewDetails"))
                {
                    GridViewRow gvrow = grdOrderVendors.Rows[index];

                    string OrderId = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                    PreviewOrderDetails(Convert.ToInt32(OrderId));
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#viewOrderDetailModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);



                }
                if (e.CommandName.Equals("ViewPayment"))
                {
                    GridViewRow gvrow = grdOrderVendors.Rows[index];

                    string OrderId = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                    PreviewPaymentHistory(Convert.ToInt32(OrderId));
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#viewOrderPaymentHistory').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);



                }
            }
        }



        private void PreviewOrderDetails(int OrderId)
        {
            string innerHtml = string.Empty;
            string Productshtml = string.Empty, CurrentProductPrice = string.Empty,
                OrderProductPrice = string.Empty, Units = string.Empty, ProductCost = string.Empty;

            List<Models.MViewModels.MViewOrderDetails> OrderDetails = new List<Models.MViewModels.MViewOrderDetails>();
            Classes.CViewClasses.CViewOrderDetails cod = new Classes.CViewClasses.CViewOrderDetails();
            OrderDetails = cod.GetAllDetails(OrderId);
            innerHtml += "<div class=\"row pricing-stack pricing-table margin-top-lg\">";
            Productshtml += "<div class=\"col-md-3 pricing-table-plan \"><div class=\"well title-hidden\">";
            Productshtml += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>Products</b></li>";
            CurrentProductPrice += "<div class=\"col-md-2 pricing-table-plan \"><div class=\"well title-hidden\">";
            CurrentProductPrice += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>CurrentProductPrice</b></li>";
            OrderProductPrice += "<div class=\"col-md-2 pricing-table-plan \"><div class=\"well title-hidden\">";
            OrderProductPrice += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>OrderProductPrice</b></li>";
            Units += "<div class=\"col-md-2 pricing-table-plan \"><div class=\"well title-hidden\">";
            Units += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>Units</b></li>";
            ProductCost += "<div class=\"col-md-2 pricing-table-plan \"><div class=\"well title-hidden\">";
            ProductCost += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>ProductCost</b></li>";

            for (int i = 0; i < OrderDetails.Count; i++)
            {
                Productshtml += "<li>" + OrderDetails[i].ProductName + "</li>";
                ProductCost += "<li>" + OrderDetails[i].ProductCost + "</li>";
                Units += "<li>" + OrderDetails[i].Units + "</li>";
                OrderProductPrice += "<li>" + OrderDetails[i].OrderProductPrice + "</li>";
                CurrentProductPrice += "<li>" + OrderDetails[i].CurrentProductPrice + "</li>";

            }

            Productshtml += "</ul></div></div>";
            ProductCost += "</ul></div></div>";
            Units += "</ul></div></div>";
            OrderProductPrice += "</ul></div></div>";
            CurrentProductPrice += "</ul></div></div>";

            innerHtml += Productshtml + CurrentProductPrice + OrderProductPrice + Units + ProductCost + "</div>";
            divDetails.InnerHtml = innerHtml;


        }

        private void PreviewPaymentHistory(int OrderId)
        {
            string innerHtml = string.Empty;
            string Date = string.Empty, AccountName = string.Empty, PaidAmount = string.Empty
                , ChequeNumber = string.Empty, ModeOfPayment = string.Empty, CummulativePayment = string.Empty;

            List<Models.MViewModels.MViewPaymentHistory> PaymentHistory = new List<Models.MViewModels.MViewPaymentHistory>();
            Classes.CViewClasses.CViewOrderDetails cod = new Classes.CViewClasses.CViewOrderDetails();
            PaymentHistory = cod.GetPaymentHistory(OrderId);
            innerHtml += "<div class=\"row pricing-stack pricing-table margin-top-lg\">";
            Date += "<div class=\"col-md-1 pricing-table-plan \"><div class=\"well title-hidden\">";
            Date += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>Date</b></li>";
            PaidAmount += "<div class=\"col-md-1 pricing-table-plan \"><div class=\"well title-hidden\">";
            PaidAmount += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>Paid</b></li>";
            ChequeNumber += "<div class=\"col-md-2 pricing-table-plan \"><div class=\"well title-hidden\">";
            ChequeNumber += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>ChequeNumber</b></li>";
            ModeOfPayment += "<div class=\"col-md-1 pricing-table-plan \"><div class=\"well title-hidden\">";
            ModeOfPayment += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>Mode</b></li>";
            CummulativePayment += "<div class=\"col-md-1 pricing-table-plan \"><div class=\"well title-hidden\">";
            CummulativePayment += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>++</b></li>";
            AccountName += "<div class=\"col-md-4 pricing-table-plan \"><div class=\"well title-hidden\">";
            AccountName += "<ul class=\"pricing-table-features-list\"><li class=\"price\"><b>AccountName</b></li>";

            for (int i = 0; i < PaymentHistory.Count; i++)
            {
                Date += "<li>" + PaymentHistory[i].Date + "</li>";
                PaidAmount += "<li>" + PaymentHistory[i].PaidAmount + "</li>";
                ChequeNumber += "<li>" + PaymentHistory[i].ChequeNumber + "</li>";
                ModeOfPayment += "<li>" + PaymentHistory[i].ModeOfPayment + "</li>";
                CummulativePayment += "<li>" + PaymentHistory[i].CummulativePayment + "</li>";
                AccountName += "<li>" + PaymentHistory[i].AccountName + "</li>";
            }

            Date += "</ul></div></div>";
            PaidAmount += "</ul></div></div>";
            ChequeNumber += "</ul></div></div>";
            ModeOfPayment += "</ul></div></div>";
            CummulativePayment += "</ul></div></div>";
            AccountName += "</ul></div></div>";

            innerHtml += Date + AccountName + ModeOfPayment + ChequeNumber + PaidAmount + CummulativePayment + "</div>";
            divPayments.InnerHtml = innerHtml;
        }

        private void BindGrids()
        {
            Classes.CViewClasses.CViewOrderDetails cvo = new Classes.CViewClasses.CViewOrderDetails();
            List<Models.MViewModels.MViewOrders> ClientOrders = new List<Models.MViewModels.MViewOrders>()
                , VendorOrder = new List<Models.MViewModels.MViewOrders>();
            ClientOrders = cvo.GetAll("Clients");
            ClientOrders = ClientOrders.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            VendorOrder = cvo.GetAll("Vendors");
            VendorOrder = VendorOrder.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            grdOrdersClients.DataSource = ClientOrders;
            grdOrdersClients.DataBind();
            grdOrderVendors.DataSource = VendorOrder;
            grdOrderVendors.DataBind();
        }
    }

}