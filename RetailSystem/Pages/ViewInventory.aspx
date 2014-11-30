<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewInventory.aspx.cs" Inherits="RetailSystem.Pages.ViewInventory" %>

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
                        <span>View <span class="de-em">Inventory</span></span>
                        <small>Inventory of the Products 
                            <asp:Label ID="lblFiscalYear" runat="server" Text="Label">2013</asp:Label>
                            .</small>
                    </h2>


                    <h2 class="title-divider">
                        <small>Filters
                            <asp:Label ID="Label1" runat="server" Text="Label">2013</asp:Label>
                            .</small>
                    </h2>
                    <!--Stack 1: 3 plans-->
                    <h5>Select Specific Product
                  </h5>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlProducts" runat="server" EnableViewState="true" CssClass="form-control">
                        </asp:DropDownList>

                    </div>

                    <div id="divViewAll" runat="server">
                        <h5>View All 
                  </h5>
                        <div class="form-group">
                            <asp:CheckBox ID="cbViewAll" runat="server" EnableViewState="true" CssClass="form-control"></asp:CheckBox>

                        </div>
                    </div>


                    <div class="form-actions">
                        <asp:Button ID="btnFilter" runat="server" Text="Filter" ValidationGroup="salesjournal" CssClass="btn btn-primary" OnClick="btnFilter_Click" />
                    </div>

                    <asp:Repeater ID="repInventory" runat="server">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered">
                                <tr>
                                    <td><b>WarehouseName</b></td>
                                    <td><b>ProductCode</b></td>
                                    <td><b>ProductName</b></td>
                                    <td><b>Quantity</b></td>
                                    <td><b>Cost Per Unit</b></td>
                                    <td><b>Total Cost </b></td>

                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "WareHouseName") %>  
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "ProductCode") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "ProductName") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "Quantity") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "Cost") %> 
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "TotalCost") %> 
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
