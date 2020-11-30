using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLibrary.Models
{
    public class DisplayPatientModel
    {
        [Required]
        public string OPDNumber { get; set; }

        [Required]
        [MinLength(2, ErrorMessage ="First Name is too short")]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Phone Number is too short")]
        public string Phone { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Notes { get; set; }
    }
}
