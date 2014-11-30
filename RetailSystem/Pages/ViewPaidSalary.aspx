<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewPaidSalary.aspx.cs" Inherits="RetailSystem.Pages.ViewPaidSalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdRec" runat="server" Width="940px" HorizontalAlign="Center"
                        AutoGenerateColumns="false" AllowPaging="true"
                       CssClass="table table-hover table-striped">
                        <Columns>
                            <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                             <asp:BoundField DataField="Month" HeaderText="Month" />
                             <asp:BoundField DataField="Date" HeaderText="Date" />
                             <asp:BoundField DataField="Amount" HeaderText="Amount" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
