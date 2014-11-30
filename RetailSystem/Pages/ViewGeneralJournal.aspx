<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewGeneralJournal.aspx.cs" Inherits="RetailSystem.Pages.ViewGeneralJourna" %>

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
                        <span>View <span class="de-em">General Journal</span></span>

                    </h2>
                    <!--Stack 1: 3 plans-->
                    <asp:UpdatePanel ID="upCrudGrid" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdRec" runat="server" Width="940px" HorizontalAlign="Center"
                                AutoGenerateColumns="false" AllowPaging="false"
                                CssClass="table table-hover table-striped">
                                <Columns>
                                    <asp:BoundField DataField="Date" HeaderText="Date of Entry" />
                                    <asp:BoundField DataField="AccountId" HeaderText="Account Id" />    
                                    <asp:BoundField DataField="AccountName" HeaderText="Account Name" />                                  
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="Debit" HeaderText="Debit" />
                                    <asp:BoundField DataField="Credit" HeaderText="Credit" />


                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>

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
