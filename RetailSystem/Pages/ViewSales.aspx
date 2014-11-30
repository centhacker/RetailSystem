<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewSales.aspx.cs" Inherits="RetailSystem.Pages.ViewSales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="block">
        <!--Default Pricing Table-->
        <div id="content">
            <div class="container">
                <div class="block">
                    <!--Default Pricing Table-->
                    <h2 class="title-divider">
                        <span>View <span class="de-em">Sales</span></span>
                        <small>View Owner Equity Fiscal Year Wise <asp:Label ID="lblFiscalYear" runat="server" Text="Label">2013</asp:Label> .</small>
                    </h2>
                    <!--Stack 1: 3 plans-->
                    <div class="row pricing-stack pricing-table margin-top-lg">
                        <div class="col-md-3 pricing-table-features ">
                            <div class="well title-hidden">
                                <ul class="pricing-table-features-list">
                                    <li class="title"></li>
                                    <li class="price">Accounts</li>
                                    <li>User Accounts</li>
                                    <li>Private Projects</li>
                                    <li>Public Projects</li>

                                </ul>
                            </div>
                        </div>
                        <div class="col-md-3 pricing-table-plan">
                            <div class="well">
                                <ul class="pricing-table-features-list">
                                    <li class="title">Assets</li>
                                    <li class="price"><span class="digits">$</span></li>

                                    <li>100</li>
                                    <li>200</li>
                                    <li>300</li>
                                    <li class="price"><span class="digits">Total</span></li>
                                    <li>300</li>

                                </ul>
                            </div>
                        </div>
                        
                        <div class="col-md-3 pricing-table-plan">
                            <div class="well">
                                <ul class="pricing-table-features-list">
                                    <li class="title">Sales <span class="fancy"> + Liabilities</span></li>
                                    <li class="price"><span class="digits">$</span></li>

                                   <li>100</li>
                                    <li>200</li>
                                    <li>300</li>
                                    <li class="price"><span class="digits">Total</span></li>
                                    <li>300</li>


                                </ul>
                            </div>
                        </div>
                        <div class="col-md-3 pricing-table-features ">
                            <div class="well title-hidden">
                                <ul class="pricing-table-features-list">
                                    <li class="title"></li>
                                    <li class="price">Accounts</li>
                                    <li>User Accounts</li>
                                    <li>Private Projects</li>
                                    <li>Public Projects</li>

                                </ul>
                            </div>
                        </div>
                    </div>

                   
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
</asp:Content>
