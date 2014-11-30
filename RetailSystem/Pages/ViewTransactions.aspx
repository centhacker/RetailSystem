<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewTransactions.aspx.cs" Inherits="RetailSystem.Pages.ViewInventoryProductWise" %>

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
                        <span>View <span class="de-em">Inventory Transactions Date Wise</span></span>
                        View Inventory Transactions Date Wise
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
                    <div class="row">
                        <div class="col-md-12">
                            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdTransactions" runat="server" Width="940px" HorizontalAlign="Center"
                                        AutoGenerateColumns="false"
                                        CssClass="table table-hover table-striped" ShowFooter="true">
                                        <Columns>
                                            <asp:BoundField DataField="Date" HeaderText="Date Of Transactions" FooterText="Total" />
                                            <asp:BoundField DataField="WareHouse" HeaderText="WareHouse" />
                                            <asp:BoundField DataField="Product" HeaderText="Product Name" />
                                            <asp:BoundField DataField="Units" HeaderText="Units" />
                                            <asp:BoundField DataField="Type" HeaderText="Type Of Transaction" />
                                        </Columns>

                                    </asp:GridView>


                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>


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
