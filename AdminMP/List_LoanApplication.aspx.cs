using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.IO;

public partial class AdminMP_List_LoanApplication : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  DataTable dt = new DataTable();
  protected void Page_Load(object sender, EventArgs e)
  {
    string getdata = "Select * from Loan_Application inner join Register_Farmers on Register_Farmers.ID = Loan_Application.ID;";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    ad.Fill(dt);
    if (dt.Rows.Count > 0)
    {
      StringBuilder sb1 = new StringBuilder();
      StringBuilder sb2 = new StringBuilder();
      StringBuilder sb3 = new StringBuilder();
      StringBuilder sb4 = new StringBuilder();
      sb1.Append("<thead><tr><th>Sno</th><th>Date & Time</th><th>Farmer Name</th><th>Bank Name</th><th>Branch Name</th><th>Account Number</th><th>Loan Amount</th><th>Purpose</th><th>Status</th></tr></thead> ");
      sb1.Append("<tbody>");
      sb2.Append("<thead><tr><th>Sno</th><th>Date & Time</th><th>Farmer Name</th><th>Bank Name</th><th>Branch Name</th><th>Account Number</th><th>Loan Amount</th><th>Purpose</th><th>Status</th></tr></thead> ");
      sb2.Append("<tbody>");
      sb3.Append("<thead><tr><th>Sno</th><th>Date & Time</th><th>Farmer Name</th><th>Bank Name</th><th>Branch Name</th><th>Account Number</th><th>Loan Amount</th><th>Purpose</th><th>Status</th></tr></thead> ");
      sb3.Append("<tbody>");
      sb4.Append("<thead><tr><th>Sno</th><th>Date & Time</th><th>Farmer Name</th><th>Bank Name</th><th>Branch Name</th><th>Account Number</th><th>Loan Amount</th><th>Purpose</th><th>Status</th></tr></thead> ");
      sb4.Append("<tbody>");
      int i = 1;
      foreach (DataRow rows in dt.Rows)
      {
        if (rows["Status"].ToString() == "Pending")
        {
          sb1.Append("<tr>");
          sb1.Append("<td>" + i++ + "</td>");
          sb1.Append("<td>" + rows["Date_of_Application"] + "</td>");
          sb1.Append("<td>" + rows["Name"] + "</td>");
          sb1.Append("<td>" + rows["Bank_Name"] + "</td>");
          sb1.Append("<td>" + rows["Branch_Name"] + "</td>");
          sb1.Append("<td>" + rows["Account_Number"] + "</td>");
          sb1.Append("<td>" + rows["Loan_Amount"] + "</td>");
          sb1.Append("<td>" + rows["Purpose"] + "</td>");
          sb1.Append("<td style='color:orange;'>" + rows["Status"] + "</td>");
          sb1.Append("<td>" + "<a class='btn btn-primary' href=\"LoanStatus.aspx?a=" + rows["Loan_ID"] + "\">More Info</a>" + "</td>");
          sb1.Append("</tr>");
        }
 
        else if (rows["Status"].ToString() == "Recommended")
        {
          sb2.Append("<tr>");
          sb2.Append("<td>" + i++ + "</td>");
          sb2.Append("<td>" + rows["Date_of_Application"] + "</td>");
          sb2.Append("<td>" + rows["Name"] + "</td>");
          sb2.Append("<td>" + rows["Bank_Name"] + "</td>");
          sb2.Append("<td>" + rows["Branch_Name"] + "</td>");
          sb2.Append("<td>" + rows["Account_Number"] + "</td>");
          sb2.Append("<td>" + rows["Loan_Amount"] + "</td>");
          sb2.Append("<td>" + rows["Purpose"] + "</td>");
          sb2.Append("<td style='color:blue;'>" + rows["Status"] + "</td>");
          sb2.Append("<td>" + "<a class='btn btn-primary' href=\"LoanStatus.aspx?a=" + rows["Loan_ID"] + "\">More Info</a>" + "</td>");
          sb2.Append("</tr>");
        }

        else if (rows["Status"].ToString() == "Approved")
        {
          sb3.Append("<tr>");
          sb3.Append("<td>" + i++ + "</td>");
          sb3.Append("<td>" + rows["Date_of_Application"] + "</td>");
          sb3.Append("<td>" + rows["Name"] + "</td>");
          sb3.Append("<td>" + rows["Bank_Name"] + "</td>");
          sb3.Append("<td>" + rows["Branch_Name"] + "</td>");
          sb3.Append("<td>" + rows["Account_Number"] + "</td>");
          sb3.Append("<td>" + rows["Loan_Amount"] + "</td>");
          sb3.Append("<td>" + rows["Purpose"] + "</td>");
          sb3.Append("<td style='color:green;'>" + rows["Status"] + "</td>");
          sb3.Append("<td>" + "<a class='btn btn-primary' href=\"LoanStatus.aspx?a=" + rows["Loan_ID"] + "\">More Info</a>" + "</td>");
          sb3.Append("</tr>");
        }
        else
        {
          sb4.Append("<tr>");
          sb4.Append("<td>" + i++ + "</td>");
          sb4.Append("<td>" + rows["Date_of_Application"] + "</td>");
          sb4.Append("<td>" + rows["Name"] + "</td>");
          sb4.Append("<td>" + rows["Bank_Name"] + "</td>");
          sb4.Append("<td>" + rows["Branch_Name"] + "</td>");
          sb4.Append("<td>" + rows["Account_Number"] + "</td>");
          sb4.Append("<td>" + rows["Loan_Amount"] + "</td>");
          sb4.Append("<td>" + rows["Purpose"] + "</td>");
          sb4.Append("<td style='color:red;'>" + rows["Status"] + "</td>");
          sb4.Append("<td>" + "<a class='btn btn-primary' href=\"LoanStatus.aspx?a=" + rows["Loan_ID"] + "\">More Info</a>" + "</td>");
          sb4.Append("</tr>");
        }
      }

      sb1.Append("</tbody>");
      show1.Text = sb1.ToString();
      sb2.Append("</tbody>");
      show2.Text = sb2.ToString();
      sb3.Append("</tbody>");
      show3.Text = sb3.ToString();
      sb4.Append("</tbody>");
      show4.Text = sb4.ToString();
    }
  }
  protected void Export_btn(object sender, EventArgs e)
  {
    // Set the license context for EPPlus
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

    try
    {

      // Define the SQL query to retrieve data from the database
      string getdata = "SELECT * FROM Loan_Application;";

      using (SqlCommand cmd = new SqlCommand(getdata, connection))
      {
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
            string filePath = Path.Combine(Server.MapPath("~/ListOfLoan.xlsx"));
            FileInfo fileInfo = new FileInfo(filePath);
            package.SaveAs(fileInfo);

            // Provide a success message or redirect to download the file
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=ListOfLoan.xlsx");
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
      Console.WriteLine("Error: " + ex.Message);
    }
  }

}
