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
            string sql = $@"INSERT INTO consultation (Date, Notes, Medicines, Days, MaramTherapyDone, AmountCharged, AmountReceived, PatientId) 
                           VALUES (@Date, @Notes, @Medicines, @Days, {(consultation.MaramTherapyDone ? 1 : 0)}, @AmountCharged, @AmountReceived, @PatientId);";

            return _db.SaveData(sql, consultation);
        }

        public Task DeleteConsultation(int consultationId)
        {
            string sql = $"DELETE FROM consultation WHERE Id = {consultationId}";
            return _db.SaveData(sql, new { });
        }

        public Task EditConsultation(ConsultationModel consultation)
        {
            string sql = $@"UPDATE consultation
                           SET
                           Date = @Date,
                           Notes = @Notes,
                           Medicines = @Medicines,
                           Days = @Days,
                           MaramTherapyDone = {(consultation.MaramTherapyDone ? 1 : 0)},
                           AmountCharged = @AmountCharged,
                           AmountReceived = @AmountReceived
                           WHERE Id = @Id;";
            return _db.SaveData(sql, consultation);
        }
    }
}
