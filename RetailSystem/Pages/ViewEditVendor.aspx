<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewEditVendor.aspx.cs" Inherits="RetailSystem.Pages.ViewEditVendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdVendor" runat="server" Width="940px" HorizontalAlign="Center"
                        OnRowCommand="grdVendor_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="id" CssClass="table table-hover table-striped">
                        <Columns>



                            <asp:BoundField DataField="id" HeaderText="Vendor id" />
                            <asp:BoundField DataField="Name" HeaderText="Vendor name" />
                            <asp:BoundField DataField="Addreess" HeaderText="Vendor Address" />
                            <asp:BoundField DataField="Phone" HeaderText="Vendor phone" />


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
                    <h4 class="modal-title">Update Vendor Record
                    </h4>
                </div>
                <asp:UpdatePanel ID="upEdit" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <h5>Vendor id
                            </h5>
                            <div class="form-group">

                                <asp:Label ID="lblVendor" runat="server" Text="Label"></asp:Label>
                            </div>
                            <h5>Vendor name
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtVendorname" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtVendorname" runat="server" ErrorMessage="Please Enter Vendor Name" ForeColor="Red"></asp:RequiredFieldValidator>

                            <h5>Vendor Address
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtVendorAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtVendorAddress" runat="server" ErrorMessage="Please Enter Vendor Address" ForeColor="Red"></asp:RequiredFieldValidator>
                            <h5>Vendor phone
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtVendorphone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtVendorphone" runat="server" ErrorMessage="Please Enter Vendor phone" ForeColor="Red"></asp:RequiredFieldValidator>



                            <div class="modal-footer">
                                <asp:Button ID="btnSave" runat="server" Text="Update Record" CssClass="btn btn-info" OnClick="btnSave_Click1" />
                            </div>
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
