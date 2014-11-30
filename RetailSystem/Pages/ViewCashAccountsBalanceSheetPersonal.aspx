<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewCashAccountsBalanceSheetPersonal.aspx.cs" Inherits="RetailSystem.Pages.ViewCashAccountsBalanceSheetPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        ul.nav-tabs li.dropdown .dropdown-menu {
            min-width: 200px !important;
        }
    </style>
    <asp:UpdatePanel ID="upPayments" runat="server">
        <ContentTemplate>




            <h2 class="title-divider">
                <span>View Accounts<span class="de-em"> Balance Sheet</span></span>
            </h2>

            <h5>Select Bank Account
            </h5>
            <div class="form-group">

                <asp:DropDownList ID="ddlAccountType" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>

            <br />

            <asp:Button ID="btnFilter" CssClass="btn btn-primary" runat="server" Text="Filter" OnClick="btnFilter_Click" />

            <br />
            <asp:GridView ID="grdAccounts" runat="server" Width="940px" HorizontalAlign="Center"
                AutoGenerateColumns="false" AllowPaging="True" PageSize="3"
                CssClass="table table-bordered table-hover"
                PagerStyle-CssClass="bs-pagination"
                DataKeyNames="AccountId">
                <Columns>
                    <asp:BoundField DataField="AccountId" HeaderText="AccountId" />
                    <asp:BoundField DataField="Date" HeaderText="AccountId" />
                    <asp:BoundField DataField="Description" HeaderText="AccountId" />
                    <asp:BoundField DataField="Debit" HeaderText="AccountId" />
                    <asp:BoundField DataField="Credit" HeaderText="AccountId" />
                    <asp:BoundField DataField="Balance" HeaderText="AccountId" />
                    <asp:BoundField DataField="TransactionBy" HeaderText="AccountId" />
                </Columns>

            </asp:GridView>





        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
