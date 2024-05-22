<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP/MasterPage.master" AutoEventWireup="true" CodeFile="CreatePoints.aspx.cs" Inherits="AdminMP_CreatePoints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                  <h3 class="card-title">Create Points</h3>
                </div>
                <div class="card-body">
                  <div class="row">
                    <div class="col-md-4">
                      <asp:Label runat="server">State</asp:Label>
                      <asp:DropDownList ID='dd_State' runat='server' class='form-control select2' AutoPostBack="true" OnTextChanged="dd_State_TextChanged">
                        <asp:ListItem Text="Select from list" Value="" Disabled="true" Selected="True"></asp:ListItem>
                      </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
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
                      <asp:DropDownList ID="dd_City" runat="server" class="form-control select2">
                                                <asp:ListItem Text="Select from list" Value="" Disabled="true" Selected="True"></asp:ListItem>
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="dd_City"
                        InitialValue=""
                        ErrorMessage="Select City"
                        ForeColor="Red"
                        CssClass="validation-error"
                        Display="Dynamic">
                      </asp:RequiredFieldValidator>
                    </div>
                                 <div class="col-md-4">
                      <asp:Label runat="server">Point Name</asp:Label>
                      <asp:TextBox ID="txt_PointName" runat="server" class="form-control" placeholder="Enter new point name"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txt_PointName" 
                        InitialValue=""
                        ErrorMessage="Enter Point Name"
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
                      <asp:Button ID="CreatePoint" runat="server" Text="Create" OnClick="CreatePoint_Click"
                        class="btn btn-primary" />
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
