using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLibrary.Models
{
    public class DisplayConsultationModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public bool MaramTherapyDone { get; set; }

        public int PatientId { get; set; }
    }
}
