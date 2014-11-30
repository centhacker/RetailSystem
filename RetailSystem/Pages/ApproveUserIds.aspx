<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ApproveUserIds.aspx.cs" Inherits="RetailSystem.Pages.ApproveUserIds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="block">

        <h2 class="title-divider">
            <span>Approve <span class="de-em">Registered Users </span></span>

        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <asp:GridView ID="grdUsers" runat="server" Width="940px" HorizontalAlign="Center"
                    OnRowCommand="grdUsers_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                    DataKeyNames="id" CssClass="table table-hover table-striped" OnRowDeleting="grdUsers_RowDeleting1">
                    <Columns>



                        <asp:BoundField DataField="id" HeaderText="Id" />
                        <asp:BoundField DataField="name" HeaderText="User Id" />
                        <asp:BoundField DataField="eDate" HeaderText="Date Registered" />

                        <asp:ButtonField CommandName="approve" ControlStyle-CssClass="btn btn-info"
                            ButtonType="Button" Text="Approve" HeaderText="Approve User">
                            <ControlStyle CssClass="btn btn-info"></ControlStyle>
                        </asp:ButtonField>
                        <asp:ButtonField CommandName="notapprove" ControlStyle-CssClass="btn btn-info"
                            ButtonType="Button" Text="Not Approve" HeaderText="Dont Approve User">
                            <ControlStyle CssClass="btn btn-info"></ControlStyle>
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>




            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!--@modal - update modal-->
    <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Message From Server
                </h4>
                </div>
                <asp:UpdatePanel ID="upEdit" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="alert alert-success">
                                <b>
                                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </b>
                            </div>
                        </div>


                    </ContentTemplate>

                </asp:UpdatePanel>

                <div class="modal-footer">
                 
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

                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
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

