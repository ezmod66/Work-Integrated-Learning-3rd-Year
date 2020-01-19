using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
	public class CourtOrderDates
	{
		private string firstName;
		private string surname;
		private string courtOrderDate;

		public CourtOrderDates(string firstName, string surname, string courtOrderDate)
		{
			this.FirstName = firstName;
			this.Surname = surname;
			this.CourtOrderDate = courtOrderDate;
		}

		public string FirstName { get => firstName; set => firstName = value; }
		public string Surname { get => surname; set => surname = value; }
		public string CourtOrderDate { get => courtOrderDate; set => courtOrderDate = value; }
	}
}