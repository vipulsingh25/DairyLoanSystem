<%@ Page Title="" Language="C#" MasterPageFile="~/FarmerMP/MasterPage.master" AutoEventWireup="true" CodeFile="MilkDetails.aspx.cs" Inherits="FarmerMP_MilkDetails"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style>

        .validation-error {
          display: none;
          font-size: 12px;
        }

    .validation-error:before {
        content: "* ";
    }

    .section-msg{
      position:absolute;

    }

        .loader {
          display: none;
          position: fixed;
          top: 0;
          left: 0;
          width: 100%;
          height: 100%;
          background: rgba(255, 255, 255, 0.8);
          text-align: center;
          font-size: 18px;
          z-index: 9999;
        }

        .loader div{
          position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="wrapper">
    <div class="content-wrapper">
      <section class="content">
        <div class="row">
          <div class="col-md-3 mt-4">
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Add Daily Milk Details</h3>
              </div>
              <div class="card-body">
                <div class="row">
                                                                          <div class="col-12">
                <asp:Label runat="server">Agent Name</asp:Label>
            <asp:DropDownList ID="agent_name" runat="server" class="form-control">
               <asp:ListItem Text="Select from list" Value="" Disabled="true" Selected="True"></asp:ListItem>
            </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
              ControlToValidate="agent_name"
              InitialValue=""
              ErrorMessage="Choose Farmer"
              ForeColor="Red"
              CssClass="validation-error"
              Display="Dynamic">
        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                  <div class="col-12">
                  <asp:Label runat="server">Milk Type</asp:Label>
                  <asp:DropDownList ID="milk_type" runat="server" class="form-control">
                    <asp:ListItem Text="Choose Type" Value="" Disabled="true" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="COW">COW</asp:ListItem>
                    <asp:ListItem Value="BUFFALO">BUFFALO</asp:ListItem>
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="milk_type"
                    InitialValue=""
                    ErrorMessage="Required Field"
                    ForeColor="Red"
                    CssClass="validation-error"
                    Display="Dynamic">
                  </asp:RequiredFieldValidator>
                </div>
                </div>
                <div class="row">
                  <div class="col-12">
                                      <asp:Label runat="server">Milk Quantity (in litres)</asp:Label>
                  <asp:TextBox ID="milk_quantity" runat="server"  class="form-control" OnTextChanged="milk_quantity_TextChanged" AutoPostBack="true"/>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="milk_quantity"
                    InitialValue=""
                    ErrorMessage="Required Field"
                    ForeColor="Red"
                    CssClass="validation-error"
                    Display="Dynamic">
                  </asp:RequiredFieldValidator>
                  </div>
                </div>
                <div class="row">
                  <div class="col-12">
                     <asp:Label runat="server">Total Cost</asp:Label>
                    <asp:Textbox runat="server" ID="txt_totalcost" class="form-control" ReadOnly="true" Style="cursor: not-allowed;"></asp:Textbox>
                  </div>
                </div>
                  <div class="row">
                    <div class="card-footer bg-white">
                      <asp:Button ID="btn_addmilk" runat="server" Text="Add Details" OnClick="btn_addmilk_Click" class="btn btn-success"/>
                    </div>
                  </div>
                </div>
              <!-- /.card-body -->
            </div>
          </div>
          <div class="col-md-9 mt-4">
              <div class="card">
                <div class="card-header">
                  <h3 class="card-title">User Details</h3>
                </div>
                <div id="showdiv" class="card-body" style="overflow-x:scroll; ">
                  <table id="example2" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show"></asp:Literal>
                  </table>
                </div>
              </div>
            </div>
        </div>
      </section>
      <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
  </div>

</asp:Content>

