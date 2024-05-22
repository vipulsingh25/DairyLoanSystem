<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateAgentDetails.aspx.cs" Inherits="UserDetails_UpdateAgentDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title></title>
  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
  <!-- Font Awesome -->
  <link rel="stylesheet" href="..//plugins/fontawesome-free/css/all.min.css" />
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
  <!-- Tempusdominus Bootstrap 4 -->
  <link rel="stylesheet" href="..//plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" />
  <!-- iCheck -->
  <link rel="stylesheet" href="..//plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
  <!-- JQVMap -->
  <link rel="stylesheet" href="..//plugins/jqvmap/jqvmap.min.css" />
  <!-- Theme style -->
  <link rel="stylesheet" href="..//dist/css/adminlte.min.css" />
  <!-- overlayScrollbars -->
  <link rel="stylesheet" href="..//plugins/overlayScrollbars/css/OverlayScrollbars.min.css" />
  <!-- Daterange picker -->
  <link rel="stylesheet" href="..//plugins/daterangepicker/daterangepicker.css" />
  <!-- summernote -->
  <link rel="stylesheet" href="..//plugins/summernote/summernote-bs4.min.css" />
            <style>

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
               <div id="loader" class="loader">
    <div>
          <img src="../../dist/img/loader.gif" />
      <br />
      <p>Loading...</p>
    </div>
</div>
  <form id="form1" runat="server">
    <section class="content">
      <div class="container-fluid">
        <div class="row" style="display: flex; justify-content: center;">
          <div class="col-md-10 mt-4">
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Update Personal Details</h3>
              </div>
              <div class="card-body">
                <div class="row">
                  <div class="col-md-3">
                    <asp:Label runat="server">Name</asp:Label>
                    <asp:TextBox ID="tb_Name" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                  </div>
                  <div class="col-md-3">
                    <asp:Label runat="server">Email/Mobile</asp:Label>
                    <asp:TextBox ID="tb_Email" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                  </div>
                  <div class="col-md-3">
                    <asp:Label ID="lb_mobile" runat="server">Mobile No.</asp:Label>
                    <asp:TextBox ID="tb_Mobile" runat="server" class="form-control" MaxLength="10" onkeypress="return isNumeric(event);" placeholder="Enter Mobile No."/>
                    <asp:RequiredFieldValidator ID="validator_mobile" runat="server"
                      ControlToValidate="tb_Mobile"
                      InitialValue=""
                      ErrorMessage="Enter Mobile No."
                      ForeColor="Red"
                      CssClass="validation-error"
                      Display="Dynamic">
                    </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="Exp_mobile" runat="server"
    ControlToValidate="tb_Mobile"
    ValidationExpression="^\d{10}$"
    ErrorMessage="Enter a valid 10-digit Mobile No."
    ForeColor="Red"
    CssClass="validation-error"
    Display="Dynamic">
</asp:RegularExpressionValidator>
                  </div>
                  <div class="col-md-3">
                    <asp:Label runat="server">Gender</asp:Label>
                    <asp:DropDownList ID="dd_Gender" runat="server" class="form-control select2">
                      <asp:ListItem Text="Select Gender" Value="" Disabled="true" Selected="True"></asp:ListItem>
                      <asp:ListItem runat="server">Male</asp:ListItem>
                      <asp:ListItem runat="server">Female</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                      ControlToValidate="dd_Gender"
                      InitialValue=""
                      ErrorMessage="Select Your Gender"
                      ForeColor="Red"
                      CssClass="validation-error"
                      Display="Dynamic">
                    </asp:RequiredFieldValidator>
                  </div>
                </div>
              </div>
              <div class="card-body">
                <div class="row">
                                    <div class="col-md-3">
                    <asp:Label runat="server">State</asp:Label>
                    <asp:DropDownList ID="ddlState" runat="server" class="form-control select2" AutoPostBack="true" OnTextChanged="ddlState_TextChanged">
                      <asp:ListItem Text="Select State" Value="" Disabled="true" Selected="True"></asp:ListItem>
                    </asp:DropDownList>   
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                      ControlToValidate="ddlState"
                      InitialValue=""
                      ErrorMessage="Enter State"
                      ForeColor="Red"
                      CssClass="validation-error"
                      Display="Dynamic">
                    </asp:RequiredFieldValidator>
                  </div>

                                    <div class="col-md-3">
                    <asp:Label runat="server">City</asp:Label>
                    <asp:DropDownList ID="ddlCity" runat="server" class="form-control select2">
                      <asp:ListItem Text="Select City" Value="" Disabled="true" Selected="True"></asp:ListItem>
                    </asp:DropDownList>                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                      ControlToValidate="ddlCity"
                      InitialValue=""
                      ErrorMessage="Enter City"
                      ForeColor="Red"
                      CssClass="validation-error"
                      Display="Dynamic">
                    </asp:RequiredFieldValidator>
                  </div>

                                    <div class="col-md-2">
                    <asp:Label runat="server">Pin</asp:Label>
                    <asp:TextBox ID="tb_Pin" runat="server" class="form-control" MaxLength="6" placeholder="Enter Pincode" onkeypress="return isNumeric(event);" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                      ControlToValidate="tb_Pin"
                      InitialValue=""
                      ErrorMessage="Enter Pincode"
                      ForeColor="Red"
                      CssClass="validation-error"
                      Display="Dynamic">
                    </asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
    ControlToValidate="tb_Pin"
    ValidationExpression="^\d{6}$"
    ErrorMessage="Enter a valid 6-digit Pincode No."
    ForeColor="Red"
    CssClass="validation-error"
    Display="Dynamic">
