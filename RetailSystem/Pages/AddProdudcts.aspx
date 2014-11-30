<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AddProdudcts.aspx.cs" Inherits="RetailSystem.Pages.AddProdudcts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">Products</span></span>
        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>Product Code
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtProductCode" runat="server" CssClass="form-control"   ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtProductCode" runat="server" ErrorMessage="Please Enter Product Code" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>

                <h5>Product Name
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"   ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtProductName" runat="server" ErrorMessage="Please Enter Product Name" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>
                <h5>Product Tag1  
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtProductTag1" runat="server" CssClass="form-control"   ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtProductTag1" runat="server" ErrorMessage="Please Enter Product Tag1" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>
                <h5>Product Tag2
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtProductTag2" runat="server" CssClass="form-control"   ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator4" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtProductTag2" runat="server" ErrorMessage="Please Enter Product Tag2" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>
                <h5>Product Manufacturer
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtProductManufacturer" runat="server" CssClass="form-control"   ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator5" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtProductManufacturer" runat="server" ErrorMessage="Please Enter Product Manufacturer" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>
                <h5>Cost Price
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtCostPrice" runat="server" TextMode="Number" CssClass="form-control"    ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator7" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtCostPrice" runat="server" ErrorMessage="Please Enter Product Cost Price" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>
                <h5>Sale Price
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtSalePrice" runat="server" TextMode="Number" CssClass="form-control"   ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator8" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtSalePrice" runat="server" ErrorMessage="Please Enter Product Sale Price" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>

                <h5>Product Description
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtProductDescription" runat="server" CssClass="form-control"   ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator6" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtProductDescription" runat="server" ErrorMessage="Please Enter Product Description" ForeColor="Red" ValidationGroup="frmBank"></asp:RequiredFieldValidator>

                <h5>Product VendorId
                  </h5>
                <div class="form-group">

                    <asp:DropDownList ID="ddlVendorId" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>


                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save Record" OnClick="btnSave_Click" ValidationGroup="frmBank" />



                <!--@modal - Client Type modal-->
                <!--@modal - update modal-->
                <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h4 class="modal-title">Message From Server
                </h4>
                            </div>
                            <div class="modal-body">
                                <div class="success">
                                    <asp:Label runat="server" ID="lblError"></asp:Label>
                                </div>
                            </div>

                        </div>

                        <!-- /.modal -->
                        <!-- /.modal-dialog -->
                    </div>
                </div>

                 
            </ContentTemplate>
        </asp:UpdatePanel>
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

                                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
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
