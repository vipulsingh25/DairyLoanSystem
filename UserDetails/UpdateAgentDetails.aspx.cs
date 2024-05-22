using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class UserDetails_UpdateAgentDetails : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["Name"] != null)
    {
      tb_Name.Text = Session["Name"].ToString();
    }
    if (Session["Email"] != null)
    {
      tb_Email.Text = Session["Email"].ToString();
    }

    if (Regex.IsMatch(tb_Email.Text, @"^(?:(\+\d{1,3})[- ]?)?\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$"))
    {
      validator_mobile.Visible = false;
      Exp_mobile.Visible = false;
      tb_Mobile.ReadOnly = true;
      tb_Mobile.Text = "Not Required";
    }

    getState();
  }

  protected void getState()
  {
    string getState = "select distinct ST_Code,STATE_NAME from StateList order by STATE_NAME asc";
    connection.Open();
    SqlCommand cmds = new SqlCommand(getState, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt = new DataTable();
    ad.Fill(dt);
    if (dt.Rows.Count > 0)
    {
      foreach (DataRow rows in dt.Rows)
      {
        ddlState.Items.Add(new ListItem(rows[1].ToString(), rows[0].ToString()));
      }
    }
    connection.Close();
  }

  protected void getCity()
  {
    ddlCity.Items.Clear();
    string StateValue = ddlState.SelectedValue;
    string getCity = "select distinct SDT_Code,SUB_DISTRICT_NAME from StateList where ST_Code = @StateValue order by SUB_DISTRICT_NAME asc";
    connection.Open();
    SqlCommand cmds = new SqlCommand(getCity, connection);
    cmds.Parameters.AddWithValue("@StateValue", StateValue);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt = new DataTable();
    ad.Fill(dt);
    if (dt.Rows.Count > 0)
    {
      foreach (DataRow rows in dt.Rows)
      {
        ddlCity.Items.Add(new ListItem(rows[1].ToString(), rows[0].ToString()));
      }
    }
    connection.Close();
  }

  /*protected void updateAgentdetails()
  {
    string Mobile = tb_Mobile.Text;
    string Gender = dd_Gender.Text;
    string Address = tb_Address.Text;
    string Pin = tb_Pin.Text;
    string State = txt_State.Text;
    string City = ddlCity.Text;
    connection.Open();
    string update = "UPDATE Register_Agent SET mobile = N'" + Mobile.Replace("'", "") + "', gender = N'" + Gender.Replace("'", "") + "',address = N'" + Address.Replace("'", "") + "',pin = N'" + Pin.Replace("'", "") +
      "',city = N'" + City.Replace("'", "") + "',state = N'" + State.Replace("'", "") + "' where ID = N'" + Session["ID"].ToString() + "';select SCOPE_IDENTITY();";

    SqlCommand cmd = new SqlCommand(update, connection);
    int iss = cmd.ExecuteNonQuery();
    connection.Close();
  }*/


  protected void updateAgentdetails()
  {
    string Mobile;
    if (Regex.IsMatch(tb_Email.Text, @"^(?:(\+\d{1,3})[- ]?)?\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$"))
    {
      Mobile = "Not Required";
    }
    else
    {
      Mobile = tb_Mobile.Text;
    }
    string Gender = dd_Gender.Text;
    string Address = tb_Address.Text;
    string Pin = tb_Pin.Text;
    string State = ddlState.SelectedItem.Text;
    string City = ddlCity.SelectedItem.Text;
    connection.Open();
    string update = "UPDATE Register_Agent SET mobile = N'" + Mobile.Replace("'", "") + "', gender = N'" + Gender.Replace("'", "") + "',address = N'" + Address.Replace("'", "") + "',pin = N'" + Pin.Replace("'", "") +
      "',city = N'" + City.Replace("'", "") + "',state = N'" + State.Replace("'", "") + "' where ID = N'" + Session["ID"].ToString() + "';select SCOPE_IDENTITY();";

    SqlCommand cmd = new SqlCommand(update, connection);
    int iss = cmd.ExecuteNonQuery();
    connection.Close();
  }


  protected void changeLOG()
  {
    if (connection.State != ConnectionState.Open)
    {
      connection.Open();
    }

    if (connection.State == ConnectionState.Open)
    {
      string update = "UPDATE Register_Agent SET FirstTimeLOG = 'NO' Where ID = " + Session["ID"].ToString() + ";";
      SqlCommand cmd = new SqlCommand(update, connection);
      int rowsAffected = cmd.ExecuteNonQuery();
      connection.Close();
    }
  }


  protected void btn_update_Click(object sender, EventArgs e)
  {
    updateAgentdetails();
    changeLOG();
    string script = "<script>alert('Update Successful');</script>";
    Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
    Response.Redirect("..//PoolingMP/DashBoard.aspx");
  }

  /*protected void tb_Pin_TextChanged(object sender, EventArgs e)
  {
    string Pincode = tb_Pin.Text;
    GetStatesForPincode(Pincode);
    string[] cities = GetCitiesForPincode(Pincode);
    ddlCity.Items.Clear();
    foreach (string city in cities)
    {
      ddlCity.Items.Add(new ListItem(city));
    }

  }

  private void GetStatesForPincode(string pincode)
  {
    connection.Open();
    String GetState = "Select State from Pincode Where PIN = " + pincode + ";";
    SqlCommand cmd = new SqlCommand(GetState, connection);
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
      ddlState.Text = reader.GetString(0);
    }
    connection.Close();
  }

  private string[] GetCitiesForPincode(string pincode)
  {
    connection.Open();
    List<string> cities = new List<string>();
    String GetState = "Select City from Pincode Where PIN = " + pincode + ";";
    SqlCommand cmd = new SqlCommand(GetState, connection);
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
      cities.Add(reader["City"].ToString());
    }
    connection.Close();
    return cities.ToArray();
  }*/

  protected void ddlState_TextChanged(object sender, EventArgs e)
  {
    getCity();
  }
}
