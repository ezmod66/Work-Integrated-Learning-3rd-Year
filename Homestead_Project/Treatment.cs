using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Treatment
    {
        private int treatmentID;
        private string treatmentDescription;
        private string treatmentType;
        private DateTime treatmentDate;

        public Treatment(int treatmentID, string treatmentDescription, string treatmentType, DateTime treatmentDate)
        {
            this.treatmentID = treatmentID;
            this.treatmentDescription = treatmentDescription;
            this.treatmentType = treatmentType;
            this.treatmentDate = treatmentDate;
        }

        public int TreatmentID
        {
            get => treatmentID;
            set => treatmentID = value;
        }
        public string TreatmentDescription
        {
            get => treatmentDescription;
            set => treatmentDescription = value;
        }
        public string TreatmentType
        {
            get => treatmentType;
            set => treatmentType = value;
        }
        public DateTime TreatmentDate
        {
            get => treatmentDate;
            set => treatmentDate = value;
        }
    }  
        
}