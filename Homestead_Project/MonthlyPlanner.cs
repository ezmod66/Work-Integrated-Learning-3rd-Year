using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class MonthlyPlanner
    {
        private string activityName;
        private string activityDate;
        private string cfirstName;
        private string csurname;
        private string courtDate;
        private string dfirstName;
        private string dsurname;
        private string dob;

        public MonthlyPlanner(string activityName, string activityDate, string cfirstName, string csurname, string courtDate, string dfirstName, string dsurname, string dob)
        {
            this.ActivityName = activityName;
            this.ActivityDate = activityDate;
            this.CfirstName = cfirstName;
            this.Csurname = csurname;
            this.CourtDate = courtDate;
            this.DfirstName = dfirstName;
            this.Dsurname = dsurname;
            this.Dob = dob;
        }

        public string ActivityName { get => activityName; set => activityName = value; }
        public string ActivityDate { get => activityDate; set => activityDate = value; }
        public string CfirstName { get => cfirstName; set => cfirstName = value; }
        public string Csurname { get => csurname; set => csurname = value; }
        public string CourtDate { get => courtDate; set => courtDate = value; }
        public string DfirstName { get => dfirstName; set => dfirstName = value; }
        public string Dsurname { get => dsurname; set => dsurname = value; }
        public string Dob { get => dob; set => dob = value; }


    }
}