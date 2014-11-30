<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="RetailSystem.Pages.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        ul.nav-tabs li.dropdown .dropdown-menu {
            min-width: 200px !important;
        }
    </style>
    <asp:UpdatePanel ID="upPayments" runat="server">
        <ContentTemplate>

            <h2 class="title-divider">
                <span>Payments <span class="de-em">Of Orders </span></span>
                <small>Payments of Orders from Clients and Vendors</small>
            </h2>

            <div class="tabbable">
                <ul id="myTab" class="nav nav-tabs">
                    <li class="active"><a href="#tab1" data-toggle="tab">Payment Of Sale Orders from Clients</a></li>
                    <li><a href="#tab2" data-toggle="tab">Payment Of Purchase Orders to Vendors</a></li>

                </ul>
                <div id="myTabContent" class="tab-content">

                    <div class="tab-pane fade in active" id="tab1">
                        <h2 class="title-divider">
                            <span>Payment <span class="de-em">from Sale Orders to Clients</span></span>

                        </h2>
                        <asp:GridView ID="grdSales" runat="server" Width="940px" HorizontalAlign="Center"
                            OnRowCommand="grdSales_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                            DataKeyNames="OrderId" CssClass="table table-hover table-striped">
                            <Columns>
                                <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                                <asp:BoundField DataField="OrderName" HeaderText="Order Name" />
                                <asp:BoundField DataField="OrderCode" HeaderText="Order Code" />
                                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                                <asp:BoundField DataField="PaymentId" HeaderText="Payment Id" />
                                <asp:BoundField DataField="ClientId" HeaderText="Client Id" />
                                <asp:BoundField DataField="ClientName" HeaderText="Client Name" />
                                <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" />
                                <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amount" />



                                <asp:ButtonField CommandName="showOrder" ControlStyle-CssClass="btn btn-info"
                                    ButtonType="Button" Text="Show Order Details" HeaderText="View Order Details">
                                    <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                </asp:ButtonField>
                                <asp:ButtonField CommandName="payment" ControlStyle-CssClass="btn btn-info"
                                    ButtonType="Button" Text="Pay for Order" HeaderText="Payment">
                                    <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="tab-pane fade" id="tab2">

                        <h2 class="title-divider">
                            <span>Payment <span class="de-em">of Purchase Orders to Vendors</span></span>

                        </h2>
                        <asp:GridView ID="grdPurchases" runat="server" Width="940px" HorizontalAlign="Center"
                            OnRowCommand="grdPurchases_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                            DataKeyNames="OrderId" CssClass="table table-hover table-striped">
                            <Columns>
                                <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                                <asp:BoundField DataField="OrderName" HeaderText="Order Name" />
                                <asp:BoundField DataField="OrderCode" HeaderText="Order Code" />
                                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                                <asp:BoundField DataField="PaymentId" HeaderText="Payment Id" />
                                <asp:BoundField DataField="VendorId" HeaderText="Vendor Id" />
                                <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                                <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" />
                                <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amount" />



                                <asp:ButtonField CommandName="showOrder" ControlStyle-CssClass="btn btn-info"
                                    ButtonType="Button" Text="Show Order Details" HeaderText="View Order Details">
                                    <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                </asp:ButtonField>
                                <asp:ButtonField CommandName="payment" ControlStyle-CssClass="btn btn-info"
                                    ButtonType="Button" Text="Pay for Order" HeaderText="Payment">
                                    <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>

                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="modal fade" id="modalSalesPayment" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Journal Preview
                    </h4>
                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">

                            <h5>Order ID
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblSalesOrderID" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Payment ID
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblSalesPaymentId" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Order Code
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblSalesOrderCode" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Order Name
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblSalesOrderName" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Client ID
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblSalesClientId" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Client Name
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblSalesClientName" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Total Cost
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblSalesTotalCost" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Amount Paid
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblSalesAmountPaid" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Amount Remaining
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblSalesAmountRemaining" runat="server" CssClass="form-control"></asp:Label>
                            </div>


                            <h5>Select Bank Account
                            </h5>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlSaleAccount" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <h5>Or
                            </h5>
                            <h5>Use Default Account to recieve payments
                            </h5>
                            <div class="checkbox">
                                <label>
                                    <asp:CheckBox ID="cbSalesDefault" runat="server" />


                                </label>
                            </div>
                            <h5>Amount</h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtSalesAmount" runat="server" CssClass="form-control" TextMode="Number" CausesValidation="true"  ValidationGroup="frmSales"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtSalesAmount" runat="server" ErrorMessage="Please Enter Amount" ForeColor="Red" ValidationGroup="frmSales"></asp:RequiredFieldValidator>

                            <h5>Date Of Payment</h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtSalesDate" runat="server" CssClass="form-control datepicker" CausesValidation="true"  ValidationGroup="frmSales"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtSalesDate" runat="server" ErrorMessage="Please Enter Date" ForeColor="Red" ValidationGroup="frmSales"></asp:RequiredFieldValidator>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="modal-footer">
                    <asp:Button ID="btnPaymentSales" runat="server" Text="Recieve Payment for Order" CssClass="btn btn-info" ValidationGroup="frmSales" OnClick="btnPaymentSales_Click" />
                </div>

            </div>
            <!-- /.modal-content -->
        </div>

        <!-- /.modal-dialog -->
    </div>
    <div class="modal fade" id="modalPurchasePayment" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Journal Preview
                    </h4>
                </div>


                <div class="modal-body"> 
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <h5>Order ID
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblPurchaseOrderId" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Payment ID
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblPurchasePaymentId" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Order Code
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblPurchaseOrderCode" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Order Name
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblPurchaseOrderName" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Vendor ID
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblPurchaseVendorId" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Vendor Name
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblPurchaseVendorName" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Total Cost
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblPurchaseTotalCost" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Amount Paid
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblPurchaseAmountPaid" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Amount Remaining
                            </h5>
                            <div class="form-group">
                                <asp:Label ID="lblPurchaseAmountRemaining" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <h5>Select Bank Account
                            </h5>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlPurchaseAccount" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <h5>Or
                            </h5>

                            <h5>Use Default Account to Pay Vendors
                            </h5>
                            <div class="checkbox">
                                <label>
                                    <asp:CheckBox ID="cbPurchases" runat="server" />
                                </label>
                            </div>
                            <h5>Amount</h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtPurchaseAmount" runat="server" CssClass="form-control" TextMode="Number" CausesValidation="true"  ValidationGroup="frmPurchase"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtPurchaseAmount" runat="server" ErrorMessage="Please Enter Amount" ForeColor="Red" ValidationGroup="frmPurchase"></asp:RequiredFieldValidator>

                            <h5>Date Of Payment</h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtPurchaseDate" runat="server" CssClass="form-control datepicker" CausesValidation="true"  ValidationGroup="frmPurchase"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator4" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtPurchaseDate" runat="server" ErrorMessage="Please Enter Amount" ForeColor="Red" ValidationGroup="frmPurchase"></asp:RequiredFieldValidator>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnPaymentPurchase" runat="server" Text="Pay for current order" ValidationGroup="frmPurchase" CssClass="btn btn-info" OnClick="btnPaymentPurchase_Click" />
                </div>


            </div>
            <!-- /.modal-content -->
        </div>

        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="modalSalesOrders" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Journal Preview
                    </h4>
                </div>


                <div class="modal-body">

                    <div id="salesOrderPreview" runat="server">
                    </div>
                </div>
                <div class="modal-footer">
                </div>


            </div>
            <!-- /.modal-content -->
        </div>

        <!-- /.modal-dialog -->
    </div>
    <div class="modal fade" id="modalPurchaseOrders" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Journal Preview
                    </h4>
                </div>


                <div class="modal-body">


                    <div id="modalPurchaseOrderPreview" runat="server">
                    </div>
                </div>
                <div class="modal-footer">
                </div>


            </div>
            <!-- /.modal-content -->
        </div>

        <!-- /.modal-dialog -->
    </div>
     <div class="modal fade" id="modalError" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Message From Server
                    </h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="updatePanelError" runat="server">
                        <ContentTemplate>
                            <div class="alert-danger">

                                <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="modal-footer">
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
