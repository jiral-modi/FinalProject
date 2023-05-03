using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Customer_Appointment
    {
        public Customer customer { get; set; }
        public Appointments appointments { get; set; }
        public Customer_Appointment(Customer c, Appointments a)
        {
            customer = c;
            appointments = a;           
        }
    }
}
