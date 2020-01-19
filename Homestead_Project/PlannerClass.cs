using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class PlannerClass
    {
        private int plannerID;
        private int activityID;
        private string filenumber;
        private string staffID;

        public PlannerClass()
        {
        }


        public PlannerClass(int plannerID, int activityID, string filenumber, string staffID)
        {
            this.plannerID = plannerID;
            this.activityID = activityID;
            this.filenumber = filenumber;
            this.staffID = staffID;
        }

        public int PlannerID1 { get => plannerID; set => plannerID = value; }
        public int ActivityID { get => activityID; set => activityID = value; }
        public string Filenumber { get => filenumber; set => filenumber = value; }
        public string StaffID { get => staffID; set => staffID = value; }
    }
}