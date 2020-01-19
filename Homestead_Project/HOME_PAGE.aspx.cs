using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homestead_Project
{
    public partial class HOME_PAGE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime today = DateTime.Today;
                string date = today.ToString("yyyy/MM/dd");
                getMonthlyPlanner(date);
            }
        }

        public void getMonthlyPlanner(string date)
        {
            IList<Activity> activities = new DB_Manager().GetMonthlyActivities(date);
            IList<Birthdate> childData = new DB_Manager().GetMonthlyBirthdays(date);
            IList<CourtOrderDates> courtDate = new DB_Manager().GetMonthlyCourtDates(date);

            if (activities.Count > 0)
            {
                txtActivities.Text = activities.Count.ToString();

            } else
            {
                txtActivities.Text = "No Activities Available for this Month";
            }
            if (childData.Count > 0)
            {
                txtBirthdays.Text = childData.Count.ToString();
            } else
            {
                txtBirthdays.Text = "No Birthdays for this Month";
            }
            if (courtDate.Count > 0)
            {
                txtCourtDates.Text = courtDate.Count.ToString();

            } else
            {
                txtCourtDates.Text = "No Court Dates for this Month";
            }
        }

        protected void AddNewDetails(object sender, EventArgs e)
        {
            Response.Redirect("Add_Child_Details.aspx");
        }

        protected void ViewDetails(object sender, EventArgs e)
        {
            Response.Redirect("View_Child_Details.aspx");
        }

        protected void UpdateDetails(object sender, EventArgs e)
        {
            Response.Redirect("Update_Child_Details.aspx");
        }

        protected void OpenRegister(object sender, EventArgs e)
        {
            Response.Redirect("Daily_Attendance_Register.aspx");
        }

        protected void OpenAttendanceReport(object sender, EventArgs e)
        {
            Response.Redirect("AttendanceRecord_Per_Child.aspx");
        }

        protected void OpenAttendanceRecordForAllKids(object sender, EventArgs e)
        {
            Response.Redirect("Monthly_Attendance_Report.aspx");
        }

        protected void OpenCurrentActivities(object sender, EventArgs e)
        {
            Response.Redirect("Activities.aspx");
        }

        protected void OpenActivityAttendance(object sender, EventArgs e)
        {
            Response.Redirect("Activity_Attendance_Register.aspx");
        }

        protected void OpenPointSystem(object sender, EventArgs e)
        {
            Response.Redirect("Point_System.aspx");
        }

        protected void OpenPlanner(object sender, EventArgs e)
        {
            Response.Redirect("Planner.aspx");
        }


    }
}