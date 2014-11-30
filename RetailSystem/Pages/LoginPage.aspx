<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="RetailSystem.Pages.LoginPage" %>

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

                            <!--header rightside-->
                            
                        </div>

                    </div>
                </div>



            </div>
        </div>
        <div id="content">
            <div class="container">
                <div class="form-group">
                    <h3 class="title-divider">
              <span>Login</span> 
              <small>Not signed up? <a href="#">Sign up here</a>.</small>
            </h3>
                    <h5>
                        User Name
                    </h5>
                                    <label class="sr-only" for="login-email">User Id</label>
                                    <asp:TextBox ID="txtLoginUserId" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                 <h5>
                        Password
                    </h5>
                                <div class="form-group">
                                    <label class="sr-only" for="login-password">Password</label>
                                    <asp:TextBox ID="txtLoginPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="btnLogin_Click"/>
                                <asp:Label ID="lblShow" runat="server" Text="" ForeColor="Red"></asp:Label>
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

    </form>
    <!--Scripts -->
    <script src="../Scripts/jquery.min.js"></script>
    <!--Legacy jQuery support for quicksand plugin-->
    <script src="../Scripts/jquery-migrate-1.2.1.min.js"></script>

    <!--Bootstrap third-party plugins-->
    <script src="../Scripts/bootstrap-hover-dropdown.min.js"></script>
    <script src="../Scripts/bootstrap-switch.min.js"></script>

    <!--JS plugins-->
    <script src="../Scripts/prism.js"></script>
    <script src="../Scripts/jquery.backstretch.min.js"></script>
    <script src="../Scripts/jquery.themepunch.plugins.min.js"></script>
    <script src="../Scripts/jquery.themepunch.revolution.min.js"></script>
    <script src="../Scripts/jquery.flexslider-min.js"></script>
    <script src="../Scripts/jquery.clingify.min.js"></script>
    <script src="../Scripts/jquery.jpanelmenu.min.js"></script>
    <script src="../Scripts/jRespond.js"></script>
    <script src="../Scripts/jquery.quicksand.js"></script>
    <script src="../Scripts/jquery.fitvids.js"></script>

    <!--Custom scripts mainly used to trigger libraries -->
    <script src="../Scripts/script.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>

    <!-- Bootstrap JS -->
    <script src="../Scripts/bootstrap.min.js"></script>

    <script>
        $(function () {
            $(".datepicker").datepicker({


            });

        });

        function DatePickerInit() {
            $(".datepicker").datepicker({


            });
        }
    </script>
</body>
</html>
