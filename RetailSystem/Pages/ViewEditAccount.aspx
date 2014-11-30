<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewEditAccount.aspx.cs" Inherits="RetailSystem.Pages.ViewEditAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdAccountTransaction" runat="server" Width="940px" HorizontalAlign="Center"
                        OnRowCommand="grdAccountTransaction_RowCommand" AutoGenerateColumns="false" 
                        DataKeyNames="id" CssClass="table table-hover table-striped">
                        <Columns>



                            <asp:BoundField DataField="id" HeaderText="Account Transaction Id" />
                            <asp:BoundField DataField="BankId" HeaderText="Bank Id" />
                            <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" />
                            <asp:BoundField DataField="AccountTitle" HeaderText="Account Title" />
                            <asp:BoundField DataField="AccountHolderId" HeaderText="Account Holder Id" />
                            <asp:BoundField DataField="OpeningBalance" HeaderText="Opening Balance" />
                            <asp:BoundField DataField="Balance" HeaderText="Balance" />
                            <asp:ButtonField CommandName="editRecord" ControlStyle-CssClass="btn btn-info"
                                ButtonType="Button" Text="Edit" HeaderText="Edit Record">
                                <ControlStyle CssClass="btn btn-info"></ControlStyle>
                            </asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!--@modal - update modal-->
    <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Update Client Record
                    </h4>
                </div>
                <asp:UpdatePanel ID="upEdit" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <h5>Account Id
                            </h5>
                            <div class="form-group">

                                <asp:Label ID="lblAccountTransaction" runat="server" Text="Label"></asp:Label>
                            </div>
                            <h5>Bank Id
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtBankId" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtBankId" runat="server" ErrorMessage="Please Enter Bankk Id" ForeColor="Red"></asp:RequiredFieldValidator>

                            <h5>Account Number
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtAccountNumber" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtAccountNumber" runat="server" ErrorMessage="Please Enter Account Number" ForeColor="Red"></asp:RequiredFieldValidator>
                            <h5>Account Title
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtAccountTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtAccountTitle" runat="server" ErrorMessage="Please Enter Account Title" ForeColor="Red"></asp:RequiredFieldValidator>
                            <h5>Account HolderId
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtAccountHolderId" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator4" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtAccountHolderId" runat="server" ErrorMessage="Please Enter Account HolderId" ForeColor="Red"></asp:RequiredFieldValidator>
                            <h5>Opening Balance
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtOpeningBalance" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                           
                            <h5>Balance
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtBalance" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                        </div>


                        <div class="modal-footer">
                            <asp:Button ID="btnSave" runat="server" Text="Update Record" CssClass="btn btn-info" OnClick="btnSave_Click" />
                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>
            </div>
        </div>
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
    <!-- /.modal -->
</asp:Content>
