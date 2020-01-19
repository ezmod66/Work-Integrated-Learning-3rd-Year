using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class LegalStatus
    {
        private int legalStatusID;
        private string legalStatusDescription;

        public LegalStatus(int legalStatusID, string legalStatusDescription)
        {
            this.LegalStatusID = legalStatusID;
            this.LegalStatusDescription = legalStatusDescription;
        }

        public int LegalStatusID { get => legalStatusID; set => legalStatusID = value; }
        public string LegalStatusDescription { get => legalStatusDescription; set => legalStatusDescription = value; }
    }
}