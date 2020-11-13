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
    }
}
