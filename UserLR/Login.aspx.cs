using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class UserLR_Login : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  DataTable dt = new DataTable();
  protected void Page_Load(object sender, EventArgs e)
    {
  }
  protected void Login_btn_Click(object sender, EventArgs e)
  {
    if (Log_Id.SelectedValue == "1")
    {
      string FirstTimeLOG = "";
      connection.Open();
      String Validate = "Select * from Register_Farmers where Email = @Email and Password = @Password";
      SqlCommand cmds = new SqlCommand(Validate, connection);
      cmds.Parameters.AddWithValue("@Email", Log_email.Text);
      cmds.Parameters.AddWithValue("@Password", Log_password.Text);
      cmds.CommandTimeout = 120;
      SqlDataReader Reader = cmds.ExecuteReader();
      if (Reader.HasRows)
      {
        while (Reader.Read())
        {
          string ID = Reader["ID"].ToString();
          string Name = Reader["Name"].ToString();
          string Email = Reader["Email"].ToString();
          string Mobile = Reader["mobile"].ToString();
          string Gender = Reader["gender"].ToString();
          string Address = Reader["address"].ToString();
          string Pin = Reader["pin"].ToString();
          string City = Reader["city"].ToString();
          string State = Reader["state"].ToString();
          FirstTimeLOG = Reader["FirstTimeLOG"].ToString();
          Session["Name"] = Name;
          Session["email"] = Email;
          Session["ID"] = ID;
          Session["Mobile"] = Mobile;
          Session["Gender"] = Gender;
          Session["Address"] = Address;
          Session["Pin"] = Pin;
          Session["City"] = City;
          Session["State"] = State;
        }
        Reader.Close(); // Close the SqlDataReader
        connection.Close(); // Close the SqlConnection
        if(FirstTimeLOG == "YES")
        {
          Response.Redirect("..//UserDetails/UpdateFarmerDetails.aspx");
        }
        else
        {
          Response.Redirect("..//FarmerMP/DashBoard.aspx");
        }
      }
      else
      {
        string script = "<script>alert('User Not Registered or Incorrect Details');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
        Reader.Close(); // Close the SqlDataReader
        connection.Close(); // Close the SqlConnection
      }
    }
    else if (Log_Id.SelectedValue == "2")
    {
      string FirstTimeLOG = "";
      connection.Open();
      String Validate = "Select * from Register_Agent where Email = @Email and Password = @Password";
      SqlCommand cmds = new SqlCommand(Validate, connection);
      cmds.Parameters.AddWithValue("@Email", Log_email.Text);
      cmds.Parameters.AddWithValue("@Password", Log_password.Text);

      SqlDataReader Reader = cmds.ExecuteReader();
      if (Reader.HasRows)
      {
        while (Reader.Read())
        {
          string ID = Reader["ID"].ToString();
          string Name = Reader["Name"].ToString();
          string Email = Reader["Email"].ToString();
          string Mobile = Reader["mobile"].ToString();
          string Gender = Reader["gender"].ToString();
          string Address = Reader["address"].ToString();
          string Pin = Reader["pin"].ToString();
          string City = Reader["city"].ToString();
          string State = Reader["state"].ToString();
          FirstTimeLOG = Reader["FirstTimeLOG"].ToString();
          Session["Name"] = Name;
          Session["email"] = Email;
          Session["ID"] = ID;
          Session["Mobile"] = Mobile;
          Session["Gender"] = Gender;
          Session["Address"] = Address;
          Session["Pin"] = Pin;
          Session["City"] = City;
          Session["State"] = State;
        }
        Reader.Close(); // Close the SqlDataReader
        connection.Close(); // Close the SqlConnection
        if (FirstTimeLOG == "YES")
        {
          Response.Redirect("..//UserDetails/UpdateAgentDetails.aspx");
        }
        else
        {
          Response.Redirect("..//PoolingMP/DashBoard.aspx");
        }
      }
      else
      {
        string script = "<script>alert('User Not Registered or Incorrect Details');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
        Reader.Close(); // Close the SqlDataReader
        connection.Close(); // Close the SqlConnection
      }
    }
  }
}
