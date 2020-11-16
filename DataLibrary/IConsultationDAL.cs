using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IConsultationDAL
    {
        Task<List<ConsultationModel>> GetConsultations(int patientId);
    }
}