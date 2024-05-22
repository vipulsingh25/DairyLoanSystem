<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP/MasterPage.master" AutoEventWireup="true" CodeFile="List_LoanApplication.aspx.cs" Inherits="AdminMP_List_LoanApplication" %>

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
                <h3 class="card-title">Pending Applications</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-plus"></i>
                  </button>
                </div>
                <!-- /.card-tools -->
              </div>
              <!-- /.card-header -->
              <div id="showdiv" class="card-body" style="display: none; overflow-x:scroll; max-height:60vh; min-height:fit-content;">
                                                                  <div class="buttons mt-2 ml-2">
                                    <asp:button runat="server" Text="Export to Excel" Onclick="Export_btn"/>
                                  </div>
                  <table ID="loan_table1" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show1"></asp:Literal>
                  </table>
                
              </div>
              <!-- /.card-body -->
            </div>
            <!-- /.card -->
          </div>
            <div class="col-md-12 mt-4 ">
            <div class="card card-primary collapsed-card">
              <div class="card-header">
                <h3 class="card-title">Recommended Applications</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-plus"></i>
                  </button>
                </div>
                <!-- /.card-tools -->
              </div>
              <!-- /.card-header -->
              <div id="showdiv2" class="card-body" style="display: none; overflow-x:scroll; max-height:60vh; min-height:fit-content;">
                                                                  <div class="buttons mt-2 ml-2">
                                    <asp:button runat="server" Text="Export to Excel" Onclick="Export_btn"/>
                                  </div>
                  <table ID="loan_table2" class="table table-bordered table-hover">
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
                <h3 class="card-title">Approved Applications</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-plus"></i>
                  </button>
                </div>
                <!-- /.card-tools -->
              </div>
              <!-- /.card-header -->
              <div id="showdiv3" class="card-body" style="display: none; overflow-x:scroll; max-height:60vh; min-height:fit-content;">
                                                                  <div class="buttons mt-2 ml-2">
                                    <asp:button runat="server" Text="Export to Excel" Onclick="Export_btn"/>
                                  </div>
                  <table ID="loan_table3" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show3"></asp:Literal>
                  </table>
                
              </div>
              <!-- /.card-body -->
            </div>
            <!-- /.card -->
          </div>
            <div class="col-md-12 mt-4 ">
            <div class="card card-danger collapsed-card">
              <div class="card-header">
                <h3 class="card-title">Rejected Applications</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-plus"></i>
                  </button>
                </div>
                <!-- /.card-tools -->
              </div>
              <!-- /.card-header -->
              <div id="showdiv4" class="card-body" style="display: none; overflow-x:scroll; max-height:60vh; min-height:fit-content;">
                                                                  <div class="buttons mt-2 ml-2">
                                    <asp:button runat="server" Text="Export to Excel" Onclick="Export_btn"/>
                                  </div>
                  <table ID="loan_table4" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show4"></asp:Literal>
                  </table>
                
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

