<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AssignRoles.aspx.cs" Inherits="RetailSystem.Pages.AssignRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updateClientForm" runat="server">
        <ContentTemplate>
            <h5>Roles
                  </h5>
            <div class="form-group">

                <asp:DropDownList ID="ddlEmployees" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <h5>Users
                  </h5>
            <div class="form-group">

                <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>


            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Assign Roles" OnClick="btnSave_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <!--@modal - update modal-->
    <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Assigned Roles
                </h4>
                </div>
                <asp:UpdatePanel ID="upEdit" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="alert-info">

                                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </div>
                            <asp:GridView ID="grdClients" runat="server" Width="940px" HorizontalAlign="Center"
                                AutoGenerateColumns="false" AllowPaging="true"
                                DataKeyNames="id" CssClass="table table-hover table-striped">
                                <Columns>



                                    <asp:BoundField DataField="Role" HeaderText="Client Id" />
                                    <asp:BoundField DataField="ClientTypeld" HeaderText="Client Type Name" />
                                    <asp:BoundField DataField="Name" HeaderText="Client Name" />
                                    <asp:BoundField DataField="phone" HeaderText="Client Phone" />

                                </Columns>
                            </asp:GridView>
                        </div>


                    </ContentTemplate>

                </asp:UpdatePanel>

                <div class="modal-footer">
                    <asp:Button ID="Button1" runat="server" Text="Update Record" CssClass="btn btn-info" OnClick="btnSave_Click" />
                </div>
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
