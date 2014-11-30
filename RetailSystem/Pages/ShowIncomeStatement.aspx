<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ShowIncomeStatement.aspx.cs" Inherits="RetailSystem.Pages.ShowIncomeStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdAccountTransaction" runat="server" Width="940px" HorizontalAlign="Center"
                        AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="id" CssClass="table table-hover table-striped">
                        <Columns>
                            <asp:BoundField DataField="Accounts" HeaderText="Accounts" />
                            <asp:BoundField DataField="Revenue" HeaderText="Revenue" />
                            <asp:BoundField DataField="Expense" HeaderText="Expense" />
                            <asp:BoundField DataField="Units" HeaderText="Units In Hand" />
                            <asp:BoundField DataField="PerUnitCost" HeaderText="Per Unit Cost" />
                            <asp:BoundField DataField="Total" HeaderText="Total Inventory" />
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
