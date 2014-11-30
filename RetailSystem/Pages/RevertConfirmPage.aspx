<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="RevertConfirmPage.aspx.cs" Inherits="RetailSystem.RevertConfirmPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .grid-control {
            width: 100%;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grdOrderConfirm" runat="server" Width="940px" HorizontalAlign="Center"
                OnRowCommand="grdOrderConfirm_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                DataKeyNames="ProductId" CssClass="table table-hover table-striped">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="Products" />
                    <asp:BoundField DataField="ProductName" HeaderText="Products" />
                    <asp:BoundField DataField="Price" HeaderText="Cost Price" />

                    <asp:TemplateField HeaderText="Units In Order">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCp" runat="server" TextMode="Number" CssClass="grid-control form-control " Text='<%# Bind("Units") %>' ForeColor="#009933" Font-Bold="True" AutoPostBack="true"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField CommandName="revert" ControlStyle-CssClass="btn btn-info"
                        ButtonType="Button" Text="Revert Order" HeaderText="Revert Order">
                        <ControlStyle CssClass="btn btn-info"></ControlStyle>
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>
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
</asp:Content>
