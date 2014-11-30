<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="RetailSystem.Pages.AddDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">Departments</span></span>
            <small>Add New Department or click<a href="#headofdepartmentModalId" data-toggle="modal"> Add New Head Of Department</a> to Add new Head Of Department</small>
        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>Name
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtName" ControlToValidate="txtName" runat="server" ErrorMessage="Please Enter Name of the Department" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false"></asp:RequiredFieldValidator>
                </div>
                <h5>Address
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtAddress" ControlToValidate="txtAddress" runat="server" ErrorMessage="Please Enter Address of the Department" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false"></asp:RequiredFieldValidator>
                </div>

                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" ValidationGroup="frmBank" />
                <asp:Button ID="btnViewDepartment" runat="server" CssClass="btn btn-primary" Text="View / Edit Departments" />
                <asp:Button ID="btnShowHod" runat="server" CssClass="btn btn-primary" Text="Add Head Of Department" />


            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!--@modal - Client Type modal-->
    <div class="modal fade" id="headofdepartmentModalId" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Add New Head Of Department
                </h4>
                </div>
                <div class="modal-body">


                    <asp:UpdatePanel ID="updateClientType" runat="server">
                        <ContentTemplate>
                            <h5>Employee
                  </h5>
                            <div class="form-group">

                                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control"></asp:DropDownList>

                            </div>
                            <h5>Department
                  </h5>
                            <div class="form-group">

                                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control"></asp:DropDownList>

                            </div>
                            <br />
                            <asp:Button ID="btnSubmitHod" CssClass="btn btn-primary" runat="server" Text="Submit New Client Type" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
            <div class="modal-footer">
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->



</asp:Content>
