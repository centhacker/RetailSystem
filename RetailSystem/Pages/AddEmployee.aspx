<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="RetailSystem.Pages.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span>Add <span class="de-em">Employees</span></span>
            <small>Add New Employee or click<a href="#ClientTypesModal" data-toggle="modal"> Add New Employee Types</a> to Add new Employee Types</small>
        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                <h5>Employee First Name
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtEmployeeFirstName" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtEmployeeFirstName" runat="server" ErrorMessage="Please Enter Employee First Name" ForeColor="Red"></asp:RequiredFieldValidator>

                <h5>Employee Last Name
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtEmployeeLastName" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtEmployeeLastName" runat="server" ErrorMessage="Please Enter Employee Last Name" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>Employee Date Of Birth
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtEmployeeDateOfBirth" runat="server" CssClass="form-control datepicker" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtEmployeeDateOfBirth" runat="server" ErrorMessage="Please Enter Employee Date Of Birth" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>Employee Gender
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtEmployeeGender" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator4" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtEmployeeGender" runat="server" ErrorMessage="Please Enter Employee Gender" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>Employee Address
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtEmployeeAddress" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator5" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtEmployeeAddress" runat="server" ErrorMessage="Please Enter Bank EmailAddress" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>Employee City
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtEmployeeCity" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator6" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtEmployeeCity" runat="server" ErrorMessage="Please Enter Employee City" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>Employee Home Phone
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtEmployeeHomePhone" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator7" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtEmployeeHomePhone" runat="server" ErrorMessage="Please Enter Employee Home Phone" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>Employee CellNo
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtEmployeeCellNo" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator8" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtEmployeeCellNo" runat="server" ErrorMessage="Please Enter Employee CellNO" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>Employee Email
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtEmployeeEmail" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator9" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtEmployeeEmail" runat="server" ErrorMessage="Please Enter Employee Email" ForeColor="Red"></asp:RequiredFieldValidator>
                <h5>Employee Emergency ContactNo
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtEmployeeEmergencyContactNo" runat="server" CssClass="form-control" CausesValidation="true"  ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator10" ValidationGroup="frmBank" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtEmployeeEmergencyContactNo" runat="server" ErrorMessage="Please Enter Employee Date Of Birth" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save Record" ValidationGroup="frmBank" OnClick="btnSaveEmployee_Click" />

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
    <!--@modal - Client Type modal-->

    <!-- /.modal-dialog -->



</asp:Content>

