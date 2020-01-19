using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Shelter
    {
        private int shelterID;
        private string shelterName;

        public Shelter(int shelterID, string shelterName)
        {
            this.ShelterID = shelterID;
            this.ShelterName = shelterName;
        }

        public int ShelterID { get => shelterID; set => shelterID = value; }
        public string ShelterName { get => shelterName; set => shelterName = value; }
    }
}