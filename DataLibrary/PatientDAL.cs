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
            string sql = "SELECT * FROM patient";

            return _db.LoadData<PatientModel, dynamic>(sql, new { });
        }

        public Task AddPatient(PatientModel patient)
        {
            string sql = @"INSERT INTO patient (FirstName, LastName, Phone, Address, City, Notes) 
                           VALUES (@FirstName, @LastName, @Phone, @Address, @City, @Notes);";

            return _db.SaveData(sql, patient);
        }

        public Task DeletePatient(int patientId)
        {
            string sql = $"DELETE FROM patient WHERE Id = {patientId}";
            return _db.SaveData(sql, new { });
        }
    }
}
