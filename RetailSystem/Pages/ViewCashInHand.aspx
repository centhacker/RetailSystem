<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewCashInHand.aspx.cs" Inherits="RetailSystem.Pages.ViewCashInHand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server"> 
                <ContentTemplate>
                    <asp:GridView ID="grdAccountTransaction" runat="server" Width="940px" HorizontalAlign="Center"
                      DataKeyNames="ProductName"  OnRowCommand="grdAccountTransaction_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                         CssClass="table table-hover table-striped">
                        <Columns>
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                            <asp:BoundField DataField="ProductTag1" HeaderText="Tag 1" />
                            <asp:BoundField DataField="ProductTag2" HeaderText="Tag 2" />
                            <asp:BoundField DataField="WarehouseName" HeaderText="WareHouse Name" />
                            <asp:BoundField DataField="Units" HeaderText="Units In Hand" />
                            <asp:BoundField DataField="PerUnitCost" HeaderText="Per Unit Cost" />
                            <asp:BoundField DataField="Total" HeaderText="Total Inventory" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <br />
                    <div class="alert-success">
                        Your total Cash in hand in terms of inventory is:
                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
