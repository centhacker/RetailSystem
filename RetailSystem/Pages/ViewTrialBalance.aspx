<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewTrialBalance.aspx.cs" Inherits="RetailSystem.Pages.ViewTrialBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="title-divider">
        <span>View <span class="de-em">Trial Balance</span></span>
    </h2>
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdAccountTransaction" runat="server" Width="940px" HorizontalAlign="Center"
                        AutoGenerateColumns="false"
                        CssClass="table table-hover table-striped" ShowFooter="true">
                        <Columns>
                            <asp:BoundField DataField="AccountId" HeaderText="Accounts ID" FooterText="Total" />
                            <asp:BoundField DataField="AccountName" HeaderText="Accounts Name" />
                            <asp:BoundField DataField="Debit" HeaderText="Debit" />
                            <asp:BoundField DataField="Credit" HeaderText="Credit" />
                        </Columns>

                    </asp:GridView>


                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
