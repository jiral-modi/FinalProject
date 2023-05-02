using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Employee
    {
        private static int autoIncrement = 1234;
        public double Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MedicalLicense { get; set; }


        public Employee()
        {
            autoIncrement++;
            Id = autoIncrement;
        }
    }
}
