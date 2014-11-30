<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewInventoryTransactions.aspx.cs" Inherits="RetailSystem.Pages.ViewInventoryTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">
        <!--Default Pricing Table-->
        <div id="content">
            <div class="container">
                <div class="block">
                    <!--Default Pricing Table-->
                    <h2 class="title-divider">
                        <span>View <span class="de-em">Inventory Transactions</span></span>
                        <small>Inventory Transactions
                            <asp:Label ID="lblFiscalYear" runat="server" Text="Label">2013</asp:Label>
                            .</small>
                    </h2>
                    <div id="divViewAll" runat="server">
                        <h5>View All 
                  </h5>
                        <div class="form-group">
                            <asp:CheckBox ID="cbViewAll" runat="server" EnableViewState="true" CssClass="form-control"></asp:CheckBox>

                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnFilter" runat="server" Text="Filter" ValidationGroup="salesjournal" CssClass="btn btn-primary" OnClick="btnFilter_Click" />
                        </div>
                    </div>
                    <asp:Repeater ID="repInventoryBalance" runat="server">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered">
                                <tr>
                                    <td><b>Date</b></td>
                                    <td><b>WareHouse Name</b></td>
                                    <td><b>Product Name</b></td>
                                    <td><b>Purchase Units</b></td>
                                    <td><b>Purchase Units Cost</b></td>
                                    <td><b>Purchase Total</b></td>
                                    <td><b>Sale Units</b></td>
                                    <td><b>Sale Units Cost</b></td>
                                    <td><b>Sale Total</b></td>
                                    <td><b>Balance Units</b></td>
                                    <td><b>Balance Units Cost</b></td>
                                    <td><b>Balance Total</b></td>


                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "date") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "WarehouseName") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "ProductName") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "PurchaseUnits") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "PurchaseUnitsCost") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "PurchaseTotal") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "SaleUnits") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "SaleUnitsCost") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "SaleTotal") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "BalanceUnits") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "BalanceUnitsCost") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "BalanceTotal") %> 
                                </td>

                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table> 
                        </FooterTemplate>
                    </asp:Repeater>



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
            <!-- /.modal-content -->
        </div>

        <!-- /.modal-dialog -->
    </div>
</asp:Content>
