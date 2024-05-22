<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateAdetails.aspx.cs" Inherits="AdminMP_UpdateAdetails" %>

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

       
          </div>

        </div>
      </section>
    </div>
  </div>
</asp:Content>

