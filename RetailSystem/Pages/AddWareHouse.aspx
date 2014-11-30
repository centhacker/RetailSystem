<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AddWareHouse.aspx.cs" Inherits="RetailSystem.Pages.AddWareHouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">WareHouse</span></span>
           
        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>WareHouse Name
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtWareHouseName" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtWareHouseName" runat="server" ErrorMessage="Please Enter WareHouse Name" ForeColor="Red"></asp:RequiredFieldValidator>

                <h5>WareHouse Address
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtWareHouseAddress" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtWareHouseAddress" runat="server" ErrorMessage="Please Enter WareHouse Address" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>WareHouse Phone No
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtWareHousePhoneNo" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtWareHousePhoneNo" runat="server" ErrorMessage="Please Enter WareHouse Phone No" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>WareHouse Description
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtWareHouseDescription" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator4" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtWareHouseDescription" runat="server" ErrorMessage="Please Enter WareHouse Description" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>WareHouse OpenedDate
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtWareHouseOpenedDate" runat="server" CssClass="datepicker form-control " CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator5" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtWareHouseOpenedDate" runat="server" ErrorMessage="Please Enter WareHouse OpenedDate" ForeColor="Red"></asp:RequiredFieldValidator>

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
