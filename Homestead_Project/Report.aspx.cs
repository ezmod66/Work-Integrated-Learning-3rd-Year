using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homestead_Project
{
    public partial class Report : System.Web.UI.Page
    {
        DB_Manager manager = new DB_Manager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IList<Facility> facilities = new DB_Manager().GetFacicilities();
                if (facilities != null)
                {
                    cbFalicities.DataSource = facilities;
                    cbFalicities.DataTextField = "FacilityName";
                    cbFalicities.DataValueField = "FacilityID";
                    cbFalicities.DataBind();
                }
            }

            Session["facility"] = Convert.ToInt32(cbFalicities.SelectedValue);
        }

        protected void cbFalicities_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["facility"] = Convert.ToInt32(cbFalicities.SelectedValue);
        }

        protected void MonthCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Session["month"] = MonthCombo.SelectedIndex + 1;

        }

        protected void btnSearch(object sender, EventArgs e)
        {
            txtNumOfBirthdays.Text = manager.getBirthdays(Convert.ToInt32(Session["month"]), Convert.ToInt32(Session["facility"])).ToString();
            txtNumOfActivities.Text = manager.getNumOfActivities(Convert.ToInt32(Session["month"]), Convert.ToInt32(Session["facility"])).ToString();
            txtNumOfEnrolment.Text = manager.getNumOfEnrolled(Convert.ToInt32(Session["month"]), Convert.ToInt32(Session["facility"])).ToString();
            txtNumOfDismissed.Text = manager.getNumOfExits(Convert.ToInt32(Session["month"]), Convert.ToInt32(Session["facility"])).ToString();
            txtNumOfHV.Text = manager.getHomeVisit(Convert.ToInt32(Session["month"]), Convert.ToInt32(Session["facility"])).ToString();
            txtCourtDates.Text = manager.getCourtDates(Convert.ToInt32(Session["month"]), Convert.ToInt32(Session["facility"])).ToString();

        }

    }
}