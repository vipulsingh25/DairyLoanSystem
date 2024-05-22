using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Net.Mail;

public partial class AdminMP_LoanStatus : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  string Farmer_ID;
  DataTable dt = new DataTable();
  protected void Page_Load(object sender, EventArgs e)
    {

    if (Session["SuccessMessage"] != null)
    {
      string script = "<script>alert('Application Submitted Successfully');</script>";
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
    connection.Open();
    string getdata = "Select Register_Farmers.ID,Farmer_Documents.name,Register_Farmers.Email,Register_Farmers.mobile,Farmer_Documents.Aadhar_Number,Farmer_Documents.Pancard_Number,Loan_Application.Bank_Name,Loan_Application.Branch_Name,Loan_Application.Account_Number,Loan_Application.IFSC_Code,Loan_Application.Loan_Amount,Loan_Application.Purpose,Loan_Application.Status from Register_Farmers inner join Farmer_Documents ON Register_Farmers.ID = Farmer_Documents.ID inner join Loan_Application on Farmer_Documents.ID = Loan_Application.ID Where Loan_ID = " + Fid + ";";
    SqlCommand cmd = new SqlCommand(getdata, connection);
    SqlDataReader Reader = cmd.ExecuteReader();
    if (Reader.HasRows)
    {
      while (Reader.Read())
      {
        if (Reader.GetString(12) == "Recommended" )
        {
          Approved.Text = "Recommend";
          Approved.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000FF");
          Approved.Enabled = false;
          UnApproved.Visible = false;
        }
        else if (Reader.GetString(12) == "Rejected")
        {
          Approved.Text = "Rejected";
          Approved.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
          Approved.Enabled = false;
          UnApproved.Visible = false;
        }
        else if (Reader.GetString(12) == "Approved")
        {
          Approved.Text = "Approved";
          Approved.ForeColor = System.Drawing.ColorTranslator.FromHtml("#008000");
          Approved.Enabled = false;
          UnApproved.Visible = false;
        }
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


public void SendEmail(string recipientEmail, string subject, string body)
{
  string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
  int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
  string smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
  string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

  using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
  {
    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
    smtpClient.EnableSsl = true; // Enable SSL if required by your SMTP server

    MailMessage mailMessage = new MailMessage();
    mailMessage.From = new MailAddress(smtpUsername);
    mailMessage.To.Add(new MailAddress(recipientEmail));
    mailMessage.Subject = subject;
    mailMessage.Body = body;
    mailMessage.IsBodyHtml = true; // Set to true if you're sending HTML content

    smtpClient.Send(mailMessage);
  }
}


protected void Approved_Click(object sender, EventArgs e)
    {
    SendEmail("vipulsingh1025@gmail.com", "Recommended Loan Application", "P2P has Send you Loan Application.");
    connection.Open();
    string Fid = Request.QueryString["a"].ToString();
    string updateStatus = "Update Loan_Application Set Status = 'Recommended' where Loan_ID = " + Fid + ";";
    SqlCommand cmds = new SqlCommand(updateStatus,connection);
    int iss = cmds.ExecuteNonQuery();
    if(iss > 0)
    {
      Session["SuccessMessage"] = "Application Approved Successfully";
      Response.Redirect("AllFarmerDetails.aspx?a=" + Farmer_ID + "");
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
      Response.Redirect("AllFarmerDetails.aspx?a=" + Farmer_ID + "");
    }
    connection.Close();
  }
}
