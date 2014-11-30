<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AddBank.aspx.cs" Inherits="RetailSystem.Pages.AddBank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">Banks</span></span>
         
        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>Bank Name
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="false"  ControlToValidate="txtBankName" runat="server" ErrorMessage="Please Enter Bank Name" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>

                <h5>Bank Branch
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtBankBranch" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtBankBranch" runat="server" ErrorMessage="Please Enter Bank Branch" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>
                <h5>Bank Branch Code
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtBankBranchCode" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtBankBranchCode" runat="server" ErrorMessage="Please Enter Bank BranchCode" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>
                <h5>Bank Telephone Number
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtBankTelephoneNumber" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator4" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtBankTelephoneNumber" runat="server" ErrorMessage="Please Enter Bank TelephoneNumber" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>
                <h5>Bank Email Address
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtBankEmailAddress" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator5" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtBankEmailAddress" runat="server" ErrorMessage="Please Enter Bank EmailAddress" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save Record" OnClick="btnSave_Click" ValidationGroup="frmBank" />

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
