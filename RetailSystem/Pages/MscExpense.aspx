﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="MscExpense.aspx.cs" Inherits="RetailSystem.Pages.MscExpense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">Miscellaneous Expense</span></span>

        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>Date
                </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtdate" runat="server" TextMode="Date" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>
                 <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtdate" runat="server" ErrorMessage="Please Enter Vendor Name" ForeColor="Red"></asp:RequiredFieldValidator>

                <h5>Description
                </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtDescription" runat="server" ErrorMessage="Please Enter Vendor Name" ForeColor="Red"></asp:RequiredFieldValidator>

                <h5>Amount
                </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtamount" runat="server" TextMode="Number" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtamount" runat="server" ErrorMessage="Please Enter Vendor Name" ForeColor="Red"></asp:RequiredFieldValidator>

                <h5>Select Bank Account
                </h5>
                <div class="form-group">
                    <asp:DropDownList ID="ddlSaleAccount" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <h5>Or
                </h5>
                <h5>Use Default Account to recieve payments
                </h5>
                <div class="checkbox">
                    <label>
                        <asp:CheckBox ID="cbDefault" runat="server" />
                    </label>
                </div>


                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Add New Role" OnClick="btnSave_Click" ValidationGroup="frmBank" />


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