using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BankLogin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

  protected void Login_btn_Click(object sender, EventArgs e)
  {
    string UserName = "Bank@123";
    string Password = "Bank@123";
    if (txt_username.Text == UserName && txt_password.Text == Password)
    {
      Session["AdminID"] = "ValidAdmin";
      Response.Redirect("../BankPortal/DashBoard.aspx");
    }
    else
    {
      string script = "<script>alert('Incorrect Details');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
    }
  }
}
