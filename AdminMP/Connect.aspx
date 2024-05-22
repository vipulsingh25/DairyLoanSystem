<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP/MasterPage.master" AutoEventWireup="true" CodeFile="Connect.aspx.cs" Inherits="AdminMP_Connect" %>

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
            <div class="col-md-8 mt-4">
              <div class="card card-primary">
                <div class="card-header">
                  <h3 class="card-title">Connect Farmer & Agent</h3>
                </div>
                <div class="card-body">
                  <div class="row">
                    <div class="col-md-6">
                      <asp:Label runat="server">Farmer</asp:Label>
                      <asp:DropDownList ID='dd_Farmer' runat='server' class='form-control select2'>
                        <asp:ListItem Text="Select from list" Value="" Disabled="true" Selected="True"></asp:ListItem>
                      </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="dd_Farmer"
                        InitialValue=""
                        ErrorMessage="Choose Farmer"
                        ForeColor="Red"
                        CssClass="validation-error"
                        Display="Dynamic">
                      </asp:RequiredFieldValidator>
               
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server">Agent</asp:Label>
                      <asp:DropDownList ID="dd_Agent" runat="server" class="form-control select2">
                                                <asp:ListItem Text="Select from list" Value="" Disabled="true" Selected="True"></asp:ListItem>
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="dd_Agent"
                        InitialValue=""
                        ErrorMessage="Choose Agent"
                        ForeColor="Red"
                        CssClass="validation-error"
                        Display="Dynamic">
                      </asp:RequiredFieldValidator>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-4">
                      <asp:Label runat="server">State</asp:Label>
                      <asp:DropDownList ID='dd_State' runat='server' class='form-control select2' AutoPostBack="true" OnTextChanged="dd_State_TextChanged">
                        <asp:ListItem Text="Select from list" Value="" Disabled="true" Selected="True"></asp:ListItem>
                      </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="dd_State"
                        InitialValue=""
                        ErrorMessage="Select State"
                        ForeColor="Red"
                        CssClass="validation-error"
                        Display="Dynamic">
                      </asp:RequiredFieldValidator>
               
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server">City</asp:Label>
                      <asp:DropDownList ID='dd_City' runat='server' class='form-control select2' AutoPostBack="true" OnTextChanged="dd_City_TextChanged">
                        <asp:ListItem Text="Select from list" Value="" Disabled="true" Selected="True"></asp:ListItem>
                      </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="dd_City"
                        InitialValue=""
                        ErrorMessage="Select City"
                        ForeColor="Red"
                        CssClass="validation-error"
                        Display="Dynamic">
                      </asp:RequiredFieldValidator>
               
                    </div>

                    <div class="col-md-4">
                      <asp:Label runat="server">Point</asp:Label>
                      <asp:DropDownList ID='dd_Point' runat='server' class='form-control select2'>
                        <asp:ListItem Text="Select from list" Value="" Disabled="true" Selected="True"></asp:ListItem>
                      </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="dd_Point"
                        InitialValue=""
                        ErrorMessage="Select Point"
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
                      <asp:Button ID="connect" runat="server" Text="Connect" OnClick="Connect_Click" class="btn btn-primary" />
                    </div>
                  </div>
                </div>
                </div>
              </div>
                      <div class="col-md-9">
            <div class="card card-primary">
              <div class="card-header">
                  <h3 class="card-title">Connected Farmers & Agent List</h3>
              </div><!-- /.card-header -->
                              <div id="showdiv" class="card-body" style="overflow-x:scroll">
                  <table id="example2" class="table table-bordered table-hover">
                    <asp:Literal runat="server" ID="show"></asp:Literal>
                  </table>
                </div>
            </div>
            <!-- /.card -->
          </div>
          </div>
        </div>
      </section>
    </div>
  </div>
</asp:Content>

