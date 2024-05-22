using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class PoolingMP_Default : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  DataTable dt = new DataTable();
  protected void Getdetails(string ID)
  {
    connection.Open();
    string getdata = "select * from Register_Agent where ID =" + ID + ";";
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
  }
  protected void Page_Load(object sender, EventArgs e)
    {
    Getdetails(Session["ID"].ToString());
    }


}
