using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homestead_Project
{
	public partial class AttendanceRecord_Per_Child : System.Web.UI.Page
	{
        SqlConnection SqlConn = null;
        protected void Page_Load(object sender, EventArgs e)
		{

            if (!IsPostBack)
            {
                MakeConnection();
                DropNamesList.SelectedIndex = 0;
                combo();

            }

        }

        private void MakeConnection()
        {
            // Getting the connection string from the web.config file
            //string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =| DataDirectory |\DBDemoDB.mdf; Integrated Security = True; Connect Timeout = 30";
            //string connectionString = @"Data Source = VCCT-STD-SQL01; Initial Catalog = 18199; Integrated Security = True";
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectString"].ToString();
            // Only create new connection object if it does not already exists

            if (SqlConn == null)
            {
                SqlConn = new SqlConnection(connectionString);
            }
        }

        public void fillGridview(string fileNumber)
        {
            if (fileNumber.Equals(""))
            {
                fileNumber = DropNamesList.SelectedValue;

                MakeConnection();

                DataTable dataTable = new DataTable();
                string sqlString = "select c.childName,c.childSurname,c.fileNumber,d.dailyAttendanceType, CONCAT(DATENAME(WEEKDAY,DAY(e.dailyDate)) + ' ' + DATENAME(DAY,e.dailyDate) + ' ' +  DATENAME(MONTH, e.dailyDate)+ ' '  ,  YEAR(e.dailyDate)) as datetime  from tbl_child c, tbl_DailyAttendanceStatus d, tbl_Daily_Attendance e where(c.fileNumber = e.fileNumber) and (d.dailyAttendanceStatusID = e.dailyAttendanceStatusID) and (c.fileNumber = '" + fileNumber + "')";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlString, SqlConn);
                dataAdapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();

                SqlConn.Close();
            }
            else
            {

                MakeConnection();

                DataTable dataTable = new DataTable();
                string sqlString = "select c.childName,c.childSurname,c.fileNumber,d.dailyAttendanceType, CONCAT(DATENAME(WEEKDAY,DAY(e.dailyDate)) + ' ' + DATENAME(DAY,e.dailyDate) + ' ' +  DATENAME(MONTH, e.dailyDate)+ ' '  ,  YEAR(e.dailyDate)) as datetime  from tbl_child c, tbl_DailyAttendanceStatus d, tbl_Daily_Attendance e where(c.fileNumber = e.fileNumber) and (d.dailyAttendanceStatusID = e.dailyAttendanceStatusID) and (c.fileNumber = '" + fileNumber + "')";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlString, SqlConn);
                dataAdapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();

                SqlConn.Close();


            }
        }

        protected void viewMonthlyReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("Monthly_Attendance_Report.aspx");
        }

        public void combo()
        {
            MakeConnection();
            try
            {
                MakeConnection();
                string sqlString = "select fileNumber, Concat(childName, ' ', childSurname) as childFullName from tbl_Child";
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet("tbl_Child");
                sqlDA.Fill(ds);

                DropNamesList.DataSource = ds;
                DropNamesList.DataTextField = "childFullName";
                DropNamesList.DataValueField = "fileNumber";
                DropNamesList.DataBind();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void DropNamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int index = DropNamesList.SelectedIndex;

            string fileNumber = DropNamesList.SelectedValue;
            fillGridview(fileNumber);


        }



    }
}