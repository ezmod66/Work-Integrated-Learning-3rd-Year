using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homestead_Project
{
    public partial class Planner : System.Web.UI.Page
    {
        String selectDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            Calendar1.TodaysDate = today;
            Calendar1.SelectedDate = Calendar1.TodaysDate;

			selectDate = Calendar1.SelectedDate.ToString("yyyy/MM/dd");

			IList<Activity> activities = new DB_Manager().GetDailyActivities(selectDate);
			IList<Birthdate> childData = new DB_Manager().GetDailyBirthdays(selectDate);
			IList<CourtOrderDates> courtDate = new DB_Manager().GetDailyCourtDates(selectDate);

			if (activities.Count > 0 && childData.Count > 0)
			{
				lblDate.Text = null;
				foreach (Activity activityList in activities)
				{
					DateTime startdate = Convert.ToDateTime(activityList.ActivityDate);
					startdate.ToString("dddd, dd MMMM yyyy");
					lblDate.Text += activityList.ActivityDescription + "        " + startdate.ToString("dddd, dd MMMM yyyy") + "        " + activityList.ActivityTime + "<br/>";
				}

			}
			else
			{
				lblDate.Text = "No Activities for this day!";
			}

			if (childData.Count > 0)
			{
				lblLocation.Text = null;
				foreach (Birthdate child in childData)
				{
					DateTime startdate = Convert.ToDateTime(child.Dob);
					startdate.ToString("dddd, dd MMMM yyyy");
					lblLocation.Text += child.FirstName + "        " + child.Surname + "        " + startdate.ToString("dddd, dd MMMM yyyy");
				}
			}
			else
			{
				lblLocation.Text = "No Birthdays for today";
			}

			if (courtDate.Count > 0)
			{
				lblTime.Text = null;
				foreach (CourtOrderDates court in courtDate)
				{
					DateTime date = Convert.ToDateTime(court.CourtOrderDate);
					date.ToString("dddd, dd MMMM yyyy");
					lblTime.Text += court.FirstName + " , " + court.Surname + " , " + date.ToString("dddd, dd MMMM yyyy");
				}
			}
			else
			{
				lblTime.Text = "No Court Date";
			}


		}

       protected void ShowDiv(object sender, EventArgs e)
        {
            
            schedule.Visible = true;

            DateTime today = DateTime.Today;
            selectDate = today.ToString("yyyy/MM/dd");
            IList<Activity> activities = new DB_Manager().GetMonthlyActivities(selectDate);
            IList<Birthdate> childData = new DB_Manager().GetMonthlyBirthdays(selectDate);
            IList<CourtOrderDates> courtDate = new DB_Manager().GetMonthlyCourtDates(selectDate);

            if (activities.Count > 0)
            {
                txtActivities.Text = null;
                foreach (Activity activityList in activities)
                {
                    DateTime startdate = Convert.ToDateTime(activityList.ActivityDate);
                    startdate.ToString("dddd, dd MMMM yyyy");
                    txtActivities.Text += activityList.ActivityDescription + "        " + startdate.ToString("dddd, dd MMMM yyyy") + "        " + activityList.ActivityTime + "<br/>";
                }

                

            }
            if (childData.Count > 0)
            {
                txtBirthdays.Text = null;
                foreach (Birthdate child in childData)
                {
                    DateTime startdate = Convert.ToDateTime(child.Dob);
                    startdate.ToString("dddd, dd MMMM yyyy");
                    txtBirthdays.Text += child.FirstName + "        " + child.Surname + "        " + startdate.ToString("dddd, dd MMMM yyyy") + "<br/>";
                }

            }
            if (courtDate.Count > 0)
            {
                txtCourtDates.Text = null;
                foreach (CourtOrderDates court in courtDate)
                {
                    DateTime date = Convert.ToDateTime(court.CourtOrderDate);
                    date.ToString("dddd, dd MMMM yyyy");
                    txtCourtDates.Text += court.FirstName + " " + court.Surname + " , " + date.ToString("dddd, dd MMMM yyyy") + "<br/>";
                }
            }
            
        }

        protected void NewActivity(Object sender, EventArgs e)
        {
            Response.Redirect("Activities.aspx");
        }

  


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime myDate = new DateTime();
            myDate = Calendar1.SelectedDate;
            selectDate = myDate.ToString("yyyy/MM/dd");
            lblDate.Text = null;
            lblLocation.Text = null;
            lblTime.Text = null;

            IList<Activity> activities = new DB_Manager().GetDailyActivities(selectDate);
            IList<Birthdate> childData = new DB_Manager().GetDailyBirthdays(selectDate);
			IList<CourtOrderDates> courtDate = new DB_Manager().GetDailyCourtDates(selectDate);

            if (activities.Count > 0)
            {
                lblDate.Text = null;
                foreach (Activity activityList in activities)
                {
                    DateTime startdate = Convert.ToDateTime(activityList.ActivityDate);
                    startdate.ToString("dddd, dd MMMM yyyy");
                    lblDate.Text += activityList.ActivityDescription + "        " + startdate.ToString("dddd, dd MMMM yyyy") + "        " + activityList.ActivityTime + "<br/>";
                }
                
            } else
            {
                lblDate.Text = "No Activities for this day!";
            }

            if (childData.Count > 0)
            {
                lblLocation.Text = null;
                foreach (Birthdate child in childData)
                {
                    DateTime startdate = Convert.ToDateTime(child.Dob);
                    startdate.ToString("dddd, dd MMMM yyyy");
                    lblLocation.Text += child.FirstName + "        " + child.Surname + "        " + startdate.ToString("dddd, dd MMMM yyyy") + "\n";
                }
            } else
            {
                lblLocation.Text = "No Birthdays for today";
            }

			if(courtDate.Count > 0)
			{
				lblTime.Text = null;
				foreach(CourtOrderDates court in courtDate)
				{
					DateTime date = Convert.ToDateTime(court.CourtOrderDate);
					date.ToString("dddd, dd MMMM yyyy");
					lblTime.Text += court.FirstName + " , " + court.Surname + " , " + date.ToString("dddd, dd MMMM yyyy");
				}
			} else
			{
				lblTime.Text = "No Court Date";
			}
            
        }
    }
}