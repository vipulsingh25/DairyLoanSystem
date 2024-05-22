using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BankPortal_RejectedLoan : System.Web.UI.Page
{
  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString);
  DataTable dt = new DataTable();
  protected void Page_Load(object sender, EventArgs e)
  {
    string getdata = "Select * from Loan_Application where Status = 'Rejected';";
    SqlCommand cmds = new SqlCommand(getdata, connection);
    SqlDataAdapter ad = new SqlDataAdapter(cmds);
    ad.Fill(dt);
    if (dt.Rows.Count > 0)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("<thead><tr><th>Sno</th><th>Date & Time</th><th>Bank Name</th><th>Branch Name</th><th>Account Number</th><th>Loan Amount</th><th>Purpose</th><th>Status</th></tr></thead> ");
      sb.Append("<tbody>");
      int i = 1;
      foreach (DataRow rows in dt.Rows)
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

      sb.Append("</tbody>");

      show.Text = sb.ToString();
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
