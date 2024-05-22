<%@ Page Title="" Language="C#" MasterPageFile="~//MasterPage.master" AutoEventWireup="true" CodeFile="AllAgentDetails.aspx.cs" Inherits="AdminMP_AllAgentDetails" %>

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
            <asp:Button class="btn btn-danger" runat="server" OnClick="btn_UpdateDetails_Click" ID="btn_UpdateDetails" Text="Update Details"/>
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
                <p class="text-muted text-center">Pooling Agent</p>
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
                                  <h3 class="card-title">Assigned Farmers</h3>
                </div>
                <div class="card-body"  style="overflow-x:scroll">
                                    <table id="farmerD" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show_farmerD"></asp:Literal>
                  </table>
                </div>
              
            </div>
            <!-- /.card -->
          </div>
          <!-- /.col -->
          <div class="col-md-9">
            <div class="card card-primary" style="height:700px;">
              <div class="card-header p-2">
                  <h3 class="card-title">Milk Details</h3>
              </div><!-- /.card-header -->
                              <div id="showdiv" class="card-body" style="overflow-x:scroll">
                  <table id="example2" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show"></asp:Literal>
                  </table>
                </div>
            </div>
            <!-- /.card -->
          </div>
          <!-- /.col -->
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

