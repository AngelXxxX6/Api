using Domain.Enitity;
using Domain.Response;

namespace Service.Interfaces
{
    public interface IPatientService
    {
        Task<IBaseResponse<IEnumerable<Patient>>> GetPatients();
        Task<IBaseResponse<bool>> Create(PatientViewModel patient);
        Task<IBaseResponse<bool>> DeleteById(int id);
        Task<IBaseResponse<bool>> UpdateById(int id, PatientViewModel patient);
    }
}
