using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class FarmerMP_MilkDetails : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  DataTable dt = new DataTable();
  protected void Get_AgentList()
  {
    connection.Open();
    string getdata = "select ID,Name from Register_Agent where Farmer_ID = @farmerid";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    cmds.Parameters.AddWithValue("@farmerid", Session["ID"].ToString());
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt = new DataTable();
    ad.Fill(dt);
    if (dt.Rows.Count > 0)
    {
      foreach (DataRow rows in dt.Rows)
      {
        agent_name.Items.Add(new ListItem(rows[1].ToString(), rows[0].ToString()));
      }
    }
    connection.Close();
  }
  protected void Page_Load(object sender, EventArgs e)
    {

    if (Session["SuccessMessage"] != null)
    {
      string script = "<script>alert('Milk Added Successfully');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);

      // Clear the session variable after displaying the message
      Session.Remove("SuccessMessage");
    }

    if (Session["ID"] != null)
    {
      String get = "Select * from Milk_Details Where ID = " + Session["ID"].ToString() + ";";

      SqlCommand d = new SqlCommand(get, connection);
      SqlDataAdapter ad = new SqlDataAdapter(d);
      ad.Fill(dt);

      StringBuilder sb = new StringBuilder();
      sb.Append("<thead><tr><th>Sno</th><th>Date & Time</th><th>Milk Type</th><th>Milk Quantity (in litres)</th><th>Total Cost</th><th>Agent_Name</th><th>Status</th></tr></thead> ");
      sb.Append("<tbody>");

      int i = 1;
      foreach (DataRow rows in dt.Rows)
      {
        if (rows["Status"].ToString() == "Pending")
        {
          sb.Append("<tr>");
          sb.Append("<td>" + i++ + "</td>");
          sb.Append("<td>" + rows["Date"] + "</td>");
          sb.Append("<td>" + rows["Milk_Type"] + "</td>");
          sb.Append("<td>" + rows["Milk_Quantity"] + "</td>");
          sb.Append("<td>" + rows["Total_Cost"] + "</td>");
          sb.Append("<td>" + rows["Agent_Name"] + "</td>");
          sb.Append("<td style='color:red;'>" + rows["Status"] + "</td>");
          sb.Append("</tr>");
        }
        else
        {
          sb.Append("<tr>");
          sb.Append("<td>" + i++ + "</td>");
          sb.Append("<td>" + rows["Date"] + "</td>");
          sb.Append("<td>" + rows["Milk_Type"] + "</td>");
          sb.Append("<td>" + rows["Milk_Quantity"] + "</td>");
          sb.Append("<td>" + rows["Total_Cost"] + "</td>");
          sb.Append("<td>" + rows["Agent_Name"] + "</td>");
          sb.Append("<td style='color:green;'>" + rows["Status"] + "</td>");
          sb.Append("</tr>");
        }
      }

      sb.Append("</tbody>");

      show.Text = sb.ToString();

      Get_AgentList();
    }
    else
    {
      string script = "<script>alert('Session Expired Please Login Again');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
      Response.Redirect("..//UserLR/Login.aspx");
    }

  }


  protected void btn_addmilk_Click(object sender, EventArgs e)
    {


    string MilkType = milk_type.Text;
        string MilkQuantity = milk_quantity.Text;
    string Agent_Name = agent_name.Text;
    string TotalCost = txt_totalcost.Text;
      SqlCommand cmds = new SqlCommand("insert into Milk_Details(ID,Milk_Type,Milk_Quantity,Total_Cost,Agent_Name,Status) values (N'" + Session["ID"].ToString() + "',N'" + MilkType.Replace
("'", "") + "',N'" + MilkQuantity.Replace("'", "") + "',N'" + TotalCost.Replace("'","") + "',N'" + Agent_Name.Replace("'","") + "','Pending');select SCOPE_IDENTITY();", connection);
      connection.Open();

    int iss = cmds.ExecuteNonQuery();

    if ( iss > 0 )
    {
      Session["SuccessMessage"] = "Milk Added Successfully";
      Response.Redirect(Request.RawUrl);
    }
  }

  protected void milk_quantity_TextChanged(object sender, EventArgs e)
  {
    try
    {
      int totalliter = Convert.ToInt32(milk_quantity.Text);
      int total = totalliter * 50;
      txt_totalcost.Text = total.ToString();
    }
    catch (Exception Ex)
    {

    }
  }

  
}
