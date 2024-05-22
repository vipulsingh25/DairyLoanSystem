using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLR_Registration : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);


  protected void Page_Load(object sender, EventArgs e)
    {
  }

  protected bool UserExists(string email)
  {
    if (connection.State != ConnectionState.Open)
    {
      connection.Open();
    }

    if (connection.State == ConnectionState.Open)
    {
      string checkQuery = "SELECT Email FROM Register_Farmers WHERE Email = @Email";
      SqlCommand cmd = new SqlCommand(checkQuery, connection);
      cmd.Parameters.AddWithValue("@Email", email);

      SqlDataReader reader = cmd.ExecuteReader();
      if (reader.HasRows)
      {
        reader.Close();
        connection.Close();
        return true;
      }

      reader.Close();
      connection.Close();
    }
    return false;
  }

  protected bool AgentExists(string email)
  {
    if (connection.State != ConnectionState.Open)
    {
      connection.Open();
    }

    if (connection.State == ConnectionState.Open)
    {
      string checkQuery = "SELECT Email FROM Register_Agent WHERE Email = @Email";
      SqlCommand cmd = new SqlCommand(checkQuery, connection);
      cmd.Parameters.AddWithValue("@Email", email);

      SqlDataReader reader = cmd.ExecuteReader();
      if (reader.HasRows)
      {
        reader.Close();
        connection.Close();
        return true;
      }

      reader.Close();
      connection.Close();
    }
    return false;
  }


  protected void Reg_btn_Click(object sender, EventArgs e)
    {
      String Name = Reg_Name.Text;
      String Email = Reg_email.Text;
      String Password = Reg_password.Text;

      if (Reg_Id.SelectedValue == "1")
      {
      if (!UserExists(Email))
      {
        SqlCommand cmds = new SqlCommand("insert into Register_Farmers(Name,Email,password,FirstTimeLOG) values (N'" + Name.Replace
("'", "") + "',N'" + Email.Replace("'", "") + "',N'" + Password.Replace("'", "") + "','YES') ;select SCOPE_IDENTITY();", connection);
        connection.Open();
        int iss = cmds.ExecuteNonQuery();
        if (iss > 0)
        {
          Session["SuccessMessage"] = "Registration successful!";
          Response.Redirect("./Login.aspx");
        }
        connection.Close();
      }
      else
      {
        string script = "<script>alert('User Exists, Please Choose different email/mobile!!');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
      }
      }
      else if (Reg_Id.SelectedValue == "2")
      {
      if (!AgentExists(Email)) {
        SqlCommand cmds = new SqlCommand("insert into Register_Agent(Name,Email,password,FirstTimeLOG) values (N'" + Name.Replace
("'", "") + "',N'" + Email.Replace("'", "") + "',N'" + Password.Replace("'", "") + "','YES') ;select SCOPE_IDENTITY();", connection);
        connection.Open();
        int iss = cmds.ExecuteNonQuery();
        if (iss > 0)
        {
          Session["SuccessMessage"] = "Registration successful!";
          Response.Redirect("./Login.aspx");
        }
        connection.Close();
      }
      else
      {
        string script = "<script>alert('User Exists, Please Choose different email/mobile!!');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
      }
    }
      
    }
}
