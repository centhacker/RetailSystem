<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewEditClients.aspx.cs" Inherits="RetailSystem.Pages.ViewEditClients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdClients" runat="server" Width="940px" HorizontalAlign="Center"
                        OnRowCommand="grdClients_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="id" CssClass="table table-hover table-striped">
                        <Columns>



                            <asp:BoundField DataField="id" HeaderText="Client Id" />
                            <asp:BoundField DataField="ClientTypeld" HeaderText="Client Type Name" />
                            <asp:BoundField DataField="Name" HeaderText="Client Name" />
                            <asp:BoundField DataField="phone" HeaderText="Client Phone" />
                            <asp:BoundField DataField="EmailAddress" HeaderText="Client Email Address" />
                            <asp:BoundField DataField="Address1" HeaderText="Address1" />
                            <asp:BoundField DataField="Address2" HeaderText="Address2" />
                            <asp:BoundField DataField="City" HeaderText="City" />
                            <asp:BoundField DataField="isVendor" HeaderText="Is Client Vendor" />
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
                            <h5>Client Id
                  </h5>
                            <div class="form-group">

                                <asp:Label ID="lblClientId" runat="server" Text="Label"></asp:Label>
                            </div>

                            <h5>Select Client Type
                  </h5>
                            <div class="form-group">

                                <asp:DropDownList ID="ddlClientType" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <h5>Client Name
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtClientName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>



                            <h5>Phone
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            <h5>Email Address
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            <h5>Address 1
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            <h5>Address 2
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <h5>City
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <asp:CheckBox ID="cbIsVendor" runat="server" />
                                    Is Client A Vendor?
                   
                                </label>
                            </div>





                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdClients" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>

                <div class="modal-footer">
                    <asp:Button ID="btnSave" runat="server" Text="Update Record" CssClass="btn btn-info" OnClick="btnSave_Click" />
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
