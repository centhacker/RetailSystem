<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ShowPaidSalary.aspx.cs" Inherits="RetailSystem.Pages.ShowPaidSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">
        <!--Default Pricing Table-->
        <div id="content">
            <div class="container">
                <div class="block">
                    <!--Default Pricing Table-->
                    <h2 class="title-divider">
                        <span>View <span class="de-em">Paid Salary</span></span>
                    </h2>

                    <asp:GridView ID="grdVendor" runat="server" Width="940px" HorizontalAlign="Center"
                        AllowPaging="true"
                        DataKeyNames="id" CssClass="table table-hover table-striped">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Paid Salary Id" />
                            <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                            <asp:BoundField DataField="MonthPaid" HeaderText="Last Month Paid" />
                            <asp:BoundField DataField="Paid" HeaderText="Salary Amount" />
                            <asp:BoundField DataField="DatePaid" HeaderText="Date of Payment" />
                        </Columns>
                    </asp:GridView>



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
</asp:Content>
