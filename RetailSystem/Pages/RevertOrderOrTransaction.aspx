<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="RevertOrderOrTransaction.aspx.cs" Inherits="RetailSystem.Pages.RevertOrderOrTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span class="de-em">Revert Order Or Transactions</span>

        </h2>
        <div class="tabbable">
            <ul id="myTab" class="nav nav-tabs">
                <li class="active"><a href="#tab1" data-toggle="tab">Revert Orders</a></li>
                <li><a href="#tab2" data-toggle="tab">Revert Transactions</a></li>

            </ul>
            <div id="myTabContent" class="tab-content">
                <div class="tab-pane fade in active" id="tab1">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdOrders" runat="server" Width="940px" HorizontalAlign="Center"
                                OnRowCommand="grdOrders_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                                DataKeyNames="id" CssClass="table table-hover table-striped">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Order Id" />
                                    <asp:BoundField DataField="OrderName" HeaderText="Order Name" />
                                    <asp:BoundField DataField="OrdersNo" HeaderText="Order Code" />
                                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                                    <asp:BoundField DataField="OrderType" HeaderText="Order Type" />

                                    <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" />

                                    <asp:ButtonField CommandName="revert" ControlStyle-CssClass="btn btn-info"
                                        ButtonType="Button" Text="Revert" HeaderText="Revert">
                                        <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="tab-pane fade" id="tab2">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdTransactions" runat="server" Width="940px" HorizontalAlign="Center"
                                OnRowCommand="grdTransactions_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                                DataKeyNames="TransactionId" CssClass="table table-hover table-striped">
                                <Columns>
                                    <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" />
                                    <asp:BoundField DataField="Product" HeaderText="Products" />
                                    <asp:BoundField DataField="Units" HeaderText="Units" />
                                    <asp:BoundField DataField="WareHouse" HeaderText="WareHouse" />
                                    <asp:BoundField DataField="Type" HeaderText="Type Of Transaction" />
                                    <asp:ButtonField CommandName="revert" ControlStyle-CssClass="btn btn-info"
                                        ButtonType="Button" Text="Revert" HeaderText="Revert">
                                        <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
        </div>

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


    <div class="modal fade" id="OrderConfirm" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Message From Server
                    </h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="updatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="alert-danger alert">
                                Are You sure you want to revert the Order : 
                                <asp:Label ID="lblOrderConfirm" runat="server" Text="Label"></asp:Label>

                                <asp:GridView ID="grdOrderConfirm" runat="server" Width="940px" HorizontalAlign="Center"
                                OnRowCommand="grdOrderConfirm_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                                DataKeyNames="TransactionId" CssClass="table table-hover table-striped">
                                <Columns>
                                    <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" />
                                    <asp:BoundField DataField="Product" HeaderText="Products" />
                                    <asp:BoundField DataField="Units" HeaderText="Units" />
                                    <asp:BoundField DataField="WareHouse" HeaderText="WareHouse" />
                                    <asp:BoundField DataField="Type" HeaderText="Type Of Transaction" />
                                    <asp:ButtonField CommandName="revert" ControlStyle-CssClass="btn btn-info"
                                        ButtonType="Button" Text="Revert" HeaderText="Revert">
                                        <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                            </div>
                            <div class="alert-info">
                                All Inventory and payments will be reverted
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="modal-footer">
                        <asp:Button ID="btnOrderConfirmYes" runat="server" Text="Yes" CssClass="btn btn-info" ValidationGroup="frmSales" OnClick="btnOrderConfirmYes_Click" />

                    </div>
                </div>

            </div>
        </div>
    </div>


    <div class="modal fade" id="TransactionConfirm" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Message From Server
                    </h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="updatePanel4" runat="server">
                        <ContentTemplate>
                            <div class="alert-danger alert">
                                Are You sure you want to revert the Transaction : 
                                <asp:Label ID="lblTransactionConfirm" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="alert-info">
                                All Inventory and payments will be reverted
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="modal-footer">
                        <asp:Button ID="btnTransactionConfirm" runat="server" Text="Yes" CssClass="btn btn-info" ValidationGroup="frmSales" OnClick="btnTransactionConfirm_Click" />

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
