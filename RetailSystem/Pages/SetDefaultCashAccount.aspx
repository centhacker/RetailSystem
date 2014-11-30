<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="SetDefaultCashAccount.aspx.cs" Inherits="RetailSystem.Pages.SetDefaultCashAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">Cash Accounts</span></span>

        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>


                <div class="tabbable">
                    <ul id="myTab" class="nav nav-tabs">
                        <li class="active"><a href="#tab1" data-toggle="tab">Set Purchase Account</a></li>
                        <li><a href="#tab2" data-toggle="tab">Set Sales Account</a></li>

                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <div class="tab-pane fade in active" id="tab1">
                            <h5>Default Purchase Account
                  </h5>
                            <div class="form-group">

                                <asp:DropDownList ID="ddlPurchaseAccount" CssClass="form-control" runat="server"  OnSelectedIndexChanged="ddlPurchaseAccount_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <h5>Default Purchase Account
                  </h5>
                            <div class="form-group">
                                <asp:Label ID="lblPurchaseAccount" runat="server"></asp:Label>
                                 </div>


                            <asp:Button ID="btnSetPurchase" runat="server" ValidationGroup="frmBank" CssClass="btn btn-primary" Text="Set Purchase Default Account" OnClick="btnSetPurchase_Click" />

                        </div>
                        <div class="tab-pane fade" id="tab2">
                            <h5>Default Sales Account
                  </h5>
                            <div class="form-group">

                                <asp:DropDownList ID="ddlSalesAccount" CssClass="form-control" runat="server" ></asp:DropDownList>
                            </div>
                              <h5>Default Purchase Account
                  </h5>
                            <div class="form-group">
                                <asp:Label ID="lblSalesAccount" runat="server"></asp:Label>
                                 </div>



                            <asp:Button ID="btnSetSales" runat="server" ValidationGroup="frmBank" CssClass="btn btn-primary" Text="Set Sales Default Account" OnClick="btnSetSales_Click" />

                        </div>

                    </div>
                </div>
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
