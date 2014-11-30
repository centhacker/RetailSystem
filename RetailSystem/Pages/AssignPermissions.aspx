<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AssignPermissions.aspx.cs" Inherits="RetailSystem.Pages.AssignPermissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span>Assign <span class="de-em">Permissions to Roles </span></span>

        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>Roles
                </h5>
                <div class="form-group">
                    <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <h5>Admin / All
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbAllRead" runat="server" OnCheckedChanged="cbAllRead_CheckedChanged" />
                            Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbAllWrite" runat="server" OnCheckedChanged="cbAllWrite_CheckedChanged" />
                            Write?
                   
                        </label>
                    </div>
                </div>
                <div class="col-md-3">
                    <h5>Employees
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbEmployeeRead" runat="server" />
                            Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbEmployeeWrite" runat="server" />
                            Write?
                   
                        </label>
                    </div>
                </div>
                <div class="col-md-3">
                    <h5>Expenses
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbExpense" runat="server" />
                            Expenses?
                   
                        </label>
                    </div>

                </div>
                <div class="col-md-3">
                    <h5>Orders : Sales and Purchase
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbOrdersRead" runat="server" />
                            Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbOrdersWrite" runat="server" />
                            Write?
                   
                        </label>
                    </div>
                </div>
                <div class="col-md-3">
                    <h5>WareHouse
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbWareHouseRead" runat="server" />
                            Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbWareHouseWrite" runat="server" />
                            Write?
                   
                        </label>
                    </div>
                </div>

                <div class="col-md-3">
                    <h5>Accounts
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbAccountsRead" runat="server" />
                            Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbAccountsWrite" runat="server" />
                            Write?
                   
                        </label>
                    </div>
                </div>
                <div class="col-md-3">
                    <h5>Clients
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbClientsRead" runat="server" />
                            Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbClientsWrite" runat="server" />
                            Write?
                   
                        </label>
                    </div>
                </div>
                <div class="col-md-3">
                    <h5>Payroll
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbPayrollRead" runat="server" />
                            Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbPayrollWrite" runat="server" />
                            Write?
                   
                        </label>
                    </div>
                </div>
                <div class="col-md-3">
                    <h5>Products
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbProductsRead" runat="server" />
                            Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbProductsWrite" runat="server" />
                            Write?
                   
                        </label>
                    </div>
                </div>
                <div class="col-md-3">
                    <h5>User & Roles Management
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbUserManegementRead" runat="server" />
                            Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbUserManegementWrite" runat="server" />
                            Write?
                   
                        </label>
                    </div>
                </div>
                <div class="col-md-3">
                    <h5>Vendor
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbVendorRead" runat="server" />
                            Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbVendorWrite" runat="server" />
                            Write?
                   
                        </label>
                    </div>
                </div>
                <div class="col-md-3">
                    <h5>Bank And Accounts
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbBankRead" runat="server" />
                            Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbBankWrite" runat="server" />
                            Write?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbBankUser" runat="server" />
                            Use Accounts for Transactions?
                   
                        </label>
                    </div>
                </div>
                <div class="col-md-3">
                    <h5>Inventory and Sales
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbInventoryRead" runat="server" />
                            View Inventory Reports?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbSalesJournal" runat="server" />
                            View / Write Sales and Purchase Journal ?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbGeneralJournalRead" runat="server" />
                            View General Journal and other Reports?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbGeneralJournalWrite" runat="server" />
                            Write General Journal?
                   
                        </label>
                    </div>
                </div>

                <div class="col-md-3">
                    <h5>Payments
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbPaymentsRead" runat="server" />
                            Payments Read?
                   
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbPaymentsWrite" runat="server" />
                            Payments Write?
                   
                        </label>
                    </div>
                </div>

                <div class="col-md-3">
                    <h5>Reports
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbReportsRead" runat="server" />
                            Reports Read?
                   
                        </label>
                    </div>

                </div>
                <div class="col-md-3">
                    <h5>Opening Balance
                    </h5>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbOpeningBalance" runat="server" />
                            Open Balance?
                   
                        </label>
                    </div>

                </div>



                <asp:Button ID="btnSave" runat="server" Text="Save / Update Role" CssClass="btn btn-primary" OnClick="btnSave_Click" />


            </ContentTemplate>
        </asp:UpdatePanel>
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
