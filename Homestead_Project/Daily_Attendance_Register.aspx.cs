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
    public partial class Daily_Attendance_Register : System.Web.UI.Page
    {
        SqlConnection SqlConn = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            txtDate.Text = today.ToLongDateString();
            MakeConnection();
            if (!IsPostBack)
            {
                fillGridview();
                GridView1.SelectedIndex = 0;

            }
        }

        //DB CONNECTION
        private void MakeConnection()
        {
            // Getting the connection string from the web.config file
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectString"].ToString();

            // Only create new connection object if it does not already exists
            if (SqlConn == null)
            {
                SqlConn = new SqlConnection(connectionString);

            }
        }

        //the data gid view will be filled with data from databse
        public void fillGridview()
        {
            MakeConnection();
            //Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT fileNumber,childName,childSurname FROM tbl_Child", SqlConn);
            dataAdapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            SqlConn.Close();
        }

        //enable user to edit the rows and columns and also giving the user options for saving dat to the database
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            fillGridview();
        }

        /*
        * enable user to edit the rows and columns and also giving the user options for saving dat to the database
        * 
        */
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label fileNumber = GridView1.Rows[e.RowIndex].FindControl("fileNumber") as Label;


            string file = Convert.ToString(fileNumber.Text);
            DateTime date = Convert.ToDateTime(txtDate.Text);

            DropDownList selectedAttendance = GridView1.Rows[e.RowIndex].FindControl("dropAttendace") as DropDownList;
            int attendanceDescription = Convert.ToInt32(selectedAttendance.SelectedIndex);


            try
            {
                SqlConn.Open();
                String sqlSelectQuery = "INSERT into tbl_Daily_Attendance values (@fileNumber, @dailyAttendanceStatusID, @dailyDate)";
                SqlCommand cmd = new SqlCommand(sqlSelectQuery, SqlConn);

                cmd.Parameters.Add("@dailyDate", SqlDbType.Date).Value = date;
                cmd.Parameters.Add("@fileNumber", SqlDbType.VarChar, 40).Value = file;
                cmd.Parameters.Add("@dailyAttendanceStatusID", SqlDbType.Int).Value = attendanceDescription;

                cmd.ExecuteNonQuery();
                SqlConn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            GridView1.EditIndex = -1;
            fillGridview();


        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            fillGridview();


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("HOME_PAGE.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataTable dt = new DataTable();
                    MakeConnection();
                    SqlConn.Open();
                    var dropdown = (DropDownList)e.Row.FindControl("dropAttendace");
                    string sql = "SELECT * FROM tbl_DailyAttendanceStatus";

                    SqlCommand cmd = new SqlCommand(sql, SqlConn);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);


                    dataAdapter.Fill(dt);

                    SqlConn.Close();

                    dropdown.DataSource = dt;

                    dropdown.DataTextField = "dailyAttendanceType";

                    dropdown.DataValueField = "dailyAttendanceStatusID";

                    dropdown.DataBind();

                    string selectedAttendance = DataBinder.Eval(e.Row.DataItem, "dailyAttendanceType").ToString();
                    dropdown.Items.FindByValue(selectedAttendance).Selected = true;




                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }


        }
    }
}