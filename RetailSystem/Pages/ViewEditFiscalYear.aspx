<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewEditFiscalYear.aspx.cs" Inherits="RetailSystem.Pages.ViewEditFiscalYear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span>Set<span class="de-em">Fiscal Year</span></span>

        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>



                <h5>Set Default Fiscal Year
                  </h5>
                <div class="form-group">

                    <asp:DropDownList ID="ddlFiscalYear" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>



                <asp:Button ID="btnSetPurchase" runat="server" ValidationGroup="frmBank" CssClass="btn btn-primary" Text="Set Purchase Default Account" OnClick="btnSetPurchase_Click" />


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

</asp:Content>
