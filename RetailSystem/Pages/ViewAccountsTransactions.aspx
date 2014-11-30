<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewAccountsTransactions.aspx.cs" Inherits="RetailSystem.Pages.ViewAccountsTransactions" %>

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
                            <asp:BoundField DataField="Debit" HeaderText="Debit" />
                            <asp:BoundField DataField="Credit" HeaderText="Credit" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            
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
