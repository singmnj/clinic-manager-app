using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class DisplayConsultationModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public bool MaramTherapyDone { get; set; }

        public int PatientId { get; set; }
    }
}