</asp:RegularExpressionValidator>
                  </div>

                  <div class="col-md-4">
                    <asp:Label runat="server">Address</asp:Label>
                    <asp:TextBox ID="tb_Address" runat="server" class="form-control" placeholder="Enter your Address"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                      ControlToValidate="tb_Address"
                      InitialValue=""
                      ErrorMessage="Enter Your Address"
                      ForeColor="Red"
                      CssClass="validation-error"
                      Display="Dynamic">
                    </asp:RequiredFieldValidator>
                  </div>
                </div>
              </div>
              <div class="card-body" style="display: flex; justify-content: center;">
                <div class="row">
                  <!--<div class="card-footer bg-white">
                    <asp:Button ID="submit" runat="server" Text="Update" class="btn btn-primary" />
                  </div>-->
                </div>
              </div>
            </div>
          </div>
        </div>
                      <div class="row mb-4">
          <div class="col-md-12" style="display: flex; justify-content: center;">
            <asp:Button Text="Update Details & Next" OnClick="btn_update_Click" runat="server" ID="btn_update" class="btn btn-success" />
          </div>
        </div>
      </div>
    </section>
  </form>

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

  <script type="text/javascript">
    function isNumeric(evt) {
      var charCode = (evt.which) ? evt.which : event.keyCode;
      if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
      }
      return true;
    }
      </script>

  <script src="../../plugins/jquery/jquery.min.js"></script>
  <!-- jQuery UI 1.11.4 -->
  <script src="../../plugins/jquery-ui/jquery-ui.min.js"></script>
  <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
  <script>
    $.widget.bridge('uibutton', $.ui.button)
</script>
  <!-- Bootstrap 4 -->
  <script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
  <!-- ChartJS -->
  <script src="../../plugins/chart.js/Chart.min.js"></script>
  <!-- Sparkline -->
  <script src="../../plugins/sparklines/sparkline.js"></script>
  <!-- JQVMap -->
  <script src="../../plugins/jqvmap/jquery.vmap.min.js"></script>
  <script src="../../plugins/jqvmap/maps/jquery.vmap.usa.js"></script>
  <!-- jQuery Knob Chart -->
  <script src="../../plugins/jquery-knob/jquery.knob.min.js"></script>
  <!-- daterangepicker -->
  <script src="../../plugins/moment/moment.min.js"></script>
  <script src="../../plugins/daterangepicker/daterangepicker.js"></script>
  <!-- Tempusdominus Bootstrap 4 -->
  <script src="../../plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
  <!-- Summernote -->
  <script src="../../plugins/summernote/summernote-bs4.min.js"></script>
  <!-- overlayScrollbars -->
  <script src="../../plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
  <!-- AdminLTE App -->
  <script src="../../dist/js/adminlte.js"></script>
  <!-- AdminLTE for demo purposes -->
  <script src="../../dist/js/demo.js"></script>
  <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
  <script src="../../dist/js/pages/dashboard.js"></script>
</body>
</html>

