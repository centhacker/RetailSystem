<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Purchases.aspx.cs" Inherits="RetailSystem.Pages.Purchases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .grid-control {
            width: 100%;
        }
    </style>
    <div class="block">


        <asp:UpdatePanel ID="updateGridSalesJournal" runat="server">
            <ContentTemplate>

                <h2 class="title-divider">
                    <span>Add <span class="de-em">New Purchase Transaction</span></span>
                    <small>Add Products to Inventory</small>
                </h2>
                
                <h5>WareHouse
                  </h5>
                <div class="form-group">
                    <asp:DropDownList ID="ddlWareHouse" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>
                <h5>Date Of Journal
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control datepicker" CausesValidation="true"  ValidationGroup="salesjournal"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtDate" runat="server" ErrorMessage="Please Enter Date" ForeColor="Red" ValidationGroup="salesjournal"></asp:RequiredFieldValidator>

                <asp:GridView ID="grdSales" runat="server"
                    ShowFooter="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table table-hover table-striped"
                    GridLines="None" OnRowDeleting="grdSales_RowDeleting" >
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="SNo" />

                        <asp:TemplateField HeaderText="Products">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlProducts" runat="server" CssClass="grid-control form-control" AutoPostBack="true"  OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField> 


                        <asp:TemplateField HeaderText="Cost Price">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCp" runat="server" CssClass="grid-control form-control" AutoPostBack="true" Font-Bold="True"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                         <asp:TemplateField HeaderText="Vendor">
                            <ItemTemplate>
                                <asp:Label ID="txtVendor" runat="server" AutoPostBack="true"    ></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Units">
                            <ItemTemplate>
                                <asp:TextBox ID="txtUnits" runat="server" TextMode="Number" CssClass="grid-control form-control" AutoPostBack="true" OnTextChanged="txtUnits_TextChanged" ></asp:TextBox>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Cost">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTotal" runat="server" CssClass="grid-control form-control" AutoPostBack="true"></asp:TextBox>
                            </ItemTemplate>




                            <FooterStyle HorizontalAlign="Left" />
                            <FooterTemplate>
                                <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" CssClass="btn btn-primary" OnClick="ButtonAdd_Click" />
                            </FooterTemplate>
                        </asp:TemplateField>


                        <asp:CommandField
                            ShowDeleteButton="True" />
                    </Columns>


                </asp:GridView>

                <div class="form-actions">
                    <asp:Button ID="btnPreview" runat="server" Text="Save Journal" ValidationGroup="salesjournal" CssClass="btn btn-lg btn-primary" OnClick="btnPreview_Click" />
                </div>



            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <div class="modal fade" id="modalPreview" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Journal Preview
                </h4>
                </div>

                <asp:UpdatePanel ID="updatePanelPreview" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div id="previewDiv" runat="server">

                            </div>
                            <h5>Discount
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtDiscount" TextMode="Number" Text="0" runat="server" CssClass="form-control " CausesValidation="true" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnSave" runat="server" Text="Save this Journal" CssClass="btn btn-info" OnClick="btnSave_Click" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <!-- /.modal-content -->
        </div>

        <!-- /.modal-dialog -->
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