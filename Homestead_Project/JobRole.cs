using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class JobRole
    {
        private int jobRoleID;
        private string jobRoleDescription;

        public JobRole(int jobRoleID, string jobRoleDescription)
        {
            this.JobRoleID = jobRoleID;
            this.JobRoleDescription = jobRoleDescription;
        }

        public int JobRoleID { get => jobRoleID; set => jobRoleID = value; }
        public string JobRoleDescription { get => jobRoleDescription; set => jobRoleDescription = value; }
    }
}