using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FarmerMP_Default : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);

  protected void Page_Load(object sender, EventArgs e)
    {
    if (Session["ID"] != null)
    {
      if (!IsPostBack)
      {
        if (Request.QueryString["imageID"] != null)
        {
          int imageID = Convert.ToInt32(Request.QueryString["imageID"]);

          {
            connection.Open();
            string selectQuery = "SELECT Aadhar_Image FROM Farmer_Documents WHERE ID = N'" + Session["ID"].ToString() + "';select SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            string imagePath = cmd.ExecuteScalar().ToString();

            // Set response headers for download
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=image.jpg");
            Response.TransmitFile(Server.MapPath(imagePath));
            Response.End();
          }
        }
      }

    }
    else
    {
      string script = "<script>alert('Session Expired Please Login Again');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
      Response.Redirect("..//UserLR/Login.aspx");
    }
  }
}
