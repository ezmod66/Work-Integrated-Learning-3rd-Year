using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Gender
    {
        private int genderID;
        private string genderDescription;

        public Gender(int genderID, string genderDescription)
        {
            this.GenderID = genderID;
            this.GenderDescription = genderDescription;
        }

        public int GenderID { get => genderID; set => genderID = value; }
        public string GenderDescription { get => genderDescription; set => genderDescription = value; }
    }
}