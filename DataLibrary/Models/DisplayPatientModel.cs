using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLibrary.Models
{
    public class DisplayPatientModel
    {
        [Required]
        [MinLength(2, ErrorMessage ="First Name is too short")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
