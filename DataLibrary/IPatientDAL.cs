using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IPatientDAL
    {
        Task AddPatient(PatientModel patient);
        Task<List<PatientModel>> GetPatients();
    }
}