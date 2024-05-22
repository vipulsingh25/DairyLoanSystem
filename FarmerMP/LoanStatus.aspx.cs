using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FarmerMP_LoanStatus : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);

  protected void Page_Load(object sender, EventArgs e)
    {

    if (Session["SuccessMessage"] != null)
    {
      string script = "<script>alert('Application Submitted Successfully');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);

      // Clear the session variable after displaying the message
      Session.Remove("SuccessMessage");
    }


    if (Session["ID"] != null)
    {
      connection.Open();
      string data = "select Status from Loan_Application where ID = @ID;";
      SqlCommand cmds = new SqlCommand(data, connection);
      cmds.Parameters.AddWithValue("@ID", Session["ID"].ToString());
      SqlDataReader reader = cmds.ExecuteReader();
      if (reader.HasRows)
      {
        while (reader.Read())
        {
          if (reader.GetString(0) == "Pending" || reader.GetString(0) == "Recommended")
          {
            submit.Text = "Previous Request Pending";
            submit.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            submit.Enabled = false;
          }
        }

      }
      reader.Close();




      String Validate = "Select Farmer_Documents.name,Register_Farmers.Email,Register_Farmers.mobile,Farmer_Documents.Aadhar_Number,Farmer_Documents.Pancard_Number from Register_Farmers inner join Farmer_Documents ON Register_Farmers.ID = Farmer_Documents.ID Where Register_Farmers.ID = " + Session["ID"].ToString() + ";";
      SqlCommand cmd = new SqlCommand(Validate, connection);
      SqlDataReader Reader = cmd.ExecuteReader();
      if (Reader.HasRows)
      {
        while (Reader.Read())
        {
          string Name = Reader[0].ToString();
          string Email = Reader[1].ToString();
          string Phone = Reader[2].ToString();
          string Aadhar = Reader[3].ToString();
          string Pan = Reader[4].ToString();
          tb_Name.Text = Name;
          tb_Email.Text = Email;
          tb_Phone.Text = Phone;
          tb_Pancardnumber.Text = Pan;
          tb_Aadharnumber.Text = Aadhar;
        }// Close the SqlDataReader
      }
      Reader.Close();



      connection.Close();
      getdata(Session["ID"].ToString());
      BankList();
    }
    else
    {
      string script = "<script>alert('Session Expired Please Login Again');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
      Response.Redirect("..//UserLR/Login.aspx");
    }

  }

  protected void getdata(string ID)
  {
      connection.Open();
      string data = "select * from Loan_Application where ID = @ID;";
      SqlCommand cmds = new SqlCommand(data, connection);
    cmds.Parameters.AddWithValue("@ID", ID);  
      DataTable dt = new DataTable();
      SqlDataAdapter ad = new SqlDataAdapter(cmds);
      ad.Fill(dt);
      StringBuilder sb = new StringBuilder();
      sb.Append("<thead><tr><th>Sno</th><th>Date & Time</th><th>Bank Name</th><th>Branch Name</th><th>Account Number</th><th>Loan Amount</th><th>Purpose</th><th>Status</th></tr></thead> ");
      sb.Append("<tbody>");
      int i = 1;
      foreach (DataRow rows in dt.Rows)
      {
      if (rows["Status"].ToString() == "Pending")
      {
        sb.Append("<tr>");
        sb.Append("<td>" + i++ + "</td>");
        sb.Append("<td>" + rows["Date_of_Application"] + "</td>");
        sb.Append("<td>" + rows["Bank_Name"] + "</td>");
        sb.Append("<td>" + rows["Branch_Name"] + "</td>");
        sb.Append("<td>" + rows["Account_Number"] + "</td>");
        sb.Append("<td>" + rows["Loan_Amount"] + "</td>");
        sb.Append("<td>" + rows["Purpose"] + "</td>");
        sb.Append("<td style='color:orange;'>" + rows["Status"] + "</td>");
        sb.Append("</tr>");
      }
      else if(rows["Status"].ToString() == "Rejected")
      {
        sb.Append("<tr>");
        sb.Append("<td>" + i++ + "</td>");
        sb.Append("<td>" + rows["Date_of_Application"] + "</td>");
        sb.Append("<td>" + rows["Bank_Name"] + "</td>");
        sb.Append("<td>" + rows["Branch_Name"] + "</td>");
        sb.Append("<td>" + rows["Account_Number"] + "</td>");
        sb.Append("<td>" + rows["Loan_Amount"] + "</td>");
        sb.Append("<td>" + rows["Purpose"] + "</td>");
        sb.Append("<td style='color:red;'>" + rows["Status"] + "</td>");
        sb.Append("</tr>");
      }
      else if (rows["Status"].ToString() == "Approved")
      {
        sb.Append("<tr>");
        sb.Append("<td>" + i++ + "</td>");
        sb.Append("<td>" + rows["Date_of_Application"] + "</td>");
        sb.Append("<td>" + rows["Bank_Name"] + "</td>");
        sb.Append("<td>" + rows["Branch_Name"] + "</td>");
        sb.Append("<td>" + rows["Account_Number"] + "</td>");
        sb.Append("<td>" + rows["Loan_Amount"] + "</td>");
        sb.Append("<td>" + rows["Purpose"] + "</td>");
        sb.Append("<td style='color:green;'>" + rows["Status"] + "</td>");
        sb.Append("</tr>");
      }
      else if (rows["Status"].ToString() == "Recommended")
      {
        sb.Append("<tr>");
        sb.Append("<td>" + i++ + "</td>");
        sb.Append("<td>" + rows["Date_of_Application"] + "</td>");
        sb.Append("<td>" + rows["Bank_Name"] + "</td>");
        sb.Append("<td>" + rows["Branch_Name"] + "</td>");
        sb.Append("<td>" + rows["Account_Number"] + "</td>");
        sb.Append("<td>" + rows["Loan_Amount"] + "</td>");
        sb.Append("<td>" + rows["Purpose"] + "</td>");
        sb.Append("<td style='color:blue;'>" + rows["Status"] + "</td>");
        sb.Append("</tr>");
      }
    }

      sb.Append("</tbody>");

      show.Text = sb.ToString();
      
      connection.Close();
  }

  protected void SaveFD()
  {
    string Bank_Name = tb_Bankname.SelectedItem.Text;
    string Branch_Name = tb_Branchname.Text;
    string Account_Number = tb_Accountnumber.Text;
    string IFSC = tb_IFSC.Text;
    string Loan_Amount = tb_Loanamount.Text;
    string Purpose = dd_Purpose.Text;
      if (connection.State != ConnectionState.Open)
    {
      connection.Open();
    }

    if (connection.State == ConnectionState.Open)
    {

      SqlCommand cmds = new SqlCommand("Insert into Loan_Application(ID,Bank_Name,Branch_Name,Account_Number,IFSC_Code,Loan_Amount,Purpose,Status) values(N'" + Session["ID"].ToString() + "',N'" + Bank_Name.Replace("'", "") + "',N'" + Branch_Name.Replace("'", "") + "',N'" + Account_Number.Replace("'", "") + "',N'" + IFSC.Replace("'", "") +
      "',N'" + Loan_Amount.Replace("'", "") + "',N'" + Purpose.Replace("'", "") + "','Pending');select SCOPE_IDENTITY();", connection);
      int iss = cmds.ExecuteNonQuery();
      if (iss > 0)
      {
        string script = "<script>alert('Request Send');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
      }
      connection.Close();
    }
  }

    protected void submit_Click(object sender, EventArgs e)
    {
      SaveFD();
    Session["SuccessMessage"] = "Application Submitted Successfully";
    Response.Redirect(Request.RawUrl);
  }

  protected void BankList()
  {
    connection.Open();
    string getdata = "select * from Bank_List;";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt = new DataTable();
    ad.Fill(dt);
    if (dt.Rows.Count > 0)
    {
      foreach (DataRow rows in dt.Rows)
      {
        tb_Bankname.Items.Add(new ListItem(rows[1].ToString(), rows[0].ToString()));
      }
    }
    connection.Close();
  }
}
