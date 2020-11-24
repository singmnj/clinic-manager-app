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

        public Task AddConsultation(ConsultationModel consultation)
        {
            string sql = $@"INSERT INTO consultation (Date, Notes, MaramTherapyDone, AmountCharged, AmountReceived, PatientId) 
                           VALUES (@Date, @Notes, {(consultation.MaramTherapyDone ? 1 : 0)}, @AmountCharged, @AmountReceived, @PatientId);";

            return _db.SaveData(sql, consultation);
        }
    }
}
