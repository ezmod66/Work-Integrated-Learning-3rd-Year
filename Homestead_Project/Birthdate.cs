using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Birthdate
    {
        //private string fileNumber;
        private string firstName;
        private string surname;
        private string dob;
       // private string courtDate;

        public Birthdate()
        {

        }

        public Birthdate(string firstName, string surname, string dob)
        {
            //this.FileNumber = fileNumber;
            this.FirstName = firstName;
            this.Surname = surname;
            this.Dob = dob;
            //this.CourtDate = courtDate;
        }

        //public string FileNumber { get => fileNumber; set => fileNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Dob { get => dob; set => dob = value; }
        //public string CourtDate { get => courtDate; set => courtDate = value; }
    }
}