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
using System.Diagnostics.SymbolStore;

public partial class PoolingMP_AllUserDetails : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  DataTable dt = new DataTable();
  protected void Page_Load(object sender, EventArgs e)

  {

    if (Session["SuccessMessage"] != null)
    {
      string script = "<script>alert('Validate Successfully');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);

      // Clear the session variable after displaying the message
      Session.Remove("SuccessMessage");
    }
    string Fid = Request.QueryString["a"].ToString();
    string getdata = "Select * from Register_Farmers inner join Milk_Details ON Register_Farmers.ID = Milk_Details.ID Where Register_Farmers.ID = " + Fid + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    ad.Fill(dt);

    /*String getfarmerinfo = "select * from Register_Farmers where ID = " + Fid + ";";
    SqlCommand cmd = new SqlCommand(getfarmerinfo, connection);
    SqlDataAdapter ad2 = new SqlDataAdapter(cmd);
    ad2.Fill(dt);*/

    StringBuilder sb = new StringBuilder();
    sb.Append("<thead><tr><th>Sno</th><th>Date & Time</th><th>Milk Type</th><th>Milk Quantity (Kg)</th><th>Total Cost</th><th>Status</th></tr></thead> ");
    sb.Append("<tbody>");

    

    int i = 1;
    foreach (DataRow rows in dt.Rows)
    {
      if (rows["Status"].ToString() == "Pending")
      {
        Farmer_Name.Text = rows["Name"].ToString();
        Farmer_Sex.Text = rows["gender"].ToString();
        Farmer_Email.Text = rows["Email"].ToString();
        Farmer_Address.Text = rows["Address"].ToString();
        sb.Append("<tr>");
        sb.Append("<td>" + i++ + "</td>");
        sb.Append("<td>" + rows["Date"] + "</td>");
        sb.Append("<td>" + rows["Milk_Type"] + "</td>");
        sb.Append("<td>" + rows["Milk_Quantity"] + "</td>");
        sb.Append("<td>" + rows["Total_Cost"] + "</td>");
        sb.Append("<td><a class='btn btn-primary' href='FullFarmerDetails.aspx?a=" + rows["ID"] + "&b=" + rows["Sno"] + "'> Validate </ a > ");
        sb.Append("<asp:Button runat='server' ID='validate' OnClick='validate_click' style='display: none;'/>");
        sb.Append("</td>");
        sb.Append("</tr>");
      }
      else
      {
        Farmer_Name.Text = rows["Name"].ToString();
        Farmer_Sex.Text = rows["gender"].ToString();
        Farmer_Email.Text = rows["Email"].ToString();
        Farmer_Address.Text = rows["Address"].ToString();
        sb.Append("<tr>");
        sb.Append("<td>" + i++ + "</td>");
        sb.Append("<td>" + rows["Date"] + "</td>");
        sb.Append("<td>" + rows["Milk_Type"] + "</td>");
        sb.Append("<td>" + rows["Milk_Quantity"] + "</td>");
        sb.Append("<td>" + rows["Total_Cost"] + "</td>");
        sb.Append("<td style='color:green;'>" + rows["Status"] +"</td>");
        sb.Append("</td>");
        sb.Append("</tr>");
      }
      
    }
    sb.Append("</tbody>");
    show.Text = sb.ToString();
    validate_click();
  }


  protected void validate_click()
  {
    connection.Open();
    if (Request.QueryString["b"] != null)
    {
      string Fid = Request.QueryString["a"].ToString();
      string Mid = Request.QueryString["b"].ToString();
      string updatestatus = "update Milk_Details set Status = 'Done' where Sno = " + Mid + ";";
      SqlCommand cmds = new SqlCommand(updatestatus, connection);
      int iss = cmds.ExecuteNonQuery();
      if ( iss > 0 )
      {
        Session["SuccessMessage"] = "Validate Successfully";
        string newUrl = Request.Url.AbsolutePath + "?a=" + Server.UrlEncode(Fid);
        Response.Redirect(newUrl);
      }
    }
    else
    {

    }

    connection.Close();
  }
}
