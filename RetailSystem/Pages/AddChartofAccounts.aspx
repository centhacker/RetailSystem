<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AddChartofAccounts.aspx.cs" Inherits="RetailSystem.Pages.Add_ChartofAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">Chart Of Accounts</span></span>
            <small>Add New Clients or click<a href="#ClientTypesModal" data-toggle="modal"> Add New Client Types</a> to Add new Client Types</small>
        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>Account type
                </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtAccounttype" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtAccounttype" runat="server" ErrorMessage="Please Enter Account Type" ForeColor="Red"></asp:RequiredFieldValidator>


                <h5>Account Name
                </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtAccountName" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtAccountName" runat="server" ErrorMessage="Please Enter Account Name" ForeColor="Red"></asp:RequiredFieldValidator>


                <h5>Account Number
                </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtAccountNumber" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="rfvClientName" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtAccountNumber" runat="server" ErrorMessage="Please Enter Account Number"></asp:RequiredFieldValidator>
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save Record" OnClick="btnSave_Click" ValidationGroup="frmBank"/>
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
