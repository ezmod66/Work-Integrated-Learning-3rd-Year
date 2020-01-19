using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Nationality
    {
        private int nationalityID;
        private string nationalityDesc;

        public Nationality(int nationalityID, string nationalityDesc)
        {
            this.NationalityID = nationalityID;
            this.NationalityDesc = nationalityDesc;
        }

        public int NationalityID { get => nationalityID; set => nationalityID = value; }
        public string NationalityDesc { get => nationalityDesc; set => nationalityDesc = value; }
    }
}