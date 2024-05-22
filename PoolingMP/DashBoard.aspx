<%@ Page Title="" Language="C#" MasterPageFile="~/PoolingMP/MasterPage.master" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="PoolingMP_DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
              .custom-bg{
          background-image: url('../../dist/img/farmerdash.png');
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
                <h5 class="mt-4">Personal Details</h5>
              </div>
              <div class="icon">
                <i class="far fa-address-card"></i>
              </div>
              <a href="./Default.aspx" class="small-box-footer mt-4">Click here <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <div class="col-lg-3 col-6">
            <div class="small-box bg-success">
              <div class="inner">
                <h5 class="mt-4">Farmer Details</h5>
              </div>
              <div class="icon">
                <i class="fas fa-id-badge"></i>
              </div>
              <a href="./FarmerDetails.aspx" class="small-box-footer mt-4">Click here <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <div class="col-lg-3 col-6">
            <div class="small-box bg-warning">
              <div class="inner">
                <h5 class="mt-4">Add Milk Details</h5>
              </div>
              <div class="icon">
                <i class="fa fa-edit"></i>
              </div>
              <a href="./Diary.aspx" class="small-box-footer mt-4">Click here <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>

</asp:Content>

