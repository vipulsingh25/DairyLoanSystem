<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateFdetails.aspx.cs" Inherits="AdminMP_UpdateFdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="wrapper">
    <div class="content-wrapper">
      <section class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12 mt-4 ">
            <div class="card card-warning collapsed-card">
              <div class="card-header">
                <h3 class="card-title">Personal Details</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-plus"></i>
                  </button>
                </div>
                <!-- /.card-tools -->
              </div>
              <!-- /.card-header -->
              <div id="showdiv" class="card-body" style="display: none; min-height:fit-content;">
                  <table ID="table_personaldetails" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show1"></asp:Literal>
                  </table>
              </div>

              <div class="card-body" style="display: flex; justify-content: center;">
                <div class="row">
                  <!--<div class="card-footer bg-white">
                    <asp:Button ID="submit" runat="server" Text="Update" class="btn btn-primary" />
                  </div>-->
                </div>
              </div>
              <!-- /.card-body -->
            </div>
            <!-- /.card -->
          </div>
            <div class="col-md-12 mt-4 ">
            <div class="card card-primary collapsed-card">
              <div class="card-header">
                <h3 class="card-title">Documents</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-plus"></i>
                  </button>
                </div>
                <!-- /.card-tools -->
              </div>
              <!-- /.card-header -->
              <div id="showdiv2" class="card-body" style="display: none; overflow-x:scroll; max-height:60vh; min-height:fit-content;">
                                                    
                  <table ID="table_documents" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show2"></asp:Literal>
                  </table>
                
              </div>
              <!-- /.card-body -->
            </div>
            <!-- /.card -->
          </div>
            <div class="col-md-12 mt-4 ">
            <div class="card card-success collapsed-card">
              <div class="card-header">
                <h3 class="card-title">Aadhar & Pancard</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-plus"></i>
                  </button>
                </div>
                <!-- /.card-tools -->
              </div>
              <!-- /.card-header -->
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
              <!-- /.card-body -->
            </div>
            <!-- /.card -->
          </div>
       
          </div>

        </div>
      </section>
    </div>
  </div>
</asp:Content>
