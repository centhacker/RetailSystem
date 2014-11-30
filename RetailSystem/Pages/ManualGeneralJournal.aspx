<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ManualGeneralJournal.aspx.cs" Inherits="RetailSystem.Pages.ManualGeneralJournal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .form-control {
            width: 100%;
        }
    </style>
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdJournal" runat="server"
                        ShowFooter="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table table-hover table-striped"
                        GridLines="None" OnRowDeleting="grdJournal_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="SNo" />
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlAccounts" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Desciption">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                         
                            <asp:TemplateField HeaderText="Debit Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDebit" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Credit Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCredit" runat="server"></asp:TextBox>
                                </ItemTemplate>



                                <FooterStyle
                                    HorizontalAlign="Right" />
                                <FooterTemplate>
                                    <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:CommandField
                                ShowDeleteButton="True" />
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
    <!-- /.modal-content -->
        </div>

        <!-- /.modal-dialog -->
    </div>

</asp:Content>
