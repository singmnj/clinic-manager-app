using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IConsultationDAL
    {
        Task AddConsultation(ConsultationModel consultation);
        Task<List<int>> GetConsultationsOnDaysBack(int days);
        Task DeleteConsultation(int consultationId);
        Task EditConsultation(ConsultationModel consultation);
        Task<List<ConsultationModel>> GetConsultations(int patientId);
        Task<List<int>> GetEarningsForMonthsBack(int months);
    }
}