using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Appointments
    {
        private static int autoIncrement;
        public int Id { get; set; }
        public DateTime date { get; set; }
        
        public Appointments()
        {
            autoIncrement++;
            Id = autoIncrement;
        }
    }
}
