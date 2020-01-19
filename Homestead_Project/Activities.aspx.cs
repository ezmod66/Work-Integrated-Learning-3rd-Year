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
    /*
This work is created by Ewan Tasker
Team member of Code Anonymous

"This is my own work and knowledge that has been applied in the code".

All the resources used for coding are indicated in the 'Çode References' section below:
- Name of the source
- Link where the source canbe accessed

*/


    /*
    Code References:

    Getting the current Date:
    
    https://stackoverflow.com/questions/6817266/how-to-get-the-current-date-without-the-time

    C# Asp.Net Gridview - Insert Update and Delete With SQL Server

    https://www.youtube.com/watch?v=vuoJeQ4L3WI


    Insert, Edit, Update, Delete Data in GridView Using Asp.Net C# | Hindi | Free Online Classes

    https://www.youtube.com/watch?v=pH7E-GM8HjE

    */

    public partial class Add_New_Activity : System.Web.UI.Page
	{

        public SqlConnection sqlConn = null;

        DB_Manager dbManager = new DB_Manager();
        SqlCommand sqlCmd;
        SqlDataReader dataReader;
        //Activity activity = new Activity();
        string entryFlag;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


            }

        }

        public Boolean TextValidation()
        {
            bool valid;
            if (activityName.Text == "")
            {
                activityName.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                activityName.BackColor = System.Drawing.Color.White;
                valid = true;
            }
            if (pointsAllocatedTxt.Text == "")
            {
                pointsAllocatedTxt.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                pointsAllocatedTxt.BackColor = System.Drawing.Color.White;
                valid = true;
            }

            if (uDateTxt.Text == "")
            {
                uDateTxt.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                uDateTxt.BackColor = System.Drawing.Color.White;
                valid = true;
            }
            if (uTimeTxt.Text == "")
            {
                uTimeTxt.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                uTimeTxt.BackColor = System.Drawing.Color.White;
                valid = true;
            }
            if (uPointsTxt.Text == "")
            {
                uPointsTxt.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }

            else
            {
                uPointsTxt.BackColor = System.Drawing.Color.White;
                valid = true;
            }

            return valid;
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
        AddActivity() is a button method for which the user decides to add an activity.
        When the user decides to add an activity the user will click the button and a form will come up.
        The form will display to the user:
        The information of the form will include all the required entries for which the user must enter.
        The system will load the facility and the status details that will allow the user to complete the entries to add an activity. 
        */
        protected void AddActivity(Object sender, EventArgs e)
        {
            newActlbl.Visible = false;
            viewActLbl.Visible = false;
            
            menuHeading.Visible = false;
            addActivityBtn.Visible = false;
            viewActivitiesBtn.Visible = false;
            UpdateActivityForm.Visible = false;
            AddActivityForm.Visible = true;
            exitViewingBtn.Visible = false;
            LoadFacilities();
            LoadActivityStatus();
            exitBtn.Visible = false;


        }

        /*
        This is a button method that is clicked if the user wants to view a list of activities that had been created. 
        */
        protected void viewActivitiesBtn_Click(object sender, EventArgs e)
        {
            newActlbl.Visible = false;
            viewActLbl.Visible = false;
            
            menuHeading.Visible = false;
            addActivityBtn.Visible = false;
            viewActivitiesBtn.Visible = false;
            viewActivitiesHeading.Visible = true;
            activityStatusOptions.Visible = true;
            UpdateActivityForm.Visible = false;
            AddActivityForm.Visible = false;
            exitViewingBtn.Visible = false;
            exitBtn.Visible = false;
            successLblMessage.Visible = false;
        }

        /*
        This is button method that will take the user back to the menu section/page for which the user can either add, update/view the activity, 
        or finish off the tasks by exiting the page back which will take the user back to the home page.
        */
        protected void exitViewingBtn_Click(object sender, EventArgs e)
        {
            newActlbl.Visible = true;
            viewActLbl.Visible = true;
          
            menuHeading.Visible = true;
            addActivityBtn.Visible = true;
            viewActivitiesBtn.Visible = true;
            viewActivitiesHeading.Visible = false;
            activityStatusOptions.Visible = false;
            activityList.Visible = false;
            UpdateActivityForm.Visible = false;
            AddActivityForm.Visible = false;
            exitViewingBtn.Visible = false;
            exitBtn.Visible = true;
            successLblMessage.Visible = false;
        }

        /*
        This is a button method that is applied when the user clicks the exit button if the user is done with tasks relating to the activity.
        The system will take the user back to the home page of the website.
        */
        protected void exitBtn_Click(object sender, EventArgs e)
        {
            newActlbl.Visible = false;
            viewActLbl.Visible = false;
            
            successLblMessage.Visible = false;
            Response.Redirect("HOME_PAGE.aspx");
        }



        /*
        SaveActivity() is a button method that is applied when the user wants to add an activity to the list.
        The details that will be saved as an activity record: Activity Name, facility Location, Inactive status, and point value of an activity.
        The system will have validation involved, which includes existing activity, empty entry, and date set for an activity.
        - If an activity exists from the database then a pop alert message will be shwon to the user that the user must either create a new activity or update the existing activity.
        - Empty entry labels will be shown visible to the user if empty entries has been made. The user must fill out the required entries that are indicated.
        The system will perform database functions mainly connection for opening and closing, and executing Insert statements, which will save the details of an activity to the database.
        The values that will be saved to the databae will be retrieved from methods that will return values with a valid data type. 
        */
        protected void SaveActivity(Object sender, EventArgs e)
        {

            entryFlag = EntryValidation();


            if (entryFlag == "Entry Required")
            {
                entryAOne.Visible = true;
                entryATwo.Visible = true;
                entryAThree.Visible = true;

            }
            else if (entryFlag == "Date Alert")
            {
                Response.Write("<script language=javascript>alert('You must enter a date that is after the Current Date.')</script>");

            }

            else
            {

                entryAOne.Visible = false;
                entryATwo.Visible = false;
                entryAThree.Visible = false;

                string existingActivityName = getActivityName(Convert.ToString(activityName.Text));

                if (Convert.ToString(activityName.Text).Equals(existingActivityName))
                {


                    Response.Write("<script language=javascript>alert('There's already an existing activity')</script>");


                }

                else
                {

                    try
                    {

                        int facilityID = 0;
                        int activityStatusID = 0;
                        string facilityName = "";
                        string activityStatusName = "";


                        MakeConnection();

                        string saveActivitySql = "insert into tbl_Activity(facilityID,activityStatusID,activityDescription,activityDate,activityTime,activityPointAllocation) values(@facilityID,@activityStatusID,@activityDescription,null,null,@activityPointAllocation)";
                        facilityName = Convert.ToString(addFacilityOptions.SelectedItem);
                        activityStatusName = "Inactive";
                        facilityID = getFacilityID(facilityName);
                        activityStatusID = getActivityStatusID(activityStatusName);
                        sqlConn.Open();




                        sqlCmd = new SqlCommand(saveActivitySql, sqlConn);
                        sqlCmd.Parameters.Add("@facilityID", SqlDbType.Int, 20).Value = facilityID;
                        sqlCmd.Parameters.Add("@activityStatusID", SqlDbType.Int, 20).Value = activityStatusID;
                        sqlCmd.Parameters.Add("@activityDescription", SqlDbType.VarChar, 30).Value = Convert.ToString(activityName.Text);

                        sqlCmd.Parameters.Add("@activityPointAllocation", SqlDbType.Int, 20).Value = Convert.ToInt32(pointsAllocatedTxt.Text);


                        sqlCmd.ExecuteNonQuery();
                        successLblMessage.Visible = true;
                        successLblMessage.Text = "Activity has been added";
                        errorLblMessage.Visible = false;
                        sqlConn.Close();
                        AddActivityForm.Visible = false;
                        menuHeading.Visible = true;
                        newActlbl.Visible = true;
                        viewActLbl.Visible = true;
                        
                        addActivityBtn.Visible = true;
                        viewActivitiesBtn.Visible = true;
                        exitBtn.Visible = true;
                        viewActivitiesHeading.Visible = false;


                    }
                    catch (Exception exception)
                    {
                        errorLblMessage.Visible = true;
                        errorLblMessage.Text = exception.Message;

                    }
                }
            }

        }


        /*
        
        This is a button method that is applied when the user decides to cancel the adding process of a new activity.
        The system will take the user back to the menu page/ section of the activities page.
             
        */
        protected void cancelAddBtn_Click(object sender, EventArgs e)
        {
            AddActivityForm.Visible = false;
            menuHeading.Visible = true;
            newActlbl.Visible = true;
            viewActLbl.Visible = true;
           
            addActivityBtn.Visible = true;
            viewActivitiesBtn.Visible = true;
            exitBtn.Visible = true;


        }

        /*
        This is the method that is used when the user selects the status of the activity.
        This occurs when the user decides that he/she wants to view the activities that are created. 
        The user wants to view the activities that are either active, Inactive, or show all.
        When this dropdownlist has been affected by the user interaction. The add, update and other components will be set invisible.
        The gridview (table) will be displayed to the user as well as populating the data onto the gridview.
        activityList is the gridview where the activity records will be populated into
        LoadActivities() is the method call that will perform functions to populate the records into the activityList gridview. 
        */
        protected void activityStatusOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string statusOption = Convert.ToString(activityStatusOptions.SelectedValue);
            activityList.Visible = true;
            successLblMessage.Visible = false;
            errorLblMessage.Visible = false;
            AddActivityForm.Visible = false;
            UpdateActivityForm.Visible = false;
            exitViewingBtn.Visible = true;
            LoadActivities(statusOption);

        }


        /*

         EditAnActivity method is applied when the user wants to update an activity from the list.
         Once the user clicks the Edit button next to the activity, the update form will display to the user with most the details shown on a the required entry boxes.
         Date and activity status won't be shown. So the user must make an entry for both activity and date if the status of an activity will be active else the user will just fill the activity status to be inactive. 

        */

        protected void EditAnActivity(object sender, EventArgs e)
        {

            try
            {

                AddActivityForm.Visible = false;
                UpdateActivityForm.Visible = true;

                LoadFacilities();
                LoadActivityStatus();
                int activityID = Convert.ToInt32((sender as LinkButton).CommandArgument);
                MakeConnection();
                sqlConn.Open();
                string sqlString = "select activityID, activityDescription, activityDate, statusDescription, activityTime, activityPointAllocation from tbl_Activity join tbl_Facility on tbl_Activity.facilityID = tbl_facility.facilityID join tbl_Activity_Status on tbl_Activity.activityStatusID = tbl_Activity_Status.activityStatusID where activityID = " + activityID;
                SqlCommand sqlCmd = new SqlCommand(sqlString, sqlConn);

                SqlDataReader dbReader = sqlCmd.ExecuteReader();

                activityIDTxt.Text = Convert.ToString(activityID);

                while (dbReader.Read())
                {

                    uActivityNameTxt.Text = Convert.ToString(dbReader["activityDescription"]);
                    uActivityNameExist.Text = Convert.ToString(dbReader["activityDescription"]);

                    if (Convert.ToString($"{dbReader["statusDescription"]}") == "Active")
                    {

                        string date = Convert.ToString($"{dbReader["activityDate"]}");
                        DateTime dt = DateTime.ParseExact(Convert.ToString($"{dbReader["activityDate"]}"), "yyyy/MM/dd hh:mm:ss", CultureInfo.InvariantCulture);
                        string dtTxt = dt.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                        uDateTxt.Text = dtTxt;
                        uTimeTxt.Text = Convert.ToString(dbReader["activityTime"]);

                    }

                    uPointsTxt.Text = Convert.ToString(dbReader["activityPointAllocation"]);


                }
                dbReader.Close();

            }
            catch (Exception exception)
            {


                Console.WriteLine(exception.Message);


            }

            sqlConn.Close();


        }


        /* 
        UpdateActivity() is a button method that is applied when the user wants to update an activity from the list.
        The system will apply validation to updating an activity, which includes empty entry, and date set for an activity.
            - Empty entry labels will be shown visible to the user if empty entries has been made. The user must fill out the required entries that are indicated.
            - If an activity has been set to either on a current date or a past date, then a pop alert message will be shown to the user that he/she must set the date that is later than the current date.
              Date validation doesn't apply to Inactive activities.
        The system will perform database functions mainly connection for opening and closing, and executing Insert statements, which will save the details of an activity to the database.
        A list of the activities will be displayed on a table.
        The values that will be saved to the databae will be retrieved from methods that will return values with a valid data type. 
        */
        protected void UpdateActivity(Object sender, EventArgs e)
        {
            entryFlag = EntryValidation();
            if (entryFlag == "Entry Required")
            {
                entryUOne.Visible = true;
                entryUTwo.Visible = true;
                entryUThree.Visible = true;
                entryUFour.Visible = true;
                entryUFive.Visible = true;
                entryUSix.Visible = true;

            }
            else if (entryFlag == "Date Alert")
            {
                Response.Write("<script language=javascript>alert('You must enter dates that are not before past dates.')</script>");

            }
            else
            {

                string existingActivity = getActivityName(uActivityNameTxt.Text.ToString());

                if (existingActivity != "")
                {

                    Response.Write($"<script language=javascript>alert('The activity already exists: {existingActivity}')</script>");

                }

                else
                {

                    entryUOne.Visible = false;
                    entryUTwo.Visible = false;
                    entryUThree.Visible = false;
                    entryUFour.Visible = false;
                    entryUFive.Visible = false;
                    entryUSix.Visible = false;


                    try
                    {
                        int facilityID = 0;
                        int activityStatusID = 0;
                        string facilityName = "";
                        string activityStatusName = "";




                        facilityName = Convert.ToString(updateFacilityOptions.SelectedItem);
                        activityStatusName = Convert.ToString(uActivityStatus.SelectedItem);
                        facilityID = getFacilityID(facilityName);
                        activityStatusID = getActivityStatusID(activityStatusName);


                        MakeConnection();
                        sqlConn.Open();

                        if (uActivityStatus.SelectedItem.ToString() != "Inactive")
                        {

                            string sqlString = "Update tbl_Activity Set facilityID = @facilityID, activityStatusID = @activityStatusID, activityDescription = @activityDescription, activityDate = @activityDate, activityTime = @activityTime, activityPointAllocation = @activityPointAllocation where activityID = " + Convert.ToInt32(activityIDTxt.Text.ToString());




                            sqlCmd = new SqlCommand(sqlString, sqlConn);
                            sqlCmd.Parameters.Add("@facilityID", SqlDbType.Int, 20).Value = facilityID;
                            sqlCmd.Parameters.Add("@activityStatusID", SqlDbType.Int, 20).Value = activityStatusID;
                            sqlCmd.Parameters.Add("@activityDescription", SqlDbType.VarChar, 30).Value = Convert.ToString(uActivityNameTxt.Text);


                            sqlCmd.Parameters.Add("@activityDate", SqlDbType.Date, 20).Value = Convert.ToDateTime(uDateTxt.Text);
                            sqlCmd.Parameters.Add("@activityTime", SqlDbType.Time, 20).Value = Convert.ToString(uTimeTxt.Text);


                            sqlCmd.Parameters.Add("@activityPointAllocation", SqlDbType.Int, 20).Value = Convert.ToInt32(uPointsTxt.Text);
                        }
                        else
                        {

                            string sqlString = "Update tbl_Activity Set facilityID = @facilityID, activityStatusID = @activityStatusID, activityDescription = @activityDescription, activityDate = null, activityTime = null, activityPointAllocation = @activityPointAllocation where activityID = " + Convert.ToInt32(activityIDTxt.Text.ToString());

                            sqlCmd = new SqlCommand(sqlString, sqlConn);
                            sqlCmd.Parameters.Add("@facilityID", SqlDbType.Int, 20).Value = facilityID;
                            sqlCmd.Parameters.Add("@activityStatusID", SqlDbType.Int, 20).Value = activityStatusID;
                            sqlCmd.Parameters.Add("@activityDescription", SqlDbType.VarChar, 30).Value = Convert.ToString(uActivityNameTxt.Text);
                            sqlCmd.Parameters.Add("@activityPointAllocation", SqlDbType.Int, 20).Value = Convert.ToInt32(uPointsTxt.Text);


                        }

                        sqlCmd.ExecuteNonQuery();
                        successLblMessage.Text = "The activity has been updated";
                        errorLblMessage.Text = "";

                        sqlConn.Close();
                        LoadActivities("Inactive");

                    }
                    catch (Exception exception)
                    {

                        Console.WriteLine(exception.Message);
                        //    errorLblMessage.Text = exception.Message;


                    }
                }
            }
            Calendar2.Visible = false;
            UpdateActivityForm.Visible = false;

        }

        /*
        This method applies to when the user decides to set the activity to be Inactive during the update process of an activity.
        If the user decides to set the status of the activity to be "Inactive" then the user doesn't need to fill out the date of an activity. 
        */
        protected void uActivityStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uActivityStatus.SelectedItem.ToString() == "Inactive")
            {

                uSelectDatebtn.Visible = false;
                dateHeadingLbl.Visible = false;
                Calendar2.Visible = false;
                uDateTxt.Visible = false;
                uSelectDatebtn.Visible = false;
                uTimeTxt.Visible = false;
                uTimeLabel.Visible = false;

            }
            else
            {
                uSelectDatebtn.Visible = true;
                dateHeadingLbl.Visible = true;
                Calendar2.Visible = true;
                uDateTxt.Visible = true;
                uTimeTxt.Visible = true;
                uTimeLabel.Visible = true;

            }
        }


        /*
        The cancelUpdate() method is used if the user decides to not make any updates then the form will disappear.
        This method applies to updating an activity.
        */
        protected void CancelUpdate(Object sender, EventArgs e)
        {

            UpdateActivityForm.Visible = false;

        }

        /*
        The LoadActivities() method is used to load a list of activities had been created.
        Validation is applied to when the user decides to see activities that are either active or inactive.
        The system will load the activities' details from the database after the system is connected to the database and the connection is open.
        Once the activities'details are loaded and displayed then the connection to the database will be closed.
             
        */
        public void LoadActivities(string activityOptions)
        {

            try
            {
                String sqlString = "";
                viewActivitiesHeading.Visible = true;
                DataTable dtTbl = new DataTable();
                MakeConnection();
                sqlConn.Open();
                if (activityOptions == "Active")
                {

                    sqlString = "select activityID, activityDescription, Format(activityDate,'yyyy/MM/dd') as activityDate, activityTime, facilityName, statusDescription, activityPointAllocation from tbl_Activity join tbl_Facility on tbl_Activity.facilityID = tbl_facility.facilityID " +
                    "join tbl_Activity_Status on tbl_Activity.activityStatusID = tbl_Activity_Status.activityStatusID where statusDescription = 'Active'";

                }
                else if (activityOptions == "Inactive")
                {


                    sqlString = "select activityID, activityDescription, Format(activityDate,'yyyy/MM/dd') as activityDate, activityTime, facilityName, statusDescription, activityPointAllocation from tbl_Activity join tbl_Facility on tbl_Activity.facilityID = tbl_facility.facilityID " +
                    "join tbl_Activity_Status on tbl_Activity.activityStatusID = tbl_Activity_Status.activityStatusID where statusDescription = 'Inactive'";

                }
                else
                {


                    sqlString = "select activityID, activityDescription, Format(activityDate,'yyyy/MM/dd') as activityDate, activityTime, facilityName, statusDescription, activityPointAllocation from tbl_Activity join tbl_Facility on tbl_Activity.facilityID = tbl_facility.facilityID " +
                    "join tbl_Activity_Status on tbl_Activity.activityStatusID = tbl_Activity_Status.activityStatusID";

                }

                SqlDataAdapter sqlAda = new SqlDataAdapter(sqlString, sqlConn);
                sqlAda.Fill(dtTbl);

                if (dtTbl.Rows.Count > 0)
                {

                    activityList.DataSource = dtTbl;
                    activityList.DataBind();

                }

                else
                {

                    dtTbl.Rows.Add(dtTbl.NewRow());
                    activityList.DataSource = dtTbl;
                    activityList.DataBind();
                    activityList.Rows[0].Cells.Clear();
                    activityList.Rows[0].Cells.Add(new TableCell());
                    activityList.Rows[0].Cells[0].ColumnSpan = dtTbl.Columns.Count;
                    activityList.Rows[0].Cells[0].Text = "No activities being listed";


                }

            }

            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
                //  errorLblMessage.Text = exception.Message;

            }

            sqlConn.Close();

        }

        /*
        The LoadFacilities() method is used to load a list of options for which the user can select.
        This applied when the user wants either add or update an activity.
        All the facility options will be shown on a dropdowlist inside both add or update forms of the activity
        */
        public void LoadFacilities()
        {

            if (AddActivityForm.Visible == true)
            {

                try
                {

                    MakeConnection();
                    sqlConn.Open();

                    String sqlString = "select facilityID,facilityName from tbl_Facility";

                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlString, sqlConn);

                    DataSet datasetFacilityList = new DataSet("FacilityList");
                    sqlDA.Fill(datasetFacilityList);

                    DataTable datatableFacilityList = datasetFacilityList.Tables[0];

                    addFacilityOptions.DataSource = datatableFacilityList;

                    addFacilityOptions.DataTextField = "facilityName";

                    addFacilityOptions.DataValueField = "facilityID";

                    addFacilityOptions.DataBind();


                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);

                }
            }
            else if (UpdateActivityForm.Visible == true)
            {

                try
                {
                    MakeConnection();
                    sqlConn.Open();

                    String sqlString = "select facilityID,facilityName from tbl_Facility";

                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlString, sqlConn);

                    DataSet datasetFacilityList = new DataSet("FacilityList");
                    sqlDA.Fill(datasetFacilityList);

                    DataTable datatableFacilityList = datasetFacilityList.Tables[0];

                    updateFacilityOptions.DataSource = datatableFacilityList;

                    updateFacilityOptions.DataTextField = "facilityName";

                    updateFacilityOptions.DataValueField = "facilityID";

                    updateFacilityOptions.DataBind();


                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);

                }

                sqlConn.Close();

            }


        }


        /*
            The LoadActivityStatus() method is used to load a list of status options for which the user can select.
            This includes 'Active' and 'Inactive'
            This applied when the user wants either add or update an activity.
            All the activity status options will be shown on a dropdowlist inside both add or update forms of the activity
        */
        public void LoadActivityStatus()
        {

            if (UpdateActivityForm.Visible == true)
            {

                try
                {
                    MakeConnection();
                    sqlConn.Open();
                    String sqlString = "select * from tbl_Activity_Status";
                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlString, sqlConn);

                    DataSet datasetFacilityList = new DataSet("TestList");
                    sqlDA.Fill(datasetFacilityList);

                    DataTable datatableFacilityList = datasetFacilityList.Tables[0];

                    uActivityStatus.DataSource = datatableFacilityList;

                    uActivityStatus.DataTextField = "statusDescription";

                    uActivityStatus.DataValueField = "activityStatusID";

                    uActivityStatus.DataBind();


                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);

                }

                sqlConn.Close();

            }

        }



        /*
        This method is applied when the user selects a date from a calender inside the "update form of an activity".
        It will display the date value into textview below the calender to show the user the date he/she had selected for an activity. 
        */
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            uDateTxt.Text = Calendar2.SelectedDate.ToShortDateString().ToString();
        }

        /*
        This is a button located inside the Update form of an activity.
        It be applied if the user sets an activity status to be active.
        */
        protected void uDateBtn_Click(object sender, EventArgs e)
        {

            Calendar2.Visible = true;

        }

        /* 
        This method is used to validate the user's entries.
        This includes:
        - Empty entry validation if the user has made an empty entry
        - Date validation if the user has set a date of an activity either before or after today's date  
        - It will store a validation value as a string value.

        The validation flag variable will store the following values if the system either picks up an entry issue:

        - "Entry Required" - If the user has made an empty entry on either or all of the required entries that are needed to be filled in
        - "Date Alert" - If the user has set a date before or on the today's date.
        -  "" - If the user has made the entries correctly according to the user's instructions

        This method applies adding and updating an activity, which the system will validate which form you are working on currently.
        The functionality is exactly the same for both adding and updating the activities.

        */
        public string EntryValidation()
        {

            string entryFlag = "";

            DateTime dt = DateTime.UtcNow.Date;
            string currentDate = dt.ToString("yyyy/MM/dd");

            if (AddActivityForm.Visible == true)
            {

                if (activityName.Text.Equals("") || addFacilityOptions.SelectedValue.Equals("") || pointsAllocatedTxt.Text.Equals(""))
                {
                    activityName.BackColor = System.Drawing.Color.LavenderBlush;
                    pointsAllocatedTxt.BackColor = System.Drawing.Color.LavenderBlush;
                    entryFlag = "Entry Required";

                }

                else
                {
                    activityName.BackColor = System.Drawing.Color.White;
                    pointsAllocatedTxt.BackColor = System.Drawing.Color.LavenderBlush;
                    entryFlag = "";


                }


            }
            else
            {


                if (uActivityStatus.SelectedItem.ToString() == "Inactive")
                {
                    if (uActivityNameTxt.Text.Equals("") || updateFacilityOptions.SelectedValue.Equals("") || uPointsTxt.Text.Equals(""))
                    {
                        uActivityNameTxt.BackColor = System.Drawing.Color.LavenderBlush;
                        entryFlag = "Entry Required";


                    }
                    else
                    {
                        uActivityNameTxt.BackColor = System.Drawing.Color.White;
                        entryFlag = "";

                    }

                }

                else
                {

                    if (uActivityNameTxt.Text.Equals("") || updateFacilityOptions.SelectedValue.Equals("") || uDateTxt.Text.Equals("") || uTimeTxt.Text.Equals("") || uPointsTxt.Text.Equals(""))
                    {
                        entryFlag = "Entry Required";
                    }

                    else
                    {
                        int todaysDateNumber = Convert.ToInt32(currentDate.Substring(8, 2));
                        int enteredDateNumber = Convert.ToInt32(Convert.ToString(uDateTxt.Text.Substring(8, 2)));

                        if (Convert.ToString(uDateTxt.Text).Equals(currentDate) || enteredDateNumber < todaysDateNumber)
                        {
                            entryFlag = "Date Alert";

                        }

                        else
                        {
                            entryFlag = "";

                        }
                    }

                }

            }

            return entryFlag;


        }

        /*
        getActivityName() method is used for validating of an existing activity.
        - This method will take name of the activity the user has entered as a string parameter.
        - The system will perform the database functionality to get activity name from the database.
          This includes:
          - Database connection.
          - Open and close the database connection.
          - Select statement to get the field's data from the table where the activity name exists.
          - Database reader will perform based on the SQL command that will take the Sql statement and the connection where the database is held and must collect the data from.
        - It will return a string value of the current activity if the activity exists else it will return an empty string value.

        This validation method is applied to both adding and updating an activity.
        */
        public string getActivityName(string existingActivity)
        {

            if (AddActivityForm.Visible == true)
            {
                string activityName = "";

                MakeConnection();
                sqlConn.Open();
                string sqlString = "select activityDescription from tbl_Activity where activityDescription = '" + existingActivity + "'";
                sqlCmd = new SqlCommand(sqlString, sqlConn);

                dataReader = sqlCmd.ExecuteReader();


                while (dataReader.Read())
                {

                    activityName = Convert.ToString($"{dataReader["activityDescription"]}");


                }

                dataReader.Close();
                sqlConn.Close();
                return activityName;
            }
            else
            {
                string activityName = "";

                if (existingActivity != uActivityNameExist.Text.ToString())
                {


                    MakeConnection();
                    sqlConn.Open();
                    string sqlString = "select activityDescription from tbl_Activity where activityDescription = '" + existingActivity + "'";
                    sqlCmd = new SqlCommand(sqlString, sqlConn);

                    dataReader = sqlCmd.ExecuteReader();


                    while (dataReader.Read())
                    {

                        activityName = Convert.ToString($"{dataReader["activityDescription"]}");


                    }

                    dataReader.Close();
                    sqlConn.Close();

                }
                else
                {

                    activityName = "";

                }

                return activityName;

            }

        }


        /* 
         This method is used to get the StatusID of an activity
         - It will take the status name as the required parameter
         - It will return the activityStatusID as an Integer value type;
         - This method applies to the required connection to the database as well as open and close the connection. 
         - It will take the value from the database by using the SQL Select statement
           read it from the database by executing the database reader
        */
        public int getActivityStatusID(string activityStatusName)
        {

            int activityStatusID = 0;

            try
            {
                MakeConnection();
                sqlConn.Open();
                string sqlString = "select activityStatusID from tbl_Activity_Status where statusDescription = '" + activityStatusName + "'";
                sqlCmd = new SqlCommand(sqlString, sqlConn);

                dataReader = sqlCmd.ExecuteReader();

                while (dataReader.Read())
                {

                    activityStatusID = Convert.ToInt32(dataReader["activityStatusID"]);

                }

                dataReader.Close();
                sqlConn.Close();

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);

            }


            return activityStatusID;

        }


        /* 
        This method is used to get the facilityID where the activity is located 
            - It will take the facility name as the required parameter
            - It will return the facilityID as an Integer value type;
            - This method applies to the required connection to the database as well as open and close the connection. 
            - It will take the value from the database by using the SQL Select statement
            read it from the database by executing the database reader
        */

        public int getFacilityID(string facilityName)
        {

            int facilityID = 0;

            try
            {
                MakeConnection();
                sqlConn.Open();
                string sqlString = "select facilityID from tbl_Facility where facilityName = '" + facilityName + "'";
                sqlCmd = new SqlCommand(sqlString, sqlConn);

                dataReader = sqlCmd.ExecuteReader();

                while (dataReader.Read())
                {

                    facilityID = Convert.ToInt32(dataReader["facilityID"]);

                }

                dataReader.Close();
                sqlConn.Close();
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);

            }

            return facilityID;

        }


    }
}