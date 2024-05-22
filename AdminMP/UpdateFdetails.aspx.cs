using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMP_UpdateFdetails : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  DataTable dt = new DataTable();
  protected void Page_Load(object sender, EventArgs e)
    {
    getPersonalData();
    getDocumentsData();
    getDocumentsImage();
    /*SqlDataAdapter ad = new SqlDataAdapter(cmds);
    ad.Fill(dt);
    if (dt.Rows.Count > 0)
    {
      StringBuilder sb1 = new StringBuilder();
      sb1.Append("<thead><tr><th>Name</th><th>Email</th><th>Phone Number</th><th>Password</th><th>Address</th><th>State</th><th>City</th><th>PIN</th></tr></thead> ");
      sb1.Append("<tbody>");

      foreach (DataRow rows in dt.Rows)
      {
          sb1.Append("<tr>");
          sb1.Append("<td>" + rows["Name"] + "</td>");
          sb1.Append("<td>" + rows["Email"] + "</td>");
          sb1.Append("<td>" + rows["mobile"] + "</td>");
          sb1.Append("<td>" + rows["Password"] + "</td>");
          sb1.Append("<td>" + rows["Address"] + "</td>");
          sb1.Append("<td>" + rows["State"] + "</td>");
          sb1.Append("<td>" + rows["City"] + "</td>");
          sb1.Append("<td>" + rows["PIN"] + "</td>");
          sb1.Append("</tr>");
     }
      sb1.Append("</tbody>");
      show1.Text = sb1.ToString();
    }*/

  }

  protected void getPersonalData()
  {
    connection.Open();
    string FID = Request.QueryString["a"].ToString();
    string getdata = "Select * from Register_Farmers where ID = " + FID;
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataReader Reader = cmds.ExecuteReader();
    if (Reader.HasRows)
    {
      StringBuilder sb1 = new StringBuilder();

      if (Reader.Read())
      {
        sb1.Append("<thead><tr><th>Name</th>");
        sb1.Append("<td>" + Reader["Name"] + "</td></tr>");
        sb1.Append("<tr><th>Email</th>");
        sb1.Append("<td>" + Reader["Email"] + "</td></tr>");
        sb1.Append("<tr><th>Phone Number</th>");
        sb1.Append("<td>" + Reader["mobile"] + "</td></tr>");
        sb1.Append("<tr><th>Password</th>");
        sb1.Append("<td>" + Reader["Password"] + "</td></tr>");
        sb1.Append("<tr><th>Address</th>");
        sb1.Append("<td>" + Reader["Address"] + "</td></tr>");
        sb1.Append("<tr><th>State</th>");
        sb1.Append("<td>" + Reader["State"] + "</td></tr>");
        sb1.Append("<tr><th>City</th>");
        sb1.Append("<td>" + Reader["City"] + "</td></tr>");
        sb1.Append("<tr><th>PIN</th>");
        sb1.Append("<td>" + Reader["PIN"] + "</td></tr></thead>");

      }
      show1.Text = sb1.ToString();
  

    }

    Reader.Close();
    connection.Close();
  }


  protected void getDocumentsData()
  {
    connection.Open();
    string FID = Request.QueryString["a"].ToString();
    string getdata = "Select * from Farmer_Documents where ID = " + FID;
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataReader Reader = cmds.ExecuteReader();
    if (Reader.HasRows)
    {
      StringBuilder sb1 = new StringBuilder();

      if (Reader.Read())
      {
        sb1.Append("<thead><tr><th>Name (Acc. to Aadhar card)</th>");
        sb1.Append("<td>" + Reader["name"] + "</td></tr>");
        sb1.Append("<tr><th>Aadhar Card Number</th>");
        sb1.Append("<td>" + Reader["Aadhar_Number"] + "</td></tr>");
        sb1.Append("<tr><th>Pancard Number</th>");
        sb1.Append("<td>" + Reader["Pancard_Number"] + "</td></tr></thead>");
      }
      show2.Text = sb1.ToString();

    }

    Reader.Close();
    connection.Close();
  }

  protected void getDocumentsImage()
  {
    connection.Open();
    string FID = Request.QueryString["a"].ToString();
    string getdata = "select * from Farmer_Documents where ID =" + FID + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt = new DataTable();
    ad.Fill(dt);
    foreach (DataRow rows in dt.Rows)
    {
      Aadhar_image.ImageUrl = rows["Aadhar_Image"].ToString();
      Pancard_image.ImageUrl = rows["Pancard_Image"].ToString();
    }
    connection.Close();
  }
}
