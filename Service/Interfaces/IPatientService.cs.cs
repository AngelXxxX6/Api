using Domain.Enitity;

namespace Service.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task<bool> CreateAsync(PatientViewModel patient);
        Task<bool> DeleteByIdAsync(int id);

        Task<bool> UpdateByIdAsync(int id, PatientViewModel patient);
    }
}
