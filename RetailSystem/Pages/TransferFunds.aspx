<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="TransferFunds.aspx.cs" Inherits="RetailSystem.Pages.TransferFunds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="block">

        <h2 class="title-divider">
            <span>Assign <span class="de-em">Permissions to Roles </span></span>

        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>Cash Account
                </h5>
                <div class="form-group">
                    <asp:DropDownList ID="ddlCashAccount" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCashAccount_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
                 
                <h5>Account Balance
                  </h5>
                <div class="form-group">

                    <asp:Label ID="lblCashAccount" runat="server" CssClass="form-control" ></asp:Label>
                </div>
                <h5>Bank Account
                </h5>
                <div class="form-group">
                    <asp:DropDownList ID="ddlBankAccount" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBankAccount_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
                 <h5>Account Balance
                  </h5>
                <div class="form-group">

                    <asp:Label ID="lblBankAccount" runat="server" CssClass="form-control" ></asp:Label>
                </div>
                
                <h5>Amount
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>


                <asp:Button ID="btnSave" runat="server" Text="Transfer" CssClass="btn btn-primary" OnClick="btnSave_Click" />


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
