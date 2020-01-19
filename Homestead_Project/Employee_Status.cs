using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Employee_Status
    {
        private int employeeStatusID;
        private string employeeDescription;

        public Employee_Status(int employeeStatusID, string employeeDescription)
        {
            this.EmployeeStatusID = employeeStatusID;
            this.EmployeeDescription = employeeDescription;
        }

        public int EmployeeStatusID { get => employeeStatusID; set => employeeStatusID = value; }
        public string EmployeeDescription { get => employeeDescription; set => employeeDescription = value; }
    }
}