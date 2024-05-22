using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BankPortal_LoanStatus : System.Web.UI.Page
{
  /*SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  string Farmer_ID;
  protected void Page_Load(object sender, EventArgs e)
  {
    string Fid = Request.QueryString["a"].ToString();
    string getdata = "Select Register_Farmers.ID,Farmer_Documents.name,Register_Farmers.Email,Register_Farmers.mobile,Farmer_Documents.Aadhar_Number,Farmer_Documents.Pancard_Number,Loan_Application.Bank_Name,Loan_Application.Branch_Name,Loan_Application.Account_Number,Loan_Application.IFSC_Code,Loan_Application.Loan_Amount,Loan_Application.Purpose from Register_Farmers inner join Farmer_Documents ON Register_Farmers.ID = Farmer_Documents.ID inner join Loan_Application on Farmer_Documents.ID = Loan_Application.ID Where Loan_ID = " + Fid + ";";
    SqlCommand cmd = new SqlCommand(getdata, connection);
    connection.Open();
    SqlDataReader Reader = cmd.ExecuteReader();
    if (Reader.HasRows)
    {
      while (Reader.Read())
      {
        Farmer_ID = Reader[0].ToString();
        tb_Name.Text = Reader[1].ToString();
        tb_Email.Text = Reader[2].ToString();
        tb_Phone.Text = Reader[3].ToString();
        tb_Aadharnumber.Text = Reader[4].ToString();
        tb_Pancardnumber.Text = Reader[5].ToString();
        tb_Bankname.Text = Reader[6].ToString();
        tb_Branchname.Text = Reader[7].ToString();
        tb_Accountnumber.Text = Reader[8].ToString();
        tb_IFSC.Text = Reader[9].ToString();
        tb_Loanamount.Text = Reader[10].ToString();
        tb_Purpose.Text = Reader[11].ToString();
      }// Close the SqlDataReader
      Reader.Close();
    }


    connection.Close();
  }

  protected void Approved_Click(object sender, EventArgs e)
  {
    connection.Open();
    string Fid = Request.QueryString["a"].ToString();
    string updateStatus = "Update Loan_Application Set Status = 'Recommended' where Loan_ID = " + Fid + ";";
    SqlCommand cmds = new SqlCommand(updateStatus, connection);
    int iss = cmds.ExecuteNonQuery();
    if (iss > 0)
    {
      Response.Redirect(".aspx?a=" + Farmer_ID + "");
    }
    connection.Close();

  }

  protected void UnApproved_Click(object sender, EventArgs e)
  {
    string Fid = Request.QueryString["a"].ToString();
    connection.Open();
    string updateStatus = "Update Loan_Application Set Status = 'Rejected' where Loan_ID = " + Fid + ";";
    SqlCommand cmds = new SqlCommand(updateStatus, connection);
    int iss = cmds.ExecuteNonQuery();
    if (iss > 0)
    {
      Response.Redirect("AllFarmerDetails.aspx?a=" + Farmer_ID + "");
    }
    connection.Close();
  }*/

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
    string getdata = "Select Farmer_Documents.Aadhar_Image,Farmer_Documents.Pancard_Image,Farmer_Documents.name,Farmer_Documents.Aadhar_Number,Farmer_Documents.Pancard_Number,Loan_Application.Bank_Name,Loan_Application.Branch_Name,Loan_Application.Account_Number,Loan_Application.IFSC_Code,Loan_Application.Loan_Amount,Loan_Application.Purpose from Loan_Application inner join Farmer_Documents on Farmer_Documents.ID = Loan_Application.ID Where Loan_ID = " + ID + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataReader Reader = cmds.ExecuteReader();
    if (Reader.HasRows)
    {
      while (Reader.Read())
      {
        Aadhar_image.ImageUrl = Reader[0].ToString();
        Pancard_image.ImageUrl = Reader[1].ToString();
        txt_name.Text = Reader[2].ToString();
        txt_Aadharnumber.Text = Reader[3].ToString();
        txt_Pancardnumber.Text = Reader[4].ToString();
        txt_Branchname.Text = Reader[6].ToString();
        txt_Bankname.Text = Reader[5].ToString();
        txt_Loanamount.Text = Reader[9].ToString();
        txt_IFSC.Text = Reader[8].ToString();
        txt_Accountnumber.Text = Reader[7].ToString();
        txt_Purpose.Text = Reader[10].ToString();
      }
      Reader.Close();
    }
    connection.Close();
  }
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["SuccessMessage"] != null)
    {
      string script = "<script>alert('Application Approved Successfully');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);

      // Clear the session variable after displaying the message
      Session.Remove("SuccessMessage");
    }

    if (Session["RejectMessage"] != null)
    {
      string script = "<script>alert('Application Rejected Successfully');</script>";
      Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);

      // Clear the session variable after displaying the message
      Session.Remove("RejectMessage");
    }

    string Fid = Request.QueryString["a"].ToString();
    string DetailsID = "";
    connection.Open();
    string GetID = "select ID,Status from Loan_Application where Loan_ID = " + Fid + ";";
    SqlCommand cmds = new SqlCommand(GetID, connection);
    SqlDataReader Reader = cmds.ExecuteReader();
    if (Reader.HasRows)
    {
      while (Reader.Read())
      {
        DetailsID = Reader["ID"].ToString();
        if (Reader["Status"].ToString() == "Rejected")
        {
          Approved.Text = "Rejected";
          Approved.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
          Approved.Enabled = false;
          UnApproved.Visible = false;

        }
        else if (Reader["Status"].ToString() == "Approved")
        {
          Approved.Text = "Approved";
          Approved.ForeColor = System.Drawing.ColorTranslator.FromHtml("#008000");
          Approved.Enabled = false;
          UnApproved.Visible = false;

        }
      }// Close the SqlDataReader
      Reader.Close();
    }
    connection.Close();

    Getdetails(DetailsID);
    GetDocuments(Fid);

  }


  protected void Approved_Click(object sender, EventArgs e)
  {
    connection.Open();
    string Fid = Request.QueryString["a"].ToString();
    string updateStatus = "Update Loan_Application Set Status = 'Approved' where Loan_ID = " + Fid + ";";
    SqlCommand cmds = new SqlCommand(updateStatus, connection);
    int iss = cmds.ExecuteNonQuery();
    if (iss > 0)
    {
      Session["SuccessMessage"] = "Application Approved Successfully";
      Response.Redirect(Request.RawUrl);
    }
    connection.Close();

  }

  protected void UnApproved_Click(object sender, EventArgs e)
  {
    string Fid = Request.QueryString["a"].ToString();
    connection.Open();
    string updateStatus = "Update Loan_Application Set Status = 'Rejected' where Loan_ID = " + Fid + ";";
    SqlCommand cmds = new SqlCommand(updateStatus, connection);
    int iss = cmds.ExecuteNonQuery();
    if (iss > 0)
    {
      Session["RejectMessage"] = "Application Rejected Successfully";
      Response.Redirect(Request.RawUrl);
    }
    connection.Close();
  }
}
