<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="RetailSystem.Pages.AddOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .grid-control {
            width: 100%;
        }
    </style>
    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">Order</span></span>
            <small>Add New Order for Client/Vendor </small>
        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>Enter Order No
                </h5>
                <div class="form-group">
                    <asp:TextBox ID="txtOrderNo" runat="server" CssClass="form-control" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvOrderNo" ControlToValidate="txtOrderNo" runat="server" ErrorMessage="Please Enter Order Number" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false"></asp:RequiredFieldValidator>

                </div>
                <h5>Enter Order Name
                </h5>
                <div class="form-group">
                    <asp:TextBox ID="txtOrderName" runat="server" CssClass="form-control" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvOrderName" ControlToValidate="txtOrderName" runat="server" ErrorMessage="Please Enter Order Name" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false"></asp:RequiredFieldValidator>

                </div>
                <h5>Enter Order Description
                </h5>
                <div class="form-group">
                    <asp:TextBox ID="txtOrderDescription" runat="server" CssClass="form-control" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>


                </div>
                <h5>Enter Order Date
                </h5>
                <div class="form-group">
                    <asp:TextBox ID="txtOrderDate" runat="server" TextMode="Date" CssClass="form-control" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv" ControlToValidate="txtOrderDate" runat="server" ErrorMessage="Please Enter Order Date" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false"></asp:RequiredFieldValidator>

                </div>
                <h5>Enter Delivery Of Order Date
                </h5>
                <div class="form-group">
                    <asp:TextBox ID="txtDeliveryOfOrderDate" runat="server" TextMode="Date" CssClass="form-control" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDeliveryDate" ControlToValidate="txtDeliveryOfOrderDate" runat="server" ErrorMessage="Please Enter Order Delivery Date" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false"></asp:RequiredFieldValidator>

                </div>


                <h5>Please select Order Type
                </h5>
                <div class="form-group">
                    <asp:DropDownList ID="ddlOrderType" runat="server" AutoPostBack="true" EnableViewState="true" CssClass="form-control" OnSelectedIndexChanged="ddlOrderType_SelectedIndexChanged">
                        <asp:ListItem Text="Please Select" Value="0">
                              
                        </asp:ListItem>
                        <asp:ListItem Text="Order To Client" Value="1">
                              
                        </asp:ListItem>
                        <asp:ListItem Text="Order From Vendor" Value="2">
                              
                        </asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div id="divClient" runat="server" visible="False">
                    <h5>Please Select Customer
                    </h5>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlCustomer" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged"></asp:DropDownList>

                    </div>
                    <h5>Add Grantor Information
                    </h5>
                      <div class="form-group">
                        <asp:CheckBox ID="cbGrantor" runat="server"  CssClass="form-control" AutoPostBack="true" OnCheckedChanged="cbGrantor_CheckedChanged"></asp:CheckBox>
                       

                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtGrantorInfo" runat="server" TextMode="Date" CssClass="form-control" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                       

                    </div>
                </div>
                <div id="divVendor" runat="server" visible="False">
                    <h5>Please Select Vendor
                    </h5>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlVendor" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>

                    </div>
                </div>
                <h5>Mode Of Payment
                </h5>
                <div class="form-group">
                    <asp:DropDownList ID="ddlModeOfPayment" AutoPostBack="true" runat="server" CssClass="form-control">
                        <asp:ListItem Value="-1" Text="Please Select"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Cash"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Cheque"></asp:ListItem>
                    </asp:DropDownList>

                </div>

                <h5>Installments
                </h5>
                <div class="form-group">
                    <asp:TextBox ID="txtInstallments" runat="server" TextMode="Number" CssClass=" form-control" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtInstallments" runat="server" ErrorMessage="Please Enter Order Delivery Date" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false"></asp:RequiredFieldValidator>

                </div>
                <h5>Installment Due Date
                </h5>
                <div class="form-group">
                    <asp:TextBox ID="txtIntallmentDueDate" runat="server" TextMode="Date" CssClass=" form-control" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtIntallmentDueDate" runat="server" ErrorMessage="Please Enter Order Delivery Date" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false"></asp:RequiredFieldValidator>

                </div>
                <h2 class="title-divider">
                    <span>Add  Products to<span class="de-em">Order</span></span>
                    <small>Add Products to Current Order </small>
                </h2>

                <asp:GridView ID="grdProducts" runat="server"
                    ShowFooter="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table table-hover table-striped"
                    GridLines="None" OnRowDeleting="grdProducts_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="SNo" />

                        <asp:TemplateField HeaderText="Products">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlProducts" AutoPostBack="true" runat="server" CssClass="grid-control form-control" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Cost Price">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCp" runat="server" AutoPostBack="true" CssClass="grid-control form-control " ForeColor="#009933" Font-Bold="True"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sale Price">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSp" runat="server" AutoPostBack="true" CssClass="grid-control form-control"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Units">
                            <ItemTemplate>
                                <asp:TextBox ID="txtUnits" AutoPostBack="true" runat="server" TextMode="Number" CssClass="grid-control form-control" OnTextChanged="txtUnits_TextChanged"></asp:TextBox>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Cost">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTotal" AutoPostBack="true" runat="server" CssClass="grid-control form-control"></asp:TextBox>
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
                    <asp:Button ID="btnSave" runat="server" Text="Save Orders" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!--@modal - Client Type modal-->



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
    </div>
    <!-- /.modal-dialog -->



</asp:Content>
