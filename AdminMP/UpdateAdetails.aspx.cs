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

public partial class AdminMP_UpdateAdetails : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  DataTable dt = new DataTable();
  protected void Page_Load(object sender, EventArgs e)
  {
    getPersonalData();
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
    string AID = Request.QueryString["a"].ToString();
    string getdata = "Select * from Register_Agent where ID = " + AID;
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
        sb1.Append("<td>" + Reader["address"] + "</td></tr>");
        sb1.Append("<tr><th>State</th>");
        sb1.Append("<td>" + Reader["state"] + "</td></tr>");
        sb1.Append("<tr><th>City</th>");
        sb1.Append("<td>" + Reader["city"] + "</td></tr>");
        sb1.Append("<tr><th>PIN</th>");
        sb1.Append("<td>" + Reader["pin"] + "</td></tr></thead>");

      }
      show1.Text = sb1.ToString();


    }

    Reader.Close();
    connection.Close();
  }
}
