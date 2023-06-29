using Domain.Enitity;
using Domain.Response;

namespace Service.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<bool> Create(PatientViewModel patient);
        Task<bool> DeleteById(int id);

        Task<bool> UpdateById(int id, PatientViewModel patient);
    }
}
