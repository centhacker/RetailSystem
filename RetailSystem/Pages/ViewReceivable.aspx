<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewReceivable.aspx.cs" Inherits="RetailSystem.Pages.ViewReceivable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h5>Client
            </h5>
            <div class="form-group">
                <asp:DropDownList CssClass="form-control" ID="ddlClient" runat="server"></asp:DropDownList>
            </div>

            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Filter" OnClick="btnSave_Click" ValidationGroup="frmBank" />

            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdRec" runat="server" Width="940px" HorizontalAlign="Center"
                        AutoGenerateColumns="false" AllowPaging="true"
                        CssClass="table table-hover table-striped">
                        <Columns>
                            <asp:BoundField DataField="ClientName" HeaderText="Client Name" />
                            <asp:BoundField DataField="OrderName" HeaderText="Order Name" />
                            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                            <asp:BoundField DataField="PaidAmount" HeaderText="Amount Recieved" />

                            <asp:BoundField DataField="TotalCost" HeaderText="Total Amount" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
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
        </div>
    </div>
</asp:Content>
