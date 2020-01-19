using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Employee
    {
        private int facilityID;
		private int addressID;
		private int jobRoleID;
		private string empFirstName;
		private string empSurname;
		private string empEmail;
		private string dob;
		private int genderID;
		private int nationalityID;
		private int employeeStatusID;
		private string password;
		
		private string contactNumber;

		public Employee(int facilityID, int addressID, int jobRoleID, string empFirstName, string empSurname, string empEmail, string dob, int genderID, int nationalityID, int employeeStatusID, string password, string contactNumber)
		{
			this.facilityID = facilityID;
			this.addressID = addressID;
			this.jobRoleID = jobRoleID;
			this.empFirstName = empFirstName;
			this.empSurname = empSurname;
			this.empEmail = empEmail;
			this.dob = dob;
			this.genderID = genderID;
			this.nationalityID = nationalityID;
			this.employeeStatusID = employeeStatusID;
			this.password = password;
			
			this.contactNumber = contactNumber;
		}

		public int FacilityID { get => facilityID; set => facilityID = value; }
		public int AddressID { get => addressID; set => addressID = value; }
		public int JobRoleID { get => jobRoleID; set => jobRoleID = value; }
		public string EmpFirstName { get => empFirstName; set => empFirstName = value; }
		public string EmpSurname { get => empSurname; set => empSurname = value; }
		public string EmpEmail { get => empEmail; set => empEmail = value; }
		public string Dob { get => dob; set => dob = value; }
		public int GenderID { get => genderID; set => genderID = value; }
		public int NationalityID { get => nationalityID; set => nationalityID = value; }
		public int EmployeeStatusID { get => employeeStatusID; set => employeeStatusID = value; }
		public string Password { get => password; set => password = value; }

		public string ContactNumber { get => contactNumber; set => contactNumber = value; }
	}
}