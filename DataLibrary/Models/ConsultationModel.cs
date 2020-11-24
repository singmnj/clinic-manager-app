using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class ConsultationModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public bool MaramTherapyDone { get; set; }

        public int AmountCharged { get; set; }

        public int AmountReceived { get; set; }

        public int PatientId { get; set; }
    }
}
