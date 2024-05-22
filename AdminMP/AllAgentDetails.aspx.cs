using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMP_AllAgentDetails : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);

  protected void get_APD(string ID)
  {
    string data = "select * from Register_Agent Where ID = " + ID + ";";
    SqlCommand cmds = new SqlCommand(data, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt = new DataTable();
    ad.Fill(dt);
    foreach (DataRow rows in dt.Rows)
    {
      Farmer_Name.Text = rows[1].ToString();
      Farmer_Sex.Text = rows[6].ToString();
      Farmer_Email.Text = rows[2].ToString();
      Farmer_Address.Text = rows[7].ToString();
    }
  }

  protected void get_MD(string ID)
  {
    string getdata = "Select * from Verifymilk_Details where ID = " + ID + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt1 = new DataTable();
    ad.Fill(dt1);
    if (dt1.Rows.Count > 0)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("<thead><tr><th>Sno</th><th>Date & Time</th><th>Milk Type</th><th>Milk Quantity (Kg)</th><th>Rate Per Kg</th><th>Total Cost</th><th>Farmer</th></tr></thead> ");
      sb.Append("<tbody>");
      int i = 1;
      foreach (DataRow rows in dt1.Rows)
      {
        sb.Append("<tr>");
        sb.Append("<td>" + i++ + "</td>");
        sb.Append("<td>" + rows[1] + "</td>");
        sb.Append("<td>" + rows[2] + "</td>");
        sb.Append("<td>" + rows[3] + "</td>");
        sb.Append("<td>" + rows[4] + "</td>");
        sb.Append("<td>" + rows[5] + "</td>");
        sb.Append("<td>" + rows[6] + "</td>");
        sb.Append("</tr>");
      }

      sb.Append("</tbody>");

      show.Text = sb.ToString();

    }
  }

  protected void get_farmerD(string ID)
  {
    string getdata = "Select ID,Name from Register_Farmers where Agent_ID = " + ID + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt1 = new DataTable();
    ad.Fill(dt1);
    if (dt1.Rows.Count > 0)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("<thead><tr><th>Farner</th><th>Details</th></tr></thead> ");
      sb.Append("<tbody>");
      foreach (DataRow rows in dt1.Rows)
      {
        sb.Append("<tr>");
        sb.Append("<td>" + rows["Name"] + "</td>");
        sb.Append("<td>" + "<a class='btn btn-primary' href=\"AllFarmerDetails.aspx?a=" + rows["ID"] + "\">More Info</a>" + "</td>");
        sb.Append("</tr>");
      }

      sb.Append("</tbody>");

      show_farmerD.Text = sb.ToString();
    }

  }

  protected void Page_Load(object sender, EventArgs e)
  {
    string Fid = Request.QueryString["a"].ToString();
    get_APD(Fid);
    get_MD(Fid);
    get_farmerD(Fid);
  }

  protected void btn_UpdateDetails_Click(object sender, EventArgs e)
  {
    string ID = Request.QueryString["a"].ToString();
    Response.Redirect("./UpdateAdetails.aspx?a=" + ID);
  }
}
