<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="RetailSystem.Pages.AddClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">Clients</span></span>
            <small>Add New Clients or click<a href="#ClientTypesModal" data-toggle="modal"> Add New Client Types</a> to Add new Client Types</small>
        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>Select Client Type
                  </h5>
                <div class="form-group">

                    <asp:DropDownList ID="ddlClientType" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <h5>Client Name
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtClientName" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="rfvClientName" Display="Dynamic" SetFocusOnError="false" ForeColor="Red" ControlToValidate="txtClientName"  runat="server" ValidationGroup="frmBank" ErrorMessage="Please Enter Client Name"></asp:RequiredFieldValidator>

                <h5>Phone
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator ID="rfvPhone" ForeColor="Red" ControlToValidate="txtPhone" Display="Dynamic" SetFocusOnError="false" runat="server" ValidationGroup="frmBank" ErrorMessage="Please Enter Client Phone Number"></asp:RequiredFieldValidator>
                <h5>Email Address
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator ID="rfvEmail" ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic" SetFocusOnError="false" runat="server" ValidationGroup="frmBank" ErrorMessage="Please Enter Client Email"></asp:RequiredFieldValidator>
                <h5>Address 1
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator ID="rfvAddress1" ForeColor="Red" ControlToValidate="txtAddress1" Display="Dynamic" SetFocusOnError="false" runat="server" ValidationGroup="frmBank" ErrorMessage="Please Enter Address 1 of Client"></asp:RequiredFieldValidator>
                <h5>Address 2
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control" CausesValidation="true" ></asp:TextBox>
                </div>
                <h5>City
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" CausesValidation="true" ></asp:TextBox>
                </div>

                 <h5>NIC
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtNIC" runat="server" CssClass="form-control" CausesValidation="true" ></asp:TextBox>
                </div>

                 <h5>Grantor Name
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtGrantorName" runat="server" CssClass="form-control" CausesValidation="true" ></asp:TextBox>
                </div>

                 <h5>Grantor NIC
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtGrantorNIC" runat="server" CssClass="form-control" CausesValidation="true" ></asp:TextBox>
                </div>
                <div class="checkbox">
                    <label>
                        <asp:CheckBox ID="cbIsVendor" runat="server" />
                        Is Client A Vendor?
                   
                    </label>
                </div>


                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit New Client" OnClick="btnSubmit_Click" ValidationGroup="frmBank" />
               
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!--@modal - Client Type modal-->
    <div class="modal fade" id="ClientTypesModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Add New Client Types
                </h4>
                </div>
                <div class="modal-body">

                    <h5>Client Types
                  </h5>
                    <asp:UpdatePanel ID="updateClientType" runat="server">
                        <ContentTemplate>
                            <div class="form-group">

                                <asp:TextBox ID="txtClientType" runat="server" ValidationGroup="modalClient" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvClientTyoe" ForeColor="Red" ControlToValidate="txtClientType"  Display="Dynamic" SetFocusOnError="false" runat="server" ValidationGroup="modalClient" ErrorMessage="Please Enter Address 1 of Client"></asp:RequiredFieldValidator>
               
                                <br />
                                <asp:Button ID="btnSubmitClientType" CssClass="btn btn-primary" runat="server" Text="Submit New Client Type" ValidationGroup="modalClient" OnClick="btnSubmitClientType_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
            <div class="modal-footer">
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
    </div>
    <!-- /.modal-dialog -->
</asp:Content>

