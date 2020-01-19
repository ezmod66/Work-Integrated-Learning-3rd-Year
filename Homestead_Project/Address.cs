using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Address
    {
        private int addresssID;
        private string streetName;
        private int postalCode;
        private string town;
        private string suburb;
        private string houseNumber;

        public Address(int addresssID, string streetName, int postalCode, string town, string suburb, string houseNumber)
        {
            this.AddresssID = addresssID;
            this.StreetName = streetName;
            this.PostalCode = postalCode;
            this.Town = town;
            this.Suburb = suburb;
            this.HouseNumber = houseNumber;
        }

        public int AddresssID { get => addresssID; set => addresssID = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public int PostalCode { get => postalCode; set => postalCode = value; }
        public string Town { get => town; set => town = value; }
        public string Suburb { get => suburb; set => suburb = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
    }
}