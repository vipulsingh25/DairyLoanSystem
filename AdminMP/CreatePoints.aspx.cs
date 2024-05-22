using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMP_CreatePoints : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);

  protected void Page_Load(object sender, EventArgs e)
    {
    if (Session["SuccessMessage"] != null)
    {
      string script = "<script>alert('Added Successfully');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);

      // Clear the session variable after displaying the message
      Session.Remove("SuccessMessage");
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
        dd_State.Items.Add(new ListItem(rows[1].ToString(), rows[0].ToString()));
      }
    }
    connection.Close();
  }

  protected void getCity()
  {
    dd_City.Items.Clear();
    string StateValue = dd_State.SelectedValue;
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
        dd_City.Items.Add(new ListItem(rows[1].ToString(), rows[0].ToString()));
      }
    }
    connection.Close();
  }


  protected void dd_State_TextChanged(object sender, EventArgs e)
  {
    getCity();
  }

  protected void CreatePoint_Click(object sender, EventArgs e)
    {
    connection.Open();
    string AddPoint = "update Point set State = @state ,St_Code = " + dd_State.SelectedValue + ",City = @city,City_Code = " + dd_City.SelectedValue + ",PointName = @pointname;";
    SqlCommand cmds = new SqlCommand(AddPoint, connection);
    cmds.Parameters.AddWithValue("@state", dd_State.SelectedItem.Text);
    cmds.Parameters.AddWithValue("@city", dd_City.SelectedItem.Text);
    cmds.Parameters.AddWithValue("@pointname", txt_PointName.Text);
    int iss = cmds.ExecuteNonQuery();
    if (iss > 0)
    {
      Session["SuccessMessage"] = "Created Successfully";
      Response.Redirect(Request.RawUrl);
    }
    connection.Close();
  }
}
