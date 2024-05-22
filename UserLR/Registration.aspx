<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="UserLR_Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <title>Register</title>
  
  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css" />
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css" />

  <style>
    .validation-error {
        display: none;
        font-size: 12px;
    }

    .validation-error:before {
        content: "* ";
    }
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
<body class="hold-transition register-page custom-bg">
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
      <!--<h5 style="text-align:center">Loan Easy</h5>-->
      <h6>Powered By <span style="font-size:20px; color:teal;">Finquant Technologies</span></h6>
    </div>
<div class="register-box">
  <div class="card card-outline card-primary custom-css" style="margin-top:40px;">
    <div class="card-header text-center">
      <a href="../../index2.html" class="h1"><b>Register</b></a>
    </div>
    <div class="card-body">
      <!--<p class="login-box-msg">Register a new membership</p>-->

      <form runat="server" action="#" method="post">
         <div class="input-group mt-3">
            <asp:DropDownList ID="Reg_Id" runat="server" class="form-control">
              <asp:ListItem Text="Select Your ID" Value="" Disabled="true" Selected="True"></asp:ListItem>
              <asp:ListItem Value="1">Milk Farmer</asp:ListItem>
              <asp:ListItem Value="2">Pooling Agent</asp:ListItem>
            </asp:DropDownList>
            <div class="input-group-append">
              <div class="input-group-text">
                <span class="fas fa-id-card"></span>
              </div>
            </div>
        </div>

        <asp:RequiredFieldValidator ID="Options" runat="server"
              ControlToValidate="Reg_Id"
              InitialValue=""
              ErrorMessage="Please select your ID"
              ForeColor="Red"
              CssClass="validation-error mt-2"
              Display="Dynamic">
        </asp:RequiredFieldValidator>

        <div class="input-group mt-3">
          <asp:TextBox runat="server" ID="Reg_Name" class="form-control" placeholder="Full Name"/>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
        </div>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
              ControlToValidate="Reg_Name"
              InitialValue=""
              ErrorMessage="Enter Your Name"
              ForeColor="Red"
              CssClass="validation-error mt-2"
              Display="Dynamic">
        </asp:RequiredFieldValidator>

        <div class="input-group mt-3">
          <asp:TextBox runat="server" ID="Reg_email" class="form-control" placeholder="Email/Mobile no."/>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
        </div>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
              ControlToValidate="Reg_email"
              InitialValue=""
              ErrorMessage="Enter Your Email/Mobile no."
              ForeColor="Red"
              CssClass="validation-error mt-2"
              Display="Dynamic">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revEmailPhone" runat="server" ControlToValidate="Reg_email"
    ValidationExpression="^(?:(\+\d{1,3})[- ]?)?\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$|^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
    ErrorMessage="Invalid Email or Phone format"
          CssClass ="validation-error mt-2"
    Display="Dynamic" ForeColor="Red" />

        <div class="input-group mt-3">
          <asp:TextBox runat="server" ID="Reg_password" TextMode="password" class="form-control" placeholder="Password"/>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
              ControlToValidate="Reg_password"
              InitialValue=""
              ErrorMessage="Enter Your password"
              ForeColor="Red"
              CssClass="validation-error mt-2"
              Display="Dynamic">
        </asp:RequiredFieldValidator>

        <div class="input-group mt-3">
          <asp:TextBox runat="server" ID="Reg_repassword" TextMode="password" class="form-control" placeholder="Retype password"/>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>

        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="Reg_password" ControlToValidate="Reg_repassword" 
            ErrorMessage="Password does not match." ForeColor="red"></asp:CompareValidator>
        <div class="row" style="justify-content:center;">
          <!-- /.col -->
          <div class="col-4">
            <asp:button runat="server" OnClick="Reg_btn_Click" Text="Register" class="btn btn-primary btn-block" ID="Reg_btn"></asp:button>
          </div>
          <!-- /.col -->
        </div>
      </form>
      <p class="mb-0 mt-2" style="text-align: center;">
        <asp:Label runat="server">Already Register?</asp:Label>
        <a href="./Login.aspx" class="text-center">Login here</a>
      </p>
    </div>
    <!-- /.form-box -->
  </div><!-- /.card -->
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
<!-- /.register-box -->
<!-- jQuery -->
<script src="../../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>
</body>
</html>
