using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class ConsultationDAL : IConsultationDAL
    {
        private readonly IDataAccess _db;

        public ConsultationDAL(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<ConsultationModel>> GetConsultations(int patientId)
        {
            string sql = $"SELECT * FROM consultation WHERE PatientId = @PatientId ORDER BY Date DESC";

            return _db.LoadData<ConsultationModel, dynamic>(sql, new { PatientId = patientId });
        }
    }
}
