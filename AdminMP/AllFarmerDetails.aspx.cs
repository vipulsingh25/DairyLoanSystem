using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.Services;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Reflection;
using System.Net.Mail;
using System.Data.OleDb;
using OfficeOpenXml;
using System.Collections;
using System.Reflection.Emit;
using System.Net.NetworkInformation;

public partial class AdminMP_AllUserDetails : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);


  protected void GetDocuments(string ID)
  {
    connection.Open();
    string getdata = "select * from Farmer_Documents where ID =" + ID + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt = new DataTable();
    ad.Fill(dt);
    foreach (DataRow rows in dt.Rows)
    {
      Aadhar_image.ImageUrl = rows["Aadhar_Image"].ToString();
      Pancard_image.ImageUrl = rows["Pancard_Image"].ToString();
    }
    connection.Close();
  }

  protected void get_FPD(string ID)
  {
    string data = "select * from Register_Farmers Where ID = " + ID + ";";
    SqlCommand cmds = new SqlCommand(data, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt2 = new DataTable();
    ad.Fill(dt2);
    foreach (DataRow rows in dt2.Rows)
    {
      Farmer_Name.Text = rows[1].ToString();
      Farmer_Sex.Text = rows[6].ToString();
      Farmer_Email.Text = rows[2].ToString();
      Farmer_Address.Text = rows[7].ToString() + ", " + rows[9].ToString() + " (" + rows[8].ToString() + ") - " + rows[10].ToString();
    }
  }

  protected void get_MD(string ID)
    {
    string getdata = "Select * from Milk_Details where ID = " + ID + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt1 = new DataTable();
    ad.Fill(dt1);
    if (dt1.Rows.Count > 0)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("<thead><tr><th>Sno</th><th>Date & Time</th><th>Milk Type</th><th>Milk Quantity (Kg)</th><th>Total Cost</th><th>Verified Status</th></tr></thead> ");
      sb.Append("<tbody>");
      int i = 1;
      foreach (DataRow rows in dt1.Rows)
      {
        if (rows["Status"].ToString() == "Done")
        {
          sb.Append("<tr>");
          sb.Append("<td>" + i++ + "</td>");
          sb.Append("<td>" + rows["Date"] + "</td>");
          sb.Append("<td>" + rows["Milk_Type"] + "</td>");
          sb.Append("<td>" + rows["Milk_Quantity"] + "</td>");
          sb.Append("<td>" + rows["Total_Cost"] + "</td>");
          sb.Append("<td style='color:#006400;font-weight:700;text-align:center;'>" + rows["Status"] + "</td>");
          sb.Append("</tr>");
        }else if(rows["Status"].ToString() == "Pending")
        {
          sb.Append("<tr>");
          sb.Append("<td>" + i++ + "</td>");
          sb.Append("<td>" + rows["Date"] + "</td>");
          sb.Append("<td>" + rows["Milk_Type"] + "</td>");
          sb.Append("<td>" + rows["Milk_Quantity"] + "</td>");
          sb.Append("<td>" + rows["Total_Cost"] + "</td>");
          sb.Append("<td style='color:red;font-weight:700;text-align:center;'>" + rows["Status"] + "</td>");
          sb.Append("</tr>");
        }
      }

      sb.Append("</tbody>");

      show.Text = sb.ToString();

    }
  }

  protected void getLD(string ID)
  {
    string getdata = "Select * from Loan_Application where ID = " + ID + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt1 = new DataTable();
    ad.Fill(dt1);
    if (dt1.Rows.Count > 0)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("<thead><tr><th>Sno</th><th>Date & Time</th><th>Bank Name</th><th>Branch Name</th><th>Account Number</th><th>Loan Amount</th><th>Purpose</th><th>Status</th></tr></thead> ");
      sb.Append("<tbody>");
      int i = 1;
      foreach (DataRow rows in dt1.Rows)
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
          sb.Append("<td>" + "<a class='btn btn-primary' href=\"LoanStatus.aspx?a=" + rows["Loan_ID"] + "\">More Info</a>" + "</td>");
          sb.Append("</tr>");
        }
        else if(rows["Status"].ToString() == "Recommended")
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
          sb.Append("<td>" + "<a class='btn btn-primary' href=\"LoanStatus.aspx?a=" + rows["Loan_ID"] + "\">More Info</a>" + "</td>");
          sb.Append("</tr>");
        }
        else
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
          sb.Append("<td>" + "<a class='btn btn-primary' href=\"LoanStatus.aspx?a=" + rows["Loan_ID"] + "\">More Info</a>" + "</td>");
          sb.Append("</tr>");
        }
      }

      sb.Append("</tbody>");

      show_loantable.Text = sb.ToString();
    }
  }

  protected void get_agentD(string ID)
  {
    string getdata = "Select ID,Name from Register_Agent where Farmer_ID = " + ID + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt1 = new DataTable();
    ad.Fill(dt1);
    if (dt1.Rows.Count > 0)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("<thead><tr><th>Agent</th><th>Details</th></tr></thead> ");
      sb.Append("<tbody>");
      foreach (DataRow rows in dt1.Rows)
      {
          sb.Append("<tr>");
          sb.Append("<td>" + rows["Name"] + "</td>");
          sb.Append("<td>" + "<a class='btn btn-primary' href=\"AllAgentDetails.aspx?a=" + rows["ID"] + "\">More Info</a>" + "</td>");
          sb.Append("</tr>");
      }

      sb.Append("</tbody>");

      show_agentD.Text = sb.ToString();
    }

  }
  protected void Page_Load(object sender, EventArgs e)
  {
    string Fid = Request.QueryString["a"].ToString();
    get_FPD(Fid);
    get_MD(Fid);
    getLD(Fid);
    get_agentD(Fid);
    GetDocuments(Fid);
  }

  protected void btn_UpdateDetails_Click(object sender, EventArgs e)
  {
    string ID = Request.QueryString["a"].ToString();
    Response.Redirect("./UpdateFdetails.aspx?a=" + ID);
  }

  protected void Export_btn(object sender, EventArgs e)
  {




    // Set the license context for EPPlus
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

    try
    {

      // Define the SQL query to retrieve data from the database
      string getdata = "SELECT * FROM Loan_Application WHERE ID = @ID";

      using (SqlCommand cmd = new SqlCommand(getdata, connection))
      {
        // Define the parameter for the ID
        cmd.Parameters.AddWithValue("@ID", Request.QueryString["a"].ToString()); // Assuming ID is defined elsewhere

        // Open the database connection
        connection.Open();

        // Create a DataTable to hold the query results
        DataTable dt1 = new DataTable();

        // Execute the SQL query and fill the DataTable
        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
        {
          ad.Fill(dt1);
        }

        // Check if there is data to export
        if (dt1.Rows.Count > 0)
        {
          using (var package = new ExcelPackage())
          {
            // Create a worksheet named "Sheet1"
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");

            // Load data from the DataTable into the worksheet
            worksheet.Cells["A1"].LoadFromDataTable(dt1, true);

            // Define the file path and save the Excel file
            string filePath = Path.Combine(Server.MapPath("~/Data.xlsx"));
            FileInfo fileInfo = new FileInfo(filePath);
            package.SaveAs(fileInfo);

            // Provide a success message or redirect to download the file
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=Data.xlsx");
            Response.TransmitFile(filePath);
            Response.End();
          }
        }
        else
        {
          Console.WriteLine("No data found to export.");
        }
      }
    }
    catch (Exception ex)
    {
      // Handle any exceptions that may occur
      Console.WriteLine("Error: " + ex.Message);
    }




    /*ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    connection.Open();
    string getdata = "Select Bank_Name from Loan_Application where ID = " + ID + ";";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    DataTable dt = new DataTable();
    ad.Fill(dt);
    foreach (DataRow rows in dt.Rows)
    {
      using (var package = new ExcelPackage())
      {
        var worksheet = package.Workbook.Worksheets.Add("Sheet1");
        worksheet.Cells["A1"].LoadFromDataTable(dt, true);
        string filePath = Path.Combine(Server.MapPath("~/ExportedData.xlsx"));
        FileInfo fileInfo = new FileInfo(filePath);
        package.SaveAs(fileInfo);
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment; filename=ExportedData.xlsx");
        Response.TransmitFile(filePath);
        Response.End();
      }
    }
    connection.Close();*/
  }
}
