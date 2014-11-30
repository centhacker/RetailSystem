<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewCashInHand.aspx.cs" Inherits="RetailSystem.Pages.ViewCashInHand" %>

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
                            <asp:BoundField DataField="Fiscal Year" HeaderText="Fiscal Year" />
                            <asp:BoundField DataField="Revenue" HeaderText="Revenue" />
                            <asp:BoundField DataField="Expense" HeaderText="Expense" />
                            <asp:BoundField DataField="Ending Balance" HeaderText="Ending Balance" />
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
