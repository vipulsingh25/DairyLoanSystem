<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP/MasterPage.master" AutoEventWireup="true" CodeFile="LoanStatus.aspx.cs" Inherits="AdminMP_LoanStatus" %>

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
                  <h3 class="card-title">Applied Loan Details</h3>
                </div>
                <div class="card-body">
                  <div class="row">
                    <div class="col-md-2">
                      <asp:Label runat="server">Name(Acc. to Aadhar)</asp:Label>
                      <asp:TextBox ID="tb_Name" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                    <div class="col-md-2">
                      <asp:Label runat="server">Email</asp:Label>
                      <asp:TextBox ID="tb_Email" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                    <div class="col-md-2">
                      <asp:Label runat="server">Phone Number</asp:Label>
                      <asp:TextBox ID="tb_Phone" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                                                            <div class="col-md-2">
                      <asp:Label runat="server">Aadharcard Number</asp:Label>
                      <asp:TextBox ID="tb_Aadharnumber" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                                        <div class="col-md-2">
                      <asp:Label runat="server">Pancard Number</asp:Label>
                      <asp:TextBox ID="tb_Pancardnumber" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                  </div>
                  </div>
                <div class="card-body">
                  <div class="row">
                                        <div class="col-md-3">
                      <asp:Label runat="server">Bank Name</asp:Label>
                      <asp:TextBox ID="tb_Bankname" runat="server" class="form-control"  ReadOnly="true" Style="cursor: not-allowed;"  />
                    </div>
                    <div class="col-md-3">
                      <asp:Label runat="server">Branch Name</asp:Label>
                      <asp:TextBox ID="tb_Branchname" runat="server" class="form-control"  ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                                        <div class="col-md-4">
                      <asp:Label runat="server">Account Number</asp:Label>
                      <asp:TextBox ID="tb_Accountnumber" runat="server" class="form-control"  ReadOnly="true" Style="cursor: not-allowed;"  />
                    </div>
                  </div>
                </div>
                <div class="card-body">
                  <div class="row">
                    <div class="col-md-2">
                      <asp:Label runat="server">IFSC Code</asp:Label>
                      <asp:TextBox ID="tb_IFSC" runat="server" class="form-control"  ReadOnly="true" Style="cursor: not-allowed;"  />
                    </div>

                    <div class="col-md-3">
                      <asp:Label runat="server">Loan Amount</asp:Label>
                      <asp:TextBox ID="tb_Loanamount" runat="server" class="form-control"  ReadOnly="true" Style="cursor: not-allowed;"  />
                    </div>

                    <div class="col-md-3">
                      <asp:Label runat="server">Purpose of Loan</asp:Label>
                      <asp:TextBox ID="tb_Purpose" runat="server" class="form-control"  ReadOnly="true" Style="cursor: not-allowed;"  />
                    </div>
                  </div>
                </div>
                <div class="card-body" style="display: flex; justify-content: center;">
                  <div class="row">
                    <div class="card-footer bg-white">
                      <asp:Button ID="Approved" runat="server" Text="Recommend" OnClick="Approved_Click"  class="btn btn-success" />
                                            <asp:Button ID="UnApproved" runat="server" Text="Reject" Onclick="UnApproved_Click"  class="btn btn-danger" />

                    </div>
                  </div>
                </div>
                </div>
              </div>
            </div>
          </div>
      </section>
    </div>
    </div>

</asp:Content>

