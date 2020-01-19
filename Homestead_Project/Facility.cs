using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Facility
    {
        private int facilityID;
        private string facilityName;

        public Facility(int facilityID, string facilityName)
        {
            this.FacilityID = facilityID;
            this.FacilityName = facilityName;
        }

        public int FacilityID { get => facilityID; set => facilityID = value; }
        public string FacilityName { get => facilityName; set => facilityName = value; }
    }
}