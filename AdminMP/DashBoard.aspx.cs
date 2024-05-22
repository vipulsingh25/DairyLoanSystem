using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMP_DashBoard : System.Web.UI.Page
{

  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);

  protected void Page_Load(object sender, EventArgs e)
    {
    if (Session["AdminID"] == null)
    {
      string script = "<script>alert('Session Expired Please Login Again');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
      Response.Redirect("..//AdminLogin/Login.aspx");
    }
    NumberofFarmer();
    NumberofAgent();
    NumberofLoan();
  }

  protected void NumberofFarmer()
  {
    connection.Open();
    string getcount = "select count(Email) from Register_Farmers";
    SqlCommand cmd = new SqlCommand(getcount, connection);
    SqlDataReader Reader = cmd.ExecuteReader();
    if (Reader.HasRows)
    {
      if(Reader.Read())
      {
        TotalFarmers.Text = Reader[0].ToString();
      }
    }
    Reader.Close();
    connection.Close();
  }

  protected void NumberofAgent()
  {
    connection.Open();
    string getcount = "select count(Email) from Register_Agent";
    SqlCommand cmd = new SqlCommand(getcount, connection);
    SqlDataReader Reader = cmd.ExecuteReader();
    if (Reader.HasRows)
    {
      if (Reader.Read())
      {
        TotalAgent.Text = Reader[0].ToString();
      }
    }
    Reader.Close();
    connection.Close();
  }

  protected void NumberofLoan()
  {
    connection.Open();
    string getcount = "select count(*) from Loan_Application";
    SqlCommand cmd = new SqlCommand(getcount, connection);
    SqlDataReader Reader = cmd.ExecuteReader();
    if (Reader.HasRows)
    {
      if (Reader.Read())
      {
        TotalLoans.Text = Reader[0].ToString();
      }
    }
    Reader.Close();
    connection.Close();
  }
}
