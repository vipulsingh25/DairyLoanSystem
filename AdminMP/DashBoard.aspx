<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP/MasterPage.master" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="AdminMP_DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
              .custom-bg{
          background-image: url('../../dist/img/bank.png');
          background-position:bottom;
              background-repeat: no-repeat;
        }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="content-wrapper custom-bg">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Dashboard</h1>
          </div>
        </div>
      </div>
    </div>
    <section class="content">
      <div class="container-fluid">
        <div class="row">
          <div class="col-lg-3 col-6">
            <div class="small-box bg-info">
              <div class="inner">
                <h3><asp:Literal runat="server" ID="TotalFarmers"></asp:Literal></h3>
                <p>Farmer Details</p>
              </div>
              <div class="icon">
                <i class="far fa-address-card"></i>
              </div>
              <a href="./FDetails.aspx" class="small-box-footer">View List <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <div class="col-lg-3 col-6">
            <div class="small-box bg-success">
              <div class="inner">
                <h3><asp:Literal runat="server" ID="TotalAgent"></asp:Literal></h3>
                <p>Agent Details</p>
              </div>
              <div class="icon">
                <i class="fas fa-id-badge"></i>
              </div>
              <a href="./ADetails.aspx" class="small-box-footer">View List <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <div class="col-lg-3 col-6">
            <div class="small-box bg-warning">
              <div class="inner">
                <h3>12</h3>
                <p>Connect Agent</p>
              </div>
              <div class="icon">
                <i class="fa fa-edit"></i>
              </div>
              <a href="./Connect.aspx" class="small-box-footer">Click here <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
                    <div class="col-lg-3 col-6">
            <div class="small-box bg-primary">
              <div class="inner">
                <h3><asp:Literal runat="server" ID="TotalLoans"></asp:Literal></h3>
                <p>Loan Applications</p>
              </div>
              <div class="icon">
                <i class="fas fa-id-badge"></i>
              </div>
              <a href="./List_LoanApplication.aspx" class="small-box-footer">View List <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
                              <div class="col-lg-3 col-6">
            <div class="small-box bg-danger">
              <div class="inner">
                <h3><asp:Literal runat="server" ID="CreatePoints"></asp:Literal></h3>
                <p>Create Points</p>
              </div>
              <div class="icon">
                <i class="fa fa-edit"></i>
              </div>
              <a href="./CreatePoints.aspx" class="small-box-footer">Create Now <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>

</asp:Content>

