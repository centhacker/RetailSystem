<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="SetDefaultFiscalYear.aspx.cs" Inherits="RetailSystem.Pages.SetDefaultFiscalYear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="alert-danger">
            <b>Set Current Fiscal Year to be Used
            </b>
        </div>
        <h5>Fiscal Year 
                  </h5>
        <div class="form-group">

            <asp:DropDownList ID="ddlFiscalYear" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>



        <asp:Button ID="btnSave" runat="server" ValidationGroup="frmBank" CssClass="btn btn-primary" Text="Save Record" OnClick="btnSave_Click" />

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

                    <div class="alert-danger">

                        <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                    </div>

                    <div class="modal-footer">
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
