<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewEditEmployees.aspx.cs" Inherits="RetailSystem.Pages.ViewEditEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdEmployees" runat="server" Width="940px" HorizontalAlign="Center"
                        OnRowCommand="grdEmployees_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="id" CssClass="table table-hover table-striped">
                        <Columns>



                            <asp:BoundField DataField="id" HeaderText="Employee Id" />
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                            <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" />
                            <asp:BoundField DataField="CellNo" HeaderText="CellNo" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="EmergencyContactNo" HeaderText="EmergencyContactNo" />


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
                    <h4 class="modal-title">Update Employee Record
                    </h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="upEdit" runat="server">
                        <ContentTemplate>

                            <h5>First Name
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtName" ControlToValidate="txtFirstName" runat="server" ErrorMessage="Please Enter Name of the Department" Display="Dynamic" SetFocusOnError="false"></asp:RequiredFieldValidator>
                            </div>
                            <h5>Last Name
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLastName" runat="server" ErrorMessage="Please Enter Name of the Department" Display="Dynamic" SetFocusOnError="false"></asp:RequiredFieldValidator>
                            </div>
                            <h5>Cell Number
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtCellNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCellNumber" runat="server" ErrorMessage="Please Enter Name of the Department" Display="Dynamic" SetFocusOnError="false"></asp:RequiredFieldValidator>
                            </div>
                            <h5>Date Of Birth
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtbob" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <h5>Gender
                            </h5>
                            <div class="form-group">

                                <asp:DropDownList ID="ddlGender" runat="server"></asp:DropDownList>
                            </div>



                            <h5>Address
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <h5>City
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <h5>Home Phone
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtHomePhone" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <h5>Email
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <h5>Emergency Contact Number
                            </h5>
                            <div class="form-group">

                                <asp:TextBox ID="txtEmergencyContact" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>




                        </ContentTemplate>

                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSave" runat="server" Text="Update Record" CssClass="btn btn-info" OnClick="btnSave_Click" />
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
    <!-- /.modal -->
</asp:Content>
