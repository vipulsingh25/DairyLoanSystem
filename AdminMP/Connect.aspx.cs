using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Activities.Expressions;

public partial class AdminMP_Connect : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);

  protected void Get_FarmerList()
  {
    connection.Open();
    string getdata = "Select * from Register_Farmers;";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    System.Data.DataTable dt = new System.Data.DataTable();
    ad.Fill(dt);
    if (dt.Rows.Count > 0)
    {
      foreach (DataRow rows in dt.Rows)
      {
        dd_Farmer.Items.Add(new ListItem(rows[1].ToString(), rows[0].ToString()));
      }
    }
    connection.Close();
  }

  protected void Get_AgentList()
  {
    connection.Open();
    string getdata = "Select * from Register_Agent;";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    System.Data.DataTable dt = new System.Data.DataTable();
    ad.Fill(dt);
    if (dt.Rows.Count > 0)
    {
      foreach (DataRow rows in dt.Rows)
      {
        dd_Agent.Items.Add(new ListItem(rows[1].ToString(), rows[0].ToString()));
      }
    }
    connection.Close();
  }

  protected void getState()
  {
    string getState = "select distinct ST_Code,STATE_NAME from StateList order by STATE_NAME asc";
    connection.Open();
    SqlCommand cmds = new SqlCommand(getState, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    System.Data.DataTable dt = new System.Data.DataTable();
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
    System.Data.DataTable dt = new System.Data.DataTable();
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

  protected void getPoint()
  {
    dd_Point.Items.Clear();
    string getCity = "select PointName from Point where City_Code = " + dd_City.SelectedValue + "order by PointName asc;";
    connection.Open();
    SqlCommand cmds = new SqlCommand(getCity, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    System.Data.DataTable dt = new System.Data.DataTable();
    ad.Fill(dt);
    if (dt.Rows.Count > 0)
    {
      foreach (DataRow rows in dt.Rows)
      {
        dd_Point.Items.Add(new ListItem(rows[0].ToString()));
      }
    }
    connection.Close();
  }
  protected void dd_State_TextChanged(object sender, EventArgs e)
  {
    getCity();
  }

  protected void dd_City_TextChanged(object sender, EventArgs e)
  {
    getPoint();
  }

  protected void Page_Load(object sender, EventArgs e)
    {

    if (Session["SuccessMessage"] != null)
    {
      string script = "<script>alert('Connected Successfully');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);

      // Clear the session variable after displaying the message
      Session.Remove("SuccessMessage");
    }

    if (!IsPostBack)
    {
      Get_FarmerList();
      Get_AgentList();
      getState();
      string getdata = "select Register_Farmers.Name,Register_Agent.Name from Register_Farmers inner join Register_Agent on Register_Farmers.Agent_ID = Register_Agent.ID;";
      SqlCommand cmds = new SqlCommand(getdata, connection);
      SqlDataAdapter ad = new SqlDataAdapter(cmds);
      System.Data.DataTable dt1 = new System.Data.DataTable();
      ad.Fill(dt1);
      if (dt1.Rows.Count > 0)
      {
        StringBuilder sb = new StringBuilder();
        sb.Append("<thead><tr><th>Sno</th><th>Farmer</th><th>Assigned Agent</th></tr></thead> ");
        sb.Append("<tbody>");
        int i = 1;
        foreach (DataRow rows in dt1.Rows)
        {
          sb.Append("<tr>");
          sb.Append("<td>" + i++ + "</td>");
          sb.Append("<td>" + rows[0] + "</td>");
          sb.Append("<td>" + rows[1] + "</td>");
          sb.Append("</tr>");
        }
        sb.Append("</tbody>");

        show.Text = sb.ToString();

      }
    }
    }
  /*protected void Find_Click(object sender, EventArgs e)
  {
    string selectedFarmer = dd_Farmer.SelectedValue;
    string selectedAgent = dd_Agent.SelectedValue;

    connection.Open();

    string getaddress = "Select Pin from Register_Farmers where ID = @SelectedFarmer";
    SqlCommand cmd = new SqlCommand(getaddress, connection);
    cmd.Parameters.AddWithValue("@SelectedFarmer", selectedFarmer);

    SqlDataReader Reader = cmd.ExecuteReader();
    dd_Agent.Items.Clear();
    dd_Agent.Items.Add(new ListItem("Select from list", ""));
    while (Reader.Read())
    {
      String Pin = Reader["Pin"].ToString();
      string Pincode = dd_Point.Text.ToString();

      SqlConnection innerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);

      {
        if(dd_Point.Text == "")
        {
          innerConnection.Open();
          String Aname = "select ID,Name from Register_Agent where Pin = @Pin";
          SqlCommand cmds = new SqlCommand(Aname, innerConnection);
          cmds.Parameters.AddWithValue("@Pin", Pin);

          SqlDataAdapter ad = new SqlDataAdapter(cmds);
          System.Data.DataTable newdt = new System.Data.DataTable();
          ad.Fill(newdt);

          if (newdt.Rows.Count > 0)
          {
            foreach (DataRow rows in newdt.Rows)
            {
              dd_Agent.Items.Add(new ListItem(rows[1].ToString(), rows[0].ToString()));
            }
          }
        }else if(dd_Point.Text != null)
        {
          innerConnection.Open();
          String Aname = "select ID,Name from Register_Agent where Pin = " + Pincode;
          SqlCommand cmds = new SqlCommand(Aname, innerConnection);
          SqlDataAdapter ad = new SqlDataAdapter(cmds);
          System.Data.DataTable newdt = new System.Data.DataTable();
          ad.Fill(newdt);

          if (newdt.Rows.Count > 0)
          {
            foreach (DataRow rows in newdt.Rows)
            {
              dd_Agent.Items.Add(new ListItem(rows[1].ToString(), rows[0].ToString()));
            }
          }
        }

        while (innerReader.Read())
        {
          dd_Agent.Items.Add(new ListItem(innerReader["Name"].ToString(), innerReader["ID"].ToString()));
        }

        innerReader.Close();
      }
    }

    Reader.Close();
    connection.Close();
  }*/

  protected void UpdateFarmer(string Name,string ID)
  {
    connection.Open();
    string AddAgent = "UPDATE Register_Farmers SET Agent_ID = @Agent_ID WHERE ID = @FarmerID";
    SqlCommand cmd = new SqlCommand(AddAgent, connection);
    cmd.Parameters.AddWithValue("@Agent_ID", Name);
    cmd.Parameters.AddWithValue("@FarmerID",ID);
    int iss = cmd.ExecuteNonQuery();
    connection.Close();
  }

  protected void UpdateAgent(string Name, string ID)
  {
    connection.Open();
    string AddAgent = "UPDATE Register_Agent SET Farmer_ID = @Farmer_ID WHERE ID = @AgentID";
    SqlCommand cmd = new SqlCommand(AddAgent, connection);
    cmd.Parameters.AddWithValue("@Farmer_ID", Name);
    cmd.Parameters.AddWithValue("@AgentID", ID);
    int iss = cmd.ExecuteNonQuery();
    connection.Close();
  }
  protected void Connect_Click(object sender, EventArgs e)
  {
    string selectedAgentName = dd_Agent.Text;
    string selectedFarmerID = dd_Farmer.SelectedValue;
    string selectedFarmerName = dd_Farmer.Text;
    string selectedAgentID = dd_Agent.SelectedValue;
    UpdateFarmer(selectedAgentName, selectedFarmerID);
    UpdateAgent(selectedFarmerName, selectedAgentID);
    Session["SuccessMessage"] = "Connected Successfully";
    Response.Redirect(Request.RawUrl);
  }

}
