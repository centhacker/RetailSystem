<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewEditWarehouse.aspx.cs" Inherits="RetailSystem.Pages.ViewEditWarehouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdWareHouse" runat="server" Width="940px" HorizontalAlign="Center"
                        OnRowCommand="grdWareHouse_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="id" CssClass="table table-hover table-striped">
                        <Columns>



                            <asp:BoundField DataField="id" HeaderText="WareHouse id" />
                            <asp:BoundField DataField="Name" HeaderText="WareHouse name" />
                            <asp:BoundField DataField="Address" HeaderText="WareHouse Address" />
                            <asp:BoundField DataField="Phone" HeaderText="WareHouse phone" />
                            <asp:BoundField DataField="Description" HeaderText="WareHouse Description" />


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
                            <h5>WareHouse id
                            </h5>
                            <div class="form-group">

                                <asp:Label ID="lblWareHouse" runat="server" Text="Label"></asp:Label>
                            </div>
                            <h5>WareHouse name
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtWareHousename" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtWareHousename" runat="server" ErrorMessage="Please Enter WareHouse Name" ForeColor="Red"></asp:RequiredFieldValidator>

                            <h5>WareHouse Address
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtWareHouseAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtWareHouseAddress" runat="server" ErrorMessage="Please Enter WareHouse Address" ForeColor="Red"></asp:RequiredFieldValidator>
                            <h5>WareHouse phone
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtWareHousephone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtWareHousephone" runat="server" ErrorMessage="Please Enter WareHouse phone" ForeColor="Red"></asp:RequiredFieldValidator>

                            <h5>WareHouse Description
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtWarehouseDescription" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator4" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtWareHouseDescription" runat="server" ErrorMessage="Please Enter WareHouse Description" ForeColor="Red"></asp:RequiredFieldValidator>




                            <div class="modal-footer">
                                <asp:Button ID="btnSave" runat="server" Text="Update Record" CssClass="btn btn-info" OnClick="btnSave_Click" />
                            </div>
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
