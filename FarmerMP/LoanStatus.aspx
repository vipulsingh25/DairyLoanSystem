<%@ Page Title="" Language="C#" MasterPageFile="~/FarmerMP/MasterPage.master" AutoEventWireup="true" CodeFile="LoanStatus.aspx.cs" Inherits="FarmerMP_LoanStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
    .validation-error {
      display: none;
      font-size: 12px;
    }

    .validation-error:before {
      content: "* ";
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="wrapper">
    <div class="content-wrapper">
      <section class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-10 mt-4">
              <div class="card card-primary">
                <div class="card-header">
                  <h3 class="card-title">Application for Loan</h3>
                </div>
                <div class="card-body">
                  <div class="row">
                    <div class="col-md-3">
                      <asp:Label runat="server">Name(Acc. to Aadhar)</asp:Label>
                      <asp:TextBox ID="tb_Name" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                    <div class="col-md-3">
                      <asp:Label runat="server">Email</asp:Label>
                      <asp:TextBox ID="tb_Email" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                    <div class="col-md-3">
                      <asp:Label runat="server">Phone Number</asp:Label>
                      <asp:TextBox ID="tb_Phone" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                  </div>
                  </div>
                <div class="card-body">
                  <div class="row">
                                        <div class="col-md-3">
                      <asp:Label runat="server">Aadharcard Number</asp:Label>
                      <asp:TextBox ID="tb_Aadharnumber" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                                        <div class="col-md-3">
                      <asp:Label runat="server">Pancard Number</asp:Label>
                      <asp:TextBox ID="tb_Pancardnumber" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                  </div>
                </div>
                <div class="card-body">
                  <div class="row">
                                        <div class="col-md-3">
                      <asp:Label runat="server">Bank Name</asp:Label>
<asp:DropDownList ID="tb_Bankname" runat="server" class="form-control">
               <asp:ListItem Text="Select from list" Value="" Disabled="true" Selected="True"></asp:ListItem>
            </asp:DropDownList>                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="tb_Bankname"
                        InitialValue=""
                        ErrorMessage="Required Field"
                        ForeColor="Red"
                        CssClass="validation-error"
                        Display="Dynamic">
                      </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                      <asp:Label runat="server">Branch Name</asp:Label>
                      <asp:TextBox ID="tb_Branchname" runat="server" class="form-control" placeholder="Enter Branch Name" />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="tb_Branchname"
                        InitialValue=""
                        ErrorMessage="Required Field"
                        ForeColor="Red"
                        CssClass="validation-error"
                        Display="Dynamic">
                      </asp:RequiredFieldValidator>
                    </div>
                                        <div class="col-md-4">
                      <asp:Label runat="server">Account Number</asp:Label>
                      <asp:TextBox ID="tb_Accountnumber" runat="server" class="form-control" placeholder="Enter Account Number"/>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="tb_Accountnumber"
                        InitialValue=""
                        ErrorMessage="Required Field"
                        ForeColor="Red"
                        CssClass="validation-error"
                        Display="Dynamic">
                      </asp:RequiredFieldValidator>
                                          <asp:RegularExpressionValidator ID="revAccountNumber" runat="server" ControlToValidate="tb_Accountnumber" 
    ValidationExpression="^[0-9]{9,18}$" ErrorMessage="Please enter a valid account number (9-18 digits)." 
    Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="card-body">
                  <div class="row">
                    <div class="col-md-2">
                      <asp:Label runat="server">IFSC Code</asp:Label>
                      <asp:TextBox ID="tb_IFSC" runat="server" class="form-control" placeholder="Enter IFSC Code" MaxLength=11/>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ControlToValidate="tb_IFSC"
                        InitialValue=""
                        ErrorMessage="Required Field"
                        ForeColor="Red"
                        CssClass="validation-error"
                        Display="Dynamic">
                      </asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="revIFSCCode" runat="server" ControlToValidate="tb_IFSC" 
    ValidationExpression="^[A-Za-z]{4}[0][0-9]{6}$" ErrorMessage="Please enter a valid IFSC code (e.g., ABCD0123456)." 
    Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>

                    <div class="col-md-3">
                      <asp:Label runat="server">Loan Amount</asp:Label>
                      <asp:TextBox ID="tb_Loanamount" runat="server" class="form-control" placeholder="Enter Loan Amount"/>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                        ControlToValidate="tb_Loanamount"
                        InitialValue=""
                        ErrorMessage="Required Field"
                        ForeColor="Red"
                        CssClass="validation-error"
                        Display="Dynamic">
                      </asp:RequiredFieldValidator>
                    </div>

                    <div class="col-md-3">
                      <asp:Label runat="server">Purpose of Loan</asp:Label>
                      <asp:DropDownList ID="dd_Purpose" runat="server" class="form-control select2">
                        <asp:ListItem Text="Select from list" Value="" Disabled="true" Selected="True"></asp:ListItem>
                        <asp:ListItem runat="server">purchasing Cattle</asp:ListItem>
                        <asp:ListItem runat="server">Equipments</asp:ListItem>
                        <asp:ListItem runat="server">Feed</asp:ListItem>
                        <asp:ListItem runat="server">Infrastructure</asp:ListItem>
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="dd_Purpose"
                        InitialValue=""
                        ErrorMessage="Required Field"
                        ForeColor="Red"
                        CssClass="validation-error"
                        Display="Dynamic">
                      </asp:RequiredFieldValidator>
                    </div>
                  </div>
                </div>
                <div class="card-body" style="display: flex; justify-content: center;">
                  <div class="row">
                    <div class="card-footer bg-white">
                      <asp:Button ID="submit" runat="server" Text="Request For Loan" OnClick="submit_Click" class="btn btn-primary" />
                    </div>
                  </div>
                </div>
                </div>
              </div>
            </div>
                    <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header">
                  <h3 class="card-title">Loan Details</h3>
                </div>
                <div id="showdiv" class="card-body" style="overflow-x:scroll; ">
                  <table id="example2" class="table table-bordered table-hover">
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

