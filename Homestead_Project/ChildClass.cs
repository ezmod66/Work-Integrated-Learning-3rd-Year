using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class ChildClass
    {
        private int childID;
        private string childName;
        private string childSurname;
        private int socialWorkerID;
        private int childWorkerID;
        private string fileNumber;
        private int statutoryID;
        private int relationshipID;
        private int facilityID;
        private string dob;
        private int genderID;
        private int schoolID;
        private string schoolName;
        private string schoolContactNumber;
        private int nationality;
        private int legalStatus;
        private int familyID;
        private string familyFirstName;
        private string familySurname;
        private string contactNumber;
        private int addressID;
        private int houseNumber;
        private string streetName;
        private string suburb;
        private string town;
        private string province;
        private int postalCode;
        private string courtOrderDate;
        private string addmissionDate;
        private string exitDate;
        private int yearsInShelter;
        private string familyNote;
        private int familyGender;


        public ChildClass(int childID, string childName, string childSurname, int socialWorkerID, int childWorkerID, string fileNumber, int statutoryID, int relationshipID, int facilityID, string dob, int genderID, int schoolID, string schoolName, string schoolContactNumber, int nationality, int legalStatus, int familyID, string familyFirstName, string familySurname, string contactNumber, int addressID, int houseNumber, string streetName, string suburb, string town, string province, int postalCode, string courtOrderDate, string addmissionDate, string exitDate, int yearsInShelter, string familyNote, int familyGender)
        {
            this.ChildID = childID;
            this.ChildName = childName;
            this.ChildSurname = childSurname;
            this.SocialWorkerID = socialWorkerID;
            this.ChildWorkerID = childWorkerID;
            this.FileNumber = fileNumber;
            this.StatutoryID = statutoryID;
            this.RelationshipID = relationshipID;
            this.FacilityID = facilityID;
            this.Dob = dob;
            this.GenderID = genderID;
            this.SchoolID = schoolID;
            this.SchoolName = schoolName;
            this.SchoolContactNumber = schoolContactNumber;
            this.Nationality = nationality;
            this.LegalStatus = legalStatus;
            this.FamilyID = familyID;
            this.FamilyFirstName = familyFirstName;
            this.FamilySurname = familySurname;
            this.ContactNumber = contactNumber;
            this.AddressID = addressID;
            this.HouseNumber = houseNumber;
            this.StreetName = streetName;
            this.Suburb = suburb;
            this.Town = town;
            this.Province = province;
            this.PostalCode = postalCode;
            this.CourtOrderDate = courtOrderDate;
            this.AddmissionDate = addmissionDate;
            this.ExitDate = exitDate;
            this.YearsInShelter = yearsInShelter;
            this.FamilyNote = familyNote;
            this.FamilyGender = familyGender;
            
        }


        public string ChildName { get => childName; set => childName = value; }
        public string ChildSurname { get => childSurname; set => childSurname = value; }
        public int SocialWorkerID { get => socialWorkerID; set => socialWorkerID = value; }
        public int ChildWorkerID { get => childWorkerID; set => childWorkerID = value; }
        public string FileNumber { get => fileNumber; set => fileNumber = value; }
        public int StatutoryID { get => statutoryID; set => statutoryID = value; }
        public int RelationshipID { get => relationshipID; set => relationshipID = value; }
        public int FacilityID { get => facilityID; set => facilityID = value; }
        public string Dob { get => dob; set => dob = value; }
        public int GenderID { get => genderID; set => genderID = value; }
        public int SchoolID { get => schoolID; set => schoolID = value; }
        public string SchoolName { get => schoolName; set => schoolName = value; }
        public string SchoolContactNumber { get => schoolContactNumber; set => schoolContactNumber = value; }
        public int Nationality { get => nationality; set => nationality = value; }
        public int LegalStatus { get => legalStatus; set => legalStatus = value; }
        public int FamilyID { get => familyID; set => familyID = value; }
        public string FamilyFirstName { get => familyFirstName; set => familyFirstName = value; }
        public string FamilySurname { get => familySurname; set => familySurname = value; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public int AddressID { get => addressID; set => addressID = value; }
        public int HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public string Suburb { get => suburb; set => suburb = value; }
        public string Town { get => town; set => town = value; }
        public string Province { get => province; set => province = value; }
        public int PostalCode { get => postalCode; set => postalCode = value; }
        public string CourtOrderDate { get => courtOrderDate; set => courtOrderDate = value; }
        public string AddmissionDate { get => addmissionDate; set => addmissionDate = value; }
        public string ExitDate { get => exitDate; set => exitDate = value; }
        public int YearsInShelter { get => yearsInShelter; set => yearsInShelter = value; }
        public string FamilyNote { get => familyNote; set => familyNote = value; }
        public int FamilyGender { get => familyGender; set => familyGender = value; }
        public int ChildID { get => childID; set => childID = value; }
    }
}