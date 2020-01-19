using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Activity
    {
   
        private string activityDescription;
        private string activityDate;
        private string activityTime;
        private int pointsAllocated;

        public Activity(string activityDescription, string activityDate, string activityTime, int pointsAllocated)
        {
            
            this.ActivityDescription = activityDescription;
            this.ActivityDate = activityDate;
            this.ActivityTime = activityTime;
            this.PointsAllocated = pointsAllocated;
        }

       
        public string ActivityDescription { get => activityDescription; set => activityDescription = value; }
        public string ActivityDate { get => activityDate; set => activityDate = value; }
        public string ActivityTime { get => activityTime; set => activityTime = value; }
        public int PointsAllocated { get => pointsAllocated; set => pointsAllocated = value; }
    }
}