using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IPatientDAL
    {
        Task<List<PatientModel>> GetPatients();
    }
}