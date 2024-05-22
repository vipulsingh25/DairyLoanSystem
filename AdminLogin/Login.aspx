<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminLogin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>Login</title>
  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css" />
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css" />

    <style>
        .custom-bg{
          /*background-image: url('../../dist/img/logo.jpg');
          background-repeat: no-repeat;
          background-position:center;*/

          background-color:white;

        }

        .custom-css{
          background-color:ghostwhite;
        }

        .custom-div{
            width:100%;
            height:250px;
            background-color:teal;
            position:absolute;
            top:0;
            border-radius:0px 0px 30px 30px;
            text-align:center;
        }

        .custom-div img{
            height:120px;
            width:120px;
            margin-top:10px;
        }

        .custom-div2{
            position:absolute;
            bottom:0;
        }

        .validation-error {
        display: none;
        font-size: 12px;
    }

    .validation-error:before {
        content: "* ";
    }

    .loader {
          display: none;
          position: fixed;
          top: 0;
          left: 0;
          width: 100%;
          height: 100%;
          background: white;
          text-align: center;
          font-size: 18px;
          z-index: 9999;
        }

        .loader div{
          position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
        }
    </style>

</head>
<body>
  <div class="hold-transition login-page bg-transparent custom-bg">
                     <div id="loader" class="loader">
    <div>
          <img src="../../dist/img/loader.gif" />
      <br />
      <p>Loading...</p>
    </div>
</div>
     <div class="custom-div">
      <img src="../../dist/img/companylogo.png"/>
    </div>
    <div class="custom-div2">
      <h6>Powered By <span style="font-size:20px; color:teal;">Finquant Technologies</span></h6>
    </div>
  <div class="login-box">
    <!-- /.login-logo -->
    <div class="card card-outline card-primary custom-css">
      <div class="card-header text-center">
        <a href="../../index2.html" class="h1"><b>Admin Portal</b></a>
      </div>
      <div class="card-body">
        <!--<p class="login-box-msg">Sign in</p>-->

        <form runat="server" action="#" method="post">


          <div class="input-group mt-3">
            <asp:TextBox runat="server" ID="txt_username" class="form-control" placeholder="UserName" />
            <div class="input-group-append">
              <div class="input-group-text">
                <span class="fas fa-envelope"></span>
              </div>
            </div>
          </div>

                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
              ControlToValidate="txt_username"
              InitialValue=""
              ErrorMessage="Enter Your Username"
              ForeColor="Red"
              CssClass="validation-error"
              Display="Dynamic">
        </asp:RequiredFieldValidator>

          <div class="input-group mt-3">
            <asp:TextBox TextMode="Password" ID="txt_password" runat="server" class="form-control" placeholder="Password" />
            <div class="input-group-append">
              <div class="input-group-text">
                <span class="fas fa-lock"></span>
              </div>
            </div>
          </div>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
              ControlToValidate="txt_password"
              InitialValue=""
              ErrorMessage="Enter Your Password"
              ForeColor="Red"
              CssClass="validation-error"
              Display="Dynamic">
        </asp:RequiredFieldValidator>

          <div class="row mt-3" style="justify-content: center;">
            <div class="col-4">
              <asp:button ID="Login_btn" runat="server" Text="Sign In" class="btn btn-primary btn-block" OnClick="Login_btn_Click"></asp:button>
            </div>
          </div>
        </form>
      </div>
    </div>
  </div>
</div>

    <script>
      // Function to show the loader
      function showLoader() {
        document.getElementById("loader").style.display = "block";
      }

      // Function to hide the loader
      function hideLoader() {
        document.getElementById("loader").style.display = "none";
      }

      // Event handler for page load
      window.addEventListener("load", function () {
        hideLoader(); // Hide the loader when the page has finished loading.
      });

      // Event handler for beforeunload (page is about to reload)
      window.addEventListener("beforeunload", function () {
        showLoader(); // Show the loader when the page is about to reload.

        // Set a timeout to hide the loader after 3 seconds (3000 milliseconds)
        setTimeout(function () {
          window.location.reload();
          hideLoader();// Reload the page after a delay (adjust this as needed)
        }, 3000);
        window.addEventListener("load", function () {
          hideLoader();// Reload the page after a delay (adjust this as needed)
        });
      });
  </script>
  <!-- jQuery -->
  <script src="../../plugins/jquery/jquery.min.js"></script>
  <!-- Bootstrap 4 -->
  <script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
  <!-- AdminLTE App -->
  <script src="../../dist/js/adminlte.min.js"></script>
</body>
</html>
