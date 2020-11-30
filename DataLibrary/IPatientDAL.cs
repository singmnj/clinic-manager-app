using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IPatientDAL
    {
        Task AddPatient(PatientModel patient);
        Task DeletePatient(int patientId);
        Task EditPatient(PatientModel patient);
        Task<List<PatientModel>> GetPatient(int patientId);
        Task<List<PatientModel>> GetPatients();
    }
}