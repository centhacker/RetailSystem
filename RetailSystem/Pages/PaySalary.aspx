<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="PaySalary.aspx.cs" Inherits="RetailSystem.Pages.PaySalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">

        <h2 class="title-divider">
            <span>Pay Salary <span class="de-em">To Employees</span></span>

        </h2>

        <asp:UpdatePanel ID="updateClientForm" runat="server">
            <ContentTemplate>
                 <h5>Pay Salary With Bank/Cash Account
                  </h5>
                    <div class="form-group">
                        <asp:DropDownList runat="server" ID="ddlOption" AutoPostBack="true" OnSelectedIndexChanged="ddlOption_SelectedIndexChanged" CssClass="form-control">
                            <asp:ListItem Value="-1" Text="Please Select">

                            </asp:ListItem>
                             <asp:ListItem Value="1" Text="Bank Account">

                            </asp:ListItem>
                             <asp:ListItem Value="2" Text="Cash Account">

                            </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                <div id="divBankAccount" runat="server">
                    <h5>Bank Account 
                  </h5>
                    <div class="form-group">
                        <asp:DropDownList runat="server" ID="ddlAccount" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div id="divCashAccount" runat="server">


                    <h5>Cash Account 
                  </h5>
                    <div class="form-group">
                        <asp:DropDownList runat="server" ID="ddlCashAccount" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>

                <h5>Employee Name
                  </h5>
                <div class="form-group">
                    <asp:DropDownList runat="server" ID="ddlEmployee" CssClass="form-control"></asp:DropDownList>
                </div>


                <h5>Month Paid for Current Year
                  </h5>
                <div class="form-group">


                    <asp:TextBox ID="txtMonth" runat="server" TextMode="Month" CssClass="form-control" ValidationGroup="frmBank"></asp:TextBox>

                </div>

                <h5>Paid Amount
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtPaidAmount" runat="server" TextMode="Number" CssClass="form-control" ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <h5>Date Of Payment
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtDateOfPayment" runat="server" CssClass="form-control datepicker" ValidationGroup="frmBank"></asp:TextBox>
                </div>


                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save Record" OnClick="btnSave_Click" />

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
</asp:Content>
