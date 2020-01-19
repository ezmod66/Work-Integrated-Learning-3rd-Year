using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homestead_Project
{
    public partial class Activity_Attendance_Register : System.Web.UI.Page
    {
        public SqlConnection sqlConn = null;

        DB_Manager dbManager = new DB_Manager();
        SqlCommand sqlCmd;
        SqlDataReader dbReader;
        int activityID;
        int attendanceStatusID;
        string fileNumber;
        int uReload = 0;
        int aReload = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }
        }

        public SqlConnection MakeConnection()
        {
            // Getting the connection string from the web.config file
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectString"].ToString();

            // Only create new connection object if it does not already exists
            if (sqlConn == null)
            {
                sqlConn = new SqlConnection(connectionString);
            }

            return sqlConn;
        }

        /*
        LoadDateInputs() method is used to the load the possible activity dates into the dropdownlist for which the user will be selecting
        It will populate the data to the either the add attendance or update attendance dropdownlist whenever the user decides to either add or update a child attendance
             
        */
        public void LoadDateInputs(string attendanceTaskType)
        {

            if (attendanceTaskType == "Add Attendance")
            {
                try
                {
                    String sqlString;
                    MakeConnection();
                    sqlConn.Open();

                    addDateActivityOption.Items.Add("Select a Date");
                    addActivityOption.Items.Add("Select an Activity");

                    sqlString = "SELECT distinct activityDate FROM tbl_Activity join tbl_Activity_Status on tbl_Activity.activityStatusID = tbl_Activity_Status.activityStatusID " +
                    "where statusDescription = 'active' ";

                    sqlCmd = new SqlCommand(sqlString, sqlConn);

                    dbReader = sqlCmd.ExecuteReader();


                    while (dbReader.Read())
                    {
                        DateTime dt = DateTime.ParseExact(Convert.ToString($"{dbReader["activityDate"]}"), "yyyy/MM/dd hh:mm:ss", CultureInfo.InvariantCulture);
                        string dtTxt = dt.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                        addDateActivityOption.Items.Add(dtTxt);


                    }

                    sqlConn.Close();
                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);

                }
            }
            else
            {

                try
                {
                    String sqlString;
                    MakeConnection();
                    sqlConn.Open();


                    updateActivityDateOption.Items.Add("Select a Date");
                    updateActivityOption.Items.Add("Select an Activity");

                    sqlString = "SELECT distinct attendanceDate FROM tbl_Activity_Attendance";

                    sqlCmd = new SqlCommand(sqlString, sqlConn);

                    dbReader = sqlCmd.ExecuteReader();


                    while (dbReader.Read())
                    {
                        DateTime dt = DateTime.ParseExact(Convert.ToString($"{dbReader["attendanceDate"]}"), "yyyy/MM/dd hh:mm:ss", CultureInfo.InvariantCulture);
                        string dtTxt = dt.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                        updateActivityDateOption.Items.Add(dtTxt);


                    }

                    sqlConn.Close();
                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);

                }


            }



        }


        /*
        This method is used to bind the possible activities dropdownlist for either add attendance or update the attendance.
        Possible activities will be populated to the dropdownlist based on a activity date the user had selected.
             
        */
        public void bindActivityInputs()
        {
            if (listOfChildren.Visible == true)
            {
                try
                {
                    String sqlString;


                    sqlString = "SELECT activityID,activityDescription, activityDate FROM tbl_Activity join tbl_Activity_Status on tbl_Activity.activityStatusID = tbl_Activity_Status.activityStatusID " +
                                            "where statusDescription = 'active' and activityDate = '" + addDateActivityOption.SelectedItem + "'";




                    MakeConnection();
                    sqlConn.Open();


                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlString, sqlConn);


                    DataSet activityList = new DataSet("activityList");
                    sqlDA.Fill(activityList);
                    DataTable datatableActivityList = activityList.Tables[0];


                    addActivityOption.DataSource = datatableActivityList;

                    addActivityOption.DataTextField = "activityDescription";

                    addActivityOption.DataValueField = "activityID";

                    addActivityOption.DataBind();

                    sqlConn.Close();
                    LoadChildren();
                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);

                }
            }
            else
            {

                try
                {
                    String sqlString;



                    sqlString = "SELECT distinct activityDescription, tbl_Activity_Attendance.activityID  FROM tbl_Activity_Attendance JOIN tbl_Activity ON tbl_Activity_Attendance.activityID = tbl_Activity.activityID join tbl_Activity_Status on tbl_Activity.activityStatusID = tbl_Activity_Status.activityStatusID" +
                         " WHERE attendanceDate = '" + updateActivityDateOption.SelectedItem + "'";
                    MakeConnection();
                    sqlConn.Open();


                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlString, sqlConn);


                    DataSet activityList = new DataSet("activityList");
                    sqlDA.Fill(activityList);
                    DataTable datatableActivityList = activityList.Tables[0];


                    updateActivityOption.DataSource = datatableActivityList;

                    updateActivityOption.DataTextField = "activityDescription";

                    updateActivityOption.DataValueField = "activityID";

                    updateActivityOption.DataBind();

                    sqlConn.Close();
                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);

                }

            }



        }

        /*
        Loadchildren() method is used to populate the details of each child into a gridview(table)
        The details for each child that be populated into the table is:
        name
        surname

        It will be populated based on the Eval() function that has been set for the first two column fields which are Labels. 
        */
        public void LoadChildren()
        {

            if (listOfChildren.Visible == true)
            {

                try
                {
                    DataTable dtTbl = new DataTable();
                    MakeConnection();
                    sqlConn.Open();

                    String sqlString = "SELECT childName, childSurname FROM tbl_Child";
                    SqlDataAdapter sqlAda = new SqlDataAdapter(sqlString, sqlConn);
                    sqlAda.Fill(dtTbl);

                    if (dtTbl.Rows.Count > 0)
                    {

                        listOfChildren.DataSource = dtTbl;
                        listOfChildren.DataBind();

                    }

                    else
                    {

                        dtTbl.Rows.Add(dtTbl.NewRow());
                        listOfChildren.DataSource = dtTbl;
                        listOfChildren.DataBind();
                        listOfChildren.Rows[0].Cells.Clear();
                        listOfChildren.Rows[0].Cells.Add(new TableCell());
                        listOfChildren.Rows[0].Cells[0].ColumnSpan = dtTbl.Columns.Count;
                        listOfChildren.Rows[0].Cells[0].Text = "No children being listed";


                    }

                    sqlConn.Close();

                }

                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);
                    //  errorLblMessage.Text = exception.Message;

                }

            }
            else
            {

                try
                {
                    DataTable dtTbl = new DataTable();
                    MakeConnection();
                    sqlConn.Open();

                    String sqlString = "select childName, childSurname, activityStatusDescription, activityPointAllocation " +
                        "from tbl_Activity_Attendance " +
                        "join tbl_Child on tbl_Activity_Attendance.fileNumber = tbl_Child.fileNumber ";

                    SqlDataAdapter sqlAda = new SqlDataAdapter(sqlString, sqlConn);
                    sqlAda.Fill(dtTbl);

                    if (dtTbl.Rows.Count > 0)
                    {

                        attendanceList.DataSource = dtTbl;
                        attendanceList.DataBind();

                    }

                    else
                    {

                        dtTbl.Rows.Add(dtTbl.NewRow());
                        attendanceList.DataSource = dtTbl;
                        attendanceList.DataBind();
                        attendanceList.Rows[0].Cells.Clear();
                        attendanceList.Rows[0].Cells.Add(new TableCell());
                        attendanceList.Rows[0].Cells[0].ColumnSpan = dtTbl.Columns.Count;
                        attendanceList.Rows[0].Cells[0].Text = "No children being listed";


                    }
                    sqlConn.Close();
                }

                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);
                    //  errorLblMessage.Text = exception.Message;

                }




            }





        }


        /*
        This is a menu option button when the user decides to make a children attendance register.
        All the ASP GUI components relating to the add attendance will be set to visibile for which the user can perform his/her actions 
        relating to add attendance for each child involving in an activity
        */
        protected void childrenList_Click(object sender, EventArgs e)
        {
            aActivityLbl.Visible = true;
            aDateLbl.Visible = true;
            addDateActivityOption.Visible = true;
            addActivityOption.Visible = true;
            listOfChildren.Visible = true;
            saveAttendanceBtn.Visible = true;
            btnCancelView.Visible = true;

            uDateLbl.Visible = false;
            uActivityLbl.Visible = false;
            updateActivityDateOption.Visible = false;
            updateActivityOption.Visible = false;
            attendanceList.Visible = false;
            searchAttendanceBtn.Visible = false;
            updateAttendanceBtn.Visible = false;
            btnUpdateCancel.Visible = false;


            childrenList.Visible = false;
            childAttendanceList.Visible = false;
            exitBtn.Visible = false;

            LoadDateInputs("Add Attendance");
            LoadChildren();


        }


        /*
        This is a menu option button when the user decides to view an attendance that has already been made.
        The user can also update a child's attendance if the user makes a mistake.
             
        */
        protected void childAttendanceList_Click(object sender, EventArgs e)
        {
            aActivityLbl.Visible = false;
            aDateLbl.Visible = false;
            addDateActivityOption.Visible = false;
            addActivityOption.Visible = false;
            listOfChildren.Visible = false;
            saveAttendanceBtn.Visible = false;
            btnCancelView.Visible = false;



            uDateLbl.Visible = true;
            uActivityLbl.Visible = true;
            updateActivityDateOption.Visible = true;
            btnUpdateCancel.Visible = true;
            updateActivityOption.Visible = true;
            searchAttendanceBtn.Visible = true;
            attendanceList.Visible = false;
            updateAttendanceBtn.Visible = false;

            childrenList.Visible = false;
            childAttendanceList.Visible = false;
            exitBtn.Visible = false;

            LoadDateInputs("Update Attendance");

        }

        /*
        This a menu option if the user finishes his/her tasks
        The system will take the user back to the Home Page           
        */
        protected void exitBtn_Click(object sender, EventArgs e)
        {


            Response.Redirect("HOME_PAGE.aspx");

        }

        /*
        This is a button method used when the user is happy with adding the attendance for all the children.
        The system will take the user back to the menu page of the attendance           
        */
        protected void saveAttendanceBtn_Click(object sender, EventArgs e)
        {
            childrenList.Visible = true;
            childAttendanceList.Visible = true;
            exitBtn.Visible = true;
            addActivityOption.Items.Clear();
            addDateActivityOption.Items.Clear();
            aActivityLbl.Visible = false;
            aDateLbl.Visible = false;
            addDateActivityOption.Visible = false;
            addActivityOption.Visible = false;
            listOfChildren.Visible = false;
            saveAttendanceBtn.Visible = false;
            btnCancelView.Visible = false;
            addActivityOption.ClearSelection();
            addDateActivityOption.ClearSelection();


        }

        /*
        This is a button method used when the user is happy with the attendance for all the children based on the activity and date, 
        as well as the updates the user has made for specific children's attendance details
        The system will take the user back to the menu page of the attendance           
        */
        protected void updateAttendanceBtn_Click(object sender, EventArgs e)
        {
            childrenList.Visible = true;
            childAttendanceList.Visible = true;
            exitBtn.Visible = true;
            updateActivityDateOption.Items.Clear();
            updateActivityOption.Items.Clear();
            uDateLbl.Visible = false;
            uActivityLbl.Visible = false;
            updateActivityDateOption.Visible = false;
            updateActivityOption.Visible = false;
            AttendanceHeadingLbl.Visible = false;
            attendHeadDateLbl.Visible = false;
            attendHeadActivityLbl.Visible = false;
            attendanceList.Visible = false;
            searchAttendanceBtn.Visible = false;
            updateAttendanceBtn.Visible = false;
            btnUpdateCancel.Visible = false;
            attendanceDateLbl.Visible = false;
            attendanceActivityLbl.Visible = false;


        }

        /*
        This is the dropdownlist affect where the user selects one of the dates the system has provided in the dropdownlist
        When the user selects a date, it will bind the activity dropdownlist that will be happening on that date.
        This occurs when the user makes an attendance register.
        */
        protected void addDateActivityOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindActivityInputs();

        }

        /*
        This is gridview(table) row data bound method.
        It is used to bind/populate the attendance status options into the dropdownlist (Attendance Status column)
        It will affect the gridview(table) when the user makes a children's attendance register.
        */
        protected void listOfChildren_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                try
                {
                    MakeConnection();

                    //        sqlConn.Open();

                    var dropdown = (DropDownList)e.Row.FindControl("listOfAttendanceOptions");
                    string sql = "select * from tbl_Activity_Attendance_Status";

                    sqlCmd = new SqlCommand(sql, sqlConn);

                    SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);

                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    sqlConn.Close();


                    dropdown.DataSource = dt;

                    dropdown.DataTextField = "activityAttendanceStatusType";

                    dropdown.DataValueField = "activityAttendanceStatusID";

                    dropdown.DataBind();

                    string selectedAttendance = DataBinder.Eval(e.Row.DataItem, "activityAttendanceStatusType").ToString();
                    dropdown.Items.FindByValue(selectedAttendance).Selected = true;


                }

                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);


                }



            }


        }

        /*
        This is a button event method when the wants to make an attendance for a specific child. It will be specified by the the row index of the child,
        as well enabling specific column fields to be edited.
        It will also refresh the the gridview(table) to enable the editing effect to happen.
         */
        protected void listOfChildren_RowEditing(object sender, GridViewEditEventArgs e)
        {
            saveAttendanceBtn.Visible = false;
            listOfChildren.EditIndex = e.NewEditIndex;
            LoadChildren();
        }


        /*
        This is a button event method used when the user wants to save the attendance of a child based on the activity and date as well as the attendance status of the child.
        This method will set the gridview(table) from edit into the readonly gridview. By making it happen it will use loadchildren method to refresh the gridview as well the data.
        The change that will be made is that the label in the attendance status will be set to status value for which the user had selected for the child.
        User entry validation applies inside this method.
        This includes:
        Empty entry - either date of the activity, activty name or both, for which the user hadn't selected.
            
        */
        protected void listOfChildren_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            bool emptyEntryFlag = emptyEntryValidation();

            if (emptyEntryFlag == true)
            {

                Response.Write($"<script language=javascript>alert('You hadn't made an empty or either date, the activity name or both. Date: {addDateActivityOption.SelectedItem.ToString()} Activity Name: {addActivityOption.SelectedItem.ToString()}')</script>");

                //  Response.Write($"<script language=javascript>alert('This student has already been recorded: Attendance date - {dtTxt} Activity - {addActivityOption.SelectedItem.ToString()}')</script>");

            }

            else
            {
                Label childNameLbl = listOfChildren.Rows[e.RowIndex].FindControl("aChildName") as Label;
                Label childSurnameLbl = listOfChildren.Rows[e.RowIndex].FindControl("aChildSurname") as Label;
                string childName = Convert.ToString(childNameLbl.Text);
                string childSurname = Convert.ToString(childSurnameLbl.Text);
                DropDownList selectedAttendance = listOfChildren.Rows[e.RowIndex].FindControl("listOfAttendanceOptions") as DropDownList;
                string attendanceDescription = Convert.ToString(selectedAttendance.SelectedItem);
                string dtTxt = Convert.ToString(addDateActivityOption.SelectedItem);


                bool existingEntry = getAttendanceEntry(childName, childSurname, addActivityOption.SelectedItem.ToString(), dtTxt);

                if (existingEntry == true)
                {

                    Response.Write($"<script language=javascript>alert('This student has already been recorded: Attendance date - {dtTxt} Activity - {addActivityOption.SelectedItem.ToString()}')</script>");

                }
                else
                {

                    fileNumber = getFileNumber(childName, childSurname);
                    activityID = getActivityID(Convert.ToString(addActivityOption.SelectedItem));
                    attendanceStatusID = getAttendanceStatusID(attendanceDescription);
                    int points = getActivityPointValue(attendanceDescription, Convert.ToString(addActivityOption.SelectedItem));



                    try
                    {

                        string sqlString = "insert into tbl_Activity_Attendance(activityID,fileNumber,attendanceStatusID,attendanceDate) values(@activityID,@fileNumber,@attendanceStatusID,@attendanceDate)";

                        MakeConnection();
                        sqlConn.Open();

                        sqlCmd = new SqlCommand(sqlString, sqlConn);

                        sqlCmd.Parameters.Add("@activityID", SqlDbType.Int).Value = activityID;
                        sqlCmd.Parameters.Add("@fileNumber", SqlDbType.VarChar, 30).Value = fileNumber;
                        sqlCmd.Parameters.Add("@attendanceStatusID", SqlDbType.Int).Value = attendanceStatusID;
                        sqlCmd.Parameters.Add("@attendanceDate", SqlDbType.Date).Value = dtTxt;

                        sqlCmd.ExecuteNonQuery();

                        sqlConn.Close();

                    }
                    catch (Exception exception)
                    {

                        Console.WriteLine(exception.Message);

                    }

                    try
                    {


                        string sqlString = "insert into tbl_Points(fileNumber,activityID,allocatedPointValue,reasonForPoints) values(@fileNumber,@activityID,@allocatedPointValue,@reasonForPoints)";

                        MakeConnection();
                        sqlConn.Open();

                        sqlCmd = new SqlCommand(sqlString, sqlConn);

                        sqlCmd.Parameters.Add("@fileNumber", SqlDbType.VarChar, 40).Value = fileNumber;
                        sqlCmd.Parameters.Add("@activityID", SqlDbType.Int).Value = activityID;
                        sqlCmd.Parameters.Add("@allocatedPointValue", SqlDbType.Int).Value = points;
                        sqlCmd.Parameters.Add("@reasonForPoints", SqlDbType.VarChar, 30).Value = attendanceDescription;

                        sqlCmd.ExecuteNonQuery();



                        sqlConn.Close();
                        listOfChildren.EditIndex = -1;

                        LoadChildren();
                        Label attendanceLbl = listOfChildren.Rows[e.RowIndex].FindControl("attendanceTxt") as Label;
                        attendanceLbl.Text = "Yes";
                        saveAttendanceBtn.Visible = true;

                    }

                    catch (Exception exception)
                    {

                        Console.WriteLine(exception.Message);

                    }


                }
            }


        }

        /*
        This is a cancel event button when the user decides to cancel the entry of an attendance for a child.
        The system will refresh the gridview from edit to read only as well refresh the children's details.
        */
        protected void listOfChildren_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            listOfChildren.EditIndex = -1;
            LoadChildren();
            saveAttendanceBtn.Visible = true;

        }


        /*
        This is the dropdownlist affect where the user selects one of the dates the system has provided in the dropdownlist
        When the user selects a date, it will bind the activity dropdownlist that will be happening on that date.
        This occurs when the user updates an attendance register.
        */
        protected void updateActivityDateOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindActivityInputs();

        }

        /*
        This is a search button method when the user wants to search an attendance list, containing all the children that have attended the activity.
        The system will search the attendance records from the database, the LoadChildAttendance() method performs the data search functions.
        The search will be based on activity date and the name of the activity.
        Empty Entry validation applies to the search process.

        */
        protected void searchAttendanceBtn_Click(object sender, EventArgs e)
        {

            bool emptyEntryFlag = emptyEntryValidation();
            if (emptyEntryFlag == true)
            {
                Response.Write("<script language=javascript>alert('You hadn't selected both date and the activity name')</script>");
                attendanceDateLbl.Visible = false;
                attendanceActivityLbl.Visible = false;
                attendanceList.Visible = false;
            }
            else
            {

                AttendanceHeadingLbl.Visible = true;
                attendHeadDateLbl.Visible = true;
                attendHeadActivityLbl.Visible = true;
                attendanceDateLbl.Visible = true;
                attendanceActivityLbl.Visible = true;
                updateAttendanceBtn.Visible = true;
                attendanceDateLbl.Text = updateActivityDateOption.SelectedItem.ToString();
                attendanceActivityLbl.Text = updateActivityOption.SelectedItem.ToString();
                attendanceList.Visible = true;
                LoadChildAttendance();
            }
        }


        /*
        This is gridview(table) row data bound method.
        It is used to bind/populate the attendance status options into the dropdownlist (Attendance Status column)
        It will affect the gridview(table) when the user update a children's attendance register.
        */
        protected void attendanceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                try
                {
                    MakeConnection();

                    //    sqlConn.Open();

                    var attendanceDropdown = (DropDownList)e.Row.FindControl("uListOfAttendanceOptions");
                    string sql = "select * from tbl_Activity_Attendance_Status";

                    sqlCmd = new SqlCommand(sql, sqlConn);

                    SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);

                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    sqlConn.Close();
                    attendanceDropdown.DataSource = dt;

                    attendanceDropdown.DataTextField = "activityAttendanceStatusType";

                    attendanceDropdown.DataValueField = "activityAttendanceStatusID";

                    attendanceDropdown.DataBind();

                    string selectedAttendance = DataBinder.Eval(e.Row.DataItem, "activityAttendanceStatusType").ToString();
                    attendanceDropdown.Items.FindByValue(selectedAttendance).Selected = true;





                }

                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);


                }


                try
                {
                   MakeConnection();

                    sqlConn.Open();
                    string dateTxt = attendanceDateLbl.Text.ToString();

                    var activityDropdown = (DropDownList)e.Row.FindControl("uListOfActivityOptions");
                    string activitySql = "select distinct activityDescription,tbl_Activity_Attendance.activityID from tbl_Activity_Attendance join tbl_Activity on tbl_Activity_Attendance.activityID = tbl_Activity.activityID where attendanceDate = '" + attendanceDateLbl.Text.ToString() + "'";


                    sqlCmd = new SqlCommand(activitySql, sqlConn);

                    SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);

                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    sqlConn.Close();


                    activityDropdown.DataSource = dt;

                    activityDropdown.DataTextField = "activityDescription";

                    activityDropdown.DataValueField = "activityID";

                    activityDropdown.DataBind();

                    string selectedActivity = DataBinder.Eval(e.Row.DataItem, "activityDescription").ToString();
                    activityDropdown.Items.FindByValue(selectedActivity).Selected = true;





                }

                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);


                }

            }
        }

        /*
        This is a button event method when the wants to update an attendance for a specific child. It will be specified by the the row index of the child,
        as well enabling specific column fields to be edited.
        It will also refresh the the gridview(table) to enable the editing effect to happen.
        */
        protected void attendanceList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            searchAttendanceBtn.Visible = false;
            updateAttendanceBtn.Visible = false;
            attendanceList.EditIndex = e.NewEditIndex;
            LoadChildAttendance();
        }


        /*
        This is a button event method used when the user wants to update the attendance of a child based on the activity and date as well as the attendance status of the child.
        This method will set the gridview(table) from edit into the readonly gridview. By making it happen it will use loadchildren method to refresh the gridview as well the data.
        The change that will be made is that the label in the attendance status will be set to status value for which the user had selected for the child.
        User entry validation applies inside this method.
        */
        protected void attendanceList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label childNameLbl = attendanceList.Rows[e.RowIndex].FindControl("uChildName") as Label;
            Label childSurnameLbl = attendanceList.Rows[e.RowIndex].FindControl("uChildSurname") as Label;
            string childName = Convert.ToString(childNameLbl.Text);
            string childSurname = Convert.ToString(childSurnameLbl.Text);
            DropDownList selectedAttendance = attendanceList.Rows[e.RowIndex].FindControl("uListOfAttendanceOptions") as DropDownList;
            string attendanceDescription = Convert.ToString(selectedAttendance.SelectedItem);
            DropDownList selectedActivity = attendanceList.Rows[e.RowIndex].FindControl("uListOfActivityOptions") as DropDownList;
            string activityName = Convert.ToString(updateActivityOption.SelectedItem);
            string dtTxt = Convert.ToString(updateActivityDateOption.SelectedItem);

            fileNumber = getFileNumber(childName, childSurname);
            activityID = getActivityID(activityName);
            attendanceStatusID = getAttendanceStatusID(attendanceDescription);
            int points = getActivityPointValue(attendanceDescription, Convert.ToString(activityName));


            try
            {

                string sqlString = "Update tbl_Activity_Attendance set attendanceStatusID = @attendanceStatusID, attendanceDate = @attendanceDate";

                MakeConnection();
                sqlConn.Open();

                sqlCmd = new SqlCommand(sqlString, sqlConn);

                sqlCmd.Parameters.Add("@attendanceStatusID", SqlDbType.Int).Value = attendanceStatusID;
                sqlCmd.Parameters.Add("@attendanceDate", SqlDbType.Date).Value = dtTxt;

                sqlCmd.ExecuteNonQuery();

                sqlConn.Close();

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);

            }

            try
            {


                string sqlString = "Update tbl_Points set allocatedPointValue = @allocatedPointValue, reasonForPoints = @reasonForPoints where fileNumber = '" + fileNumber + "'";

                MakeConnection();
                sqlConn.Open();

                sqlCmd = new SqlCommand(sqlString, sqlConn);

                sqlCmd.Parameters.Add("@allocatedPointValue", SqlDbType.Int).Value = points;
                sqlCmd.Parameters.Add("@reasonForPoints", SqlDbType.VarChar, 30).Value = attendanceDescription;

                sqlCmd.ExecuteNonQuery();



                sqlConn.Close();
                attendanceList.EditIndex = -1;
                LoadChildAttendance();
                Label activityUpdatedLbl = attendanceList.Rows[e.RowIndex].FindControl("activityUpdateTxt") as Label;
                activityUpdatedLbl.Text = "Yes";
                searchAttendanceBtn.Visible = true;
                updateAttendanceBtn.Visible = true;

            }

            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);

            }




        }


        /*
        This is a cancel event button when the user decides to cancel the update entry of an attendance for a child.
        The system will refresh the gridview from edit to read only as well refresh the attendance list details.
        */
        protected void attendanceList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            attendanceList.EditIndex = -1;
            LoadChildAttendance();

        }



        /*
        This is a boolean method used to validate the date and activity for both add and modidfy attendance tasks.
        Validation implies if the user either makes an empty.
        This includes if the user either selects the "Select a Date" or "Select an Activity" as wrong/empty entry.
        It will set the boolean variable value to true if an empty or wrong entry has been made.
        It will set the boolean variable value to false if there are no empty nor wrong entry has been made.
        It will return a boolean value to the RowUpdating methods for both Add and Update Attendance tasks, which is "emptyEntryMade".

        */
        public bool emptyEntryValidation()
        {
            bool emptyEntryMade = false;
            if (searchAttendanceBtn.Visible == true)
            {

                if (updateActivityDateOption.SelectedItem.ToString() == "Select a Date" || updateActivityOption.SelectedItem.ToString() == "Select an Activity")
                {

                    emptyEntryMade = true;

                }
            }
            else
            {

                if (addDateActivityOption.SelectedItem.ToString() == "Select a Date" || addActivityOption.SelectedItem.ToString() == "Select an Activity")
                {

                    emptyEntryMade = true;

                }


            }


            return emptyEntryMade;



        }

        /*
        This is a boolean Validation method used to validate if there's an existing attendance entry of a child.
        EntryMade is a boolean flag that will set the value to either true or false
        The boolean variable will be set to true if there's an existing attendance entry been made on the child.
        The variable will only be set to false if there's no existing attendance entry been made on the child.
        */
        public bool getAttendanceEntry(string name, string surname, string activityName, string activityDate)
        {

            bool entryMade = false;

           MakeConnection();
            sqlConn.Open();
            string sqlString = "select childName, childSurname from tbl_Activity_Attendance join tbl_Activity on tbl_Activity_Attendance.activityID = tbl_Activity.activityID join tbl_Child on tbl_Activity_Attendance.fileNumber = tbl_Child.fileNumber where childName = '" + name + "' and childSurname = '" + surname + "' and activityDescription = '" + activityName + "'" + " and attendanceDate = '" + activityDate + "'";
            sqlCmd = new SqlCommand(sqlString, sqlConn);

            dbReader = sqlCmd.ExecuteReader();


            while (dbReader.Read())
            {

                entryMade = true;


            }
            dbReader.Close();
            sqlConn.Close();

            return entryMade;
        }


        /*
        This method is used to get the activity ID from the the activity table.
        It will take the activty name as the required parameter to get the activity ID.
        It will return the ID value as int value type.
        The variable that will be returning the int value is "activityID".
        */
        public int getActivityID(string activityName)
        {
            int activityID = 0;

            try
            {
                MakeConnection();
                sqlConn.Open();

                string sqlString = "select activityID from tbl_Activity where activityDescription = '" + activityName + "'";
                sqlCmd = new SqlCommand(sqlString, sqlConn);

                dbReader = sqlCmd.ExecuteReader();

                while (dbReader.Read())
                {

                    activityID = Convert.ToInt32(dbReader["activityID"]);

                }

                dbReader.Close();

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);

            }
            sqlConn.Close();
            return activityID;

        }

        /*
        This method is used to get the File number of a child from the the tbl_Child table.
        It will take the child's name and surname as the required parameter to get the file number.
        It will return the file number value as a string value type.
        The string variable that will be returning the value is "childFileNumber".
        */
        public string getFileNumber(string childName, string childSurname)
        {
            string childFileNumber = "";
            try
            {
                MakeConnection();
                sqlConn.Open();


                string sqlString = "select fileNumber from tbl_Child where childName = '" + childName + "' and childSurname = '" + childSurname + "'";
                sqlCmd = new SqlCommand(sqlString, sqlConn);

                dbReader = sqlCmd.ExecuteReader();

                while (dbReader.Read())
                {

                    childFileNumber = Convert.ToString(dbReader["fileNumber"]);

                }

                dbReader.Close();

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);

            }
            sqlConn.Close();
            return childFileNumber;

        }
        /*
        This method is used to get the attendance status ID of an attendance from tbl_Activity_Attendance table.
        It will take the attendance description as the string required parameter to get attendance status ID.
        It will return the attendance status ID value as aN int value type.
        The int variable that will be returning the value is "attendanceStatusID".
        */
        public int getAttendanceStatusID(string attendanceDescription)
        {
            int attendanceStatusID = 0;
            try
            {
               MakeConnection();
                sqlConn.Open();


                string sqlString = "select activityAttendanceStatusID from tbl_Activity_Attendance_Status where activityAttendanceStatusType = '" + attendanceDescription + "'";
                sqlCmd = new SqlCommand(sqlString, sqlConn);

                dbReader = sqlCmd.ExecuteReader();

                while (dbReader.Read())
                {

                    attendanceStatusID = Convert.ToInt32(dbReader["activityAttendanceStatusID"]);

                }

                dbReader.Close();
                sqlConn.Close();

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);

            }

            return attendanceStatusID;

        }

        /*
        This method is used to get the attendance points value of a specific activity  from tbl_Activity table.
        It will take the attendance option, and activty name as the required parameters to get the point for the child's attendance.
        It will return the attendance points value as an int(number) value type.
        The int variable that will be returning the value is "pointValue".
        Validation will applied to this method.
        The validation is based on the child's attendance:
        - positive(+) points added to the child's total points if the child had attended the activity 
        - minus(-) the point value from the child's total points if the child is absent/ hadn't attend the activity.
        - 0 points if the child is excused from the activity
        */
        public int getActivityPointValue(string activityAttendanceOption, string activityName)
        {

            int pointValue = 0;

            try
            {

                MakeConnection();
                sqlConn.Open();

                string sqlString = "select activityPointAllocation from tbl_Activity where activityDescription = '" + activityName + "'";
                sqlCmd = new SqlCommand(sqlString, sqlConn);

                dbReader = sqlCmd.ExecuteReader();

                while (dbReader.Read())
                {



                    if (activityAttendanceOption == "Present")
                    {

                        pointValue = Convert.ToInt32(dbReader["activityPointAllocation"]);

                    }
                    else if (activityAttendanceOption == "Did not Attend")
                    {

                        pointValue = -Convert.ToInt32(dbReader["activityPointAllocation"]);


                    }
                    else
                    {

                        pointValue = 0;

                    }

                }

                dbReader.Close();
                sqlConn.Close();

            }
            catch (Exception exception)
            {

                Console.WriteLine("Error: " + exception.Message);


            }


            return pointValue;

        }

        /*
        This method is used to load the attendance list based on the activity date and the name of the activity the user is searching an attendance for.
        The system will load the data from the database and populate it into the gridview(table) for which the user can see the exact information on activty attendance on that date.
        */
        public void LoadChildAttendance()
        {

            try
            {

                DataTable dtTbl = new DataTable();
                int activityID = getActivityID(Convert.ToString(updateActivityOption.SelectedItem));
                MakeConnection();
                sqlConn.Open();

                string sqlString = "select pointsID, childName, childSurname, allocatedPointValue, reasonForPoints from tbl_Points join tbl_Activity on tbl_Points.activityID = tbl_Activity.activityID " +
                    "join tbl_Child on tbl_Points.fileNumber = tbl_Child.fileNumber " +
                    "where tbl_Activity.activityID = " + activityID + "";


                SqlDataAdapter sqlAda = new SqlDataAdapter(sqlString, sqlConn);
                sqlAda.Fill(dtTbl);

                if (dtTbl.Rows.Count > 0)
                {

                    attendanceList.DataSource = dtTbl;
                    attendanceList.DataBind();

                }

                else
                {

                    dtTbl.Rows.Add(dtTbl.NewRow());
                    attendanceList.DataSource = dtTbl;
                    attendanceList.DataBind();
                    attendanceList.Rows[0].Cells.Clear();
                    attendanceList.Rows[0].Cells.Add(new TableCell());
                    attendanceList.Rows[0].Cells[0].ColumnSpan = dtTbl.Columns.Count;
                    attendanceList.Rows[0].Cells[0].Text = "No activities being listed";


                }



            }

            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);

            }

        }

        protected void cancelUpdate_Click(object sender, EventArgs e)
        {
            childrenList.Visible = true;
            childAttendanceList.Visible = true;
            exitBtn.Visible = true;

            updateActivityDateOption.Items.Clear();
            updateActivityOption.Items.Clear();
            uDateLbl.Visible = false;
            uActivityLbl.Visible = false;
            updateActivityDateOption.Visible = false;
            updateActivityOption.Visible = false;
            AttendanceHeadingLbl.Visible = false;
            attendHeadDateLbl.Visible = false;
            attendHeadActivityLbl.Visible = false;
            attendanceList.Visible = false;
            searchAttendanceBtn.Visible = false;
            updateAttendanceBtn.Visible = false;
            btnUpdateCancel.Visible = false;
            attendanceDateLbl.Visible = false;
            attendanceActivityLbl.Visible = false;

        }

        protected void cancelView_CLICK(object sender, EventArgs e)
        {
            childrenList.Visible = true;
            childAttendanceList.Visible = true;
            exitBtn.Visible = true;

            childrenList.Visible = true;
            childAttendanceList.Visible = true;
            exitBtn.Visible = true;
            addActivityOption.Items.Clear();
            addDateActivityOption.Items.Clear();
            aActivityLbl.Visible = false;
            aDateLbl.Visible = false;
            addDateActivityOption.Visible = false;
            addActivityOption.Visible = false;
            listOfChildren.Visible = false;
            saveAttendanceBtn.Visible = false;
            btnCancelView.Visible = false;
            addActivityOption.ClearSelection();
            addDateActivityOption.ClearSelection();
        }
    }

    }
