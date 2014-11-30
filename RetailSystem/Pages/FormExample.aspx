<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="FormExample.aspx.cs" Inherits="RetailSystem.Pages.FormExample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">
        <!--Default Pricing Table-->
        <h2 class="title-divider">
            <span>Example <span class="de-em">Forms</span></span>
            <small>Example Forms to create other Forms</small>
        </h2>


        <h5>Enter Email
                  </h5>
        <div class="form-group">
            <label class="sr-only" for="login-email">Email</label>
            <input type="email" id="Email1" class="form-control email" placeholder="Email" />
        </div>
        <h5>Enter Password
                  </h5>
        <div class="form-group">
            <label class="sr-only" for="login-password">Password</label>
            <input type="password" id="Password1" class="form-control password" placeholder="Password" />
        </div>
        <button type="button" class="btn btn-primary">Login</button>


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
