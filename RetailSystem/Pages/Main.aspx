<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="RetailSystem.Pages.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">
        <!--Default Pricing Table-->
        <h2 class="title-divider">
            <span>Setup <span class="de-em">Plans</span></span>
            <small>Quick Links to Setup forms</small>
        </h2>

        <div class="row pricing-stack margin-top-lg">
            <div class="col-md-4">
                <div class="well">

                    <p class="price"><span class="fancy">Products Section</span></p>
                    <ul class="unstyled points">
                        <li><a href="#">Add Products</a></li>
                        <li><a href="#">View All Products</a></li>

                    </ul>
                    <p class=" btn-primary"></p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="well active">

                    <p class="price">

                        <span class="digits">Sales</span>
                        <span class="term">Journal</span>
                    </p>
                    <ul class="unstyled points">
                        <li><a href="SalesJournal.aspx">New Journal</a></li>

                    </ul>

                </div>
            </div>
            <div class="col-md-4">
                <div class="well">
                    <h3 class="title">Vendors
                  </h3>
                    <p class="price"><span class="fancy">Vendors Section</span></p>
                    <ul class="unstyled points">
                        <li><a href="#">Add Vendors</a></li>
                        <li><a href="#">View All Vendors</a></li>

                    </ul>

                </div>
            </div>
        </div>
        <!--Stack 2: 3 in row-->
        <div class="row pricing-stack margin-top-lg">
            <div class="col-md-offset-1 col-sm-4 col-md-4">
                <div class="well">

                    <p class="price"><span class="fancy">Customers Section</span></p>
                    <ul class="unstyled points">
                        <li><a href="#">Add Customers</a> </li>
                        <li><a href="#">View Customers</a> </li>

                    </ul>

                </div>
            </div>

            <div class="col-md-offset-2 col-sm-4 col-md-4">
                <div class="well">
                    <h3 class="title">WareHouse
                  </h3>
                    <p class="price"><span class="fancy">WareHouse Section</span></p>
                    <ul class="unstyled points">
                        <li><a href="#">Add WareHouse</a> </li>
                        <li><a href="#">View WareHouse</a> </li>

                    </ul>

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
