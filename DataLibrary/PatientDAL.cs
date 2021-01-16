using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class PatientDAL : IPatientDAL
    {
        private readonly IDataAccess _db;

        public PatientDAL(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<PatientModel>> GetPatients()
        {
            string sql = @"SELECT p.*,sum(c.AmountCharged) - sum(c.AmountReceived) AS Due FROM patient p
                           LEFT JOIN consultation c ON
                           p.Id = c.PatientId
                           GROUP BY p.Id";

            return _db.LoadData<PatientModel, dynamic>(sql, new { });
        }

        public Task<List<PatientModel>> GetPatient(int patientId)
        {
            string sql = $@"SELECT p.*,sum(c.AmountCharged) - sum(c.AmountReceived) AS Due FROM patient p
                           LEFT JOIN consultation c ON
                           p.Id = c.PatientId
                           GROUP BY p.Id HAVING p.Id = @Id";

            return _db.LoadData<PatientModel, dynamic>(sql, new { Id = patientId });
        }

        public Task AddPatient(PatientModel patient)
        {
            string sql = @"INSERT INTO patient (OPDNumber, FirstName, LastName, Gender, Phone, DOB, Address, City, Notes) 
                           VALUES (@OPDNumber, @FirstName, @LastName, @Gender, @Phone, @DOB, @Address, @City, @Notes);";

            return _db.SaveData(sql, patient);
        }

        public Task EditPatient(PatientModel patient)
        {
            string sql = @"UPDATE patient 
                           SET 
                           FirstName = @FirstName, 
                           LastName = @LastName, 
                           Gender = @Gender, 
                           Phone = @Phone, 
                           DOB = @DOB, 
                           Address = @Address, 
                           City = @City, 
                           Notes = @Notes
                           WHERE Id = @Id;";

            return _db.SaveData(sql, patient);
        }

        public Task DeletePatient(int patientId)
        {
            string sql = $"DELETE FROM patient WHERE Id = {patientId}";
            return _db.SaveData(sql, new { });
        }
    }
}
