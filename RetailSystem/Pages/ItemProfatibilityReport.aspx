<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ItemProfatibilityReport.aspx.cs" Inherits="RetailSystem.Pages.ItemProfatibilityReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdAccountTransaction" runat="server" Width="940px" HorizontalAlign="Center"
                        AutoGenerateColumns="false" AllowPaging="true"
                        CssClass="table">
                        <Columns>
                           
                            <asp:BoundField DataField="Inventory" HeaderText="Inventory" />
                            <asp:BoundField DataField="ActualCost" HeaderText="Actual Cost" />
                            <asp:BoundField DataField="ActualRevenue" HeaderText="Actual Revenue" />
                            <asp:BoundField DataField="UnitsSold" HeaderText="Units Sold" />
                            <asp:BoundField DataField="Diff" HeaderText="Diff" />
                            <asp:BoundField DataField="Percent" HeaderText="Percent" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <br />
                    <div class="alert-success">
                       
                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
