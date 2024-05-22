using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class AdminMP_FDetails : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  DataTable dt = new DataTable();
  protected void Page_Load(object sender, EventArgs e)
    {
    String get = "Select * from Register_Farmers;";
    SqlCommand d = new SqlCommand(get, connection);
    SqlDataAdapter ad = new SqlDataAdapter(d);
    ad.Fill(dt);

    StringBuilder sb = new StringBuilder();
    sb.Append("<thead><tr><th>Sno</th><th>Date of Joining</th><th>Name</th><th>Profile Details</th></tr></thead> ");
    sb.Append("<tbody>");

    int i = 1;
    foreach (DataRow rows in dt.Rows)
    {
      sb.Append("<tr>");
      sb.Append("<td>" + i++ + "</td>");
      sb.Append("<td>" + rows["Date_of_Joining"] + "</td>");
      sb.Append("<td>" + rows["Name"] + "</td>");
      sb.Append("<td>" + "<a class='btn btn-primary' href=\"AllFarmerDetails.aspx?a=" + rows["ID"] + "\">View Details</a>" + "</td>");
      sb.Append("</tr>");
    }

    sb.Append("</tbody>");

    show.Text = sb.ToString();

  }
}
