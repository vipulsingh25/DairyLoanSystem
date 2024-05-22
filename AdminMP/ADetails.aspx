<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP/MasterPage.master" AutoEventWireup="true" CodeFile="ADetails.aspx.cs" Inherits="AdminMP_ADetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="wrapper">
    <div class="content-wrapper">
      <section class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12 mt-4">
              <div class="card card-primary">
                <div class="card-header">
                  <h3 class="card-title">Agent Details</h3>
                </div>
                <div id="showdiv" class="card-body" style="overflow-x:scroll">
                  <table id="Atable" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show"></asp:Literal>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  </div>
</asp:Content>

