<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewEditOrderLine.aspx.cs" Inherits="RetailSystem.Pages.ViewEditOrderLine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        @media (min-width: 768px) {
            .modal-dialog-large {
                width: 80%!important;
            }
        }
    </style>
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>

                    <div class="tabbable">
                        <ul id="myTab" class="nav nav-tabs">
                            <li class="active"><a href="#tab1" data-toggle="tab">Orders from Clients</a></li>
                            <li><a href="#tab2" data-toggle="tab">Orders to Vendors</a></li>

                        </ul>
                        <div id="myTabContent" class="tab-content">

                            <div class="tab-pane fade in active" id="tab1">
                                <h2 class="title-divider">
                                    <span>Orders<span class="de-em"> to Clients</span></span>

                                </h2>
                                <asp:GridView ID="grdOrdersClients" runat="server" Width="940px" HorizontalAlign="Center"
                                    OnRowCommand="grdOrdersClients_RowCommand" AutoGenerateColumns="false"
                                    DataKeyNames="OrderId" CssClass="table table-hover table-striped">
                                    <Columns>
                                        <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                                        <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                                        <asp:BoundField DataField="OrderName" HeaderText="Order Name" />
                                        <asp:BoundField DataField="OrderDescription" HeaderText="Order Description" />

                                        <asp:BoundField DataField="ClientName" HeaderText="Client Name" />
                                        <asp:BoundField DataField="GrantorName" HeaderText="Grantor Name" />
                                        <asp:BoundField DataField="OrderCost" HeaderText="Order Cost" />
                                        <asp:BoundField DataField="Installments" HeaderText="Installments" />
                                        <asp:BoundField DataField="InstallmentsDueDate" HeaderText="Due Date" />
                                        <asp:BoundField DataField="ModeOfPayment" HeaderText="Due Date" />
                                        <asp:ButtonField CommandName="viewDetails" ControlStyle-CssClass="btn btn-info"
                                            ButtonType="Button" Text="View Order Details" HeaderText="View Order Record">
                                            <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                        </asp:ButtonField>
                                        <asp:ButtonField CommandName="ViewPayment" ControlStyle-CssClass="btn btn-info"
                                            ButtonType="Button" Text="View Payment History" HeaderText="View Payment Record">
                                            <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                        </asp:ButtonField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="tab-pane fade" id="tab2">

                                <h2 class="title-divider">
                                    <span>Orders<span class="de-em"> to Vendors</span></span></h2>
                                <asp:GridView ID="grdOrderVendors" runat="server" Width="940px" HorizontalAlign="Center"
                                    OnRowCommand="grdOrderVendors_RowCommand" AutoGenerateColumns="false"
                                    DataKeyNames="OrderId" CssClass="table table-hover table-striped">
                                    <Columns>
                                        <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                                        <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                                        <asp:BoundField DataField="OrderName" HeaderText="Order Name" />
                                        <asp:BoundField DataField="OrderDescription" HeaderText="Order Description" />

                                        <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                                        <asp:BoundField DataField="OrderCost" HeaderText="Order Cost" />
                                        <asp:BoundField DataField="Installments" HeaderText="Installments" />
                                        <asp:BoundField DataField="InstallmentsDueDate" HeaderText="Due Date" />
                                        <asp:BoundField DataField="ModeOfPayment" HeaderText="Due Date" />
                                        <asp:ButtonField CommandName="viewDetails" ControlStyle-CssClass="btn btn-info"
                                            ButtonType="Button" Text="View Order Details" HeaderText="View Order Record">
                                            <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                        </asp:ButtonField>
                                        <asp:ButtonField CommandName="ViewPayment" ControlStyle-CssClass="btn btn-info"
                                            ButtonType="Button" Text="View Payment History" HeaderText="View Payment Record">
                                            <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                        </asp:ButtonField>

                                    </Columns>
                                </asp:GridView>


                            </div>

                        </div>
                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>



    <div class="modal fade" id="viewOrderDetailModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-large">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">View Complete Detail Of Order
                    </h4>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div id="divDetails" runat="server">
                            </div>
                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>

                <div class="modal-footer">
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <!--@modal - update modal-->
    <div class="modal fade" id="viewOrderPaymentHistory" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-large">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">View/Update Order Details
                    </h4>
                </div>
                <asp:UpdatePanel ID="upOrderProductPanel" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div id="divPayments" runat="server">
                            </div>
                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>

                <div class="modal-footer">
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->



</asp:Content>
