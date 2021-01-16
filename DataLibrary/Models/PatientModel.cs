using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        public string OPDNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Notes { get; set; }  
        
        public int Due { get; set; }
    }
}
