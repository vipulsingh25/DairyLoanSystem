<%@ Page Title="" Language="C#" MasterPageFile="~/PoolingMP/MasterPage.master" AutoEventWireup="true" CodeFile="PaymentStatus.aspx.cs" Inherits="PoolingMP_PaymentStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="wrapper">
    <div class="content-wrapper">
      <section class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-8 mt-4">
              <div class="card" style="min-height:75vh;">
                <div class="card-header">
                  <h3 class="card-title">Make Payment</h3>
                </div>
                <div id="showdiv" class="card-body">
                  <div class="row">
                                                                                              <div class="col-md-4">
                <asp:Label runat="server">Farmer</asp:Label>
            <asp:DropDownList ID="Farmer_name" runat="server" class="form-control">
               <asp:ListItem Text="Select from list" Value="" Disabled="true" Selected="True"></asp:ListItem>
            </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
              ControlToValidate="Farmer_name"
              InitialValue=""
              ErrorMessage="Choose Farmer"
              ForeColor="Red"
              CssClass="validation-error"
              Display="Dynamic">
        </asp:RequiredFieldValidator>
                    </div>
                  </div>
                  <div class="row">
                                                          <div class="col-md-4">
                      <asp:Label runat="server">Date (From: DD/MM/YYYY)</asp:Label>
                      <asp:TextBox ID="txt_fromdate" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                  
                                                          <div class="col-md-4">
                      <asp:Label runat="server">Date (To: DD/MM/YYYY)</asp:Label>
                      <asp:TextBox ID="txt_todate" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                  </div>
                    <div class="col-md-4" style="display:flex; align-items:end; justify-content:center;">
                <asp:Button runat="server" ID="btn_ViewDetails" Text="View Details" class="btn btn-primary" OnClick="btn_ViewDetails_Click"/>
                    </div>
                    </div>
                  <div class="row">
                                                                              <div class="col-md-4">
                      <asp:Label runat="server">Total Payment</asp:Label>
                      <asp:TextBox ID="txt_totalpayment" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;"/>
                    </div>
                                                                                                 <div class="col-md-4">
                      <asp:Label runat="server">Due Payment</asp:Label>
                      <asp:TextBox ID="txt_due" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;"/>
                      <asp:Label runat="server" style="color:orange;">(Payment you have to pay)</asp:Label>

                    </div>
                  </div>
                                    <div class="row">
 <div class="col-md-4">
                      <asp:Label runat="server">Farmer Name</asp:Label>
                      <asp:TextBox ID="txt_aadharname" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server">Farmer IFSC CODE</asp:Label>
                      <asp:TextBox ID="txt_IFSC" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server">Farmer Account Number</asp:Label>
                      <asp:TextBox ID="txt_accountnumber" runat="server" class="form-control" ReadOnly="true" Style="cursor: not-allowed;" />
                    </div>
                  </div>
                  <div class="row">
                                  <div class="card-body">
                <div class="form-group">
                  <asp:Label ID="Photo_payment" runat="server">Upload Screenshot of Payment</asp:Label>
                  <div class="input-group">
                    <div class="custom-file">
                      <asp:FileUpload ID="paymentUpload" runat="server" accept=".jpg, .png, .pdf" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                    ControlToValidate="paymentUpload"
                    InitialValue=""
                    ErrorMessage="Required Field"
                    ForeColor="Red"
                    CssClass="validation-error1"
                    Display="Dynamic">
                  </asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                        ControlToValidate="paymentUpload"
                        ValidationExpression="^.+\.(jpg|png|pdf)$"
                        ErrorMessage="Only JPG, PNG, and PDF files are allowed."
                        Display="Dynamic" />
                    </div>
                    <div class="input-group-append">
                      <span style="color: orange;">*Only in ".jpg, .png, .pdf" format</span>
                    </div>
                  </div>
                </div>
                <asp:Label runat="server" ID="Verify_msg" Style="color: #4CAF50;"></asp:Label>
              </div>

                  </div>

                  <div class="row">
                              <div class="col-md-12" style="display: flex; justify-content: center;">
            <asp:Button Text="Make Payment"  runat="server" ID="btn_payment" onclick="MakePayment" class="btn btn-success" />
          </div>
                  </div>
                  <!--<table id="table_payment" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show_payment"></asp:Literal>
                  </table>-->
                </div>
              </div>
            </div>
            <div class="col-4 mt-4">
              <div class="card" style="min-height:75vh;">
                <div class="card-header">
                  <h3 class="card-title">Uploaded Proof</h3>
                </div>
                <div class="card-body">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Literal runat="server" ID="Uploadedproof"></asp:Literal>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-12">
              <div class="card">
                <div class="card-header">
                  <h3 class="card-title">Payment History</h3>
                </div>
                <div class="card-body">
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  </div>
</asp:Content>

