<%@ Page Title="" Language="C#" MasterPageFile="~/BankPortal/MasterPage.master" AutoEventWireup="true" CodeFile="RejectedLoan.aspx.cs" Inherits="BankPortal_RejectedLoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="wrapper">
    <div class="content-wrapper">
      <section class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-12 mt-4">
              <div class="card card-primary">
                <div class="card-header">
                  <h3 class="card-title">Rejected Loan Applications</h3>
                </div>
                                                  <div class="buttons mt-2 ml-2">
                                    <asp:button runat="server" Text="Export to Excel" Onclick="Export_btn"/>
                                  </div>
                <div id="showdiv" class="card-body" style="overflow-x:scroll">
                  <table ID="loan_table" class="table table-bordered table-hover">
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

