﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RetailSystem.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />


    <title>Retail System</title>
    <meta charset="utf-8" /> 
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- @todo: fill with your company info or remove -->
    <meta name="description" content="" />
    <meta name="author" content="Themelize.me" />

   <!-- Bootstrap CSS -->
    <link href="Scripts/bootstrap.min.css" rel="stylesheet" />

    <!-- Bootstrap third-party plugins css -->
    <link href="Scripts/bootstrap.switch.min.css" media="screen" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="Scripts/font-awsome.css" rel="stylesheet" />



    <!-- Theme style -->
    <link href="Scripts/Theme/theme-style.css" rel="stylesheet" />



    <!-- Your custom override -->
    <link href="Scripts/Theme/custome-style.css" rel="stylesheet" />
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

                                        <li class="dropdown ">
                                            
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
            </div>
        </div>
        <!-- FOOTER -->

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
        <!--Hidden elements - excluded from jPanel Menu on mobile-->
        <div class="hidden-elements jpanel-menu-exclude">
            <!--@modal - signup modal-->
            <div class="modal fade" id="signup-modal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h4 class="modal-title">Sign Up
                </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel ID="updateClientForm" runat="server">
                                <ContentTemplate>
                                    <h5>User ID
                  </h5>
                                    <div class="form-group">

                                        <asp:TextBox ID="txtuserID" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtuserID" runat="server" ErrorMessage="Please Enter UserId" ForeColor="Red"></asp:RequiredFieldValidator>

                                    <h5>Password
                  </h5>
                                    <div class="form-group">

                                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                     <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="false" ControlToValidate="txtPassword" runat="server" ErrorMessage="Please Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>

                                    <asp:Label ID="lbluser" runat="server" ForeColor="Red"></asp:Label>

                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Create New User" OnClick="btnSave_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-footer">
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->

            <!--@modal - login modal-->
            <div class="modal fade" id="login-modal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h4 class="modal-title">Login
                </h4>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <label class="sr-only" for="login-email">User Id</label>
                                        <asp:TextBox ID="txtLoginUserId" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="login-password">Password</label>
                                        <asp:TextBox ID="txtLoginPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="btnLogin_Click" />
                                    <asp:Label ID="lblShow" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-footer">
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->

            <!--@modal - Success modal-->
            <div class="modal fade" id="modalSuccess" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>

                        </div>
                        <div class="modal-body">


                            <div class="alert alert-success">Successully Processed!</div>


                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->
            </div>

            <!--@modal - Danger modal-->
            <div class="modal fade" id="modalDanger" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>

                        </div>
                        <div class="modal-body">




                            <div class="alert alert-danger">The request was not processed!</div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->
            </div>
        </div>
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
