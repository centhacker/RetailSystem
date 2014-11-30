<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewAccountsBalanceSheet.aspx.cs" Inherits="RetailSystem.Pages.ViewAccountsBalanceSheet" %>

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

            <asp:Button ID="btnFilter" CssClass="btn btn-primary" runat="server" Text="Show Balance" OnClick="btnFilter_Click" />

            <br />
            <asp:GridView ID="grdAccounts" runat="server" Width="940px" HorizontalAlign="Center"
                AutoGenerateColumns="false" AllowPaging="True" PageSize="3"
                CssClass="table table-bordered table-hover" OnPageIndexChanged="grdAccounts_PageIndexChanged" OnPageIndexChanging="grdAccounts_PageIndexChanging"
                PagerStyle-CssClass="bs-pagination"
                DataKeyNames="AccountId">
                <Columns>
                    <asp:BoundField DataField="AccountId" HeaderText="AccountId" />
                    <asp:BoundField DataField="eDate" HeaderText="Date" />
                    <asp:BoundField DataField="AccountNumber" HeaderText="AccountNumber" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Debit" HeaderText="Debit" />
                    <asp:BoundField DataField="Credit" HeaderText="Credit" />
                    <asp:BoundField DataField="Total" HeaderText="Remaining Total" />

                </Columns>

            </asp:GridView>





        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
