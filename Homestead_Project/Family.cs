using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Family
    {
        private int familyID;
        private string relationship;
        private string familyNotes;

        public Family(int familyID, string relationship, string familyNotes)
        {
            this.FamilyID = familyID;
            this.Relationship = relationship;
            this.FamilyNotes = familyNotes;
        }

        public int FamilyID { get => familyID; set => familyID = value; }
        public string Relationship { get => relationship; set => relationship = value; }
        public string FamilyNotes { get => familyNotes; set => familyNotes = value; }
    }
}