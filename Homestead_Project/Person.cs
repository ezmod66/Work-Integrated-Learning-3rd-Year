using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homestead_Project
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string dateOfBirth;
        private string nationality;
        public Person()
        {

        }

        public Person(string firstName, string lastName, string dateOfBirth, string nationality)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.nationality = nationality;
        }

        public string FirstNmae1 { get => firstName; set => firstName = value; }
        public string LatstNmae1 { get => lastName; set => lastName = value; }
        public string DateOfBirth1 { get => dateOfBirth; set => dateOfBirth = value; }
        public string Nationality { get => nationality; set => nationality = value; }
    }
}