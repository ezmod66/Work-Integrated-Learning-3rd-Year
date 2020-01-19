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
    public partial class Monthly_Attendance_Report : System.Web.UI.Page
    {
        SqlConnection SqlConn = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            MakeConnection();
            if (!IsPostBack)
            {
                MonthCombo.SelectedIndex = 0;

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

        protected void viewAttendanceRecordPerChild_Click(object sender, EventArgs e)
        {
            Response.Redirect("AttendanceRecord_Per_Child.aspx");

        }

        /*Method to fill the grid view after the user select a month from the combobox
         * displays the child details according to the month slected in the combo box
         */
        public void fillGridview(int month)
        {
            MakeConnection();

            
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select c.childName,c.childSurname,c.fileNumber,d.dailyAttendanceType, CONCAT(DATENAME(WEEKDAY,DAY(e.dailyDate)) + ' ' + DATENAME(DAY,e.dailyDate) + ' ' +  DATENAME(MONTH, e.dailyDate) + ' '  ,  YEAR(e.dailyDate)) as datetime  from tbl_child c, tbl_DailyAttendanceStatus d, tbl_Daily_Attendance e where(c.fileNumber = e.fileNumber) and (d.dailyAttendanceStatusID = e.dailyAttendanceStatusID) and (Month(e.dailyDate) = " + month + ")", SqlConn);
            dataAdapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();

            SqlConn.Close();

        }

        //this is where the gridview is loaded and refreshed when a combo box selection is made
        protected void MonthCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeConnection();
            SqlConn.Open();

            Session["month"] = MonthCombo.SelectedIndex + 1;


            try
            {


                 fillGridview(Convert.ToInt32(Session["month"]));

                SqlConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }

    }
}