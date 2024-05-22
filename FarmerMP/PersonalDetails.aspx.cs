using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FarmerMP_PersonalDetails : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  DataTable dt = new DataTable();

  protected void Getdetails(string ID)
  {
    connection.Open();
    string getdata = "select * from Register_Farmers where ID =" + ID + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    ad.Fill(dt);
    foreach (DataRow rows in dt.Rows)
    {
      tb_Name.Text = rows[1].ToString();
      tb_Email.Text = rows[2].ToString();
      tb_Mobile.Text = rows[5].ToString();
      tb_Gender.Text = rows[6].ToString();
      tb_Address.Text = rows[7].ToString();
      tb_Pin.Text = rows[8].ToString();
      tb_City.Text = rows[9].ToString();
      tb_State.Text = rows[10].ToString();
    }
    connection.Close();
  }

  protected void GetDocuments(string ID)
  {
    connection.Open();
    string getdata = "select * from Farmer_Documents where ID =" + ID + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    ad.Fill(dt);
    foreach (DataRow rows in dt.Rows)
    {
      Aadhar_image.ImageUrl = rows["Aadhar_Image"].ToString();
      Pancard_image.ImageUrl = rows["Pancard_Image"].ToString();
      txt_aadharname.Text = rows["name"].ToString();
      txt_aadharnumber.Text = rows["Aadhar_Number"].ToString();
      txt_pancardnumber.Text = rows["Pancard_Number"].ToString();
    }
    connection.Close();
  }
    protected void Page_Load(object sender, EventArgs e)
    {
    if (Session["ID"] != null)
    {
      Getdetails(Session["ID"].ToString());
      GetDocuments(Session["ID"].ToString());

    }
    else
    {
      string script = "<script>alert('Session Expired Please Login Again');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
      Response.Redirect("..//UserLR/Login.aspx");
    }
  }

  protected void btn_UpdateDetails_Click(object sender, EventArgs e)
  {
    Response.Redirect("..//UserDetails/UpdateFarmerDetails.aspx");
  }
}
