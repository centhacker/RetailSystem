﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AddFiscalYear.aspx.cs" Inherits="RetailSystem.Pages.AddFiscalYear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">Bank Accounts</span></span>

        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
               

                <h5>Fiscal Year From
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control datepicker" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="false" ValidationGroup="frmBank" ControlToValidate="txtFrom" runat="server" ErrorMessage="Please Enter Fiscal Year To" ForeColor="Red"></asp:RequiredFieldValidator>
                
                
                <h5>Fiscal Year To
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtTo" runat="server" CssClass="form-control datepicker" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="false" ValidationGroup="frmBank" ControlToValidate="txtTo" runat="server" ErrorMessage="Please Enter Fiscal Year From" ForeColor="Red"></asp:RequiredFieldValidator>
                

               
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

</asp:Content>
