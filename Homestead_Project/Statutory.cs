using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Statutory
    {
        private int descriptionID;
        private string description;

        public Statutory(int descriptionID, string description)
        {
            this.DescriptionID = descriptionID;
            this.Description = description;
        }

        public int DescriptionID { get => descriptionID; set => descriptionID = value; }
        public string Description { get => description; set => description = value; }
    }
}