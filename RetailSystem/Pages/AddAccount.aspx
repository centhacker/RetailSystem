<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="RetailSystem.Pages.AddAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">Bank Accounts</span></span>

        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>Account BankId
                  </h5>
                <div class="form-group">

                    <asp:DropDownList ID="ddlBankId" CssClass="form-control" runat="server" ValidationGroup="frmBank"></asp:DropDownList>
                </div>


                <h5>Account Number
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtAccountNumber" runat="server" CssClass="form-control" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="false" ValidationGroup="frmBank" ControlToValidate="txtAccountNumber" runat="server" ErrorMessage="Please Enter Account Number" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>Account Title
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtAccountTitle" runat="server" CssClass="form-control" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtAccountTitle" runat="server" ErrorMessage="Please Enter Account Title" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>Account Holder Id
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtAccountHolderId" runat="server" CssClass="form-control" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <h5>Opening Date
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtBeginDate" runat="server" CssClass="form-control datepicker" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator4" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtAccountHolderId" runat="server" ErrorMessage="Please Enter AccountHolderId" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>Opening Balance
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtOpeningBalance" runat="server" CssClass="form-control " CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtOpeningBalance" runat="server" ErrorMessage="Please Enter AccountHolderId" ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:Button ID="btnSave" runat="server" ValidationGroup="frmBank" CssClass="btn btn-primary" Text="Save Record" OnClick="btnSave_Click" />

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
        </div>
    </div>

    <!--@modal - Client Type modal-->

    <!-- /.modal-dialog -->


    
</asp:Content>
