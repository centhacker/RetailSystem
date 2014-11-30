<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewCashAccountsVendors.aspx.cs" Inherits="RetailSystem.Pages.ViewCashAccountsVendors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdAccountTransaction" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false"
                        DataKeyNames="id" CssClass="table table-hover table-striped">
                        <Columns>



                            <asp:BoundField DataField="id" HeaderText="Account Transaction Id" />
                            <asp:BoundField DataField="CashAccountName" HeaderText="Cash Account Name" />
                            <asp:BoundField DataField="OpeningBalance" HeaderText="Opening Balance" />
                            <asp:BoundField DataField="BeginDate" HeaderText="Begin Date" />
                           
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!--@modal - update modal-->
    
    
    <!-- /.modal -->
</asp:Content>
