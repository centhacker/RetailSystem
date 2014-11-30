<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="PaymentLineSales.aspx.cs" Inherits="RetailSystem.Pages.PaymentLine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h4 class="modal-title">Journal Preview
    </h4>


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
                <h5>Select Mode Of Payment
                </h5>
                <div class="form-group">
                    <asp:DropDownList ID="ddlOption" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOption_SelectedIndexChanged">
                        <asp:ListItem Value="-1" Text="Please Select"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Bank Account"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Cash Account"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="divBankAccount" runat="server">
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
                    <h5>Cheque No.</h5>
                    <div class="form-group">

                        <asp:TextBox ID="txtCheque" runat="server" CssClass="form-control" TextMode="Number" CausesValidation="true" ValidationGroup="frmPurchase"></asp:TextBox>
                    </div>

                </div>
                <div id="divCashAccount" runat="server">
                    <h5>Select Cash Account
                    </h5>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlCashAccount" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <h5>Or
                    </h5>

                    <h5>Use Default Cash Account to Pay Vendors
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbSalePurchases" runat="server" />
                        </label>
                    </div>
                </div>





                <h5>Amount</h5>
                <div class="form-group">

                    <asp:TextBox ID="txtSalesAmount" runat="server" CssClass="form-control" TextMode="Number" CausesValidation="true" ValidationGroup="frmSales"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtSalesAmount" runat="server" ErrorMessage="Please Enter Amount" ForeColor="Red" ValidationGroup="frmSales"></asp:RequiredFieldValidator>

                <h5>Date Of Payment</h5>
                <div class="form-group">

                    <asp:TextBox ID="txtSalesDate" runat="server" CssClass="form-control datepicker" CausesValidation="true" ValidationGroup="frmSales"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtSalesDate" runat="server" ErrorMessage="Please Enter Date" ForeColor="Red" ValidationGroup="frmSales"></asp:RequiredFieldValidator>

            </div>
            <asp:Button ID="btnPaymentSales" runat="server" Text="Recieve Payment for Order" CssClass="btn btn-info" ValidationGroup="frmSales" OnClick="btnPaymentSales_Click" />

        </ContentTemplate>
    </asp:UpdatePanel>

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
