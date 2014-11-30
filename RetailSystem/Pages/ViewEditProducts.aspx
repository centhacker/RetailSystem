<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewEditProducts.aspx.cs" Inherits="RetailSystem.Pages.ViewEditProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdProduct" runat="server" Width="940px" HorizontalAlign="Center"
                        OnRowCommand="grdProduct_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="id" CssClass="table table-hover table-striped">
                        <Columns>



                            <asp:BoundField DataField="id" HeaderText="Product Id" />
                            <asp:BoundField DataField="ProductCode" HeaderText="Product Code" />
                            <asp:BoundField DataField="Name" HeaderText="Product Name" />
                            <asp:BoundField DataField="tag1" HeaderText="Product tag1" />
                            <asp:BoundField DataField="tag2" HeaderText="Product tag2" />
                            <asp:BoundField DataField="costPrice" HeaderText="Cost Price" />
                            <asp:BoundField DataField="salePrice" HeaderText="Sale Price" />
                            <asp:BoundField DataField="Vendorld" HeaderText="Vendor Id" />
                            <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                            <asp:BoundField DataField="Manufacturer" HeaderText="Product Manufacturer" />
                            <asp:BoundField DataField="Description" HeaderText="Product Description" />



                            <asp:ButtonField CommandName="editRecord" ControlStyle-CssClass="btn btn-info"
                                ButtonType="Button" Text="Edit" HeaderText="Edit Record">
                                <ControlStyle CssClass="btn btn-info"></ControlStyle>
                            </asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!--@modal - update modal-->
    <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Update Client Record
                </h4>
                </div>
                <asp:UpdatePanel ID="upEdit" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <h5>id
                  </h5>
                            <div class="form-group">

                                <asp:Label ID="lblProductid" runat="server" Text="Label"></asp:Label>
                            </div>
                            <h5>ProductCode
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtProductcode" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>



                            <h5>Product Name
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            <h5>Product tag1
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtProducttag1" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <h5>Product tag2
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtProducttag2" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <h5>Cost Price
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtCp" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <h5>Sale Price
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtSp" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <h5>Product Manufacturer
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtProductManufacturer" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <h5>Product Description
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtProductDescription" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <h5>Product VendorId
                  </h5>
                            <div class="form-group">

                                <asp:DropDownList ID="ddlVendorId" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                            <h5>Product FiscalYearId
                  </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtProductFiscalYearId" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>



                        </div>


                        <div class="modal-footer">
                            <asp:Button ID="btnSave" runat="server" Text="Update Record" CssClass="btn btn-info" OnClick="btnSave_Click" />
                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>
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
    <!-- /.modal -->
</asp:Content>
