<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetFiscalYear.aspx.cs" Inherits="RetailSystem.Pages.SetFiscalYear" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />


    <title>Retail System</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- @todo: fill with your company info or remove -->
    <meta name="description" content="" />
    <meta name="author" content="Themelize.me" />

    <!-- Bootstrap CSS -->
    <link href="../Scripts/bootstrap.min.css" rel="stylesheet" />

    <!-- Bootstrap third-party plugins css -->
    <link href="../Scripts/bootstrap.switch.min.css" media="screen" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="../Scripts/font-awsome.css" rel="stylesheet" />



    <!-- Theme style -->
    <link href="../Scripts/Theme/theme-style.css" rel="stylesheet" />



    <!-- Your custom override -->
    <link href="../Scripts/Theme/custome-style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server" ID="ScriptManager1" />
        <!-- ======== @Region: #navigation ======== -->
        <div id="navigation" class="wrapper">
            <div class="navbar-static-top">


                <!--Header & Branding region-->
                <div class="header">
                    <div class="header-inner container">
                        <div class="row">
                            <div class="col-md-8">
                                <!--branding/logo-->
                                <a class="navbar-brand" href="#" title="Home">
                                    <h1>
                                        <span>Retail</span>System<span></span>
                                    </h1>
                                </a>
                                <div class="slogan">Electronics at its best</div>
                            </div>


                        </div>

                    </div>
                </div>


                <div class="js-clingify-placeholder" style="height: 62px;">
                    <div class="js-clingify-wrapper">
                        <div class="container" data-toggle="clingify">
                            <div class="navbar">
                                <!-- mobile collapse menu button - data-toggle="toggle" = default BS menu - data-toggle="jpanel-menu" = jPanel Menu -->
                                <a class="navbar-btn" data-toggle="jpanel-menu" data-target=".navbar-collapse"><span class="bar"></span><span class="bar"></span><span class="bar"></span><span class="bar"></span></a>

                                <!--user menu-->
                                <div class="btn-group user-menu pull-right"><a href="#signup-modal" class="btn btn-primary signup" data-toggle="modal">Sign Up</a> <a href="#login-modal" class="btn btn-primary dropdown-toggle login" data-toggle="modal">Login</a> </div>

                                <!--everything within this div is collapsed on mobile-->
                                <div class="navbar-collapse collapse">
                                    <!--main navigation-->
                                    <ul class="nav navbar-nav">
                                        <li class="home-link">
                                            <a href="#"><i class="fa fa-home"></i><span class="hidden">Home</span></a>
                                        </li>


                                    </ul>
                                </div>
                                <!--/.navbar-collapse -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="content">
            <div class="container">

                <div class="alert-danger">
                    <b>No Fiscal Year found, Kindly Add new fiscal year to continue.
                    </b>
                </div>
                <h5>Fiscal Year From
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control datepicker" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="false" ValidationGroup="frmBank" ControlToValidate="txtFrom" runat="server" ErrorMessage="Please Enter Account Number" ForeColor="Red"></asp:RequiredFieldValidator>


                <h5>Fiscal Year To
                  </h5>
                <div class="form-group">

                    <asp:TextBox ID="txtTo" runat="server" CssClass="form-control datepicker" CausesValidation="true" ValidationGroup="frmBank"></asp:TextBox>
                </div>

                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="false" ValidationGroup="frmBank" ControlToValidate="txtTo" runat="server" ErrorMessage="Please Enter Account Number" ForeColor="Red"></asp:RequiredFieldValidator>



                <asp:Button ID="btnSave" runat="server" ValidationGroup="frmBank" CssClass="btn btn-primary" Text="Save Record" OnClick="btnSave_Click" />

            </div>
        </div>
        <!-- FOOTER -->
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
        <!-- ======== @Region: #footer ======== -->
        <footer id="footer">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 col">
                        <div class="block contact-block">
                            <!--@todo: replace with company contact details-->
                            <h3>Contact Us
                            </h3>
                            <address>
                                <ul class="fa-ul">
                                    <li>
                                        <abbr title="Phone"><i class="fa fa-li fa-phone"></i></abbr>
                                        019223 8092344
                                    </li>
                                    <li>
                                        <abbr title="Email"><i class="fa fa-li fa-envelope"></i></abbr>
                                        asdasdasd@asodnad.com
                                    </li>
                                    <li>
                                        <abbr title="Address"><i class="fa fa-li fa-home"></i></abbr>
                                        karachi
                                    </li>
                                </ul>
                            </address>
                        </div>
                    </div>

                    <div class="col-md-5 col">
                        <div class="block">
                            <h3>About Us
                            </h3>
                            <p>lorum epsium</p>
                        </div>
                    </div>


                </div>

                <div class="row">

                    <!--@todo: replace with company copyright details-->
                    <div class="subfooter">
                        <div class="col-md-6">
                            <p>Website Developed by <a href="#">Single Tatta</a> </p>
                        </div>

                    </div>
                </div>
            </div>
        </footer>

    </form>

    <!--Bootstrap third-party plugins-->
    <script src="Scripts/bootstrap-hover-dropdown.min.js"></script>

    <!--Custom Scripts mainly used to trigger libraries -->
    <script src="Scripts/script.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>

    <!-- Bootstrap JS -->
    <script src="Scripts/bootstrap.min.js"></script>
    <style>
        .datepicker {
            z-index: 1151;
        }
    </style>
    <!-- Pagination -->
    <script type="text/javascript" src="Scripts/bs.pagination.js"></script>
    <script>
        //Fix for datepicker Modal window: http://jsfiddle.net/surjithctly/93eTU/16/
        // Since confModal is essentially a nested modal it's enforceFocus method
        // must be no-op'd or the following error results 
        // "Uncaught RangeError: Maximum call stack size exceeded"
        // But then when the nested modal is hidden we reset modal.enforceFocus
        var enforceModalFocusFn = $.fn.modal.Constructor.prototype.enforceFocus;

        $.fn.modal.Constructor.prototype.enforceFocus = function () { };

        $confModal.on('hidden', function () {
            $.fn.modal.Constructor.prototype.enforceFocus = enforceModalFocusFn;
        });

        $confModal.modal({ backdrop: false });

        function pageLoad() {
            $(function () {

                $(".datepicker").datepicker({


                });

            });
        }
    </script>
</body>
</html>
