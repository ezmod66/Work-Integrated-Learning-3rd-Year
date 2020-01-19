using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class School
    {
        private int schoolID;
        private string schoolName;

        public School(int schoolID, string schoolName)
        {
            this.SchoolID = schoolID;
            this.SchoolName = schoolName;
        }

        public int SchoolID { get => schoolID; set => schoolID = value; }
        public string SchoolName { get => schoolName; set => schoolName = value; }
    }
}