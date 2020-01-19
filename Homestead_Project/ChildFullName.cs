using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class ChildFullName
    {
        private string childID;
        private string childFullname;

        public ChildFullName(string childID, string childFullname)
        {
            this.ChildID = childID;
            this.ChildFullname = childFullname;
        }

        public string ChildID { get => childID; set => childID = value; }
        public string ChildFullname { get => childFullname; set => childFullname = value; }
    }
}