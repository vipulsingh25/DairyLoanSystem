<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP/MasterPage.master" AutoEventWireup="true" CodeFile="AllFarmerDetails.aspx.cs" Inherits="AdminMP_AllUserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="wrapper">

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2 justify-content-between">
         <div class="col-md-0.5">
            <h2>Profile</h2>
          </div>
          <div class="col-md-0.5 text-right">
            <asp:Button class="btn btn-danger" runat="server" ID="btn_UpdateDetails" Text="Update Details" onclick="btn_UpdateDetails_Click"/>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-3">

            <!-- Profile Image -->
            <div class="card card-primary card-outline">
              <div class="card-body box-profile">
                <div class="text-center">
                  <img class="profile-user-img img-fluid img-circle"
                       src="../../dist/img/profileimg.png"
                       alt="User profile picture">
                </div>
                <h3 class="profile-username text-center"><asp:Literal ID="Farmer_Name" runat="server"></asp:Literal></h3>
                <p class="text-muted text-center">Dairy Farmer</p>
                <p class="text-muted text-center"><asp:Literal ID="Farmer_Sex" runat="server"></asp:Literal></p>
              </div>
            </div>
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">About Farmer</h3>
              </div>
              <!-- /.card-header -->
              <div class="card-body">
                <strong><i class="fas fa-book mr-1"></i>Email/Phone</strong>
                <p class="text-muted">
                  <asp:Literal ID="Farmer_Email" runat="server"></asp:Literal>
                </p>
                <hr>
                 <strong><i class="fas fa-book mr-1"></i>Address</strong>
                <p class="text-muted">
                  <asp:Literal ID="Farmer_Address" runat="server"></asp:Literal>
                </p>
              </div>
              <!-- /.card-body -->
            </div>
            <div class="card card-primary">
              <div class="card-header">
                                  <h3 class="card-title">Assigned Agent</h3>
                </div>
                <div class="card-body"  style="overflow-x:scroll">
                                    <table id="AgentD" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show_agentD"></asp:Literal>
                  </table>
                </div>
              
            </div>
            <!-- /.card -->
          </div>
          <!-- /.col -->
          <div class="col-md-9">
            <div class="card card-primary" style="height:500px;">
              <div class="card-header p-2">
                  <h3 class="card-title">Milk Details</h3>
              </div><!-- /.card-header -->
                              <div class="card-body"  style="overflow-x:scroll">
                  <table class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show"></asp:Literal>
                  </table>
                </div>
            </div>

                        <div class="card card-primary" style="height:fit-content;">
              <div class="card-header p-2">
                  <h3 class="card-title">Uploaded Data</h3>
              </div><!-- /.card-header -->
                               <div class="card-body" style="display:flex; flex-wrap:wrap; justify-content:space-evenly;align-items:center;" >
                  <div class="row">
                    <div class="col-md-12 mt-2 mb-2">
                      <asp:Label runat="server">UPLOADED AADHAR</asp:Label>
                      <asp:Image ID="Aadhar_image" runat="server" AlternateText="Aadhar" Style="width: 250px; height: 100px; margin-top: 5px;" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12 mt-2 mb-2">
                      <asp:Label runat="server">UPLOADED PANCARD</asp:Label>
                      <asp:Image ID="Pancard_image" runat="server" AlternateText="Pancard" Style="width: 250px; height: 100px; margin-top: 5px;" />
                    </div>
                  </div>
                </div>
            </div>
            <!-- /.card -->
          </div>


          <!-- /.col -->
        </div>
        <div class="row">
                    <div class="col-md-12">
            <div class="card card-primary">
              <div class="card-header p-2">
                  <h3 class="card-title">Loan Details</h3>
              </div><!-- /.card-header -->
                                  <div class="buttons mt-2 ml-2">
                                    <asp:button runat="server" Text="Export to Excel" Onclick="Export_btn"/>
                                  </div>
                              <div id="show_loan" class="card-body" style="overflow-x:scroll">
                  <table id="loan_table" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show_loantable"></asp:Literal>
                  </table>
                </div>
            </div>
            <!-- /.card -->
          </div>

        </div>
        <!-- /.row -->
      </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->

  <!-- Control Sidebar -->
  <aside class="control-sidebar control-sidebar-dark">
    <!-- Control sidebar content goes here -->
  </aside>
  <!-- /.control-sidebar -->
</div>
</asp:Content>

