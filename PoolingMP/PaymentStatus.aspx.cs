using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PoolingMP_PaymentStatus : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  protected void Page_Load(object sender, EventArgs e)
    {
    Get_FarmerList();
    }

  protected void Get_FarmerList()
  {
    connection.Open();
    string getdata = "select ID,Name from Register_Farmers where Agent_ID = @Agentid";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    cmds.Parameters.AddWithValue("@Agentid", Session["ID"].ToString());
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt = new DataTable();
    ad.Fill(dt);
    if (dt.Rows.Count > 0)
    {
      foreach (DataRow rows in dt.Rows)
      {
        Farmer_name.Items.Add(new ListItem(rows[1].ToString(), rows[0].ToString()));
      }
    }
    connection.Close();
  }

  protected void btn_ViewDetails_Click(object sender, EventArgs e)
    {

    }

  protected void MakePayment(object sender, EventArgs e)
  {

  }


}
